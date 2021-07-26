namespace Api.Models
{
    public class DeleteRelatedPersonRequest
    {
        public int PersonId { get; set; }
        public int RelatedPersonId { get; set; }
    }
}