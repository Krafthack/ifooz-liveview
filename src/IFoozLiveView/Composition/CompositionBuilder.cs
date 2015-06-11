using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IFoozLiveView.Services;
using Microsoft.Framework.DependencyInjection;

namespace IFoozLiveView.Composition
{
    public static class CompositionBuilder
    {
        public static void RegisterDependencies(IServiceCollection services)
        {
            services.AddTransient<IGameStateService, GameStateTestData>();

        }
    }
}
