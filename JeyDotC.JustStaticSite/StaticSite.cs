using JeyDotC.JustCs;
using JeyDotC.JustCs.Html.Attributes;

namespace JeyDotC.JustStaticSite
{
    public class StaticSite(string basePath)
    {
        private readonly string _basePath = basePath;

        private string? _staticContents;

        private readonly IDictionary<string, IView> _pages = new Dictionary<string, IView>();

        public StaticSite WithStaticContent(string path)
        {
            _staticContents = path;

            return this;
        }

        public StaticSite Add<TElement>(string path, IElementAttributes? props = null)
            where TElement : Element, new()
        {
            AddPage(path, new View<TElement>(props));

            return this;
        }

        public StaticSite AddPage(string path, IView view)
        {
            if (string.IsNullOrEmpty(path))
                throw new ArgumentException("Path cannot be null or empty.", nameof(path));

            if (view == null)
                throw new ArgumentNullException(nameof(view));

            _pages[path] = view;

            return this;
        }

        public void GeneratePages()
        {
            var directory = new DirectoryInfo(_basePath);
            if (!directory.Exists)
            {
                directory.Create();
            }

            foreach (var (file, view) in _pages)
            {
                var targetFile = new FileInfo(Path.Combine(_basePath, file));
                if (!targetFile.Exists)
                {
                    targetFile.Create().Close();
                }

                var pageContent = view.GetElement().RenderAsHtml();

                File.WriteAllText(targetFile.FullName, pageContent);
            }

            if(_staticContents is null)
            {
                return;
            }

            var staticContentsDiractory = new DirectoryInfo(_staticContents);

            if(!staticContentsDiractory.Exists)
            {
                return;
            }

            CopyFilesRecursively(staticContentsDiractory.FullName, directory.FullName);
        }

        private static void CopyFilesRecursively(string sourcePath, string targetPath)
        {
            //Now Create all of the directories
            foreach (string dirPath in Directory.GetDirectories(sourcePath, "*", SearchOption.AllDirectories))
            {
                Directory.CreateDirectory(dirPath.Replace(sourcePath, targetPath));
            }

            //Copy all the files & Replaces any files with the same name
            foreach (string newPath in Directory.GetFiles(sourcePath, "*.*", SearchOption.AllDirectories))
            {
                File.Copy(newPath, newPath.Replace(sourcePath, targetPath), true);
            }
        }
    }
}
