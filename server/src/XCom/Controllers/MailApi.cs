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
    public abstract class MailApiController : ControllerBase
    { 
        /// <summary>
        /// Send simple email
        /// </summary>
        /// <remarks>Send Simple Email without template</remarks>
        /// <param name="simpleMailRequest"></param>
        /// <response code="202">Accepted</response>
        /// <response code="400">Bad Request</response>
        [HttpPost]
        [Route("/simple-email")]
        [Consumes("application/json")]
        [ValidateModelState]
        [SwaggerOperation("SendSimpleEmail")]
        [SwaggerResponse(statusCode: 400, type: typeof(ErrorResponse), description: "Bad Request")]
        public abstract Task<IActionResult> SendSimpleEmail([FromBody]SimpleMailRequest simpleMailRequest);

        /// <summary>
        /// Send a templated email
        /// </summary>
        /// <remarks>Send a templated email</remarks>
        /// <param name="templatedEmailRequest"></param>
        /// <response code="200">Accepted</response>
        /// <response code="400">Bad Request</response>
        [HttpPost]
        [Route("/templated-email")]
        [Consumes("application/json")]
        [ValidateModelState]
        [SwaggerOperation("SendTemplatedEmail")]
        [SwaggerResponse(statusCode: 200, type: typeof(TemplatedEmailSuccessResponse), description: "Accepted")]
        public abstract Task<IActionResult> SendTemplatedEmail([FromBody]TemplatedEmailRequest templatedEmailRequest);
    }
}
