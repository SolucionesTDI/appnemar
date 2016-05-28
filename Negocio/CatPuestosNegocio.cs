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
            try
            {
                CatPuestosDAL _catpuestosDAL = new CatPuestosDAL();
                return _catpuestosDAL.insertarPuesto(_catpuestos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void modificarPuesto(CatPuestos _catpuestos)
        {
            try
            {
                CatPuestosDAL _catpuestosDAL = new CatPuestosDAL();
                _catpuestosDAL.modificarPuesto(_catpuestos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void eliminarPuesto(CatPuestos _catpuestos)
        {
            try
            {
                CatPuestosDAL _catpuestosDAL = new CatPuestosDAL();
                _catpuestosDAL.eliminarPuesto(_catpuestos);
            }catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<CatPuestos> list(string filtro = null)
        {
            try
            {
                CatPuestosDAL _catpuestosDAL = new CatPuestosDAL();
                return _catpuestosDAL.obtenerPuestos(filtro);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}
