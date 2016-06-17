using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;
using Entidades;

namespace Negocio
{
    public class IndicadoresNegocio
    {
        public List<Indicadores> obtenerIndicadorAcuerdosStatusUsuario(int idusuario)
        {
            try
            {
                IndicadoresDAL _indicadoresDAL = new IndicadoresDAL();
                return _indicadoresDAL.obtenerIndicadorAcuerdosStatusUsuario(idusuario);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public List<Indicadores> obtenerIndicadorSesionesStatusUsuario(int idusuario, string origen)
        {
            try
            {
                IndicadoresDAL _indicadoresDAL = new IndicadoresDAL();
                return _indicadoresDAL.obtenerIndicadorSesionesStatusUsuario(idusuario,origen);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
