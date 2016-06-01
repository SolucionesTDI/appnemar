using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuarios
    {
        public int IdUser { get; set; }
        public string Username { get; set; }
        public bool Activo { get; set; }
        public string Password { get; set; }
        public bool Visible { get; set; }
        public Perfiles Perfil { get; set; }
        public String FechaRegistro { get; set; }
        public int IdUserGestion { get; set; }
    }

    public class UsuariosDatos
    {
        
        public Usuarios User { get; set; }
        public int IdUser { get { return User.IdUser; } }
        public int IdUserDatos { get; set; }
        public string NombreUser { get; set; }
        public string ApellidoPat { get; set; }
        public string ApellidoMat { get; set; }
        public CatDepartamentos ObjDepto { get; set; }
        public CatPuestos ObjPuestos { get; set; }
        public CatSedes ObjSedes { get; set; }
        public string NombreCompleto { get; set; }

    }
}
