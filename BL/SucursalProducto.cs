using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class SucursalProducto
    {
        public int IdSucursalProducto { get; set; }
        public BL.Producto Producto { get; set; }
        public BL.Sucursal Sucursal { get; set; }
        public List<object> SucursalProductos { get; set; }

        public static BL.Result GetAll()
        {
            BL.Result result = new BL.Result();
            try
            {
                using (DL.RVillarrealExamenBriveEntities context = new DL.RVillarrealExamenBriveEntities())
                {
                    var query = context.SucursalProductoGetAll().ToList();
                    result.Objects = new List<object>();
                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            SucursalProducto  sucursalProducto = new SucursalProducto();
                            sucursalProducto.IdSucursalProducto = obj.IdSucursalProducto;
                            sucursalProducto.Sucursal = new Sucursal();
                            sucursalProducto.Sucursal.IdSucursal = obj.IdSucursal.Value;
                            sucursalProducto.Sucursal.Nombre = obj.NombreSucursal;
                            
                            result.Objects.Add(sucursalProducto);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }

                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Correct = false;
            }
            return result;
        }

        public static BL.Result ProductosAsignados(int IdSucursal)
        {
            BL.Result result = new BL.Result();
            try
            {
                using (DL.RVillarrealExamenBriveEntities context = new DL.RVillarrealExamenBriveEntities())
                {
                    var query = context.ProductosAsignados(IdSucursal).ToList();
                    result.Objects = new List<object>();
                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            BL.SucursalProducto sucursalProducto = new SucursalProducto();
                            sucursalProducto.Producto = new BL.Producto();
                            sucursalProducto.Producto.IdProducto = obj.IdProducto;
                            sucursalProducto.Producto.Nombre = obj.ProductoNombre;
                            sucursalProducto.Producto.Descripcion = obj.Descripcion;
                            sucursalProducto.Producto.Precio = obj.Precio.Value;
                            sucursalProducto.Producto.Imagen = obj.Imagen;
                            result.Objects.Add(sucursalProducto);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }

                }
            }
            catch (Exception ex)
            {
                result.ErrorMessage = ex.Message;
                result.Correct = false;
            }
            return result;


        }
    }
}
