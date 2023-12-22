namespace Educonnect.Common.Service.Entities
{
    public class FormEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int FormId { get; set; }
        public int FieldId { get; set; }
        public int FieldOrder { get; set; }
        public bool Mandatory { get; set; }
        public bool Disabled { get; set; }
        public string DefaultValue { get; set; }
        public Nullable<int> OptionOrder { get; set; }
        public int Status { get; set; }
        public Nullable<int> Score { get; set; }
        public Nullable<int> ValidationField { get; set; }
    }
}
