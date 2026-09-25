using System;
using System.Collections.Generic;
using System.Text;
using ApiDiasFestivosDominio;
using ApiDiasFestivosDominio.DTos;

namespace apidiasfestivos.Core.servicios
{
      public interface IFestivoServicio
        {
        Task<IEnumerable<Festivo>> ObtenerTodos();

        Task<Festivo> Obtener(int Id);

        Task<IEnumerable<Festivo>> Buscar(int IndiceDato, string Texto);

        Task<Festivo> Agregar(Festivo Festivo);

        Task<Festivo> Modificar(Festivo Festivo);

        Task<bool> Eliminar(int Id);

        // listar los festivos de un pais durante un año especifico 

        Task<IEnumerable<FestivosDTos>> ValidarFestivoAño(int Idpais, int año);





    }
}
