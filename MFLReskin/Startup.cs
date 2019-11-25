using Microsoft.AspNetCore.Components.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using TG.Blazor.IndexedDB;

namespace MFLReskin
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIndexedDB(dbStore =>
            {
                dbStore.DbName = "MflPlayers";
                dbStore.Version = 5;

                dbStore.Stores.Add(new StoreSchema
                {
                    Name = "Players",
                    PrimaryKey = new IndexSpec { Name = "id", KeyPath = "id", Auto = false },
                    Indexes = new List<IndexSpec>
                    {
                        new IndexSpec{ Name="name", KeyPath = "name", Auto=false },
                        new IndexSpec{ Name="team", KeyPath = "team", Auto=false },
                        new IndexSpec{ Name="position", KeyPath = "position", Auto=false }
                    }
                });

                dbStore.Stores.Add(new StoreSchema
                {
                    Name = "Leagues",
                    PrimaryKey = new IndexSpec { Name = "leagueId", KeyPath = "leagueId", Auto = false }
                });

                dbStore.Stores.Add(new StoreSchema
                {
                    Name = "User",
                    PrimaryKey = new IndexSpec { Name = "userId", KeyPath = "userId", Auto = false }
                });
            });
        }

        public void Configure(IComponentsApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
