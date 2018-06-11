using System.Linq;

namespace core.template.api
{
    using System;
    using dataAccess;
    using MediatR;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.AspNetCore.SpaServices.AngularCli;
    using Swashbuckle.AspNetCore.Swagger;
    using MediatR.Pipeline;
    using services.queries.Queries.Customer.Query;
    using StructureMap;
    using core.template.services.behaviors.Behaviors;
    using services.commands.Configuration;

    public class Startup
    {
        private static readonly string[] ExcludePaths = new string[]
        {
            "api",
            "instance",
            "clientconfig"
        };

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            //services.AddMediatR(typeof(CustomerGetHandler).GetTypeInfo().Assembly);

            services.AddMvc();
            services.AddDbContext<DemoContext>();
            services.AddDbContext<DemoContextReadOnly>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });

            services.AddCors(s => s.AddPolicy("policy", builder =>
            {
                builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin().AllowCredentials();
            }));

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            return ConfigureIoC(services);
        }

        private IServiceProvider ConfigureIoC(IServiceCollection services)
        {
            var container = new Container();
            container.Configure(cfg =>
            {
                cfg.Scan(scanner =>
                {
                    scanner.AssemblyContainingType(typeof(Startup));
                    scanner.AssemblyContainingType(typeof(services.behaviors.Configuration.MapperConfiguration));
                    scanner.AssemblyContainingType(typeof(services.commands.Configuration.MapperConfiguration));
                    scanner.AssemblyContainingType(typeof(services.queries.Configuration.MapperConfiguration));
                    scanner.ConnectImplementationsToTypesClosing(typeof(IRequestHandler<>)); // Handlers with no response
                    scanner.ConnectImplementationsToTypesClosing(typeof(IRequestHandler<,>)); // Handlers with a response
                    scanner.ConnectImplementationsToTypesClosing(typeof(IAsyncRequestHandler<>)); // Async handlers with no response
                    scanner.ConnectImplementationsToTypesClosing(typeof(IAsyncRequestHandler<,>)); // Async Handlers with a response
                    scanner.ConnectImplementationsToTypesClosing(typeof(INotificationHandler<>));
                    scanner.ConnectImplementationsToTypesClosing(typeof(IAsyncNotificationHandler<>));
                    scanner.WithDefaultConventions();
                });

                cfg.For(typeof(IPipelineBehavior<,>)).Add(typeof(RequestPreProcessorBehavior<,>));
                cfg.For(typeof(IPipelineBehavior<,>)).Add(typeof(RequestPostProcessorBehavior<,>));

                cfg.For(typeof(IRequestPreProcessor<>)).Add(typeof(PreProcessingBehavior<>));
                cfg.For(typeof(IPipelineBehavior<,>)).Add(typeof(LoggingBehavior<,>));
                cfg.For(typeof(IRequestPostProcessor<,>)).Add(typeof(PostProcessingBehavior<,>));

                cfg.For<DemoContext>().Use(_ => new DemoContext());
                cfg.For<DemoContextReadOnly>().Use(_ => new DemoContextReadOnly());

                cfg.For<SingleInstanceFactory>().Use<SingleInstanceFactory>(ctx => t => ctx.GetInstance(t)).ContainerScoped();
                cfg.For<MultiInstanceFactory>().Use<MultiInstanceFactory>(ctx => t => ctx.GetAllInstances(t)).ContainerScoped();
                cfg.For<IMediator>().Use<Mediator>();

                cfg.Populate(services);
            });

            return container.GetInstance<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("policy");
            new MapperConfiguration().Config();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseSpaStaticFiles();
            app.MapWhen(x => !ExcludePaths.Any(path => x.Request.Path.Value.ToLower().StartsWith($"/{path.ToLower()}")), builder =>
            {
                app.UseSpa(spa =>
                {
                    // To learn more about options for serving an Angular SPA from ASP.NET Core,
                    // see https://go.microsoft.com/fwlink/?linkid=864501

                    spa.Options.SourcePath = "ClientApp";

                    if (env.IsDevelopment())
                    {
                        spa.UseAngularCliServer(npmScript: "start");
                    }
                });
            });

            app.UseMvc();
            app.UseSwagger(c =>
            {
                c.PreSerializeFilters.Add((swaggerDoc, httpReq) => swaggerDoc.Host = httpReq.Host.Value);
            });

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
