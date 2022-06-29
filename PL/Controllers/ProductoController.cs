using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class ProductoController : Controller
    {
       
            [HttpGet]
            
            public ActionResult GetAll()
            {
                BL.Producto producto = new BL.Producto();
                BL.Producto.Result result = BL.Producto.GetAll(producto);

                
                producto.Productos = result.Objects;
                return View(producto);
            }

            [HttpGet]
            public ActionResult Form(int? IdProducto)
            {
                BL.Producto producto = new BL.Producto();
                if (IdProducto == null)
                {

                    return View(producto);
                }
                else
                {
                    BL.Producto.Result result = new BL.Producto.Result();
                    result = BL.Producto.GetById(IdProducto.Value);
                    if (result.Correct)
                    {
                        producto = ((BL.Producto)result.Object);
                        return View(producto);
                    }

                }
                return View();
            }
        public byte[] ConvertToBytes(HttpPostedFileBase Imagen)
        {
            byte[] data = null;
            System.IO.BinaryReader reader = new System.IO.BinaryReader(Imagen.InputStream);
            data = reader.ReadBytes((int)Imagen.ContentLength);

            return data;
        }

        [HttpPost]
            public ActionResult Form(BL.Producto producto)
            {
                BL.Producto.Result result = new BL.Producto.Result();

            HttpPostedFileBase file = Request.Files["ImagenData"];

            if (file.ContentLength > 0)
            {
                producto.Imagen = ConvertToBytes(file);
            }


            if (producto.IdProducto == null)
                {
                    result = BL.Producto.Add(producto);
                    if (result.Correct)
                    {
                        ViewBag.Message = " Se ha agregado el producto a la base de datos";

                    }
                    else
                    {
                        ViewBag.Message = "No se ha agregado a la Base de datos" + result.ErrorMessage;
                    }
                }

                else
                {
                    result = BL.Producto.Update(producto);
                    if (result.Correct)
                    {
                        ViewBag.Message = " Se ha actualizado el producto a la base de datos";

                    }
                    else
                    {
                        ViewBag.Message = "No se ha actualizado el producto" + result.ErrorMessage;
                    }
                }
                return PartialView("Modal");
            }

            [HttpGet]

            public ActionResult Delete(int IdProducto)
            {
                BL.Producto.Result result = new BL.Producto.Result();
                if (IdProducto != 0)
                {
                    result = BL.Producto.Delete(IdProducto);
                }
                if (result.Correct)
                {
                    ViewBag.Message = "Se ha eliminado el producto en la base de datos";
                }
                else
                {
                    ViewBag.Message = "No se ha podido Eliminar el producto en la base de datos" + result.ErrorMessage;
                }
                return PartialView("Modal");
            }
        }
}