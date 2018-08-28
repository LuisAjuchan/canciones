using System;
using Jvasquez.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;

namespace Jvasquez.Controllers
{
    public class GeneroController : Controller
    {
        // GET: Genero
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult ListarGeneros()
        {
            try
            {
                MusicModel genero = new MusicModel();
                List<Tbl_Generos> nombreGenero = genero.Database.SqlQuery<Tbl_Generos>("Spr_ListarGeneros").ToList();
                //{'idGenero':1, 'genero': 'Rock'}
                return Json(nombreGenero, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                return Json(ex.Message, JsonRequestBehavior.AllowGet);
            }
        }
        public String Eliminar(int idGenero)
        {
            try
            {
                MusicModel modelo = new MusicModel();
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@idGenero",
                    Value = idGenero
                };
                modelo.Database.SqlQuery<List<string>>("exec Spr_EliminarGenero @idGenero", idParam).ToList();
                return "OK";
            }
            catch (SqlException sqlExcepcion)
            {
                /* if(sqlExcepcion.ErrorCode == 21) {
                     return "Eror de conexion";
                 }else if*/
                return "Error en Base de datos: " + sqlExcepcion.Message;
            }
            catch (Exception ex)
            {
                return "Error general: " + ex.Message;
            }
        }

        public String Insertar(String nombreGenero)
        {
            try
            {
                MusicModel modelo = new MusicModel();
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@nombreGenero",
                    Value = nombreGenero
                };
                modelo.Database.SqlQuery<List<string>>("exec Spr_InsertarGenero @nombreGenero", idParam).ToList();
                return "OK";
            }
            catch (SqlException sqlExcepcion)
            {
                /* if(sqlExcepcion.ErrorCode == 21) {
                     return "Eror de conexion";
                 }else if*/
                return "Error en Base de datos: " + sqlExcepcion.Message;
            }
            catch (Exception ex)
            {
                return "Error general: " + ex.Message;
            }
        }

        public String Actualizar (String nombreGenero)
        {
            try
            {
                MusicModel modelo = new MusicModel();
                SqlParameter idParam = new SqlParameter
                {
                    ParameterName = "@nombreGenero",
                    Value = nombreGenero
                };
                modelo.Database.SqlQuery<List<string>>("exec Spr_InsertarGenero @nombreGenero", idParam).ToList();
                return "OK";
            }
            catch (SqlException sqlExcepcion)
            {
                /* if(sqlExcepcion.ErrorCode == 21) {
                     return "Eror de conexion";
                 }else if*/
                return "Error en Base de datos: " + sqlExcepcion.Message;
            }
            catch (Exception ex)
            {
                return "Error general: " + ex.Message;
            }
        }
    }
}