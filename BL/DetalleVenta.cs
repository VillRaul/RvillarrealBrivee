using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class DetalleVenta
    {
        public int IdDetalleVenta { get; set; }
        public BL.Sucursal Sucursal { get; set; }
        public int Cantidad { get; set; }
        public BL.Producto Producto { get; set; }
        public List<object> detaleVentas { get; set; }

        public static BL.Result Add(BL.DetalleVenta detalleVenta)
        {
            BL.Result result = new BL.Result();

            try
            {
                using (DL.RVillarrealExamenBriveEntities context = new DL.RVillarrealExamenBriveEntities())
                {
                    var resultQuery = context.DetalleVentaAdd(detalleVenta.Sucursal.IdSucursal, detalleVenta.Producto.IdProducto ,detalleVenta.Cantidad);


                    if (resultQuery >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        
                    }

                    result.Correct = true;

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public static Result DetalleVentaG(int IdDetalleVenta)
        {
            BL.Result result = new BL.Result();
            try
            {
                using (DL.RVillarrealExamenBriveEntities context = new DL.RVillarrealExamenBriveEntities())
                {
                    var query = context.DetalleVentaGetByID(IdDetalleVenta).ToList();
                    result.Objects = new List<object>();

                    if (query != null)
                    {

                        foreach (var obj in query)
                        {

                            BL.DetalleVenta detalleVenta = new BL.DetalleVenta();

                            detalleVenta.IdDetalleVenta = obj.IdDetalleventa;
                         
                            detalleVenta.Cantidad = obj.Cantidad.Value;
                            detalleVenta.Producto = new BL.Producto();
                            detalleVenta.Producto.IdProducto = obj.IdProducto;
                            detalleVenta.Producto.Nombre = obj.Nombre;
                            detalleVenta.Producto.Precio = obj.Precio.Value;
                            detalleVenta.Producto.Descripcion = obj.Descripcion;
                            detalleVenta.Producto.Imagen = obj.Imagen;
                            
                            result.Objects.Add(detalleVenta);

                        }
                        result.Correct = true;
                    }

                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No existen registros en la tabla Venta";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }

    }
}
