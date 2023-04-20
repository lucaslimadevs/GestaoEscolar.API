using GEscolar.Domain.Repositories;
using GEscolarAPI.Infra.SqlServer.Repositories;
using GEscolarAPI.Infra.SqlServer.UoW;

namespace GEscolar.API.Configutarion
{
    public static class DependencyInjection
    {
        public static void AddDIConfiguration(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IProfessorRepository, ProfessorRepository>();
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IDisciplinaRepository, DisciplinaRepository>();
            services.AddScoped<INotasBoletimRepository, NotasBoletimRepository>();
            services.AddScoped<IBoletimRepository, BoletimRepository>();
        }
    }

}
