using JeyDotC.JustCs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rescatando_valores
{
    internal static class ComponentExtensions
    {
        public static (IEnumerable<TElement1>, IEnumerable<Element>) GroupElements<TElement1>(this IEnumerable<Element> elements)
            where TElement1 : Element
        {
            var elementsGroup1 = new List<TElement1>();
            var allOtherElements = new List<Element>();

            foreach (var element in elements)
            {
                var elementOfType1 = element as TElement1;
                if (elementOfType1 != null)
                {
                    elementsGroup1.Add(elementOfType1);
                }
                else
                {
                    allOtherElements.Add(element);
                }
            }

            return (elementsGroup1, allOtherElements);
        }

        public static (IEnumerable<TElement1>, IEnumerable<TElement2>, IEnumerable<Element>) GroupElements<TElement1, TElement2>(this IEnumerable<Element> elements)
            where TElement1 : Element
            where TElement2 : Element
        {
            var allOtherElements = new List<Element>();
            var elementsGroup2 = new List<TElement2>();

            var (elementsGroup1, remainingElements) = elements.GroupElements<TElement1>();

            foreach (var element in remainingElements)
            {
                var elementOfType2 = element as TElement2;
                if (elementOfType2 != null)
                {
                    elementsGroup2.Add(elementOfType2);
                }
                else
                {
                    allOtherElements.Add(element);
                }
            }

            return (elementsGroup1, elementsGroup2, allOtherElements);
        }
    }
}
