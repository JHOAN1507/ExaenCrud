using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUD.Models;
using CRUD.Models.ViewModels;
namespace CRUD.Controllers

{
    public class ExamenController : Controller
    {
        // GET: Examen
        public ActionResult Index()
        {
            List<ListExamenViewModel> lst;
            using (ExamenEntities db = new ExamenEntities())
            {
                lst = (from d in db.Empleadoes
                       select new ListExamenViewModel
                       {
                           idEmpleado = d.IdEmpleado,
                           nombre = d.Nombre,
                           apellidoPaterno = d.ApellidoPaterno,
                           apellidoMaterno = d.ApellidoMaterno,
                           curp = d.Curp,


                       }).ToList();
            }
            return View(lst);
        }
        public ActionResult Nuevo()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Nuevo(TablaVieModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (ExamenEntities db = new ExamenEntities())
                    {
                        var oTabla = new Empleado();
                        oTabla.Nombre = model.nombre;
                        oTabla.ApellidoPaterno = model.apellidoPaterno;
                        oTabla.ApellidoMaterno = model.apellidoMaterno;
                        oTabla.Curp = model.curp;
                        db.Empleadoes.Add(oTabla);
                        db.SaveChanges();
                    }
                    return Redirect("~/Examen/");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public ActionResult Editar(int id)
        {
            TablaVieModel model = new TablaVieModel();
            using (ExamenEntities db = new ExamenEntities())
            {
                var oTabla = db.Empleadoes.Find(id);
                model.nombre = oTabla.Nombre;
                model.apellidoPaterno = oTabla.ApellidoPaterno;
                model.apellidoMaterno = oTabla.ApellidoMaterno;
                model.curp = oTabla.ApellidoPaterno;
                model.idEmpleado = oTabla.IdEmpleado;
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Editar(TablaVieModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (ExamenEntities db = new ExamenEntities())
                    {
                        var oTabla = db.Empleadoes.Find(model.idEmpleado);
                        oTabla.Nombre = model.nombre;
                        oTabla.ApellidoPaterno = model.apellidoPaterno;
                        oTabla.ApellidoMaterno = model.apellidoMaterno;
                        oTabla.Curp = model.curp;

                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();
                    }
                    return Redirect("~/Examen/");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            
            using (ExamenEntities db = new ExamenEntities())
            {
                
                var oTabla = db.Empleadoes.Find(id);
                db.Empleadoes.Remove(oTabla);
                db.SaveChanges();
                
            }
            return Redirect("~/Examen/");
        }
    }
}