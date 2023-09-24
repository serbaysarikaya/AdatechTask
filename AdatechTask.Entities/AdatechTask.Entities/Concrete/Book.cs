using AdatechTask.Shared.Entities.Abstract;

namespace AdatechTask.Entities.Concrete
{
    public class Book : EntityBase, IEntity
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public DateTime PublicationDate { get; set; }
        public string ISBN { get; set; }
        public string Category { get; set; }
        public int PageCount { get; set; }
        public string Publisher { get; set; }

    }
}
