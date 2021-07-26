namespace Domain.Entities
{
    public class PersonRelatedPerson
    {
        public int Id { get; set; }
        public virtual Person Person { get; set; }
        public virtual Person RelatedPerson { get; set; }
        public virtual RelatedPersonType RelatedPersonType { get; set; }
    }
}