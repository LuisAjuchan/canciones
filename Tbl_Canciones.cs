namespace Jvasquez.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tbl_Canciones
    {
        [Key]
        public int idCancion { get; set; }

        [StringLength(80)]
        public string nombreCanciones { get; set; }

        [StringLength(100)]
        public string interprete { get; set; }

        public int idGenero { get; set; }

        public int nombreGenero { get; set; }

        public virtual Tbl_Generos Tbl_Generos { get; set; }
    }
}
