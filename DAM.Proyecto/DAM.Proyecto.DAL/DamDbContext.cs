using DAM.Proyecto.Domain.Entities.DB;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DAM.Proyecto.DAL
{
    /// <summary>
    /// Class: DamDbContext
    /// Herencia: DbContext
    /// 
    /// Enlaza el codigo en C# con la base de datos
    /// Un constructor.
    /// Metodos: Todas las operaciones  CRUD, 
    ///                                 Commit y Rollback
    ///                                 conexion con la base de datos
    /// Una instancia de DbContext representa una sesión con la base de datos y se puede usar para consultar y guardar
    /// instancias de las entidades. 
    /// DbContext es una combinación de los patrones Unit Of Work y Repository.
    /// Se crea una clase que deriva de DbContext y contiene DbSet<TEntity> propiedades para cada entidad del modelo.
    /// Si las DbSet<TEntity> propiedades tienen un establecedor público, se inicializan automáticamente cuando se crea
    /// la instancia del contexto derivado.
    /// 
    /// Mas informacion: https://learn.microsoft.com/es-es/dotnet/api/microsoft.entityframeworkcore.dbcontext?view=efcore-6.0
    /// <summary>
    /// <returns></returns>

    public class DamDbContext : DbContext
    {
        public DamDbContext(DbContextOptions<DamDbContext> options) : base(options)
        {
        }

        // Por cada entidad (tabla) del proyecto hay que anadir un DbSet, para poder ser utilizado
        public DbSet<EventoEuskadiTable> EventosEuskadiTable { get; set; }
        public DbSet<TipoActividadTable> TipoActividadTable { get; set; }
        public DbSet<ImagesTable> ImageTable { get; set; }
        public DbSet<UserTable> UserTable { get; set; }
        public DbSet<EventsTable> EventsTable { get; set; }
        public DbSet<GastronomiaEuskadiTable> GastronomiaEuskadiTable { get; set; }
        public DbSet<TagsTable> TagsTable { get; set; }
        public DbSet<MaestroEventosTable> MaestroEventosTable { get; set; }
        public DbSet<ReservaTable> ReservaTable { get; set; }
        public DbSet<FechasEventosTable> FechasEventosTable { get; set; }



        private IDbContextTransaction _transaction;

        public async Task BeginTransaction()
        {
            _transaction = await Database.BeginTransactionAsync();
        }

        /// <summary>
        /// Method: Task Commit()
        /// Access: public
        /// 
        /// Si todas las transacciones fueron completadas de forma satisfactorioa, es necesario llamar a este metodo
        /// para guardar los cambios de forma permanente.
        /// Al finalizar se liberan los recursos asignados para este contexto.
        ///
        /// @param 
        /// @return
        /// <summary>
        /// <returns></returns>
        public async Task Commit()
        {
            try
            {
                await SaveChangesAsync();                               
                await _transaction.CommitAsync();
            }
            finally
            {
                // Libera los recursos asignados para este contexto.
                await _transaction.DisposeAsync();                      
            }
        }

        /// <summary>
        /// Method: Task RollBack()
        /// Access: public
        /// 
        /// Si al menos una transaccion falla, es necesario llamar a este metodo
        /// para dejar la base de datos en su estadio previo.
        /// Al finalizar se liberan los recursos asignados para este contexto.
        ///
        /// @param 
        /// @return
        /// <summary>
        /// <returns></returns>
        public async Task RollBack()
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
        }

        /// <summary>
        /// Method: OnConfigurin()
        /// Access: protected
        /// 
        /// Se llama a este método para cada instancia del contexto que se crea
        /// @param  DbContextOptionsBuilder optionsBuilder
        /// @return
        /// <summary>
        /// <returns></returns>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configurar base de datos
            string connString = @"Server=(localdb)\\mssqllocaldb;Database=Test";
            //optionsBuilder.UseSqlServer("Pruebas");

            optionsBuilder.UseInMemoryDatabase(@"InMemoryConnection");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ImagesTable>().HasOne(p => p.EventoEuskadiTable).WithMany(b => b.Images);
        }
    }
}
