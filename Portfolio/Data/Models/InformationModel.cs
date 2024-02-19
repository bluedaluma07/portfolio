namespace Portfolio.Data.Models
{
    public class InformationModel
    {
        public List<InformationItem> InformationList { get; set; }
    }

    public class InformationItem
    {
        public string InformationTitle { get; set; }
        public string InformationText { get; set; }
        public DateTime RegistDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
