using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Sucursal
    { 
            public int IdSucursal { get; set; }
            public string Nombre { get; set; }
            public string Direccion { get; set; }
            public string Telefono { get; set; }

        public static BL.Producto.Result GetById(int IdSucursal)
        {
            BL.Producto.Result result = new BL.Producto.Result();
            try
            {
                using (DL.RVillarrealExamenBriveEntities context = new DL.RVillarrealExamenBriveEntities())
                {
                    var query = context.SucursalGetById(IdSucursal).FirstOrDefault();


                    if (query != null)
                    {
                        BL.Sucursal sucursal = new Sucursal();
                        sucursal.IdSucursal = query.IdSucursal;
                        sucursal.Nombre = query.Nombre;
                        sucursal.Direccion = query.Direccion;
                        sucursal.Telefono = query.Telefono;
                        result.Object = sucursal;

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
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }

}
