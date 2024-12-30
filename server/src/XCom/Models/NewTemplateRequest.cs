/*
 * XCom.API
 *
 * This API is responsible for enabling communication with SendGrid. It implements additional features such as data retention and A/B Testing for specific templates.
 *
 * The version of the OpenAPI document: 4.0
 * Contact: phil.hotchkiss@veteransunited.com
 * Generated by: https://openapi-generator.tech
 */

using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using XCom.Converters;

namespace XCom.Models
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class NewTemplateRequest : IEquatable<NewTemplateRequest>
    {
        /// <summary>
        /// Gets or Sets TemplateName
        /// </summary>
        [Required]
        [DataMember(Name="templateName", EmitDefaultValue=false)]
        public string TemplateName { get; set; }

        /// <summary>
        /// Gets or Sets Application
        /// </summary>
        [Required]
        [DataMember(Name="application", EmitDefaultValue=true)]
        public ApplicationType Application { get; set; }

        /// <summary>
        /// Gets or Sets SendGridTemplateId
        /// </summary>
        [Required]
        [DataMember(Name="sendGridTemplateId", EmitDefaultValue=false)]
        public string SendGridTemplateId { get; set; }

        /// <summary>
        /// Gets or Sets Description
        /// </summary>
        [DataMember(Name="description", EmitDefaultValue=false)]
        public string Description { get; set; }

        /// <summary>
        /// Gets or Sets Permissions
        /// </summary>
        [DataMember(Name="permissions", EmitDefaultValue=true)]
        public int Permissions { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class NewTemplateRequest {\n");
            sb.Append("  TemplateName: ").Append(TemplateName).Append("\n");
            sb.Append("  Application: ").Append(Application).Append("\n");
            sb.Append("  SendGridTemplateId: ").Append(SendGridTemplateId).Append("\n");
            sb.Append("  Description: ").Append(Description).Append("\n");
            sb.Append("  Permissions: ").Append(Permissions).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((NewTemplateRequest)obj);
        }

        /// <summary>
        /// Returns true if NewTemplateRequest instances are equal
        /// </summary>
        /// <param name="other">Instance of NewTemplateRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(NewTemplateRequest other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    TemplateName == other.TemplateName ||
                    TemplateName != null &&
                    TemplateName.Equals(other.TemplateName)
                ) && 
                (
                    Application == other.Application ||
                    
                    Application.Equals(other.Application)
                ) && 
                (
                    SendGridTemplateId == other.SendGridTemplateId ||
                    SendGridTemplateId != null &&
                    SendGridTemplateId.Equals(other.SendGridTemplateId)
                ) && 
                (
                    Description == other.Description ||
                    Description != null &&
                    Description.Equals(other.Description)
                ) && 
                (
                    Permissions == other.Permissions ||
                    
                    Permissions.Equals(other.Permissions)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                    if (TemplateName != null)
                    hashCode = hashCode * 59 + TemplateName.GetHashCode();
                    
                    hashCode = hashCode * 59 + Application.GetHashCode();
                    if (SendGridTemplateId != null)
                    hashCode = hashCode * 59 + SendGridTemplateId.GetHashCode();
                    if (Description != null)
                    hashCode = hashCode * 59 + Description.GetHashCode();
                    
                    hashCode = hashCode * 59 + Permissions.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(NewTemplateRequest left, NewTemplateRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(NewTemplateRequest left, NewTemplateRequest right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
