using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaModelo
{
    public class cmBlog
    {
        public int idBlog { get; set; }
        public string sTitulo { get; set; }
        public string sNombre { get; set; }
        public string sTexto { get; set; }
        public string sImgBlog { get; set; }
        public DateTime? dtFechaSubida { get; set; }
        public int? iActivo { get; set; }
        public string fechaConvertida { get; set; }

    }
}
