using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUD.Models.ViewModels
{
    public class ListExamenViewModel
    {
        public int idEmpleado { get; set; }
        public string nombre { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string curp { get; set; }
        public int activo { get; set; }


    }
}