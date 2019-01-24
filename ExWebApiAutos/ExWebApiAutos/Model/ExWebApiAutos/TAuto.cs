using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExWebApiAutos.Model.ExWebApiAutos
{
    [Table("T_Auto")]
    public partial class TAuto
    {
        [Key]
        [Column("auto_id")]
        public Guid AutoId { get; set; }
        [Required]
        [Column("auto_color")]
        [StringLength(20)]
        public string AutoColor { get; set; }
        [Column("auto_aniofabri")]
        public int AutoAniofabri { get; set; }
        [Required]
        [Column("auto_nroplaca")]
        [StringLength(10)]
        public string AutoNroplaca { get; set; }
        [Column("auto_nroasientos")]
        public int AutoNroasientos { get; set; }
        [Required]
        [Column("auto_mecanico")]
        [StringLength(2)]
        public string AutoMecanico { get; set; }
        [Required]
        [Column("auto_full")]
        [StringLength(2)]
        public string AutoFull { get; set; }
        [Column("marca_id")]
        public Guid MarcaId { get; set; }

        [ForeignKey("MarcaId")]
        [InverseProperty("TAuto")]
        public TMarca Marca { get; set; }
    }
}
