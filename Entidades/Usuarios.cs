﻿using System;
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

        public Perfiles Perfil { get; set; }
    }
}
