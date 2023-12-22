namespace Educonnect.Course.Service
{
    public partial class InstituteCourse
    {
        public int InstituteCourseId { get; set; }
        public int InstituteId { get; set; }
        public int CourseId { get; set; }
        public string? SpecificCourseName { get; set; }
        public string? InstituteCourseDescription { get; set; }
        public int Publish { get; set; }
        public DateTime ActivationDate { get; set; }
        public Nullable<decimal> CourseFee { get; set; }
        public Nullable<int> DurationTypeId { get; set; }
        public Nullable<int> DurationValue { get; set; }
        public bool IsSynced { get; set; }
        public Nullable<int> CourseFeePeriod { get; set; }
        public Nullable<bool> DisplayCourseFee { get; set; }
        public string? CRICOSCode { get; set; }
        public Nullable<int> CourseLevelId { get; set; }
        public Nullable<int> StudyMode { get; set; }
        public string? WorkPlacement { get; set; }
        public string? CareerOpportunity { get; set; }
        public string? IntakeFrequency { get; set; }
        public bool IsFeeRange { get; set; }
        public Nullable<decimal> MaxFee { get; set; }
        public Nullable<decimal> MinFee { get; set; }
        public Nullable<int> NoOfSubjectRequired { get; set; }
        public string? CourseStructure { get; set; }
        public Nullable<int> CopiedFromCourseId { get; set; }
        public bool IsDurationRange { get; set; }
        public Nullable<int> MaxDuration { get; set; }
        public Nullable<int> MinDuration { get; set; }
        public Nullable<int> CourseAreaId { get; set; }
        public bool IsFromManifest { get; set; }
    }
}
