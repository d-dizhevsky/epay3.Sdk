using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel;
using System.Globalization;

namespace epay3.Web.Api.Sdk.Model
{
    /// <summary>
    /// Provides details of a token.
    /// </summary>
    [DataContract]
    public partial class GetTokenResponseModel :  IEquatable<GetTokenResponseModel>
    { 
    
        /// <summary>
        /// The type of transaction.
        /// </summary>
        /// <value>The type of transaction.</value>
        [JsonConverter(typeof(StringEnumConverter))]
        public enum TransactionTypeEnum {
            
            [EnumMember(Value = "Ach")]
            Ach,
            
            [EnumMember(Value = "Visa")]
            Visa,
            
            [EnumMember(Value = "MasterCard")]
            Mastercard,
            
            [EnumMember(Value = "Discover")]
            Discover,
            
            [EnumMember(Value = "AmericanExpress")]
            Americanexpress,
            
            [EnumMember(Value = "Jcb")]
            Jcb
        }

    
        /// <summary>
        /// The type of transaction.
        /// </summary>
        /// <value>The type of transaction.</value>
        [DataMember(Name="transactionType", EmitDefaultValue=false)]
        public TransactionTypeEnum? TransactionType { get; set; }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="GetTokenResponseModel" /> class.
        /// Initializes a new instance of the <see cref="GetTokenResponseModel" />class.
        /// </summary>
        /// <param name="Id">The unique identifier of the token..</param>
        /// <param name="AttributeValues">A collection of key/value pairs for any custom attribute values for this token..</param>
        /// <param name="TransactionType">The type of transaction..</param>
        /// <param name="MaskedAccountNumber">The masked account number for display to the user..</param>

        public GetTokenResponseModel(string Id = null, List<AttributeValueModel> AttributeValues = null, TransactionTypeEnum? TransactionType = null, string MaskedAccountNumber = null)
        {
            this.Id = Id;
            this.AttributeValues = AttributeValues;
            this.TransactionType = TransactionType;
            this.MaskedAccountNumber = MaskedAccountNumber;
            
        }
        
    
        /// <summary>
        /// The unique identifier of the token.
        /// </summary>
        /// <value>The unique identifier of the token.</value>
        [DataMember(Name="id", EmitDefaultValue=false)]
        public string Id { get; set; }
    
        /// <summary>
        /// A collection of key/value pairs for any custom attribute values for this token.
        /// </summary>
        /// <value>A collection of key/value pairs for any custom attribute values for this token.</value>
        [DataMember(Name="attributeValues", EmitDefaultValue=false)]
        public List<AttributeValueModel> AttributeValues { get; set; }
    
        /// <summary>
        /// The masked account number for display to the user.
        /// </summary>
        /// <value>The masked account number for display to the user.</value>
        [DataMember(Name="maskedAccountNumber", EmitDefaultValue=false)]
        public string MaskedAccountNumber { get; set; }

        public T GetAttributeValue<T>(string parameterName)
        {
            var value = AttributeValues.SingleOrDefault(x=>x.ParameterName == parameterName).Value;
            var converter = TypeDescriptor.GetConverter(typeof(T));

            if (value == null)
                return default(T);

            return (T)converter.ConvertFromString(null, CultureInfo.InvariantCulture, value);
        }
    
        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class GetTokenResponseModel {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  AttributeValues: ").Append(AttributeValues).Append("\n");
            sb.Append("  TransactionType: ").Append(TransactionType).Append("\n");
            sb.Append("  MaskedAccountNumber: ").Append(MaskedAccountNumber).Append("\n");
            
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
            // credit: http://stackoverflow.com/a/10454552/677735
            return this.Equals(obj as GetTokenResponseModel);
        }

        /// <summary>
        /// Returns true if GetTokenResponseModel instances are equal
        /// </summary>
        /// <param name="other">Instance of GetTokenResponseModel to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(GetTokenResponseModel other)
        {
            // credit: http://stackoverflow.com/a/10454552/677735
            if (other == null)
                return false;

            return 
                (
                    this.Id == other.Id ||
                    this.Id != null &&
                    this.Id.Equals(other.Id)
                ) && 
                (
                    this.AttributeValues == other.AttributeValues ||
                    this.AttributeValues != null &&
                    this.AttributeValues.SequenceEqual(other.AttributeValues)
                ) && 
                (
                    this.TransactionType == other.TransactionType ||
                    this.TransactionType != null &&
                    this.TransactionType.Equals(other.TransactionType)
                ) && 
                (
                    this.MaskedAccountNumber == other.MaskedAccountNumber ||
                    this.MaskedAccountNumber != null &&
                    this.MaskedAccountNumber.Equals(other.MaskedAccountNumber)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            // credit: http://stackoverflow.com/a/263416/677735
            unchecked // Overflow is fine, just wrap
            {
                int hash = 41;
                // Suitable nullity checks etc, of course :)
                
                if (this.Id != null)
                    hash = hash * 59 + this.Id.GetHashCode();
                
                if (this.AttributeValues != null)
                    hash = hash * 59 + this.AttributeValues.GetHashCode();
                
                if (this.TransactionType != null)
                    hash = hash * 59 + this.TransactionType.GetHashCode();
                
                if (this.MaskedAccountNumber != null)
                    hash = hash * 59 + this.MaskedAccountNumber.GetHashCode();
                
                return hash;
            }
        }

    }
}