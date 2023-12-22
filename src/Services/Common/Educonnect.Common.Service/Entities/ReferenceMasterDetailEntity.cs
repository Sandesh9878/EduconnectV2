namespace Educonnect.Common.Service.Entities
{
    public class ReferenceMasterDetailEntity
    {
        [Key]
        public int ReferenceMasterDetailId { get; set; }
        public int ReferenceMasterId { get; set; }
        public string? ReferenceMasterDetail { get; set; }
        public string? ReferenceMasterDetailDescription { get; set; }
        public string? Val { get; set; }
        public Nullable<int> DisplaySequence { get; set; }
        public int Status { get; set; }
        public Nullable<int> ValidationField { get; set; }
        public bool IsRequiredField { get; set; }
    }
}
