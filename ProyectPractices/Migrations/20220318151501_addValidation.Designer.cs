// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectPractices;

#nullable disable

namespace ProyectPractices.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220318151501_addValidation")]
    partial class addValidation
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-preview.2.22153.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ProyectPractices.Models.Alumno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<int>("GrupoId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.HasKey("Id");

                    b.HasIndex("GrupoId");

                    b.ToTable("Alumnos");
                });

            modelBuilder.Entity("ProyectPractices.Models.Grupo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MaestroId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.HasKey("Id");

                    b.HasIndex("MaestroId")
                        .IsUnique();

                    b.ToTable("Grupos");
                });

            modelBuilder.Entity("ProyectPractices.Models.Maestro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Maestro");
                });

            modelBuilder.Entity("ProyectPractices.Models.Materia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("MaestroId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.HasIndex("MaestroId");

                    b.ToTable("Materias");
                });

            modelBuilder.Entity("ProyectPractices.Models.MateriaAlumno", b =>
                {
                    b.Property<int>("MateriaId")
                        .HasColumnType("int");

                    b.Property<int>("AlumnoId")
                        .HasColumnType("int");

                    b.HasKey("MateriaId", "AlumnoId");

                    b.HasIndex("AlumnoId");

                    b.ToTable("MateriaAlumnos");
                });

            modelBuilder.Entity("ProyectPractices.Models.Alumno", b =>
                {
                    b.HasOne("ProyectPractices.Models.Grupo", "Grupo")
                        .WithMany("Alumnos")
                        .HasForeignKey("GrupoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Grupo");
                });

            modelBuilder.Entity("ProyectPractices.Models.Grupo", b =>
                {
                    b.HasOne("ProyectPractices.Models.Maestro", "Maestro")
                        .WithOne("Grupo")
                        .HasForeignKey("ProyectPractices.Models.Grupo", "MaestroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Maestro");
                });

            modelBuilder.Entity("ProyectPractices.Models.Materia", b =>
                {
                    b.HasOne("ProyectPractices.Models.Maestro", "Maestro")
                        .WithMany("Materias")
                        .HasForeignKey("MaestroId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Maestro");
                });

            modelBuilder.Entity("ProyectPractices.Models.MateriaAlumno", b =>
                {
                    b.HasOne("ProyectPractices.Models.Alumno", "Alumno")
                        .WithMany("MateriaAlumnos")
                        .HasForeignKey("AlumnoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProyectPractices.Models.Materia", "Materia")
                        .WithMany("MateriaAlumnos")
                        .HasForeignKey("MateriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Alumno");

                    b.Navigation("Materia");
                });

            modelBuilder.Entity("ProyectPractices.Models.Alumno", b =>
                {
                    b.Navigation("MateriaAlumnos");
                });

            modelBuilder.Entity("ProyectPractices.Models.Grupo", b =>
                {
                    b.Navigation("Alumnos");
                });

            modelBuilder.Entity("ProyectPractices.Models.Maestro", b =>
                {
                    b.Navigation("Grupo")
                        .IsRequired();

                    b.Navigation("Materias");
                });

            modelBuilder.Entity("ProyectPractices.Models.Materia", b =>
                {
                    b.Navigation("MateriaAlumnos");
                });
#pragma warning restore 612, 618
        }
    }
}
