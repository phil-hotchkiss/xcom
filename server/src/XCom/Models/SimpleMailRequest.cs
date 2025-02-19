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
    public partial class SimpleMailRequest : IEquatable<SimpleMailRequest>
    {
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
        /// Gets or Sets Attachments
        /// </summary>
        [DataMember(Name="attachments", EmitDefaultValue=false)]
        public List<Attachment> Attachments { get; set; }

        /// <summary>
        /// Gets or Sets Subject
        /// </summary>
        [DataMember(Name="subject", EmitDefaultValue=false)]
        public string Subject { get; set; }

        /// <summary>
        /// Gets or Sets Content
        /// </summary>
        [DataMember(Name="content", EmitDefaultValue=false)]
        public Content Content { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class SimpleMailRequest {\n");
            sb.Append("  To: ").Append(To).Append("\n");
            sb.Append("  Cc: ").Append(Cc).Append("\n");
            sb.Append("  Bcc: ").Append(Bcc).Append("\n");
            sb.Append("  From: ").Append(From).Append("\n");
            sb.Append("  ReplyTo: ").Append(ReplyTo).Append("\n");
            sb.Append("  SendAt: ").Append(SendAt).Append("\n");
            sb.Append("  Attachments: ").Append(Attachments).Append("\n");
            sb.Append("  Subject: ").Append(Subject).Append("\n");
            sb.Append("  Content: ").Append(Content).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
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
            return obj.GetType() == GetType() && Equals((SimpleMailRequest)obj);
        }

        /// <summary>
        /// Returns true if SimpleMailRequest instances are equal
        /// </summary>
        /// <param name="other">Instance of SimpleMailRequest to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(SimpleMailRequest other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
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
                    Attachments == other.Attachments ||
                    Attachments != null &&
                    other.Attachments != null &&
                    Attachments.SequenceEqual(other.Attachments)
                ) && 
                (
                    Subject == other.Subject ||
                    Subject != null &&
                    Subject.Equals(other.Subject)
                ) && 
                (
                    Content == other.Content ||
                    Content != null &&
                    Content.Equals(other.Content)
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
                    if (To != null)
                    hashCode = hashCode * 59 + To.GetHashCode();
                    if (Cc != null)
                    hashCode = hashCode * 59 + Cc.GetHashCode();
                    if (Bcc != null)
                    hashCode = hashCode * 59 + Bcc.GetHashCode();
                    if (From != null)
                    hashCode = hashCode * 59 + From.GetHashCode();
                    if (ReplyTo != null)
                    hashCode = hashCode * 59 + ReplyTo.GetHashCode();
                    if (SendAt != null)
                    hashCode = hashCode * 59 + SendAt.GetHashCode();
                    if (Attachments != null)
                    hashCode = hashCode * 59 + Attachments.GetHashCode();
                    if (Subject != null)
                    hashCode = hashCode * 59 + Subject.GetHashCode();
                    if (Content != null)
                    hashCode = hashCode * 59 + Content.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(SimpleMailRequest left, SimpleMailRequest right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SimpleMailRequest left, SimpleMailRequest right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
