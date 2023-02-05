namespace ParentChildrenApp.Models.DTO
{
    public class ChildDTO
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public int NoOfChild { get; set; }
        public string Gender { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public string Photo { get; set; }
    }
}
