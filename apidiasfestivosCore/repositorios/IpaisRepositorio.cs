using System;
using System.Collections.Generic;
using System.Text;
using ApiDiasFestivosDominio;

namespace apidiasfestivos.Core.repositorios
{
    public interface IpaisRepositorio
    {

        Task<IEnumerable<Pais>> ObtenertodosPaises();


        Task<Pais> Obtener(int Id);

        Task<Pais> BuscarNombre( string Texto);

        Task<Pais> Agregar(Pais Pais);

        Task<Pais> Modificar(Pais Pais);

        Task<bool> Eliminar(int Id);
        

         // obtener pais por nombre
        




    }
}
