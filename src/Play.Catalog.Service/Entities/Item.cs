using Microsoft.Net.Http.Headers;

namespace Play.Catalog.Service.Entities
{
    public class Item
    {
        public Guid Id { get; set; }
        public string name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTimeOffset CreatedDate { get; set; }

    }
}