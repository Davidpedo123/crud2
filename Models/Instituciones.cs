using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace crud2.Models
{
    [Table("a")]
    public class Institucion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(50)]
        public string? Sigla { get; set; }

        [StringLength(256)]
        public string? Ubicacion { get; set; }

        
        public float? Lat_Min { get; set; }
        public float? Lat_Max { get; set; }
        public float? Lon_Min { get; set; }
        public float? Lon_Max { get; set; }
    }
}
