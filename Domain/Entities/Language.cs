namespace Domain.Entities
{
    public class Language
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string LanguageCode { get; set; }
        public bool IsDefault { get; set; }
    }
}