namespace Educonnect.Common.Service.Entities
{
    public class Form
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Nullable<int> Step { get; set; }
        public Nullable<int> ParentId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int Status { get; set; }
        public Nullable<int> NextStep { get; set; }
        public Nullable<int> TotalSteps { get; set; }
    }
}
