using System;
using System.Collections.Generic;
using System.Linq;
using HimalayaDotnet;
using HTMLDocStructure.elements;

namespace HTMLDocStructure
{
    public class DocStructure: IDocElement
    {
        public List<IDocElement> Children { get; set; } = new List<IDocElement>();
        private IDocElement ProcessElement(HimalayaElement hElement)
        {
            IDocElement docElement = null;
            switch (hElement.TagName)
            {
                case "p":
                    docElement = new DocParagraph { };
                    break;
                case "h1":
                case "h2":
                case "h3":
                case "h4":
                case "h5":
                    var level = int.Parse(hElement.TagName.Substring(1, 1));
                    docElement = new DocHeading { Level = level };
                    break;
                case "b":
                case "strong":
                    docElement = new DocStyle { FormattingType = FormattingType.Bold };
                    break;
                case "i":
                    docElement = new DocStyle { FormattingType = FormattingType.Italic };
                    break;
                case "table":
                    docElement = new DocTable { };
                    break;
                case "tr":
                    docElement = new DocRow { };
                    break;
                case "th":
                case "td":
                    docElement = new DocCell { };
                    break;
                case "":
                    switch (hElement.Type)
                    {
                        case "text":
                            docElement = new DocText { Text = hElement.Content };
                            break;
                    }
                    break;
                default:
                    docElement = new DocElement { };
                    break;
            }
            if (docElement == null) return null;
            foreach (var hChild in hElement.Children)
            {
                var docChild = ProcessElement(hChild);
                if (docChild != null)
                {
                    docElement.Children.Add(docChild);
                }
            }
            return docElement;
        }

        public static DocStructure FromHimalaya(IEnumerable<HimalayaElement> himalayaElements)
        {
            var d = new DocStructure();
            foreach (var hElement in himalayaElements)
            {
                var docElement = d.ProcessElement(hElement);
                if (docElement != null)
                {
                    d.Children.Add(docElement);
                }
            }
            return d;
        }
    }
}
