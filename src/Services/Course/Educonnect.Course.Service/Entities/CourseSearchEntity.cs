using Educonnect.Course.Service.SearchEngine;
using System.ComponentModel.DataAnnotations;

namespace Educonnect.Course.Service.Entitites
{
    public class CourseSearchEntity
    {
        [Key]
        [LucenseKey]
        public int InstituteCourseCampusId { get; set; }
        public string CourseLevel { get; set; }
        public int CourseId { get; set; }
        public int InstituteCourseId { get; set; }
        public int CampusId { get; set; }
        public string InstituteTradingName { get; set; }
        public string SpecificCourseName { get; set; }
        public int InstituteId { get; set; }
        public int Publish { get; set; }
        public int? CourseAreaId { get; set; }
        public string CourseAreas { get; set; }

        public bool IsFeeRange { get; set; }
        public string? ImagePath { get; set; }
        public string? DeliveryModeTypeId { get; set; }
        public string? StudyModeId { get; set; }
        public string? TargetId { get; set; }
        public int Country { get; set; }
        public int? State { get; set; }
        public string StreetAddressLine1 { get; set; }
        public string Suburb { get; set; }
        public string CountryName { get; set; }
        public string CountryCode { get; set; }
        public decimal? MinFee { get; set; }
        public decimal? MaxFee { get; set; }
        public int? CourseFeePeriod { get; set; }
        public bool? DisplayCourseFee { get; set; }
        public decimal? CourseFee { get; set; }
        public int? MaxDuration { get; set; }
        public int? MinDuration { get; set; }
        public int? DurationValue { get; set; }
        public bool IsDurationRange { get; set; }
        public int? DurationTypeId { get; set; }

    }
}
