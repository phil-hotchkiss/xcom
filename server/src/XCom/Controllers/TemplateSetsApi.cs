/*
 * XCom.API
 *
 * This API is responsible for enabling communication with SendGrid. It implements additional features such as data retention and A/B Testing for specific templates
 *
 * The version of the OpenAPI document: 4.0
 * Contact: phil.hotchkiss@veteransunited.com
 * Generated by: https://openapi-generator.tech
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using XCom.Attributes;
using XCom.Models;

namespace XCom.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    public abstract class TemplateSetsApiController : ControllerBase
    { 
        /// <summary>
        /// Create a template set
        /// </summary>
        /// <remarks>Create a template set</remarks>
        /// <param name="templateSet"></param>
        /// <response code="201">Created</response>
        [HttpPost]
        [Route("/template-sets")]
        [Consumes("application/json")]
        [ValidateModelState]
        [SwaggerOperation("CreateTemplateSet")]
        [SwaggerResponse(statusCode: 201, type: typeof(TemplateSetCreateSuccessResponse), description: "Created")]
        public abstract IActionResult CreateTemplateSet([FromBody]TemplateSet templateSet);

        /// <summary>
        /// Get a template set
        /// </summary>
        /// <remarks>Get a template set by id</remarks>
        /// <param name="id"></param>
        /// <response code="200">Ok</response>
        [HttpGet]
        [Route("/template-sets/{id}")]
        [ValidateModelState]
        [SwaggerOperation("GetTemplateSet")]
        [SwaggerResponse(statusCode: 200, type: typeof(GetTemplateSetSuccessResponse), description: "Ok")]
        public abstract IActionResult GetTemplateSet([FromRoute (Name = "id")][Required]string id);

        /// <summary>
        /// Get template sets by query parameters
        /// </summary>
        /// <remarks>Get template sets by query parameters</remarks>
        /// <param name="sendGridTemplateId"></param>
        /// <param name="templateSetName"></param>
        /// <response code="200">OK</response>
        [HttpGet]
        [Route("/template-sets")]
        [ValidateModelState]
        [SwaggerOperation("QueryTemplateSets")]
        [SwaggerResponse(statusCode: 200, type: typeof(QueryTemplateSetSuccessResponse), description: "OK")]
        public abstract IActionResult QueryTemplateSets([FromQuery (Name = "sendGridTemplateId")]string sendGridTemplateId, [FromQuery (Name = "templateSetName")]string templateSetName);

        /// <summary>
        /// Update a template set
        /// </summary>
        /// <remarks>Update a template set</remarks>
        /// <param name="id"></param>
        /// <param name="templateSet"></param>
        /// <response code="204">No Content</response>
        /// <response code="400">Bad Request</response>
        /// <response code="404">Not Found</response>
        [HttpPatch]
        [Route("/template-sets/{id}")]
        [Consumes("application/json")]
        [ValidateModelState]
        [SwaggerOperation("UpdateTemplateSet")]
        [SwaggerResponse(statusCode: 400, type: typeof(ErrorResponse), description: "Bad Request")]
        [SwaggerResponse(statusCode: 404, type: typeof(ErrorResponse), description: "Not Found")]
        public abstract IActionResult UpdateTemplateSet([FromRoute (Name = "id")][Required]string id, [FromBody]TemplateSet templateSet);
    }
}
