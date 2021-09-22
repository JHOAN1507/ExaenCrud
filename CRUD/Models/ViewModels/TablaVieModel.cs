using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD.Models.ViewModels
{
    public class TablaVieModel
    {
        public int idEmpleado { get; set; }
        [Required]
        public string nombre { get; set; }
        [Required]
        public string apellidoPaterno { get; set; }
        [Required]
        public string apellidoMaterno { get; set; }
        [Required]
        public string curp { get; set; }
        public int activo { get; set; }
    }
}