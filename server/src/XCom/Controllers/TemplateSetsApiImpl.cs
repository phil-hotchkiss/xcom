using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using XCom.Application.Commands.CreateTemplateSet;
using XCom.Application.Services;
using XCom.Domain.Interfaces;
using XCom.Models;

namespace XCom.Controllers
{
    public class TemplateSetsApiImpl : TemplateSetsApiController
    {
        private readonly ITemplateSetRepository _templateSetRepository;
        private readonly ITemplateSelectionService _templateSelectionService;
        private readonly ICreateTemplateSetCommandHandler _createTemplateSetHandler;

        public TemplateSetsApiImpl(
            ITemplateSetRepository templateSetRepository,
            ITemplateSelectionService templateSelectionService,
            ICreateTemplateSetCommandHandler createTemplateSetHandler)
        {
            _templateSetRepository = templateSetRepository;
            _templateSelectionService = templateSelectionService;
            _createTemplateSetHandler = createTemplateSetHandler;
        }

        public override IActionResult CreateTemplateSet([FromBody] TemplateSet templateSet)
        {
            var command = new CreateTemplateSetCommand
            {
                TemplateSetName = templateSet.TemplateSetName,
                Categories = templateSet.Categories,
                Variations = templateSet.Variations.Select(v => new VariationDto
                {
                    SendGridTemplateId = v.SendGridTemplateId,
                    Percentage = v.Percentage
                }).ToList(),
                RateLimit = templateSet.RateLimit != null ? new RateLimitDto
                {
                    Period = templateSet.RateLimit.Period,
                    Limit = templateSet.RateLimit.Limit
                } : null
            };

            var result = _createTemplateSetHandler.HandleAsync(command).Result;
            
            if (result.IsFailed)
            {
                return BadRequest(new ErrorResponse
                {
                    Error = new ResponseError
                    {
                        Message = result.Errors.First().Message
                    }
                });
            }

            var domainTemplateSet = result.Value;
            var response = new TemplateSetCreateSuccessResponse
            {
                Data = new TemplateSetCreateSuccessResponseData
                {
                    Id = domainTemplateSet.Id.ToString(),
                    Updated = domainTemplateSet.UpdatedAt
                }
            };

            return Created($"/template-sets/{domainTemplateSet.Id}", response);
        }

        public override IActionResult GetTemplateSet([FromRoute] string id)
        {
            if (!Guid.TryParse(id, out var templateSetId))
            {
                return BadRequest(new ErrorResponse
                {
                    Error = new ResponseError()
                    {
                        Message = "Invalid ID format"
                    }
                });
            }

            var templateSet = _templateSetRepository.GetByIdAsync(templateSetId).Result;
            if (templateSet == null)
            {
                return NotFound(new ErrorResponse
                {
                    Error = new ResponseError()
                    {
                        Message = $"Template set with ID {id} not found"
                    }
                });
            }

            var response = new GetTemplateSetSuccessResponse
            {
                Data = new GetTemplateSetSuccessResponseData
                {
                    Id = templateSet.Id.ToString(),
                    TemplateSetName = templateSet.TemplateSetName,
                    Categories = templateSet.Categories,
                    RateLimit = templateSet.RateLimit != null ? new RateLimit
                    {
                        Period = templateSet.RateLimit.Period,
                        Limit = templateSet.RateLimit.Limit
                    } : null,
                    Updated = templateSet.UpdatedAt,
                    Variations = templateSet.Variations.Select(v => new Models.Variation
                    {
                        SendGridTemplateId = v.SendGridTemplateId,
                        Percentage = v.Percentage
                    }).ToList()
                }
            };

            return Ok(response);
        }

        public override IActionResult QueryTemplateSets([FromQuery] string sendGridTemplateId, [FromQuery] string templateSetName)
        {
            var templateSets = _templateSetRepository.GetByQueryAsync(sendGridTemplateId, templateSetName).Result;

            var response = new QueryTemplateSetSuccessResponse
            {
                Data = new QueryTemplateSetSuccessResponseData
                {
                    Items = templateSets.Select(ts => new TemplateSet
                    {
                        Id = ts.Id,
                        TemplateSetName = ts.TemplateSetName,
                        Categories = ts.Categories,
                        RateLimit = ts.RateLimit != null ? new RateLimit
                        {
                            Period = ts.RateLimit.Period,
                            Limit = ts.RateLimit.Limit
                        } : null,
                        Variations = ts.Variations.Select(v => new Models.Variation
                        {
                            SendGridTemplateId = v.SendGridTemplateId,
                            Percentage = v.Percentage
                        }).ToList()
                    }).ToList()
                }
            };

            return Ok(response);
        }

        public override IActionResult UpdateTemplateSet([FromRoute] string id, [FromBody] TemplateSet templateSet)
        {
            if (!Guid.TryParse(id, out var templateSetId))
            {
                return BadRequest(new ErrorResponse
                {
                    Error = new ResponseError()
                    {
                        Message = "Invalid ID format"
                    }
                });
            }

            var existingTemplateSet = _templateSetRepository.GetByIdAsync(templateSetId).Result;
            if (existingTemplateSet == null)
            {
                return NotFound(new ErrorResponse
                {
                    Error = new ResponseError()
                    {
                        Message = $"Template set with ID {id} not found"
                    }
                });
            }

            // Validate total percentage is 100%
            var totalPercentage = templateSet.Variations.Sum(v => v.Percentage);
            if (Math.Abs(totalPercentage - 100) > 0.01f)
            {
                return BadRequest(new ErrorResponse 
                {
                    Error = new ResponseError()
                    {
                        Message = "Total percentage of variations must equal 100%"
                    }
                });
            }

            var rateLimit = templateSet.RateLimit != null 
                ? Domain.Models.RateLimit.Create(templateSet.RateLimit.Period, templateSet.RateLimit.Limit)
                : null;

            existingTemplateSet.Update(
                templateSet.TemplateSetName,
                templateSet.Categories,
                templateSet.Variations.Select(v => 
                    Domain.Models.Variation.Create(v.SendGridTemplateId, v.Percentage)
                ).ToList(),
                rateLimit
            );

            _templateSetRepository.UpdateAsync(existingTemplateSet).Wait();

            return NoContent();
        }
    }
}
