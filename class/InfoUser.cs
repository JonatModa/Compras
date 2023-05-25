using Compras.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace Compras.@class
{
    public class InfoUser
    {
        
        public static Registro_Usuario Info(string IDClave)
        {
            Context db = new Context(); //llamando el contexto de las tablas registradas 
            Registro_Usuario InfoRetur = new Registro_Usuario();
            Registro_Usuario infoquery;

            int IDclave = Convert.ToInt32(IDClave);

            var Usuario = (from User in db.Registro_Usuario
                           where User.idUsuario == IDclave
                           select new
                           {
                               ID = User.idUsuario,
                               Nombre = User.Nombre + " " + User.Apellidos,
                               Foto = User.foto,
                               Correo = User.Correo,
                               Telefono = User.Telefono,
                               Contraseña = User.Contraseña
                           }).ToList();
            infoquery = new Registro_Usuario
            {
               Nombre = Usuario.Select(P => P.Nombre).FirstOrDefault(),
               foto = Usuario.Select(P => P.Foto).FirstOrDefault(),
               idUsuario = Usuario.Select(p => p.ID).FirstOrDefault(),
               Correo = Usuario.Select(p => p.Correo).FirstOrDefault(),
               Telefono = Usuario.Select(p => p.Telefono).FirstOrDefault(),
               Contraseña = Usuario.Select(p => p.Contraseña).FirstOrDefault(),

            };
            InfoRetur = infoquery;
            return InfoRetur;
        }
    }
}