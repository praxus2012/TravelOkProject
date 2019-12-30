﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CapaDatos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class TravelOKViajesEntities : DbContext
    {
        public TravelOKViajesEntities()
            : base("name=TravelOKViajesEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TO_Blog> TO_Blog { get; set; }
        public virtual DbSet<TO_Destino> TO_Destino { get; set; }
        public virtual DbSet<TO_DetalleDestinos> TO_DetalleDestinos { get; set; }
        public virtual DbSet<TO_Experiencias> TO_Experiencias { get; set; }
        public virtual DbSet<TO_Habitaciones> TO_Habitaciones { get; set; }
        public virtual DbSet<TO_Salida> TO_Salida { get; set; }
        public virtual DbSet<TO_Usuario> TO_Usuario { get; set; }
        public virtual DbSet<TO_Viajes> TO_Viajes { get; set; }
        public virtual DbSet<TOA_Usuario> TOA_Usuario { get; set; }
        public virtual DbSet<TO_Costo> TO_Costo { get; set; }
    
        public virtual int spdEliminaCosto(Nullable<int> nvSalida, Nullable<int> nvDestino, Nullable<int> nvHabitacion)
        {
            var nvSalidaParameter = nvSalida.HasValue ?
                new ObjectParameter("nvSalida", nvSalida) :
                new ObjectParameter("nvSalida", typeof(int));
    
            var nvDestinoParameter = nvDestino.HasValue ?
                new ObjectParameter("nvDestino", nvDestino) :
                new ObjectParameter("nvDestino", typeof(int));
    
            var nvHabitacionParameter = nvHabitacion.HasValue ?
                new ObjectParameter("nvHabitacion", nvHabitacion) :
                new ObjectParameter("nvHabitacion", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spdEliminaCosto", nvSalidaParameter, nvDestinoParameter, nvHabitacionParameter);
        }
    
        public virtual int spdEliminaDestinoId(Nullable<int> idDestino)
        {
            var idDestinoParameter = idDestino.HasValue ?
                new ObjectParameter("idDestino", idDestino) :
                new ObjectParameter("idDestino", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spdEliminaDestinoId", idDestinoParameter);
        }
    
        public virtual int spdEliminaSalida(string nvSalida)
        {
            var nvSalidaParameter = nvSalida != null ?
                new ObjectParameter("nvSalida", nvSalida) :
                new ObjectParameter("nvSalida", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spdEliminaSalida", nvSalidaParameter);
        }
    
        public virtual int spdEliminaSalidaId(Nullable<int> idSalida)
        {
            var idSalidaParameter = idSalida.HasValue ?
                new ObjectParameter("idSalida", idSalida) :
                new ObjectParameter("idSalida", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spdEliminaSalidaId", idSalidaParameter);
        }
    
        public virtual int spiAgregaBlog(string nvTitulo, string nvTexto, byte[] imgBlog)
        {
            var nvTituloParameter = nvTitulo != null ?
                new ObjectParameter("nvTitulo", nvTitulo) :
                new ObjectParameter("nvTitulo", typeof(string));
    
            var nvTextoParameter = nvTexto != null ?
                new ObjectParameter("nvTexto", nvTexto) :
                new ObjectParameter("nvTexto", typeof(string));
    
            var imgBlogParameter = imgBlog != null ?
                new ObjectParameter("imgBlog", imgBlog) :
                new ObjectParameter("imgBlog", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spiAgregaBlog", nvTituloParameter, nvTextoParameter, imgBlogParameter);
        }
    
        public virtual int spiAgregaImDestinosC(Nullable<int> id_Destino, string nvRutaArchivo, string nvDescripcion)
        {
            var id_DestinoParameter = id_Destino.HasValue ?
                new ObjectParameter("Id_Destino", id_Destino) :
                new ObjectParameter("Id_Destino", typeof(int));
    
            var nvRutaArchivoParameter = nvRutaArchivo != null ?
                new ObjectParameter("nvRutaArchivo", nvRutaArchivo) :
                new ObjectParameter("nvRutaArchivo", typeof(string));
    
            var nvDescripcionParameter = nvDescripcion != null ?
                new ObjectParameter("nvDescripcion", nvDescripcion) :
                new ObjectParameter("nvDescripcion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spiAgregaImDestinosC", id_DestinoParameter, nvRutaArchivoParameter, nvDescripcionParameter);
        }
    
        public virtual int spiInsertaCosto(Nullable<decimal> moCosto, Nullable<int> inDestino, Nullable<int> inSalida, Nullable<int> inHabitac, string nvTipoPer)
        {
            var moCostoParameter = moCosto.HasValue ?
                new ObjectParameter("moCosto", moCosto) :
                new ObjectParameter("moCosto", typeof(decimal));
    
            var inDestinoParameter = inDestino.HasValue ?
                new ObjectParameter("inDestino", inDestino) :
                new ObjectParameter("inDestino", typeof(int));
    
            var inSalidaParameter = inSalida.HasValue ?
                new ObjectParameter("inSalida", inSalida) :
                new ObjectParameter("inSalida", typeof(int));
    
            var inHabitacParameter = inHabitac.HasValue ?
                new ObjectParameter("inHabitac", inHabitac) :
                new ObjectParameter("inHabitac", typeof(int));
    
            var nvTipoPerParameter = nvTipoPer != null ?
                new ObjectParameter("nvTipoPer", nvTipoPer) :
                new ObjectParameter("nvTipoPer", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spiInsertaCosto", moCostoParameter, inDestinoParameter, inSalidaParameter, inHabitacParameter, nvTipoPerParameter);
        }
    
        public virtual int spiInsertaDestino(string nvDestino, string nvTitulo, string nvSubt, string nvDesc, Nullable<bool> bPrincipal)
        {
            var nvDestinoParameter = nvDestino != null ?
                new ObjectParameter("nvDestino", nvDestino) :
                new ObjectParameter("nvDestino", typeof(string));
    
            var nvTituloParameter = nvTitulo != null ?
                new ObjectParameter("nvTitulo", nvTitulo) :
                new ObjectParameter("nvTitulo", typeof(string));
    
            var nvSubtParameter = nvSubt != null ?
                new ObjectParameter("nvSubt", nvSubt) :
                new ObjectParameter("nvSubt", typeof(string));
    
            var nvDescParameter = nvDesc != null ?
                new ObjectParameter("nvDesc", nvDesc) :
                new ObjectParameter("nvDesc", typeof(string));
    
            var bPrincipalParameter = bPrincipal.HasValue ?
                new ObjectParameter("bPrincipal", bPrincipal) :
                new ObjectParameter("bPrincipal", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spiInsertaDestino", nvDestinoParameter, nvTituloParameter, nvSubtParameter, nvDescParameter, bPrincipalParameter);
        }
    
        public virtual int spiInsertaDetalleDestino(Nullable<int> idDestino, string nvRuta, string nvDescripción, Nullable<bool> bActivo)
        {
            var idDestinoParameter = idDestino.HasValue ?
                new ObjectParameter("idDestino", idDestino) :
                new ObjectParameter("idDestino", typeof(int));
    
            var nvRutaParameter = nvRuta != null ?
                new ObjectParameter("nvRuta", nvRuta) :
                new ObjectParameter("nvRuta", typeof(string));
    
            var nvDescripciónParameter = nvDescripción != null ?
                new ObjectParameter("nvDescripción", nvDescripción) :
                new ObjectParameter("nvDescripción", typeof(string));
    
            var bActivoParameter = bActivo.HasValue ?
                new ObjectParameter("bActivo", bActivo) :
                new ObjectParameter("bActivo", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spiInsertaDetalleDestino", idDestinoParameter, nvRutaParameter, nvDescripciónParameter, bActivoParameter);
        }
    
        public virtual int spiInsertaSalida(string nvSalida)
        {
            var nvSalidaParameter = nvSalida != null ?
                new ObjectParameter("nvSalida", nvSalida) :
                new ObjectParameter("nvSalida", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spiInsertaSalida", nvSalidaParameter);
        }
    
        public virtual int spInsertaComunidad(string nombre, string testimonio, Nullable<int> idViaje, Nullable<decimal> calificacion, byte[] imgDestino)
        {
            var nombreParameter = nombre != null ?
                new ObjectParameter("Nombre", nombre) :
                new ObjectParameter("Nombre", typeof(string));
    
            var testimonioParameter = testimonio != null ?
                new ObjectParameter("Testimonio", testimonio) :
                new ObjectParameter("Testimonio", typeof(string));
    
            var idViajeParameter = idViaje.HasValue ?
                new ObjectParameter("IdViaje", idViaje) :
                new ObjectParameter("IdViaje", typeof(int));
    
            var calificacionParameter = calificacion.HasValue ?
                new ObjectParameter("Calificacion", calificacion) :
                new ObjectParameter("Calificacion", typeof(decimal));
    
            var imgDestinoParameter = imgDestino != null ?
                new ObjectParameter("ImgDestino", imgDestino) :
                new ObjectParameter("ImgDestino", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("spInsertaComunidad", nombreParameter, testimonioParameter, idViajeParameter, calificacionParameter, imgDestinoParameter);
        }
    
        public virtual ObjectResult<spObtieneComunidad_Result> spObtieneComunidad()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spObtieneComunidad_Result>("spObtieneComunidad");
        }
    
        public virtual ObjectResult<spsObHabitacCostos_Result> spsObHabitacCostos(Nullable<int> idSalida, Nullable<int> idDestino)
        {
            var idSalidaParameter = idSalida.HasValue ?
                new ObjectParameter("IdSalida", idSalida) :
                new ObjectParameter("IdSalida", typeof(int));
    
            var idDestinoParameter = idDestino.HasValue ?
                new ObjectParameter("IdDestino", idDestino) :
                new ObjectParameter("IdDestino", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spsObHabitacCostos_Result>("spsObHabitacCostos", idSalidaParameter, idDestinoParameter);
        }
    
        public virtual ObjectResult<spsObtFechaViajes_Result> spsObtFechaViajes(Nullable<int> idSalida, Nullable<int> idDestino)
        {
            var idSalidaParameter = idSalida.HasValue ?
                new ObjectParameter("IdSalida", idSalida) :
                new ObjectParameter("IdSalida", typeof(int));
    
            var idDestinoParameter = idDestino.HasValue ?
                new ObjectParameter("IdDestino", idDestino) :
                new ObjectParameter("IdDestino", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spsObtFechaViajes_Result>("spsObtFechaViajes", idSalidaParameter, idDestinoParameter);
        }
    
        public virtual ObjectResult<spsObtieneCarrusel_Result> spsObtieneCarrusel(Nullable<int> id_Destino)
        {
            var id_DestinoParameter = id_Destino.HasValue ?
                new ObjectParameter("Id_Destino", id_Destino) :
                new ObjectParameter("Id_Destino", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spsObtieneCarrusel_Result>("spsObtieneCarrusel", id_DestinoParameter);
        }
    
        public virtual ObjectResult<spsObtieneDestinoDet_Result> spsObtieneDestinoDet(Nullable<int> idViaje)
        {
            var idViajeParameter = idViaje.HasValue ?
                new ObjectParameter("idViaje", idViaje) :
                new ObjectParameter("idViaje", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spsObtieneDestinoDet_Result>("spsObtieneDestinoDet", idViajeParameter);
        }
    
        public virtual ObjectResult<spsObtieneDestinosDet_Result> spsObtieneDestinosDet()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spsObtieneDestinosDet_Result>("spsObtieneDestinosDet");
        }
    
        public virtual ObjectResult<spsObtieneDestinosImg_Result> spsObtieneDestinosImg()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spsObtieneDestinosImg_Result>("spsObtieneDestinosImg");
        }
    
        public virtual ObjectResult<spsObtieneHabitaciones_Result> spsObtieneHabitaciones()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spsObtieneHabitaciones_Result>("spsObtieneHabitaciones");
        }
    
        public virtual ObjectResult<spsObtLugarDestinoViajes_Result> spsObtLugarDestinoViajes(Nullable<int> idSalida)
        {
            var idSalidaParameter = idSalida.HasValue ?
                new ObjectParameter("IdSalida", idSalida) :
                new ObjectParameter("IdSalida", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spsObtLugarDestinoViajes_Result>("spsObtLugarDestinoViajes", idSalidaParameter);
        }
    
        public virtual ObjectResult<spsObtLugarSalidaViajes_Result> spsObtLugarSalidaViajes()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spsObtLugarSalidaViajes_Result>("spsObtLugarSalidaViajes");
        }
    
        public virtual ObjectResult<spsObtLugarSalViajesDest_Result> spsObtLugarSalViajesDest(Nullable<int> idDestino)
        {
            var idDestinoParameter = idDestino.HasValue ?
                new ObjectParameter("IdDestino", idDestino) :
                new ObjectParameter("IdDestino", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spsObtLugarSalViajesDest_Result>("spsObtLugarSalViajesDest", idDestinoParameter);
        }
    
        public virtual ObjectResult<spVerificaUsuario_Result> spVerificaUsuario(string nvUsu, string nvCont)
        {
            var nvUsuParameter = nvUsu != null ?
                new ObjectParameter("nvUsu", nvUsu) :
                new ObjectParameter("nvUsu", typeof(string));
    
            var nvContParameter = nvCont != null ?
                new ObjectParameter("nvCont", nvCont) :
                new ObjectParameter("nvCont", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<spVerificaUsuario_Result>("spVerificaUsuario", nvUsuParameter, nvContParameter);
        }
    }
}
