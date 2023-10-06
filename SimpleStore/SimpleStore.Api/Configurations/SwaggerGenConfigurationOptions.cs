using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace SimpleStore.Api.Configurations
{
    internal class SwaggerGenConfigurationOptions : IConfigureOptions<SwaggerGenOptions>
    {
        private readonly IApiVersionDescriptionProvider provider;

        public SwaggerGenConfigurationOptions(IApiVersionDescriptionProvider provider)
        {
            this.provider = provider;
        }

        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(
                    description.GroupName,
                    new OpenApiInfo
                    {
                        Title = "SimpleStore API",
                        Version = description.ApiVersion.ToString(),
                        Description = "A simple product operations API",
                        TermsOfService = new Uri("https://simplestore.cz/terms"),
                        Contact = new OpenApiContact
                        {
                            Name = "SimpleStore",
                            Email = "info@simplestore.cz",
                            Url = new Uri("https://simplestore.cz/contact"),
                        },
                    });
            }
        }
    }
}
