using CapaModelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Blog
    {
        public List<cmBlog> lsObtenerListaBlog()
        {
            List<cmBlog> publicaciones = new List<cmBlog>();
            using (var contexto = new TravelOKEntitiesQA())
            {
                publicaciones = contexto.TO_Blog.Select(
                    pub => new cmBlog()
                    {
                        idBlog = pub.idBlog,
                        sTitulo = pub.nvTitulo,
                        sNombre = pub.nvTitulo,
                        sTexto = pub.nvTexto,
                        sImgBlog = pub.imgBlog,
                        iActivo = pub.Activo
                    }
                    ).ToList();
            }
            return publicaciones;
        }


        public cmBlog cmObtenerPublicacion(int idABuscar)
        {
            cmBlog publicacion = null;

           // ProductoModel pro = null;

            using (var contexto = new TravelOKEntitiesQA())
            {

                int iExiste = contexto.TO_Blog.Where(p => p.idBlog == idABuscar).Count();

                var pub = contexto.TO_Blog.FirstOrDefault(p => p.idBlog == idABuscar);
                publicacion = new cmBlog()
                {
                    idBlog = pub.idBlog,
                    sTitulo = pub.nvTitulo,
                    sNombre = pub.nvTitulo,
                    dtFechaSubida = pub.dtFechaSubida,
                    sTexto = pub.nvTexto,
                    sImgBlog = pub.imgBlog,
                    iActivo = pub.Activo,
                    fechaConvertida = pub.dtFechaSubida.ToString()
                };


            }
            return publicacion;




        }


    }
}
