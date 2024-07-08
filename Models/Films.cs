using System.ComponentModel.DataAnnotations.Schema;

namespace Test.Models
{
    public class Films
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        [ForeignKey("Actor")]
        public int ActorId { get;set; }
        public Actors Actor { get;set; }
    }
}
