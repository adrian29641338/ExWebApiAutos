using System;
using System.Collections.Generic;

namespace ExWebApiAutos.Model.ExWebApiAutos
{
    public partial class TAuto
    {
        public Guid AutoId { get; set; }
        public string AutoColor { get; set; }
        public int AutoAniofabri { get; set; }
        public string AutoNroplaca { get; set; }
        public int AutoNroasientos { get; set; }
        public string AutoMecanico { get; set; }
        public string AutoFull { get; set; }
        public Guid MarcaId { get; set; }

        public TMarca Marca { get; set; }
    }
}
