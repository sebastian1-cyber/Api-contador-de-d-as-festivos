using ApiDiasFestivosDominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace apidiasfestivos.Core.servicios
{
    public interface IpaisServicio
    {
        Task<IEnumerable<Pais>> ObtenerPais(int IdPais);

        Task<Pais> Obtener(int Id);

        Task<Pais> Agregar(Pais Pais);

        Task<Pais> Modificar(Pais Pais);

        Task<bool> Eliminar(int Id);

    }
}
