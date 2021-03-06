//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class RVillarrealExamenBriveEntities : DbContext
    {
        public RVillarrealExamenBriveEntities()
            : base("name=RVillarrealExamenBriveEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<DetalleVenta> DetalleVentas { get; set; }
        public virtual DbSet<MetodoPago> MetodoPagoes { get; set; }
        public virtual DbSet<Producto> Productoes { get; set; }
        public virtual DbSet<Sucursal> Sucursals { get; set; }
        public virtual DbSet<SucursalProducto> SucursalProductoes { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Venta> Ventas { get; set; }
    
        public virtual int DetalleVentaAdd(Nullable<int> idSucursal, Nullable<int> idProducto, Nullable<int> cantidad)
        {
            var idSucursalParameter = idSucursal.HasValue ?
                new ObjectParameter("IdSucursal", idSucursal) :
                new ObjectParameter("IdSucursal", typeof(int));
    
            var idProductoParameter = idProducto.HasValue ?
                new ObjectParameter("IdProducto", idProducto) :
                new ObjectParameter("IdProducto", typeof(int));
    
            var cantidadParameter = cantidad.HasValue ?
                new ObjectParameter("Cantidad", cantidad) :
                new ObjectParameter("Cantidad", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("DetalleVentaAdd", idSucursalParameter, idProductoParameter, cantidadParameter);
        }
    
        public virtual int ProductoAdd(string nombre, string descripcion, Nullable<decimal> precio, byte[] imagen, Nullable<int> stock, string codigoBarras)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var precioParameter = precio.HasValue ?
                new ObjectParameter("Precio", precio) :
                new ObjectParameter("Precio", typeof(decimal));
    
            var imagenParameter = imagen != null ?
                new ObjectParameter("Imagen", imagen) :
                new ObjectParameter("Imagen", typeof(byte[]));
    
            var stockParameter = stock.HasValue ?
                new ObjectParameter("Stock", stock) :
                new ObjectParameter("Stock", typeof(int));
    
            var codigoBarrasParameter = codigoBarras != null ?
                new ObjectParameter("CodigoBarras", codigoBarras) :
                new ObjectParameter("CodigoBarras", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProductoAdd", nombreParameter, descripcionParameter, precioParameter, imagenParameter, stockParameter, codigoBarrasParameter);
        }
    
        public virtual int ProductoDelete(Nullable<int> idProducto)
        {
            var idProductoParameter = idProducto.HasValue ?
                new ObjectParameter("IdProducto", idProducto) :
                new ObjectParameter("IdProducto", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProductoDelete", idProductoParameter);
        }
    
        public virtual int ProductoUpdate(Nullable<int> idProducto, string nombre, string descripcion, Nullable<decimal> precio, byte[] imagen, Nullable<int> stock, string codigoBarras)
        {
            var idProductoParameter = idProducto.HasValue ?
                new ObjectParameter("IdProducto", idProducto) :
                new ObjectParameter("IdProducto", typeof(int));
    
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            var precioParameter = precio.HasValue ?
                new ObjectParameter("Precio", precio) :
                new ObjectParameter("Precio", typeof(decimal));
    
            var imagenParameter = imagen != null ?
                new ObjectParameter("Imagen", imagen) :
                new ObjectParameter("Imagen", typeof(byte[]));
    
            var stockParameter = stock.HasValue ?
                new ObjectParameter("Stock", stock) :
                new ObjectParameter("Stock", typeof(int));
    
            var codigoBarrasParameter = codigoBarras != null ?
                new ObjectParameter("CodigoBarras", codigoBarras) :
                new ObjectParameter("CodigoBarras", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ProductoUpdate", idProductoParameter, nombreParameter, descripcionParameter, precioParameter, imagenParameter, stockParameter, codigoBarrasParameter);
        }
    
        public virtual ObjectResult<SucursalGetAll_Result> SucursalGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SucursalGetAll_Result>("SucursalGetAll");
        }
    
        public virtual ObjectResult<SucursalProductoGetAll_Result> SucursalProductoGetAll()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SucursalProductoGetAll_Result>("SucursalProductoGetAll");
        }
    
        public virtual ObjectResult<SucursalProductoGetById_Result> SucursalProductoGetById(Nullable<int> idSucursalProducto)
        {
            var idSucursalProductoParameter = idSucursalProducto.HasValue ?
                new ObjectParameter("IdSucursalProducto", idSucursalProducto) :
                new ObjectParameter("IdSucursalProducto", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SucursalProductoGetById_Result>("SucursalProductoGetById", idSucursalProductoParameter);
        }
    
        public virtual int VentaAdd(Nullable<int> idUsuario, Nullable<decimal> total, Nullable<int> idMetodoPago, string fechaVenta)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            var totalParameter = total.HasValue ?
                new ObjectParameter("Total", total) :
                new ObjectParameter("Total", typeof(decimal));
    
            var idMetodoPagoParameter = idMetodoPago.HasValue ?
                new ObjectParameter("IdMetodoPago", idMetodoPago) :
                new ObjectParameter("IdMetodoPago", typeof(int));
    
            var fechaVentaParameter = fechaVenta != null ?
                new ObjectParameter("FechaVenta", fechaVenta) :
                new ObjectParameter("FechaVenta", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("VentaAdd", idUsuarioParameter, totalParameter, idMetodoPagoParameter, fechaVentaParameter);
        }
    
        public virtual int SucursalAdd(string nombre, string direccion, string telefono)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var direccionParameter = direccion != null ?
                new ObjectParameter("Direccion", direccion) :
                new ObjectParameter("Direccion", typeof(string));
    
            var telefonoParameter = telefono != null ?
                new ObjectParameter("Telefono", telefono) :
                new ObjectParameter("Telefono", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SucursalAdd", nombreParameter, direccionParameter, telefonoParameter);
        }
    
        public virtual int SucursalProductoAdd(Nullable<int> idSucursal, Nullable<int> idProducto)
        {
            var idSucursalParameter = idSucursal.HasValue ?
                new ObjectParameter("IdSucursal", idSucursal) :
                new ObjectParameter("IdSucursal", typeof(int));
    
            var idProductoParameter = idProducto.HasValue ?
                new ObjectParameter("IdProducto", idProducto) :
                new ObjectParameter("IdProducto", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("SucursalProductoAdd", idSucursalParameter, idProductoParameter);
        }
    
        public virtual ObjectResult<ProductoGetall_Result> ProductoGetall()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ProductoGetall_Result>("ProductoGetall");
        }
    
        public virtual ObjectResult<ProductoGetById_Result> ProductoGetById(Nullable<int> idProducto)
        {
            var idProductoParameter = idProducto.HasValue ?
                new ObjectParameter("IdProducto", idProducto) :
                new ObjectParameter("IdProducto", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ProductoGetById_Result>("ProductoGetById", idProductoParameter);
        }
    
        public virtual ObjectResult<SucursalGetByProducto_Result> SucursalGetByProducto(Nullable<int> idProdcuto)
        {
            var idProdcutoParameter = idProdcuto.HasValue ?
                new ObjectParameter("IdProdcuto", idProdcuto) :
                new ObjectParameter("IdProdcuto", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SucursalGetByProducto_Result>("SucursalGetByProducto", idProdcutoParameter);
        }
    
        public virtual ObjectResult<ProductosAsignados_Result> ProductosAsignados(Nullable<int> idSucursal)
        {
            var idSucursalParameter = idSucursal.HasValue ?
                new ObjectParameter("IdSucursal", idSucursal) :
                new ObjectParameter("IdSucursal", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ProductosAsignados_Result>("ProductosAsignados", idSucursalParameter);
        }
    
        public virtual ObjectResult<SucursalGetById_Result> SucursalGetById(Nullable<int> idSucursal)
        {
            var idSucursalParameter = idSucursal.HasValue ?
                new ObjectParameter("IdSucursal", idSucursal) :
                new ObjectParameter("IdSucursal", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SucursalGetById_Result>("SucursalGetById", idSucursalParameter);
        }
    
        public virtual ObjectResult<DetalleVentaGetByID_Result> DetalleVentaGetByID(Nullable<int> idDetalleVenta)
        {
            var idDetalleVentaParameter = idDetalleVenta.HasValue ?
                new ObjectParameter("IdDetalleVenta", idDetalleVenta) :
                new ObjectParameter("IdDetalleVenta", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<DetalleVentaGetByID_Result>("DetalleVentaGetByID", idDetalleVentaParameter);
        }
    }
}
