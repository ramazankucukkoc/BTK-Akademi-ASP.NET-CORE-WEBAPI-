using WebApi.Utilities.Formatters;

namespace WebApi.Extensions
{
    public static class IMVCBuilderExtensions
    {
        public static IMvcBuilder AddCustomCsvFormatter(this IMvcBuilder mvcBuilder) =>
            mvcBuilder.AddMvcOptions(config =>
            {
                config.OutputFormatters
                .Add(new CsvOutputFormatter());
            });
    }
}
