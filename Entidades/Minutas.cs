using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace Entidades
{
    public class Minutas
    {
        public int IdSesion { get; set; }
        public CatTemas ObjTemas { get; set; }
        public string Objetivo { get; set; }
        public string Descripcion { get; set; }
        public DateTime? Fechafin { get; set; }
        public UsuariosDatos ObjUsuarios { get; set; }
        public DateTime Fecharegistro { get; set; }
        public bool Activo { get; set; }
        public CatTipoSesion ObjTipoSesion { get; set; }
        public DateTime? FechaConclusion { get; set; }
        public string Conclusion { get; set; }
        public CatStatus ObjStatus { get; set; }
        public int Diasentrega { get; set; }
        public string TiempoEntrega { get; set; }
        public DateTime? FechaBIni { get; set; }
        public DateTime? FechaBFin { get; set; }
        public string Tipoentrega { get; set; }
        public string LabelDias { get; set; }

    }

    public class MinutasUsuarios
    {
        public int IdSesionUser { get; set; }
        public Minutas ObjMinutas { get; set; }
        public UsuariosDatos ObjUsuarios { get; set; }
        public int IdUserMinuta { get; set; }

    }

    public class MinutasAcuerdos
    {
        public int IdAcuerdo { get; set; }
        public Minutas ObjMinutas { get; set; }
        public DateTime FechaIni { get; set; }
        public DateTime FechaFin { get; set; }
        public string Descripcion { get; set; }
        public DateTime? FechaIniReal { get; set; }
        public DateTime? FechaFinReal { get; set; }
        public UsuariosDatos ObjUserSesion { get; set; }
        public CatTipoAcuerdo ObjTipoacuerdo { get; set; }
        public int Diasentrega { get; set; }
        public string TiempoEntrega { get; set; }
        public DateTime FechaRegistro { get; set; }

        public DataTable ArrayAcuerdos { get; set; }
        public int IdUserMinuta { get; set; }

    }

    public class MinutasComentarios
    {
        public int Idcomentario { get; set; }
        public int IdSesionComent { get; set; }
        public string Comentarios { get; set; }
        public DateTime FechaRegistro { get; set; }
        public Usuarios ObjUsercoment { get; set; }
        public MinutasAcuerdos ObjMinutaAcuerdo { get; set; }
        public CatSedes ObjStatuscoment { get; set; }

    }
}
