using Azure;
using Azure.Data.Tables;
using System;
using System.ComponentModel.DataAnnotations;

namespace ABCRetailWebApp.Models
{
    /// <summary>
    /// Represents a customer's profile with personal information.
    /// </summary>
    public class CustomerProfiles : ITableEntity
    {
        /// <summary>
        /// Gets or sets the customer's first name.
        /// </summary>
        [Required]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the customer's last name.
        /// </summary>
        [Required]
        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters.")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the customer's email address.
        /// </summary>
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the customer's phone number.
        /// </summary>
        [Phone(ErrorMessage = "Invalid phone number.")]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the partition key for the Azure Table storage.
        /// </summary>
        public string PartitionKey { get; set; }

        /// <summary>
        /// Gets or sets the row key for the Azure Table storage.
        /// </summary>
        public string RowKey { get; set; }

        /// <summary>
        /// Gets or sets the timestamp for the Azure Table storage entity.
        /// </summary>
        public DateTimeOffset? Timestamp { get; set; }

        /// <summary>
        /// Gets or sets the ETag for the Azure Table storage entity.
        /// </summary>
        public ETag ETag { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerProfiles"/> class with default values.
        /// </summary>
        public CustomerProfiles()
        {
            PartitionKey = "CustomerProfile";
            RowKey = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerProfiles"/> class with specific values.
        /// </summary>
        /// <param name="firstName">The customer's first name.</param>
        /// <param name="lastName">The customer's last name.</param>
        /// <param name="email">The customer's email address.</param>
        /// <param name="phoneNumber">The customer's phone number.</param>
        public CustomerProfiles(string firstName, string lastName, string email, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            PartitionKey = "CustomerProfile";
            RowKey = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Returns a string representation of the customer's profile.
        /// </summary>
        /// <returns>A string representation of the profile.</returns>
        public override string ToString()
        {
            return $"Name: {FirstName} {LastName}, Email: {Email}, Phone: {PhoneNumber}";
        }

        /// <summary>
        /// Determines whether the specified <see cref="CustomerProfiles"/> is equal to the current instance.
        /// </summary>
        /// <param name="other">The <see cref="CustomerProfiles"/> to compare with the current instance.</param>
        /// <returns><c>true</c> if the specified <see cref="CustomerProfiles"/> is equal to the current instance; otherwise, <c>false</c>.</returns>
        public bool Equals(CustomerProfiles other)
        {
            if (other == null) return false;
            return FirstName == other.FirstName &&
                   LastName == other.LastName &&
                   Email == other.Email &&
                   PhoneNumber == other.PhoneNumber;
        }

        /// <summary>
        /// Determines whether the specified object is equal to the current instance.
        /// </summary>
        /// <param name="obj">The object to compare with the current instance.</param>
        /// <returns><c>true</c> if the specified object is equal to the current instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            return Equals(obj as CustomerProfiles);
        }

        /// <summary>
        /// Serves as a hash function for the current instance.
        /// </summary>
        /// <returns>A hash code for the current instance.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(FirstName, LastName, Email, PhoneNumber);
        }
    }
}
