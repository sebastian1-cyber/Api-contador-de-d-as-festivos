using Microsoft.EntityFrameworkCore;
using ApiDiasFestivosDominio;
using apidiasfestivos.Core.repositorios;
using ApiDiasFestivosInfraestructura.Persistencias;

namespace ApiDiasFestivosInfraestructura.Repositorios
{
    public class PaisRepositorio : IpaisRepositorio
    {
        private readonly ContadorDeDIasFestivosContext Contexto;
        public PaisRepositorio(ContadorDeDIasFestivosContext contexto)
        {
            this.Contexto = contexto;
        }
        

        public async Task<Pais> Obtener(int Id)
        {
            return await Contexto.Paises.FindAsync(Id);
        }

        public async Task<Pais> Agregar(Pais Pais)
        {
            // agregar elemento al DbSet
            Contexto.Paises.Add(Pais);
            // llevar los cambios a la base de datos
            await Contexto.SaveChangesAsync();
            //retornar registro agregado
            return Contexto.Paises.FirstOrDefault(pais => pais.Id == Pais.Id);
        }

        public async Task<Pais> Modificar(Pais Pais)
        {
            //buscar el elemento en el dbset
            var PaisExistente = await Contexto.Paises.FindAsync(Pais.Id);
            if (PaisExistente == null)
            {
                return null;
            }
            //cambiar los datos en el elemento del dbset
            Contexto.Entry(PaisExistente).CurrentValues.SetValues(Pais);
            // llevar los cambios a la base de datos
            await Contexto.SaveChangesAsync();

            //retornar registro modificado
            return Contexto.Paises.FirstOrDefault(pais => pais.Id == Pais.Id);
        }

        public async Task<bool> Eliminar(int Id)
        {
            var PaisExistente = await Contexto.Paises.FindAsync(Id);
            if (PaisExistente == null)
            {
                return false;
            }
            try
            {
                //quitar elemento del dbset
                Contexto.Paises.Remove(PaisExistente);
                // llevar los cambios a la base de datos
                await Contexto.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // Obtener todos los paises ordenados por nombre
        public async Task<IEnumerable<Pais>> ObtenertodosPaises()
        {
            return await Contexto.Paises
                .OrderBy(pais => pais.Nombre)
                .ToListAsync();
        }
        // buscar pais por nombre
        public async Task<Pais> BuscarNombre( string Texto)     
        {
            return await Contexto.Paises
                .FirstOrDefaultAsync(pais => pais.Nombre == Texto);
        }

    
        
    }
}
