using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppAngularAPI.Models
{
    public class CarList
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; } = "";
        [MaxLength(100)]
        public string Model { get; set; } = "";
        public int Type { get; set; }
        public string color { get; set; } = "";
        public int Pirce { get; set; }
    }
}
