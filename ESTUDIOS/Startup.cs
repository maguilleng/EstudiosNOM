using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Business.automapperProfile;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Data.Models;
using Data;
using Business;
using AutoMapper;
using Contract.Business;
using ESTUDIOS.Controllers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Data.repositoryInterface;
using Data.repository;
using System.Reflection;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using DTO;

namespace ESTUDIOS
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
        string migrationsAssembly = typeof(ESTUDIOS_NOM35Context).GetTypeInfo().Assembly.GetName().Name;

        public IConfiguration Configuration { get; }


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews()
            .AddNewtonsoftJson(options => {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.ContractResolver = new DefaultContractResolver();
            }            
            );
            services.Configure<EmailSettings>(Configuration.GetSection("EmailSettings"));
            services.Configure<PdfExportSettings>(Configuration.GetSection("PdfExport"));
            services.AddControllers();
            services.AddCors(options => options.AddPolicy(MyAllowSpecificOrigins, p =>
              //p.WithOrigins("http://localhost:4200", "https://pulseuitemp.azurewebsites.net")
              p.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader()));

            services.AddDbContext<ESTUDIOS_NOM35Context>(op => op.UseSqlServer(Configuration.GetConnectionString("Database"))); //Add       
            services.AddControllers();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.Authority = Configuration["authServer"];
                o.Audience = "aquadminApi";
                o.RequireHttpsMetadata = false;
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("ApiReader", policy => policy.RequireClaim("scope", "api.read"));
                //options.AddPolicy("Consumer", policy => policy.RequireClaim(ClaimTypes.Role, "consumer"));
            });


            services.AddControllersWithViews();
            services.AddRazorPages();
            //In production, the Angular files will be served from this directory
            //services.AddSpaStaticFiles(configuration =>
            //{
            //    configuration.RootPath = "ClientApp/dist";
            //});

            services.AddAutoMapper(typeof(EstudiosProfile));

            //Business Dependencies
            services.AddScoped<IEstudiosBusiness, EstudiosBusiness>();
            services.AddScoped<IEmpresasBusiness, EmpresasBusiness>();
            services.AddScoped<ITrabajadoresEvaluadosBusiness, TrabajadoresEvaluadosBusiness>();
            services.AddScoped<IEVNutricionalBusiness, EVNutricionalBusiness> ();
            services.AddScoped<IActividadesBusiness, ActividadesBusiness>();
            services.AddScoped<ITareasBusiness, TareasBusiness>();
            services.AddScoped<IEVMusculoesqueleticosBusiness, EVMusculoesqueleticosBusiness>();
            services.AddScoped<IEvNOM036Business, EVNOM36Business>();
            services.AddScoped<IEVNOM36ResultadosBusiness, EVNOM36ResultadosBusiness>();
            services.AddScoped<IEVAYCIluminacionBusiness, EVAYCIluminacionBusiness>();
            services.AddScoped<IEVAYCAmbSonoroBusiness, EVAYCAmbSonoroBusiness>();
            services.AddScoped<IEVAYCAmbTermicoBusiness, EVAYCAmbTermicoBusiness>();
            services.AddScoped<IEVAYCVibracionBusiness, EVAYCVibracionBusiness>();
            services.AddScoped<ILinksBusiness, LinksBusiness>();
            services.AddScoped<INotificacionesBusiness, NotificacionesBusiness>();
            services.AddScoped<IEmailService, MailService>();
            services.AddScoped<IReportesBusiness, ReportesBusiness>();
            services.AddScoped<IQuestionnairePdfExportBusiness, Business.Pdf.QuestionnairePdfExportBusiness>();
            //services.AddTransient<IEmailService,MailService>();


            // Repository Dependencies
            services.AddScoped<IEstudiosRepository, EstudiosRepository>();
            services.AddScoped<IEmpresasRepository,EmpresasRepository>();
            services.AddScoped<ITrabajadoresEvaluadosRepository, TrabajadoresEvaluadosRepository>();
            services.AddScoped<IEVNutricionalRepository, EVNutricionalRepository>();
            services.AddScoped<IActividadesRepository, ActividadesRepository>();
            services.AddScoped<ITareasRepository, TareasRepository>();
            services.AddScoped<IEVMusculoesqueleticosRepository, EVMusculoesqueleticosRepository>();
            services.AddScoped<IEVNOM36Repository, EVNOM36Repository>();
            services.AddScoped<IEVNOM36ResultadosRepository, EVNOM036ResultadosRepository>();
            services.AddScoped<IEVAYCIluminacionRepository, EVAYCIluminacionRepository>();
            services.AddScoped<IEVAYCAmbTermicoRepository, EVAYCAmbTermicoRepository>();
            services.AddScoped<IEVAYCAmbSonoroRepository, EVAYCAmbSonoroRepository>();
            services.AddScoped<IEVAYCVibracionRepository, EVAYCVibracionRepository>();
            services.AddScoped<ILinksRepository, LinksRepository>();
            services.AddScoped<INotificacionesRepository, NotifiacionesRepository>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors(MyAllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
