
using Newtonsoft.Json;

namespace backend.Models
{
    public class Incident : Entity
    {

        [JsonConstructor]
        public Incident(string title, string description, decimal value, string ongId)
        {
            Title = title;
            Description = description;
            Value = value;
            OngId = ongId;
        }

        public Incident(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public decimal Value { get; private set; }
        public string OngId { get; private set; }
        public Ong Ong { get; private set; }

        public void SetOngAuthenticated(string ongId)
        {
            this.OngId = ongId;
        }
    }
}