using apidiasfestivos.Core.repositorios;
using ApiDiasFestivosDominio;
using ApiDiasFestivosDominio.DTos;
using ApiDiasFestivosInfraestructura.Persistencias;
using Microsoft.EntityFrameworkCore;


namespace ApiDiasFestivosInfraestructura.Repositorios
{
    public class FestivoRepositorio : IFestivosRepositorio
    {
        private readonly ContadorDeDIasFestivosContext Contexto;
        public FestivoRepositorio(ContadorDeDIasFestivosContext contexto)
        {
            this.Contexto = contexto;
        }
        public async Task<IEnumerable<Festivo>> ObtenerFestivos(int Idpais)
        {
            return await Contexto.Festivos
            .Include(f => f.Tipo)
            .Where(f => f.IdPais == Idpais)
            .ToListAsync();
        }

        public async Task<Festivo> Obtener(int Id)
        {
            return await Contexto.Festivos.FindAsync(Id);
        }

        public async Task<Festivo> Agregar(Festivo Festivo)
        {
            // agregar elemento al DbSet
            Contexto.Festivos.Add(Festivo);
            // llevar los cambios a la base de datos
            await Contexto.SaveChangesAsync();
            //retornar registro agregado
            return await Contexto.Festivos.FirstOrDefaultAsync(festivo => festivo.Id == Festivo.Id);
        }

        public async Task<Festivo> Modificar(Festivo Festivo)
        {
            var FestivoExistente = await Contexto.Festivos.FindAsync(Festivo.Id);
            if (FestivoExistente == null)
            {
                return null;
            }
            //cambiar los datos en el elemento del dbset
            Contexto.Entry(FestivoExistente).CurrentValues.SetValues(Festivo);
            // llevar los cambios a la base de datos
            await Contexto.SaveChangesAsync();

            //retornar registro modificado
            return await Contexto.Festivos.FirstOrDefaultAsync(festivo => festivo.Id == Festivo.Id);
        }

        public async Task<bool> Eliminar(int Id)
        {
            var FestivoExistente = await Contexto.Festivos.FindAsync(Id);
            if (FestivoExistente == null)
            {
                return false;
            }
            try
            {
                //quitar elemento del dbset
                Contexto.Festivos.Remove(FestivoExistente);
                // llevar los cambios a la base de datos
                await Contexto.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // Implementaciones añadidas para cumplir la interfaz
        public async Task<IEnumerable<Festivo>> ValidarFechas(int Idpais, int dia, int mes, int año)
        {
            return await Contexto.Festivos
            .Include(f => f.Tipo)
            .Where(f => f.IdPais == Idpais)
            .ToListAsync();
        }

        public async Task<IEnumerable<Festivo>> ValidarFestivoAño(int Idpais, int año)
        {
            return await Contexto.Festivos
                .Where(festivo => festivo.IdPais == Idpais)
                .Include(festivo => festivo.Tipo)
                .Include(festivo => festivo.Pais)
                .OrderBy(festivo => festivo.NombreFestivo)
                .ToListAsync();
        }
        
    }
}
    