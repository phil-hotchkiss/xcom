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
    public partial class TemplatedEmailRequest : IEquatable<TemplatedEmailRequest>
    {
        /// <summary>
        /// This is the name identifying the set of templates to be grouped together for the delivery of this email
        /// </summary>
        /// <value>This is the name identifying the set of templates to be grouped together for the delivery of this email</value>
        [DataMember(Name="templateSetName", EmitDefaultValue=false)]
        public string TemplateSetName { get; set; }

        /// <summary>
        /// This key is leveraged for rate limiting purposes. When specified, if the template has a rate limit specified, the business key will be utilied for the rate limit.
        /// </summary>
        /// <value>This key is leveraged for rate limiting purposes. When specified, if the template has a rate limit specified, the business key will be utilied for the rate limit.</value>
        [DataMember(Name="businessKey", EmitDefaultValue=false)]
        public string BusinessKey { get; set; }

        /// <summary>
        /// When specified, the dynamic template data supplied to SendGrid will include relevant content associated with that branch (address, footer, website, socials)
        /// </summary>
        /// <value>When specified, the dynamic template data supplied to SendGrid will include relevant content associated with that branch (address, footer, website, socials)</value>
        [DataMember(Name="onBehalfOfBranch", EmitDefaultValue=false)]
        public string OnBehalfOfBranch { get; set; }

        /// <summary>
        /// Gets or Sets To
        /// </summary>
        [DataMember(Name="to", EmitDefaultValue=false)]
        public List<Recipient> To { get; set; }

        /// <summary>
        /// Gets or Sets Cc
        /// </summary>
        [DataMember(Name="cc", EmitDefaultValue=false)]
        public List<Recipient> Cc { get; set; }

        /// <summary>
        /// Gets or Sets Bcc
        /// </summary>
        [DataMember(Name="bcc", EmitDefaultValue=false)]
        public List<Recipient> Bcc { get; set; }

        /// <summary>
        /// Gets or Sets TemplateData
        /// </summary>
        [DataMember(Name="templateData", EmitDefaultValue=false)]
        public Object TemplateData { get; set; }

        /// <summary>
        /// Gets or Sets From
        /// </summary>
        [DataMember(Name="from", EmitDefaultValue=false)]
        public Recipient From { get; set; }

        /// <summary>
        /// Gets or Sets ReplyTo
        /// </summary>
        [DataMember(Name="replyTo", EmitDefaultValue=false)]
        public Recipient ReplyTo { get; set; }

        /// <summary>
        /// Gets or Sets SendAt
        /// </summary>
        [DataMember(Name="sendAt", EmitDefaultValue=false)]
        public DateTime SendAt { get; set; }

        /// <summary>
        /// Gets or Sets BatchId
        /// </summary>
        [DataMember(Name="batchId", EmitDefaultValue=false)]
        public string BatchId { get; set; }

        /// <summary>
        /// Gets or Sets Attachments
        /// </summary>
        [DataMember(Name="attachments", EmitDefaultValue=false)]
        public List<Attachment> Attachments { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class TemplatedEmailRequest {\n");
            sb.Append("  TemplateSetName: ").Append(TemplateSetName).Append("\n");
            sb.Append("  BusinessKey: ").Append(BusinessKey).Append("\n");
            sb.Append("  OnBehalfOfBranch: ").Append(OnBehalfOfBranch).Append("\n");
            sb.Append("  To: ").Append(To).Append("\n");
            sb.Append("  Cc: ").Append(Cc).Append("\n");
            sb.Append("  Bcc: ").Append(Bcc).Append("\n");
            sb.Append("  TemplateData: ").Append(TemplateData).Append("\n");
            sb.Append("  From: ").Append(From).Append("\n");
            sb.Append("  ReplyTo: ").Append(ReplyTo).Append("\n");
            sb.Append("  SendAt: ").Append(SendAt).Append("\n");
            sb.Append("  BatchId: ").Append(BatchId).Append("\n");
            sb.Append("  Attachments: ").Append(Attachments).Append("\n");
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
            return obj.GetType() == GetType() && Equals((TemplatedEmailRequest)obj);
        }

        /// <summary>
        /// Returns true if TemplatedEmailRequest instances are equal
        /// </summary>
        /// <param name="other">Instance of TemplatedEmailRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(TemplatedEmailRequest other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    TemplateSetName == other.TemplateSetName ||
                    TemplateSetName != null &&
                    TemplateSetName.Equals(other.TemplateSetName)
                ) && 
                (
                    BusinessKey == other.BusinessKey ||
                    BusinessKey != null &&
                    BusinessKey.Equals(other.BusinessKey)
                ) && 
                (
                    OnBehalfOfBranch == other.OnBehalfOfBranch ||
                    OnBehalfOfBranch != null &&
                    OnBehalfOfBranch.Equals(other.OnBehalfOfBranch)
                ) && 
                (
                    To == other.To ||
                    To != null &&
                    other.To != null &&
                    To.SequenceEqual(other.To)
                ) && 
                (
                    Cc == other.Cc ||
                    Cc != null &&
                    other.Cc != null &&
                    Cc.SequenceEqual(other.Cc)
                ) && 
                (
                    Bcc == other.Bcc ||
                    Bcc != null &&
                    other.Bcc != null &&
                    Bcc.SequenceEqual(other.Bcc)
                ) && 
                (
                    TemplateData == other.TemplateData ||
                    TemplateData != null &&
                    TemplateData.Equals(other.TemplateData)
                ) && 
                (
                    From == other.From ||
                    From != null &&
                    From.Equals(other.From)
                ) && 
                (
                    ReplyTo == other.ReplyTo ||
                    ReplyTo != null &&
                    ReplyTo.Equals(other.ReplyTo)
                ) && 
                (
                    SendAt == other.SendAt ||
                    SendAt != null &&
                    SendAt.Equals(other.SendAt)
                ) && 
                (
                    BatchId == other.BatchId ||
                    BatchId != null &&
                    BatchId.Equals(other.BatchId)
                ) && 
                (
                    Attachments == other.Attachments ||
                    Attachments != null &&
                    other.Attachments != null &&
                    Attachments.SequenceEqual(other.Attachments)
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
                    if (TemplateSetName != null)
                    hashCode = hashCode * 59 + TemplateSetName.GetHashCode();
                    if (BusinessKey != null)
                    hashCode = hashCode * 59 + BusinessKey.GetHashCode();
                    if (OnBehalfOfBranch != null)
                    hashCode = hashCode * 59 + OnBehalfOfBranch.GetHashCode();
                    if (To != null)
                    hashCode = hashCode * 59 + To.GetHashCode();
                    if (Cc != null)
                    hashCode = hashCode * 59 + Cc.GetHashCode();
                    if (Bcc != null)
                    hashCode = hashCode * 59 + Bcc.GetHashCode();
                    if (TemplateData != null)
                    hashCode = hashCode * 59 + TemplateData.GetHashCode();
                    if (From != null)
                    hashCode = hashCode * 59 + From.GetHashCode();
                    if (ReplyTo != null)
                    hashCode = hashCode * 59 + ReplyTo.GetHashCode();
                    if (SendAt != null)
                    hashCode = hashCode * 59 + SendAt.GetHashCode();
                    if (BatchId != null)
                    hashCode = hashCode * 59 + BatchId.GetHashCode();
                    if (Attachments != null)
                    hashCode = hashCode * 59 + Attachments.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(TemplatedEmailRequest left, TemplatedEmailRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(TemplatedEmailRequest left, TemplatedEmailRequest right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}