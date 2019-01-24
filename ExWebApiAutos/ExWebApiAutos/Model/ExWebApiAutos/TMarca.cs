using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExWebApiAutos.Model.ExWebApiAutos
{
    [Table("T_Marca")]
    public partial class TMarca
    {
        public TMarca()
        {
            TAuto = new HashSet<TAuto>();
        }

        [Key]
        [Column("marca_id")]
        public Guid MarcaId { get; set; }
        [Required]
        [Column("marca_nombre")]
        [StringLength(20)]
        public string MarcaNombre { get; set; }

        [InverseProperty("Marca")]
        public ICollection<TAuto> TAuto { get; set; }
    }
}
