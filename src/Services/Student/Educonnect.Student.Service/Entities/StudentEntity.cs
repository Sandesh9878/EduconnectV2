using System.ComponentModel.DataAnnotations;

namespace Educonnect.Student.Service.Entities
{
    public class StudentEntity
    {
        [Key]
        public int PersonId { get; set; }
        public string? Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<int> Gender { get; set; }
        public string? PrimaryEmail { get; set; }
        public string? SecondaryEmail { get; set; }
        public string? HomePhone { get; set; }
        public string? WorkPhone { get; set; }
        public string? Mobile { get; set; }
        public string CredentialId { get; set; }
        public Nullable<int> Country { get; set; }
        public int AddressId { get; set; }
        public string? AssignedTo { get; set; }
        public Nullable<System.DateTime> AssignedOn { get; set; }
        public Nullable<System.DateTime> FollowUpDate { get; set; }
        public Nullable<int> StudentCategoryId { get; set; }
        public Nullable<int> AssignedToAgent { get; set; }
        public Nullable<System.DateTime> AssignedToAgentOn { get; set; }
        public Nullable<System.DateTime> AgentFollowUpDate { get; set; }
        public bool IsLead { get; set; }
        public Nullable<int> AgentId { get; set; }
        public Nullable<int> AssignmentType { get; set; }
        public string? City { get; set; }
        public Nullable<decimal> DesiredFeeFrom { get; set; }
        public Nullable<decimal> DesiredFeeTo { get; set; }
        public bool IsZohoSynced { get; set; }
        public string? ZohoLeadId { get; set; }
        public int UtmSource { get; set; }
    }
}
