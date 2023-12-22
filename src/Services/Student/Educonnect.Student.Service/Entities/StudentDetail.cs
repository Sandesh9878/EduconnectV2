using System.ComponentModel.DataAnnotations;

namespace Educonnect.Student.Service.Entities
{
    public class StudentDetails
    {
        [Key]
        public int StudentNo { get; set; }
        public string UserRefID { get; set; }
        public int StudentId { get; set; }
        public string? NickName { get; set; }
        public DateTime DoB { get; set; }
        public int CountryOfBirth { get; set; }
        public string? CityOfBirth { get; set; }
        public Nullable<int> CountryOfPassport { get; set; }
        public string? PassportNo { get; set; }
        public DateTime? PassportExpDate { get; set; }
        public Nullable<int> MainLanguage { get; set; }
        public Nullable<int> OtherLanguage1 { get; set; }
        public Nullable<int> OtherLanguage2 { get; set; }
        public int EnglishLanguageLevel { get; set; }
        public bool DisabilityFlag { get; set; }
        public string? DisabilityDetails { get; set; }
        public int Nationality { get; set; }
        public Nullable<decimal> TutionFeeFrom { get; set; }
        public Nullable<decimal> TutionFeeTo { get; set; }
        public Nullable<int> ResidenceStatus { get; set; }
        public Nullable<int> MaritalStatus { get; set; }
    }
}
