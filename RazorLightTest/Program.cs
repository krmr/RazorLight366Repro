namespace RazorLightTest
{
    using System;
    using System.Globalization;
    using System.Threading.Tasks;

    using RazorLight;

    public class Program
    {
        static async Task Main(string[] args)
        {
            CultureInfo.CurrentUICulture = new CultureInfo("en-us");

            var engine = new RazorLightEngineBuilder()
                .UseEmbeddedResourcesProject(typeof(Program))
                .UseMemoryCachingProvider()
                .Build();

            var template = "Hello, @Model.Name. Welcome to RazorLight repository";
            var model = new ViewModel { Name = "John Doe" };

            var result = await engine.CompileRenderStringAsync("templateKey", template, model);
            Console.WriteLine(result);
        }

        public class ViewModel
        {
            public string Name { get; set; }
        }
    }
}