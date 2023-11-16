using Calamatta.Application.Interfaces;
using Calamatta.Application.Repositories;
using Calamatta.Application.Services;
using Calamatta.Infrastructure.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Calamatta.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen();
            
            services.AddSingleton<IAgentService, AgentService>();
            services.AddSingleton<ISessionService, SessionService>();
            services.AddSingleton<ITeamService, TeamService>();
            services.AddSingleton<IChatSessionService, ChatSessionService>();
            services.AddSingleton<IAgentChatCoordinatorService, AgentChatCoordinatorService>();
            services.AddSingleton(typeof(IQueueService<>), typeof(QueueService<>));
            
            services.AddSingleton<ISessionRepository, SessionRepository>();
            services.AddSingleton<IAgentRepository, AgentRepository>();
            services.AddSingleton<ITeamRepository, TeamRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}