using JeyDotC.JustStaticSite;

namespace rescatando_valores
{
    internal class Program
    {
        private const string TARGET_BASE_PATH = "docs";
        private const string STATIC_CONTENTS_PATH = "rescatando-valores\\contents";

        static void Main(string[] args)
        {
            var rootDir = args[0];

            var site = new StaticSite(Path.Combine(rootDir, TARGET_BASE_PATH));

            site.WithStaticContent(Path.Combine(rootDir, STATIC_CONTENTS_PATH))
                .Add<Pages.Index>("index.html")
                .GeneratePages();
        }
    }
}
