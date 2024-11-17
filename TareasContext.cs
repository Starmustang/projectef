using Microsoft.EntityFrameworkCore;
using proyectoef.Models;

namespace proyectoef
{
    public class TareasContext: DbContext
    {
        public DbSet<Categoria> Categorias{get;set;}
        public DbSet<Tarea> Tareas{get;set;}

        public TareasContext(DbContextOptions<TareasContext> options) :base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Categoria> categoriasInit = new List<Categoria>();
            categoriasInit.Add(new Categoria() { CategoriaId= Guid.Parse("f83bc361-e443-47f7-89ec-556241277222"), Nombre = "Actividades pendientes", Peso = 20 });
            categoriasInit.Add(new Categoria() { CategoriaId = Guid.Parse("f83bc361-e443-47f7-89ec-556241277233"), Nombre = "Actividades personales", Peso = 69 });

            modelBuilder.Entity<Categoria>(categoria =>
            {
                categoria.ToTable("Categoria");
                categoria.HasKey(p => p.CategoriaId);

                categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);

                categoria.Property(p => p.Descripcion).IsRequired(false);

                categoria.Property(p =>p.Peso);

                categoria.HasData(categoriasInit);
            });


            List<Tarea> tareasInit = new List<Tarea>();
            tareasInit.Add(new Tarea() { TareaId = Guid.Parse("f83bc361-e443-47f7-89ec-556241277234"), CategoriaId = Guid.Parse("f83bc361-e443-47f7-89ec-556241277222"), Prioridad = Prioridad.Media, Titulo ="Pago de servicios publicos", FechaCreacion = DateTime.Now});
            tareasInit.Add(new Tarea() { TareaId = Guid.Parse("f83bc361-e443-47f7-89ec-556241277235"), CategoriaId = Guid.Parse("f83bc361-e443-47f7-89ec-556241277233"), Prioridad = Prioridad.Baja, Titulo = "Terminar pelicula", FechaCreacion = DateTime.Now });
            modelBuilder.Entity<Tarea>(tarea =>
            {
                tarea.ToTable("Tarea");
                tarea.HasKey(t => t.TareaId);

                tarea.HasOne(t => t.Categoria).WithMany(t => t.Tareas).HasForeignKey(t => t.CategoriaId);

                tarea.Property(t => t.Titulo).IsRequired().HasMaxLength(200);
                tarea.Property(t => t.Descripcion).IsRequired(false);
                tarea.Property(t => t.Prioridad);
                tarea.Property(t => t.FechaCreacion);
                
                tarea.Ignore(t => t.Resumen);

                tarea.HasData(tareasInit);
            });
        }

        
    }
}