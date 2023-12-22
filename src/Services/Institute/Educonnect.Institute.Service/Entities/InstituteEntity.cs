using System.ComponentModel.DataAnnotations;

namespace Educonnect.Institute.Service.Entities
{
    public partial class InstituteEntity
    {
        [Key]
        public int InstituteId { get; set; }
        public Nullable<int> ParentInstituteId { get; set; }
        public int Country { get; set; }
        public string InstituteCode { get; set; }
        public string? InstituteLegalName { get; set; }
        public string? InstituteTradingName { get; set; }
        public int InstituteType { get; set; }
        public string? RTOCode { get; set; }
        public int Active { get; set; }
        public int Publish { get; set; }
        public System.DateTime PublishDate { get; set; }
        public Nullable<int> TotalStudentNumbers { get; set; }
        public bool EnableAgentForEnquiryAndApplication { get; set; }
        public bool IsLinkedWithMeshedPlatform { get; set; }
        public bool EnableEduconnectAsMasterAgent { get; set; }
        public bool EnableStudentDirectEnquiryOrApplication { get; set; }
        public Nullable<int> ProviderLevel { get; set; }
    }
}
