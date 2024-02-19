namespace Portfolio.Data.Models
{
    public class MenuButton
    {
        public string Text { get; set; }
        public Action OnClick { get; set; }
        public int DisplayOrder { get; set; }
        public string IconClass { get; set; }
    }
}
