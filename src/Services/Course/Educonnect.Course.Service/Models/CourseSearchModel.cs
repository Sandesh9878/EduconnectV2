using Educonnect.Course.Service.SearchEngine;

namespace Educonnect.Course.Service.Models
{
    public class CourseSearchModel
    {
        public CourseSearchModel() { }
        [LucenseKey]
        public string InstituteCourseCampusId { get; set; }
        [LucenseNotSearch]
        public string CourseId { get; set; }
        public string InstituteId { get; set; }
        public string InstituteCourseId { get; set; }
        [LucenseNotSearch]
        public string CampusId { get; set; }
        public string CourseName { get; set; }
        public string CRICOSCode { get; set; }
        public string Duration { get; set; }
        [LucenePriceField]
        public string CourseFee { get; set; }
        [LucenePriceField]
        public string MaxFee { get; set; }
        [LucenePriceField]
        public string MinFee { get; set; }
        public string CourseFeePeriod { get; set; }
        public string CourseLevel { get; set; }
        public string CourseLevelId { get; set; }
        public string Address { get; set; }
        public string InstituteName { get; set; }
        public string CourseArea { get; set; }
        public string CourseAreaId { get; set; }
        [LucenseNotSearch]
        public string Logo { get; set; }

        public string StateCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string CounrtryCode { get; set; }
        public string Suburb { get; set; }
        [LucenseNotSearch]
        public string CourseInstances { get; set; }
        [LucenseNotSearch]
        public string IsBookmarked { get; set; }
        [LucenseNotSearch]
        public string IsCompared { get; set; }
        [LucenseNotSearch]
        public string HasCoursePackage { get; set; }
        public string DisplayCourseFee { get; set; }
        [LucenseNotSearch]
        public string IsFeeRange { get; set; }
        [LuceneArrayField]
        public string StudyMode { get; set; }
        [LuceneArrayField]
        public string DeliveryMode { get; set; }
        [LuceneArrayField]
        public string Target { get; set; }
        public string Scholarship { get; set; }
        [LucenseNotSearch]
        public string IsAlreadyApplied { get; set; }
        [LucenseNotSearch]
        public string IsAlreadyEnquired { get; set; }
        [LucenseNotSearch]
        public string IsSelectedForStudyOption { get; set; }
    }
}
