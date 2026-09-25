using System;
using System.Collections.Generic;
using System.Text;
using ApiDiasFestivosDominio;

namespace apidiasfestivos.Core.servicios
{
    public interface ITipoFestivoServicio
    {

        Task<IEnumerable<TipoFestivo>> ObtenerTipoFestivo(int IdTipoFestivo);


        Task<TipoFestivo> Agregar(TipoFestivo TipoFestivo);

        Task<TipoFestivo> Modificar(TipoFestivo TipoFestivo);

        Task<bool> Eliminar(int Id);

    }
}
