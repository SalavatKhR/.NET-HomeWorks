using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Hosting;

namespace hw12
{
    public class CustomWebApplicationFactory<TStartup>:
        WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override IHostBuilder CreateHostBuilder()
        {
            return Host.
                CreateDefaultBuilder()
                .ConfigureWebHostDefaults
                (conf =>
                    { conf.UseStartup<Giraffe.App.Startup>().UseTestServer(); });
        }
    }
}