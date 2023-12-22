namespace Educonnect.Common.Service.Entities
{
    public class FormEntityOption
    {
        public int Id { get; set; }
        public int FormEntityId { get; set; }
        public string Title { get; set; }
        public int Field { get; set; }
        public int Status { get; set; }
        public Nullable<int> Score { get; set; }
        public Nullable<int> DisplaySequence { get; set; }
        public Nullable<int> NextStep { get; set; }
        public bool SupportiveTextRequired { get; set; }
        public Nullable<int> CurrentStep { get; set; }
        public Nullable<int> PreviousStep { get; set; }
        public bool SendEmail { get; set; }
        public string? ToolText { get; set; }
    }
}
