using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{  
    public class Producto
    {
        public int? IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public byte[] Imagen { get; set; }
        public int Stock { get; set; }
        public string CodigoBarras { get; set; }
        public List<object> Productos { get; set; }

        public class Result
        {
            public bool Correct { get; set; }
            public string ErrorMessage { get; set; }
            public object Object { get; set; }
            public List<object> Objects { get; set; }
            public Exception Ex { get; set; }

        }
        public static Result Add(Producto producto)
        {
            Result result = new Result();
            try
            {
                using (DL.RVillarrealExamenBriveEntities context = new DL.RVillarrealExamenBriveEntities())
                {
                    var query = context.ProductoAdd(producto.Nombre, producto.Descripcion, producto.Precio, producto.Imagen, producto.Stock, producto.CodigoBarras);
                    if (query > 0)
                    {
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

        public static Result GetAll(Producto producto)
        {
            Result result = new Result();
            try
            {
                using (DL.RVillarrealExamenBriveEntities context = new DL.RVillarrealExamenBriveEntities())
                {
                    var query = context.ProductoGetall().ToList();
                    result.Objects = new List<object>();
                    if (query != null)
                    {
                        foreach (var obj in query)
                        {
                            producto = new Producto();
                            producto.IdProducto = obj.IdProducto;
                            producto.Nombre = obj.Nombre;
                            producto.Descripcion = obj.Descripcion;
                            producto.Precio = obj.Precio.Value;
                            producto.Imagen = obj.Imagen;
                            producto.Stock = obj.Stock.Value;
                            producto.CodigoBarras = obj.CodigoBarras;
                            result.Objects.Add(producto);
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

        public static Result Delete(int IdProducto)
        {
            Result result = new Result();
            try
            {
                using (DL.RVillarrealExamenBriveEntities context = new DL.RVillarrealExamenBriveEntities())
                {
                    var query = context.ProductoDelete(IdProducto);
                    if (query >= 1)
                    {
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

        public static Result GetById(int IdProducto)
        {
            Result result = new Result();
            try
            {
                using (DL.RVillarrealExamenBriveEntities context = new DL.RVillarrealExamenBriveEntities())
                {
                    var query = context.ProductoGetById(IdProducto).FirstOrDefault();
                    

                    if (query != null)
                    {
                        Producto producto = new Producto();
                        producto.IdProducto = query.IdProducto;
                        producto.Nombre = query.Nombre;
                        producto.Descripcion = query.Descripcion;
                        producto.Precio = query.Precio.Value;
                        producto.Imagen = query.Imagen;
                        producto.Stock = query.Stock.Value;
                        producto.CodigoBarras = query.CodigoBarras;
                        result.Object = producto;

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

        public static Result Update(Producto producto)
        {
            Result result = new Result();
            try
            {
                using (DL.RVillarrealExamenBriveEntities context = new DL.RVillarrealExamenBriveEntities())
                {
                    var query = context.ProductoUpdate(producto.IdProducto, producto.Nombre, producto.Descripcion, producto.Precio, producto.Imagen, producto.Stock, producto.CodigoBarras);
                    if (query >= 1)
                    {
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
