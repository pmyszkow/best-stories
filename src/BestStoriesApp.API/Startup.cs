using System;
using System.Net.Mime;
using System.Security.Principal;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using BestStoriesApp.Core.Application;
using BestStoriesApp.Core.Port.IItemFinder;
using BestStoriesApp.Core.Port.IStoryQueryService;
using BestStoriesApp.Infrastructure.HackerNewsHttpItemFinderAdapter;

namespace BestStoriesApp.API
{
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

            services.AddControllers();
                //.AddJsonOptions(options =>
                //    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true);

            services.AddApiVersioning().AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BestStoriesApp.API", Version = "v1" });
            });

            services.AddScoped<IStoryQueryService, StoryQueryService>();
            services.AddScoped<IItemFinder, ItemFinderAdapter>();
            services.AddHttpClient<HackerNewsHttpClient>(c =>
            {
                c.BaseAddress = new Uri("https://hacker-news.firebaseio.com/v0/");
                c.DefaultRequestHeaders.Add("Accept", MediaTypeNames.Application.Json);
                c.DefaultRequestHeaders.Add("User-Agent", "HackerNewsHttpClient");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BestStoriesApp.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
