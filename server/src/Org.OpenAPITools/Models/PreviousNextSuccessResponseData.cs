/*
 * XCom.API
 *
 * No description provided (generated by Openapi Generator https://github.com/openapitools/openapi-generator)
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
using Org.OpenAPITools.Converters;

namespace Org.OpenAPITools.Models
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class PreviousNextSuccessResponseData : IEquatable<PreviousNextSuccessResponseData>
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
        /// Gets or Sets PreviousLink
        /// </summary>
        [DataMember(Name="previousLink", EmitDefaultValue=false)]
        public string PreviousLink { get; set; }

        /// <summary>
        /// Gets or Sets NextLink
        /// </summary>
        [DataMember(Name="nextLink", EmitDefaultValue=false)]
        public string NextLink { get; set; }

        /// <summary>
        /// Gets or Sets ItemsPerPage
        /// </summary>
        [DataMember(Name="itemsPerPage", EmitDefaultValue=true)]
        public int ItemsPerPage { get; set; }

        /// <summary>
        /// Gets or Sets StartIndex
        /// </summary>
        [DataMember(Name="startIndex", EmitDefaultValue=true)]
        public int StartIndex { get; set; }

        /// <summary>
        /// Gets or Sets TotalItems
        /// </summary>
        [DataMember(Name="totalItems", EmitDefaultValue=true)]
        public int TotalItems { get; set; }

        /// <summary>
        /// Gets or Sets CurrentItemCount
        /// </summary>
        [DataMember(Name="currentItemCount", EmitDefaultValue=true)]
        public int CurrentItemCount { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PreviousNextSuccessResponseData {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  Updated: ").Append(Updated).Append("\n");
            sb.Append("  Deleted: ").Append(Deleted).Append("\n");
            sb.Append("  PreviousLink: ").Append(PreviousLink).Append("\n");
            sb.Append("  NextLink: ").Append(NextLink).Append("\n");
            sb.Append("  ItemsPerPage: ").Append(ItemsPerPage).Append("\n");
            sb.Append("  StartIndex: ").Append(StartIndex).Append("\n");
            sb.Append("  TotalItems: ").Append(TotalItems).Append("\n");
            sb.Append("  CurrentItemCount: ").Append(CurrentItemCount).Append("\n");
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
            return obj.GetType() == GetType() && Equals((PreviousNextSuccessResponseData)obj);
        }

        /// <summary>
        /// Returns true if PreviousNextSuccessResponseData instances are equal
        /// </summary>
        /// <param name="other">Instance of PreviousNextSuccessResponseData to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PreviousNextSuccessResponseData other)
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
                    PreviousLink == other.PreviousLink ||
                    PreviousLink != null &&
                    PreviousLink.Equals(other.PreviousLink)
                ) && 
                (
                    NextLink == other.NextLink ||
                    NextLink != null &&
                    NextLink.Equals(other.NextLink)
                ) && 
                (
                    ItemsPerPage == other.ItemsPerPage ||
                    
                    ItemsPerPage.Equals(other.ItemsPerPage)
                ) && 
                (
                    StartIndex == other.StartIndex ||
                    
                    StartIndex.Equals(other.StartIndex)
                ) && 
                (
                    TotalItems == other.TotalItems ||
                    
                    TotalItems.Equals(other.TotalItems)
                ) && 
                (
                    CurrentItemCount == other.CurrentItemCount ||
                    
                    CurrentItemCount.Equals(other.CurrentItemCount)
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
                    if (PreviousLink != null)
                    hashCode = hashCode * 59 + PreviousLink.GetHashCode();
                    if (NextLink != null)
                    hashCode = hashCode * 59 + NextLink.GetHashCode();
                    
                    hashCode = hashCode * 59 + ItemsPerPage.GetHashCode();
                    
                    hashCode = hashCode * 59 + StartIndex.GetHashCode();
                    
                    hashCode = hashCode * 59 + TotalItems.GetHashCode();
                    
                    hashCode = hashCode * 59 + CurrentItemCount.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(PreviousNextSuccessResponseData left, PreviousNextSuccessResponseData right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PreviousNextSuccessResponseData left, PreviousNextSuccessResponseData right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
