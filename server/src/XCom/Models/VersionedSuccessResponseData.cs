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
    public partial class VersionedSuccessResponseData : IEquatable<VersionedSuccessResponseData>
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets Updated
        /// </summary>
        [DataMember(Name="updated", EmitDefaultValue=false)]
        public DateTime Updated { get; set; }

        /// <summary>
        /// Gets or Sets Deleted
        /// </summary>
        [DataMember(Name="deleted", EmitDefaultValue=false)]
        public DateTime Deleted { get; set; }

        /// <summary>
        /// Gets or Sets Etag
        /// </summary>
        [DataMember(Name="etag", EmitDefaultValue=false)]
        public string Etag { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class VersionedSuccessResponseData {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Updated: ").Append(Updated).Append("\n");
            sb.Append("  Deleted: ").Append(Deleted).Append("\n");
            sb.Append("  Etag: ").Append(Etag).Append("\n");
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
            return obj.GetType() == GetType() && Equals((VersionedSuccessResponseData)obj);
        }

        /// <summary>
        /// Returns true if VersionedSuccessResponseData instances are equal
        /// </summary>
        /// <param name="other">Instance of VersionedSuccessResponseData to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(VersionedSuccessResponseData other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Id == other.Id ||
                    Id != null &&
                    Id.Equals(other.Id)
                ) && 
                (
                    Updated == other.Updated ||
                    Updated != null &&
                    Updated.Equals(other.Updated)
                ) && 
                (
                    Deleted == other.Deleted ||
                    Deleted != null &&
                    Deleted.Equals(other.Deleted)
                ) && 
                (
                    Etag == other.Etag ||
                    Etag != null &&
                    Etag.Equals(other.Etag)
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
                    if (Id != null)
                    hashCode = hashCode * 59 + Id.GetHashCode();
                    if (Updated != null)
                    hashCode = hashCode * 59 + Updated.GetHashCode();
                    if (Deleted != null)
                    hashCode = hashCode * 59 + Deleted.GetHashCode();
                    if (Etag != null)
                    hashCode = hashCode * 59 + Etag.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(VersionedSuccessResponseData left, VersionedSuccessResponseData right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(VersionedSuccessResponseData left, VersionedSuccessResponseData right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
