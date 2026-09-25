using apidiasfestivos.Core.repositorios;
using ApiDiasFestivosDominio;
using ApiDiasFestivosInfraestructura.Persistencias;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ApiDiasFestivosInfraestructura.Repositorios
{
    public class TipoFestivoRepositorio : ITipoFestivoRepositorio
    {
        private readonly ContadorDeDIasFestivosContext Contexto;

        public TipoFestivoRepositorio(ContadorDeDIasFestivosContext contexto)
        {
            this.Contexto = contexto;
        }

        public Task<IEnumerable<TipoFestivo>> ObtenerTipoFestivo(int IdTipoFestivo)
        {
            // implementación mínima: devolver lista vacía
            return Task.FromResult<IEnumerable<TipoFestivo>>(new List<TipoFestivo>());
        }

        public async Task<TipoFestivo> Agregar(TipoFestivo tipoFestivo)
        {
            // agregar elemento al DbSet correcto
            Contexto.TiposFestivos.Add(tipoFestivo);
            // llevar los cambios a la base de datos
            await Contexto.SaveChangesAsync();
            // retornar registro agregado
            return Contexto.TiposFestivos.FirstOrDefault(tf => tf.Id == tipoFestivo.Id);
        }

        public async Task<TipoFestivo> Modificar(TipoFestivo TipoFestivo)
        {
            //buscar el elemento en el dbset
            var TipoFestivoExistente = await Contexto.TiposFestivos.FindAsync(TipoFestivo.Id);
            if (TipoFestivoExistente == null)
            {
                return null;
            }
            //cambiar los datos en el elemento del dbset
            Contexto.Entry(TipoFestivoExistente).CurrentValues.SetValues(TipoFestivo);
            // llevar los cambios a la base de datos
            await Contexto.SaveChangesAsync();

            //retornar registro modificado
            return Contexto.TiposFestivos.FirstOrDefault(tf => tf.Id == TipoFestivo.Id);
        }

        public async Task<bool> Eliminar(int Id)
        {
            var TipoFestivoExistente = await Contexto.TiposFestivos.FindAsync(Id);
            if (TipoFestivoExistente == null)
            {
                return false;
            }
            try
            {
                //quitar elemento del dbset
                Contexto.TiposFestivos.Remove(TipoFestivoExistente);
                // llevar los cambios a la base de datos
                await Contexto.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
