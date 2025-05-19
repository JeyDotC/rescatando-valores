using JeyDotC.JustCs;
using JeyDotC.JustCs.Html;
using JeyDotC.JustCs.Html.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rescatando_valores.Components
{
    internal record class PageProps : IElementAttributes
    {
        public string Title { get; init; } = string.Empty;
    }
    internal sealed class Page : ComponentElement<PageProps>
    {
        const string BOOTSTRAP_CSS = "https://cdn.jsdelivr.net/npm/bootstrap@5.3.6/dist/css/bootstrap.min.css";
        const string BOOTSTRAP_JS = "https://cdn.jsdelivr.net/npm/bootstrap@5.3.6/dist/js/bootstrap.bundle.min.js";

        protected override Element Render(PageProps? props)
        {
            var (headingSection, lateScriptsSection, children) = Children.GroupElements<HeaderSection, LateScriptsSection>();

            return _<Html>(new Attrs { Lang = "es" },
                        _<Head>(
                            _<Meta>(new Attrs { Charset = "utf-8" }),
                            _<Meta>(new Attrs { Name = "viewport", Content = "width=device-width, initial-scale=1" }),
                            _<Title>(props?.Title ?? string.Empty),
                            _<Link>(new Attrs { Href = BOOTSTRAP_CSS, Rel = "stylesheet" }),
                            _(headingSection)
                        ),
                        _<Body>(
                            _(children),
                            _<Script>(new Attrs { Src = BOOTSTRAP_JS }),
                            _(lateScriptsSection)
                        )
                    );
        }
    }
}
