namespace WebAPI.Models
{
    public partial class EnvironenmentReadings
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public string Unit { get; set; }
    }
}
