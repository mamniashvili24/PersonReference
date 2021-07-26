namespace Api.Models
{
    public class AddRelatedPersonRequest
    {
        public int PersonId { get; set; }
        public int RelatedPersonId { get; set; }
        public string RelatedPersonType { get; set; }
    }
}