using System.ComponentModel.DataAnnotations;

namespace Educonnect.Student.Service.Entities
{
    public class StudentApplication
    {

        [Key]
        public int ApplicationID { get; set; }
        public int StudentNo { get; set; }
        public int InstituteID { get; set; }
        public int InstituteCourseID { get; set; }
        public Nullable<int> AgentID { get; set; }
        public System.DateTime DateApplied { get; set; }
        public Nullable<int> CourseInstanceID { get; set; }
        public Nullable<int> StudyType { get; set; }
        public string? ApplicationRequestNotes { get; set; }
        public int CampusID { get; set; }
        public string? InstituteUserID { get; set; }
        public int Status { get; set; }
        public Nullable<int> CoursePackageId { get; set; }
        public string? AssignedTo { get; set; }
        public string? ReportTo { get; set; }
        public bool IsSyncedWithMeshedPlatform { get; set; }
        public Nullable<int> ApplicationSource { get; set; }
        public bool IsForwaredToProvider { get; set; }
        public bool IsActive { get; set; }
        public Nullable<int> TargetId { get; set; }
        public string? AppliedById { get; set; }
    }
}
