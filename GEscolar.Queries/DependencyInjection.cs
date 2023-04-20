﻿using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace GEscolar.Queries
{
    public static class DependencyInjection
    {
        public static void AddQueries(this IServiceCollection services)
        {
            services.AddMediatR(typeof(DependencyInjection));
        }
    }
}