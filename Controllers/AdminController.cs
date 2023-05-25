using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Compras.Models;

namespace Compras.Controllers
{
    public class AdminController : Controller
    {
        private Context db = new Context();
       

        // GET: Admin
        public ActionResult Index()
        {
            
            return View(db.Registro_Usuario.ToList());
        }

        // GET: Admin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registro_Usuario registro_Usuario = db.Registro_Usuario.Find(id);
            if (registro_Usuario == null)
            {
                return HttpNotFound();
            }
            return View(registro_Usuario);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idUsuario,idCarrito,Nombre,Apellidos,Correo,Telefono,Direccion,Contraseña,fecha,foto,Tipo_User")] Registro_Usuario registro_Usuario)
        {
            if (ModelState.IsValid)
            {
                db.Registro_Usuario.Add(registro_Usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(registro_Usuario);
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registro_Usuario registro_Usuario = db.Registro_Usuario.Find(id);
            if (registro_Usuario == null)
            {
                return HttpNotFound();
            }
            return View(registro_Usuario);
        }

        // POST: Admin/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idUsuario,idCarrito,Nombre,Apellidos,Correo,Telefono,Direccion,Contraseña,fecha,foto,Tipo_User")] Registro_Usuario registro_Usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registro_Usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(registro_Usuario);
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registro_Usuario registro_Usuario = db.Registro_Usuario.Find(id);
            if (registro_Usuario == null)
            {
                return HttpNotFound();
            }
            return View(registro_Usuario);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Registro_Usuario registro_Usuario = db.Registro_Usuario.Find(id);
            db.Registro_Usuario.Remove(registro_Usuario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
