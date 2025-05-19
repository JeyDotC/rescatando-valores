using JeyDotC.JustCs;
using JeyDotC.JustCs.Html;
using JeyDotC.JustCs.Html.Attributes;
using rescatando_valores.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rescatando_valores.Pages
{
    internal class Index : ComponentElement
    {
        protected override Element Render(IElementAttributes? attributes)
        => _<Page>(new PageProps { Title = "Rescatando Valores" },
                _<H1>("Bienvenidos a Rescatando Valores!"),

                _<LateScriptsSection>(
                    _<Script>(new Attrs { Src = "/js/index.js", Type = "text/javascript" })
                )
            );
    }
}
