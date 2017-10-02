﻿namespace core.template.api
{
    using core.template.dataAccess;
    using core.template.logic;
    using core.template.logic.PipeLine;
    using core.template.logic.Queries.Customer.Query;
    using MediatR;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Swashbuckle.AspNetCore.Swagger;
    using System.Reflection;
    using MediatR.Pipeline;
    using core.template.logic.Behaviors;
    using StructureMap;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var container = new Container();
            container.Configure(cfg =>
            {
                cfg.Scan(scanner =>
                {
                    scanner.AssemblyContainingType(typeof(Startup));
                    scanner.AssemblyContainingType(typeof(CustomerGetHandler));
                    scanner.ConnectImplementationsToTypesClosing(typeof(IRequestHandler<,>));
                    scanner.ConnectImplementationsToTypesClosing(typeof(IAsyncRequestHandler<,>));
                    scanner.ConnectImplementationsToTypesClosing(typeof(ICancellableAsyncRequestHandler<,>));
                    scanner.ConnectImplementationsToTypesClosing(typeof(INotificationHandler<>));
                    scanner.ConnectImplementationsToTypesClosing(typeof(IAsyncNotificationHandler<>));
                    scanner.ConnectImplementationsToTypesClosing(typeof(ICancellableAsyncNotificationHandler<>));
                    scanner.WithDefaultConventions();
                });

                cfg.For(typeof(IPipelineBehavior<,>)).Add(typeof(LoggingBehavior<,>));
                cfg.For(typeof(IPipelineBehavior<,>)).Add(typeof(PostProcessingBehavior<,>));
                cfg.For(typeof(IPipelineBehavior<,>)).Add(typeof(PreProcessingBehavior<,>));
            });
            
            services.AddMediatR(typeof(CustomerGetHandler).GetTypeInfo().Assembly);

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

            container.Populate(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors("policy");
            new Configuration().MapperConfiguration();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
