using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Jvasquez.Models;
using System.Data.SqlClient;

namespace Jvasquez.Controllers { 

    public class CancionController : Controller
    {
        // GET: Cancion
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListarCanciones()
        {
            try
            {
                MusicModel modelo = new MusicModel();
                List<CancionView> nombreCanciones = modelo.Database.SqlQuery<CancionView>("spr_ListarCanciones").ToList();
                //{'idGenero':1, 'genero': 'Rock'}
                return Json(nombreCanciones, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult Insertar(CancionView modelo1)
        {
            try
            {
                //Conexión a base de datos
                MusicModel modelo = new MusicModel();
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter("@nombreCancion", modelo1.nombreCanciones));
                parametros.Add(new SqlParameter("@interprete",  ""));
                parametros.Add(new SqlParameter("@idGenero", modelo1.idGenero));

                List<CancionView> canciones =
                    modelo.Database.SqlQuery<CancionView>("Spr_InsertarCancion @nombreCancion, @interprete, @idGenero", parametros.ToArray()).ToList();
                return Json(canciones, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult Actualizar(CancionView modelo1)
        {
            try
            {
                //Conexión a base de datos
                MusicModel modelo = new MusicModel();
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter("@idCancion", modelo1.idCancion));
                parametros.Add(new SqlParameter("@idGenero", modelo1.idGenero));
                parametros.Add(new SqlParameter("@nombreCancion", modelo1.nombreCanciones));

                List<CancionView> canciones =
                    modelo.Database.SqlQuery<CancionView>("Spr_ActualizarCancion @idCancion, @idGenero, @nombreCancion", parametros.ToArray()).ToList();
                return Json(canciones, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public ActionResult Eliminar(CancionView modelo1)
        {
            try
            {
                //Conexión a base de datos
                MusicModel modelo = new MusicModel();
                List<SqlParameter> parametros = new List<SqlParameter>();
                parametros.Add(new SqlParameter("@idCancion", modelo1.idCancion));
                

                List<CancionView> canciones =
                    modelo.Database.SqlQuery<CancionView>("Spr_EliminarCancion @idCancion ", parametros.ToArray()).ToList();
                return Json(canciones, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
    }
}