using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
//using System.Web.Mvc;

namespace Jvasquez.Models
{
    public class CancionView
    {
        
        public int idCancion { get; set; }

        public string nombreCanciones { get; set; }

        public string interprete { get; set; }

        public int idGenero { get; set; }

        public string nombreGenero { get; set; }
    }
}