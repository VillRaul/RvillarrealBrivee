using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class SucursalProductoController : Controller
    {
        
        public ActionResult GetAll()
        {
            BL.SucursalProducto SucursalProducto = new BL.SucursalProducto();
            BL.Result result = BL.SucursalProducto.GetAll();

           
            SucursalProducto.SucursalProductos = result.Objects;

            return View(SucursalProducto);
        }

        public ActionResult ProductosAsignados(int IdSucursal)
        {
            BL.Result result = new BL.Result();
            BL.SucursalProducto sucursalProducto = new BL.SucursalProducto();
            result = BL.SucursalProducto.ProductosAsignados(IdSucursal);
            BL.Producto.Result result1 = BL.Sucursal.GetById(IdSucursal);
            sucursalProducto.SucursalProductos = result.Objects;
            sucursalProducto.Sucursal = ((BL.Sucursal)result1.Object);
            return View(sucursalProducto);
        }
    }
}