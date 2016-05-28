using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;

namespace Negocio
{
    public class CatPuestosNegocio
    {
        public int insertarPuesto(CatPuestos _catpuestos)
        {
            CatPuestosDAL _catpuestosDAL = new CatPuestosDAL();
            return _catpuestosDAL.insertarPuesto(_catpuestos);
        }
        public void modificarPuesto(CatPuestos _catpuestos)
        {

            CatPuestosDAL _catpuestosDAL = new CatPuestosDAL();
            _catpuestosDAL.modificarPuesto(_catpuestos);
        }

        public void eliminarPuesto(CatPuestos _catpuestos)
        {
            CatPuestosDAL _catpuestosDAL = new CatPuestosDAL();
            _catpuestosDAL.eliminarPuesto(_catpuestos)
        }

        public List<CatPuestos> list()
        {
            CatPuestosDAL _catpuestosDAL = new CatPuestosDAL();
            return _catpuestosDAL.obtenerPuestos();
        }

    }
}
