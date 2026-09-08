using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Data.Models
{
    public partial class ESTUDIOS_NOM35Context : DbContext
    {
        public ESTUDIOS_NOM35Context()
        {
        }

        public ESTUDIOS_NOM35Context(DbContextOptions<ESTUDIOS_NOM35Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Actividade> Actividades { get; set; }
        public virtual DbSet<CuerpoNotificacione> CuerpoNotificaciones { get; set; }
        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<Estudio> Estudios { get; set; }
        public virtual DbSet<EvAycAmbientermico> EvAycAmbientermicos { get; set; }
        public virtual DbSet<EvAycAmbientesonoro> EvAycAmbientesonoros { get; set; }
        public virtual DbSet<EvAycIluminacion> EvAycIluminacions { get; set; }
        public virtual DbSet<EvAycVibracion> EvAycVibracions { get; set; }
        public virtual DbSet<EvEstadoNutricional> EvEstadoNutricionals { get; set; }
        public virtual DbSet<EvMuscoloesqueletico> EvMuscoloesqueleticos { get; set; }
        public virtual DbSet<JornadaTrabajo> JornadaTrabajos { get; set; }
        public virtual DbSet<Link> Links { get; set; }
        public virtual DbSet<NomApartado> NomApartados { get; set; }
        public virtual DbSet<NomPregunta> NomPreguntas { get; set; }
        public virtual DbSet<NomRespuesta> NomRespuestas { get; set; }
        public virtual DbSet<NomResultado> NomResultados { get; set; }
        public virtual DbSet<Regione> Regiones { get; set; }
        public virtual DbSet<Tarea> Tareas { get; set; }
        public virtual DbSet<TrabajadoresEstudio> TrabajadoresEstudios { get; set; }
        public virtual DbSet<Graficas_GUIAII> GrafciasGuiaII { get; set; }
        public virtual DbSet<TotalesRteGraficas> TotalesGraficas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=SQL8005.site4now.net,1433;Initial Catalog=db_a986f5_nom35;Persist Security Info=False;User ID=db_a986f5_nom35_admin;Password=Overtrack2023#; MultipleActiveResultSets=False; Encrypt=True; TrustServerCertificate=False; Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Actividade>(entity =>
            {
                entity.HasKey(e => e.Idactividad);

                entity.ToTable("ACTIVIDADES");

                entity.Property(e => e.Idactividad).HasColumnName("IDActividad");

                entity.Property(e => e.Actividad).HasMaxLength(150);

                entity.Property(e => e.Descripcion).HasMaxLength(250);

                entity.Property(e => e.Dotacion).HasMaxLength(75);

                entity.Property(e => e.Idempleado).HasColumnName("IDEmpleado");

                entity.Property(e => e.MaquinasEquipos).HasMaxLength(100);

                entity.Property(e => e.Materiales).HasMaxLength(100);

                entity.Property(e => e.ProtecionPersonal).HasMaxLength(75);

                entity.Property(e => e.Titulo).HasMaxLength(50);

                entity.HasOne(d => d.IdempleadoNavigation)
                    .WithMany(p => p.Actividades)
                    .HasForeignKey(d => d.Idempleado)
                    .HasConstraintName("FK_ACTIVIDADES_TRABAJADORES_ESTUDIO");
            });

            modelBuilder.Entity<CuerpoNotificacione>(entity =>
            {
                entity.HasKey(e => e.Norma);

                entity.ToTable("CUERPO_NOTIFICACIONES");

                entity.Property(e => e.Norma).HasMaxLength(10);

                entity.Property(e => e.Msjbienvenida)
                    .HasMaxLength(500)
                    .HasColumnName("MSJBienvenida");

                entity.Property(e => e.Msjdespedida)
                    .HasMaxLength(500)
                    .HasColumnName("MSJDespedida");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.Rfc);

                entity.ToTable("EMPRESAS");

                entity.HasIndex(e => e.RazonSocial, "UQ__EMPRESAS__AEC642DCDDE8015F")
                    .IsUnique();

                entity.HasIndex(e => e.Rfc, "UQ__EMPRESAS__CAFFA85E97A4DC7A")
                    .IsUnique();

                entity.Property(e => e.Rfc)
                    .HasMaxLength(13)
                    .HasColumnName("RFC");

                entity.Property(e => e.DireccionFiscal)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.Email).HasMaxLength(100);

                entity.Property(e => e.Giro)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.InstalacionOficinaBase)
                    .HasMaxLength(500)
                    .HasColumnName("Instalacion_oficina_base");

                entity.Property(e => e.Proceso).HasMaxLength(500);

                entity.Property(e => e.RazonSocial)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.RepresentanteLegal)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.ResponsableInforme).HasMaxLength(250);
            });

            modelBuilder.Entity<Estudio>(entity =>
            {
                entity.HasKey(e => e.Idestudio);

                entity.ToTable("ESTUDIOS");

                entity.Property(e => e.Idestudio).HasColumnName("IDEstudio");

                entity.Property(e => e.FechaCaptura).HasColumnType("date");

                entity.Property(e => e.FechaInforme).HasColumnType("date");

                entity.Property(e => e.GuiaIi).HasColumnName("GuiaII");

                entity.Property(e => e.GuiaIii).HasColumnName("GuiaIII");

                entity.Property(e => e.Instalacion).HasMaxLength(100);

                entity.Property(e => e.Rfcempresa)
                    .IsRequired()
                    .HasMaxLength(13)
                    .HasColumnName("RFCEmpresa");

                entity.Property(e => e.RfcempresaEva)
                    .IsRequired()
                    .HasMaxLength(13)
                    .HasColumnName("RFCEmpresaEva");

                entity.Property(e => e.Subtitulo).HasMaxLength(150);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(150);

                entity.HasOne(d => d.RfcempresaNavigation)
                    .WithMany(p => p.EstudioRfcempresaNavigations)
                    .HasForeignKey(d => d.Rfcempresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ESTUDIOS_ESTUDIOS");

                entity.HasOne(d => d.RfcempresaEvaNavigation)
                    .WithMany(p => p.EstudioRfcempresaEvaNavigations)
                    .HasForeignKey(d => d.RfcempresaEva)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ESTUDIOS_EMPRESAS");
            });

            modelBuilder.Entity<EvAycAmbientermico>(entity =>
            {
                entity.HasKey(e => e.Transid);

                entity.ToTable("EV_AYC_AMBIENTERMICO");

                entity.HasIndex(e => e.Idtarea, "UQ__EV_AYC_A__76B294D1D3F8A931")
                    .IsUnique();

                entity.Property(e => e.Transid).HasColumnName("TRANSID");

                entity.Property(e => e.EjemploPercepcion).HasMaxLength(50);

                entity.Property(e => e.Fuente).HasMaxLength(25);

                entity.Property(e => e.Idtarea).HasColumnName("IDTarea");

                entity.Property(e => e.Intensidad).HasMaxLength(25);

                entity.Property(e => e.Observaciones).HasMaxLength(150);

                entity.Property(e => e.Percepcion).HasMaxLength(25);

                entity.HasOne(d => d.IdtareaNavigation)
                    .WithOne(p => p.EvAycAmbientermico)
                    .HasForeignKey<EvAycAmbientermico>(d => d.Idtarea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EV_AYC_AMBIENTERMICO_TAREAS");
            });

            modelBuilder.Entity<EvAycAmbientesonoro>(entity =>
            {
                entity.HasKey(e => e.Transid);

                entity.ToTable("EV_AYC_AMBIENTESONORO");

                entity.HasIndex(e => e.Idtarea, "UQ__EV_AYC_A__76B294D148F16B58")
                    .IsUnique();

                entity.Property(e => e.Transid).HasColumnName("TRANSID");

                entity.Property(e => e.Continuidad).HasMaxLength(25);

                entity.Property(e => e.Fuente).HasMaxLength(25);

                entity.Property(e => e.Idtarea).HasColumnName("IDTarea");

                entity.Property(e => e.Intensidad).HasMaxLength(25);

                entity.Property(e => e.Observaciones).HasMaxLength(150);

                entity.HasOne(d => d.IdtareaNavigation)
                    .WithOne(p => p.EvAycAmbientesonoro)
                    .HasForeignKey<EvAycAmbientesonoro>(d => d.Idtarea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EV_AYC_AMBIENTESONORO_TAREAS");
            });

            modelBuilder.Entity<EvAycIluminacion>(entity =>
            {
                entity.HasKey(e => e.Transid);

                entity.ToTable("EV_AYC_ILUMINACION");

                entity.HasIndex(e => e.Idtarea, "UQ__EV_AYC_I__76B294D15F62841E")
                    .IsUnique();

                entity.HasIndex(e => e.Idtarea, "UQ__EV_AYC_I__76B294D16D671A03")
                    .IsUnique();

                entity.HasIndex(e => e.Idtarea, "UQ__EV_AYC_I__76B294D1C5FA7423")
                    .IsUnique();

                entity.Property(e => e.Transid).HasColumnName("TRANSID");

                entity.Property(e => e.Fuente).HasMaxLength(25);

                entity.Property(e => e.Idtarea).HasColumnName("IDTarea");

                entity.Property(e => e.Intensidad).HasMaxLength(25);

                entity.Property(e => e.Observaciones).HasMaxLength(150);

                entity.HasOne(d => d.IdtareaNavigation)
                    .WithOne(p => p.EvAycIluminacion)
                    .HasForeignKey<EvAycIluminacion>(d => d.Idtarea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EV_AYC_ILUMINACION_TAREAS");
            });

            modelBuilder.Entity<EvAycVibracion>(entity =>
            {
                entity.HasKey(e => e.Transid);

                entity.ToTable("EV_AYC_VIBRACION");

                entity.HasIndex(e => e.Idtarea, "UQ__EV_AYC_V__76B294D1BBC6E2D1")
                    .IsUnique();

                entity.Property(e => e.Transid).HasColumnName("TRANSID");

                entity.Property(e => e.CualSegmentario).HasMaxLength(50);

                entity.Property(e => e.Idtarea).HasColumnName("IDTarea");

                entity.Property(e => e.Intensidad).HasMaxLength(25);

                entity.Property(e => e.Observaciones).HasMaxLength(150);

                entity.Property(e => e.SegmentosCorporales).HasMaxLength(25);

                entity.HasOne(d => d.IdtareaNavigation)
                    .WithOne(p => p.EvAycVibracion)
                    .HasForeignKey<EvAycVibracion>(d => d.Idtarea)
                    .HasConstraintName("FK_EV_AYC_VIBRACION_TAREAS");
            });

            modelBuilder.Entity<EvEstadoNutricional>(entity =>
            {
                entity.HasKey(e => e.Transid);

                entity.ToTable("EV_ESTADO_NUTRICIONAL");

                entity.Property(e => e.Transid).HasColumnName("TRANSID");

                entity.Property(e => e.Altura).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Idempleado).HasColumnName("IDEmpleado");

                entity.Property(e => e.Ims)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("IMS");

                entity.Property(e => e.PerimetroAbdominal).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Peso).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.IdempleadoNavigation)
                    .WithMany(p => p.EvEstadoNutricionals)
                    .HasForeignKey(d => d.Idempleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EV_ESTADO_NUTRICIONAL_TRABAJORES_ESTUDIO");
            });

            modelBuilder.Entity<EvMuscoloesqueletico>(entity =>
            {
                entity.HasKey(e => e.Transid);

                entity.ToTable("EV_MUSCOLOESQUELETICOS");

                entity.Property(e => e.Transid).HasColumnName("TRANSID");

                entity.Property(e => e.Duracion).HasMaxLength(75);

                entity.Property(e => e.DuracionEpisodio).HasMaxLength(50);

                entity.Property(e => e.Factores).HasMaxLength(250);

                entity.Property(e => e.Idempleado).HasColumnName("IDEmpleado");

                entity.Property(e => e.Idregion).HasColumnName("IDRegion");

                entity.Property(e => e.ImpedimentoTrabajo).HasMaxLength(25);

                entity.Property(e => e.Tiempo).HasMaxLength(50);

                entity.HasOne(d => d.IdempleadoNavigation)
                    .WithMany(p => p.EvMuscoloesqueleticos)
                    .HasForeignKey(d => d.Idempleado)
                    .HasConstraintName("FK_EV_MUSCOLOESQUELETICOS_TRABAJADORES_ESTUDIO");

                entity.HasOne(d => d.IdregionNavigation)
                    .WithMany(p => p.EvMuscoloesqueleticos)
                    .HasForeignKey(d => d.Idregion)
                    .HasConstraintName("FK_EV_MUSCOLOESQUELETICOS_REGIONES");
            });

            modelBuilder.Entity<JornadaTrabajo>(entity =>
            {
                entity.HasKey(e => e.IdjornadaTrabajo);

                entity.ToTable("JORNADA_TRABAJO");

                entity.Property(e => e.IdjornadaTrabajo)
                    .ValueGeneratedNever()
                    .HasColumnName("IDJornadaTrabajo");

                entity.Property(e => e.Descripcion).HasMaxLength(100);
            });

            modelBuilder.Entity<Link>(entity =>
            {
                entity.HasKey(e => e.Idlink);

                entity.ToTable("LINKS");

                entity.Property(e => e.Idlink).HasColumnName("IDLink");

                entity.Property(e => e.Correo).HasMaxLength(100);

                entity.Property(e => e.FechaCreacion).HasColumnType("date");

                entity.Property(e => e.Idestudio).HasColumnName("IDEstudio");

                entity.Property(e => e.Link1).HasColumnName("Link");

                entity.Property(e => e.Nombre).HasMaxLength(150);

                entity.Property(e => e.Vigencia).HasColumnType("date");

                entity.HasOne(d => d.IdestudioNavigation)
                    .WithMany(p => p.Links)
                    .HasForeignKey(d => d.Idestudio)
                    .HasConstraintName("FK_LINKS_ESTUDIOS");
            });

            modelBuilder.Entity<NomApartado>(entity =>
            {
                entity.HasKey(e => e.Idapartado)
                    .HasName("PK_NOM_036_APARTADOS");

                entity.ToTable("NOM_APARTADOS");

                entity.Property(e => e.Idapartado)
                    .ValueGeneratedNever()
                    .HasColumnName("IDApartado");

                entity.Property(e => e.Descripcion).HasMaxLength(150);

                entity.Property(e => e.Norma).HasMaxLength(10);

                entity.Property(e => e.Titulo).HasMaxLength(35);
            });

            modelBuilder.Entity<NomPregunta>(entity =>
            {
                entity.HasKey(e => e.Idpregunta)
                    .HasName("PK_NOM_036_PREGUNTAS");

                entity.ToTable("NOM_PREGUNTAS");

                entity.Property(e => e.Idpregunta).HasColumnName("IDPregunta");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(800);

                entity.Property(e => e.Idapartado).HasColumnName("IDApartado");

                entity.Property(e => e.IdseccionPregunta).HasColumnName("IDSeccionPregunta");

                entity.Property(e => e.TipoPregunta).HasMaxLength(50);

                entity.Property(e => e.Titulo).HasMaxLength(350);

                entity.HasOne(d => d.IdapartadoNavigation)
                    .WithMany(p => p.NomPregunta)
                    .HasForeignKey(d => d.Idapartado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NOM_036_PREGUNTAS_NOM_036_APARTADOS");
            });

            modelBuilder.Entity<NomRespuesta>(entity =>
            {
                entity.HasKey(e => e.Idrespuesta)
                    .HasName("PK_NOM_036_RESPUESTAS");

                entity.ToTable("NOM_RESPUESTAS");

                entity.Property(e => e.Idrespuesta).HasColumnName("IDRespuesta");

                entity.Property(e => e.Descripcion)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Idapartado).HasColumnName("IDApartado");

                entity.Property(e => e.Idpregunta).HasColumnName("IDPregunta");

                entity.Property(e => e.Imagen).HasMaxLength(75);

                entity.Property(e => e.ImagenPregunta).HasMaxLength(150);

                entity.Property(e => e.Nivel)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.TipoRespuesta).HasMaxLength(25);

                entity.HasOne(d => d.IdapartadoNavigation)
                    .WithMany(p => p.NomRespuesta)
                    .HasForeignKey(d => d.Idapartado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NOM_036_RESPUESTAS_NOM_036_APARTADOS");

                entity.HasOne(d => d.IdpreguntaNavigation)
                    .WithMany(p => p.NomRespuesta)
                    .HasForeignKey(d => d.Idpregunta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NOM_036_RESPUESTAS_NOM_036_PREGUNTAS");
            });

            modelBuilder.Entity<NomResultado>(entity =>
            {
                entity.HasKey(e => e.Transid)
                    .HasName("PK_NOM_036_RESULTADOS");

                entity.ToTable("NOM_RESULTADOS");

                entity.Property(e => e.Transid).HasColumnName("TRANSID");

                entity.Property(e => e.Idapartado).HasColumnName("IDApartado");

                entity.Property(e => e.Idempleado).HasColumnName("IDEmpleado");

                entity.Property(e => e.Idpregunta).HasColumnName("IDPregunta");

                entity.Property(e => e.Idrespuesta).HasColumnName("IDRespuesta");

                entity.HasOne(d => d.IdapartadoNavigation)
                    .WithMany(p => p.NomResultados)
                    .HasForeignKey(d => d.Idapartado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NOM_036_RESULTADOS_NOM_036_APARTADOS");

                entity.HasOne(d => d.IdempleadoNavigation)
                    .WithMany(p => p.NomResultados)
                    .HasForeignKey(d => d.Idempleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NOM_RESULTADOS_TRABAJADORES_ESTUDIO");

                entity.HasOne(d => d.IdpreguntaNavigation)
                    .WithMany(p => p.NomResultados)
                    .HasForeignKey(d => d.Idpregunta)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NOM_036_RESULTADOS_NOM_036_PREGUNTAS");

                entity.HasOne(d => d.IdrespuestaNavigation)
                    .WithMany(p => p.NomResultados)
                    .HasForeignKey(d => d.Idrespuesta)
                    .HasConstraintName("FK_NOM_036_RESULTADOS_NOM_036_RESPUESTAS");
            });

            modelBuilder.Entity<Regione>(entity =>
            {
                entity.HasKey(e => e.Idregion);

                entity.ToTable("REGIONES");

                entity.Property(e => e.Idregion)
                    .ValueGeneratedNever()
                    .HasColumnName("IDRegion");

                entity.Property(e => e.Agrupacion).HasMaxLength(20);

                entity.Property(e => e.Descripcion).HasMaxLength(50);
            });

            modelBuilder.Entity<Tarea>(entity =>
            {
                entity.HasKey(e => e.Idtarea);

                entity.ToTable("TAREAS");

                entity.Property(e => e.Idtarea).HasColumnName("IDTarea");

                entity.Property(e => e.Descripcion).HasMaxLength(250);

                entity.Property(e => e.EvagentesCondiciones).HasColumnName("EVAgentes_Condiciones");

                entity.Property(e => e.Evnom036Equipo).HasColumnName("EVNom036_Equipo");

                entity.Property(e => e.Evnom036Levantar).HasColumnName("EVNom036_Levantar");

                entity.Property(e => e.Evnom036Transportar).HasColumnName("EVNom036_Transportar");

                entity.Property(e => e.Frecuencia).HasMaxLength(75);

                entity.Property(e => e.Idactividad).HasColumnName("IDActividad");

                entity.Property(e => e.Niosh).HasColumnName("NIOSH");

                entity.Property(e => e.Owas).HasColumnName("OWAS");

                entity.Property(e => e.Reba).HasColumnName("REBA");

                entity.Property(e => e.Rosa).HasColumnName("ROSA");

                entity.Property(e => e.Rula).HasColumnName("RULA");

                entity.Property(e => e.TiempoTarea).HasMaxLength(75);

                entity.Property(e => e.TipoTarea).HasMaxLength(50);

                entity.Property(e => e.Titulo).HasMaxLength(50);

                entity.Property(e => e.Ubicacion).HasMaxLength(75);

                entity.HasOne(d => d.IdactividadNavigation)
                    .WithMany(p => p.Tareas)
                    .HasForeignKey(d => d.Idactividad)
                    .HasConstraintName("FK_TAREAS_ACTIVIDADES");
            });

            modelBuilder.Entity<TrabajadoresEstudio>(entity =>
            {
                entity.HasKey(e => e.Idtrabajador)
                    .HasName("PK_TRABAJORES_ESTUDIO");

                entity.ToTable("TRABAJADORES_ESTUDIO");

                entity.Property(e => e.Idtrabajador).HasColumnName("IDTrabajador");

                entity.Property(e => e.AntiguedadCategoria)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AntiguedadPuesto)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AreaFisica)
                    .HasMaxLength(100)
                    .HasColumnName("Area_fisica");

                entity.Property(e => e.DepartamentoArea)
                    .HasMaxLength(100)
                    .HasColumnName("Departamento_Area");

                entity.Property(e => e.DescripcionPuesto)
                    .HasMaxLength(100)
                    .HasColumnName("Descripcion_puesto");

                entity.Property(e => e.Edad)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.EstadoCivil).HasMaxLength(25);

                entity.Property(e => e.Evaluador)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.ExperienciaLaboral).HasMaxLength(25);

                entity.Property(e => e.FechaEvaluacion).HasColumnType("date");

                entity.Property(e => e.Horario)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Idestudio).HasColumnName("IDEstudio");

                entity.Property(e => e.InstalacionOficinaTaller)
                    .HasMaxLength(100)
                    .HasColumnName("Instalacion_oficina_taller");

                entity.Property(e => e.JornadaTrabajo).HasMaxLength(50);

                entity.Property(e => e.NivelEstudio).HasMaxLength(50);

                entity.Property(e => e.Nombre)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.PuestoCategoria)
                    .HasMaxLength(100)
                    .HasColumnName("Puesto_Categoria");

                entity.Property(e => e.Sexo)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.TipoContratacion).HasMaxLength(50);

                entity.Property(e => e.TipoJornada).HasMaxLength(50);

                entity.Property(e => e.TipoPersonal).HasMaxLength(25);

                entity.Property(e => e.TipoPuesto).HasMaxLength(50);

                entity.HasOne(d => d.IdestudioNavigation)
                    .WithMany(p => p.TrabajadoresEstudios)
                    .HasForeignKey(d => d.Idestudio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TRABAJORES_ESTUDIO_ESTUDIOS");
            });

            OnModelCreatingPartial(modelBuilder);
            modelBuilder.Entity<Graficas_GUIAII>(entity =>
            {
                entity.HasKey(e => e.concepto);

                entity.Property(e => e.concepto).ValueGeneratedNever();

                entity.Property(e => e.concepto)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });
            OnModelCreatingPartial(modelBuilder);
            modelBuilder.Entity<TotalesRteGraficas>(entity =>
            {
                entity.HasKey(e => e.Concepto);

                entity.Property(e => e.Concepto).ValueGeneratedNever();

                entity.Property(e => e.Concepto)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
