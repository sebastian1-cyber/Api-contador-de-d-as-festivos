using ApiDiasFestivosDominio;
using ApiDiasFestivosDominio.DTos;
using System;
using System.Collections.Generic;
using System.Text;

namespace apidiasfestivos.Core.repositorios
{
    public interface IFestivosRepositorio
    {
        Task<IEnumerable<Festivo>> ObtenerFestivos(int Idpais);
        
        Task<Festivo> Obtener(int Id);
        Task<Festivo> Agregar(Festivo Festivo);   

        Task<Festivo> Modificar(Festivo Festivo);

        Task<bool> Eliminar(int Id);

        //validacion de fechas de un pais 
        Task<IEnumerable<Festivo>> ValidarFechas(int Idpais, int dia, int mes , int año);

        //listar los festivos de un pais durante un año especifico

        Task<IEnumerable<Festivo>> ValidarFestivoAño(int Idpais, int año);
       
    }
}
