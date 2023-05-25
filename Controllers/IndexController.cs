using Compras.@class;
using Compras.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace Compras.Controllers
{
    public class IndexController : Controller
    {
        // GET: Index
        private Context db = new Context(); //llamando el contexto de las tablas registradas 
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Registro()
        {
            return View();
        }
       
        public ActionResult Menu()
        {
            try
            {

            
            //string mensaje = Convert.ToString(Session["mensaje1"]);
            string mensaje = Convert.ToString(TempData["CL"]);

            if (mensaje != "")
            {

                    var Info = InfoUser.Info(mensaje); //va entrar a la clase a verificar 

               

                    if(Info.idUsuario > 0)
                    {
                        ByteArrayToImage(Info.foto);
                       // Image x = (Bitmap)((new ImageConverter()).ConvertFrom(Info.foto));
                        //mostrar imagen no queda
                        //var by = Info.foto.FirstOrDefault();
                        //MemoryStream cone =new MemoryStream(Info.foto);
                        //Image imageFrom  = Image.FromStream(cone);
                        //var I = imageFrom;
                       //var ImgCon = ByteArrayToImage(by);
                        ViewBag.Nombre = Info.Nombre;

                        return View();
                    }
                   
            }


            }
            catch 
            {
                
            }


            return RedirectToAction("Index");
        }
      
        public Image ByteArrayToImage(byte[] data)
        {//no sale 

            using (MemoryStream memstr = new MemoryStream(data))
            {
                Image img = Image.FromStream(memstr);
                return img;
            }

            //if (data == null) return null;

            //MemoryStream ms = new MemoryStream(data);
            //Bitmap bm = null;
            //try
            //{
            //    bm = new Bitmap(ms);
            //}
            //catch (Exception ex)
            //{
            //    System.Diagnostics.Debug.WriteLine(ex.Message);
            //}
            //return bm;
            //    MemoryStream ms = new MemoryStream(data);
            //Image returnImage = Image.FromStream(ms);
            //return returnImage;
        }
        [HttpPost]
        public ActionResult Registro(string UsuarioID,string password, string exampleCheck1)
        {
            try
            {
              var  Buscar_Usuario = (from User in db.Registro_Usuario
                                     where  User.Nombre == UsuarioID && User.Contraseña == password
                                     select new
                                     {
                                         id = User.idUsuario,
                                        Nombre = User.Nombre,
                                        Apellido = User.Apellidos,
                                        password = User.Contraseña,
                                        Foto = User.foto,
                                        TipO = User.Tipo_User

                                     }).ToList();
                if(Buscar_Usuario.Count > 0 )
                {

                    if(exampleCheck1 != null)
                    {

                        var Buscar_Admin = (from User in db.Registro_Usuario
                                              where User.Nombre == UsuarioID && User.Contraseña == password
                                              select new
                                              {
                                                  id = User.idUsuario,
                                                  Nombre = User.Nombre,
                                                  Apellido = User.Apellidos,
                                                  password = User.Contraseña,
                                                  Foto = User.foto,
                                                  TipO = User.Tipo_User

                                              }).ToList();
                        if(Buscar_Admin.Select(p => p.TipO).FirstOrDefault() != null )
                        {
                           // return RedirectToAction("~/Admin/Index");
                            Response.Redirect("~/Admin/Index");
                        }
                        
                       // Response.Redirect("~/Index/Admin");
                    }



                    ViewBag.Nombre = Buscar_Usuario.Select(p => p.Nombre + "  " + p.Apellido).FirstOrDefault();
                    var Id = Buscar_Usuario.Select(p => p.id).FirstOrDefault();

                    // Session["mensaje"] = "Hola mundo";
                    //Session["mensaje1"] = Id.ToString();
                    TempData["CL"] = Id.ToString();
                    //Response.Redirect("~/Menu/Index");
                    return RedirectToAction("Menu/Index");
                }
                ViewBag.Error = "No se encontro ningun Usuario Registrado";
                
            }
            catch (Exception ex)
            {

            }
            return View();
        }
        public ActionResult Formulario_Registro()
        {
            
            return View();
        }

        [HttpPost]
        //nota es importante poner a cada input el name para que post lo detecte que es lo que escribio el usuario
        public ActionResult Formulario_Registro(string NombreID, string ApellidosID, string CorreoID, string NumeroID, string DireccionID, string password, string password2, DateTime FechaNa, string imagen)
        {
            try //esto es por si llega a pasar algo inconveniente 
            {
                if(password == password2)
                {

                    var UsuarioValidar = (from User in db.Registro_Usuario
                                          where User.Nombre == NombreID
                                          select new
                                          {
                                              Nombre = User.Nombre,

                                         }).ToList();

                    if(UsuarioValidar.Count == 0)//va entrar cuando sea 0 y no encuentre ningun usuario repetido
                    {
                        byte[] byteArray = Encoding.ASCII.GetBytes(imagen);
                        //se registra todos los datos  en Registro_db
                        Registro_Usuario Registro_db = new Registro_Usuario
                        {
                            Nombre = NombreID,
                            Apellidos = ApellidosID,
                            Correo = CorreoID,
                            Telefono = NumeroID,
                            Direccion = DireccionID,
                            Contraseña = password,
                            fecha = FechaNa,
                            foto = byteArray
                        };
                        db.Registro_Usuario.Add(Registro_db);//agregamos a los campo a la tabla en la que se va a registrar
                        db.SaveChanges(); //se guarda en la base de dato 
                        Response.Redirect("~/Index/Registro");

                    }
                    ViewBag.Usuario = "El Usuario ya se encuentra Registrado";
                    
                }
                else
                {
                    ViewBag.ErrorContraseña = "ERROR";
                } 
                

            }
            catch
            {
                
            }

            //string CorreoID, string NumeroID, string DireccionID, string password, string password2, DateTime FechaNa, Image imagePreview
            return View();
        }
    }
}