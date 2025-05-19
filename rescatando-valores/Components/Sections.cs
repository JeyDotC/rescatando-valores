using JeyDotC.JustCs;
using JeyDotC.JustCs.Html.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rescatando_valores.Components
{
    internal class HeaderSection : ComponentElement
    {
        protected override Element Render(IElementAttributes? attributes) => _(Children);
    }

    internal class LateScriptsSection : ComponentElement
    {
        protected override Element Render(IElementAttributes? attributes) => _(Children);
    }
}
