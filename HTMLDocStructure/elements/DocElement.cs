using System;
using System.Collections.Generic;
using System.Text;

namespace HTMLDocStructure.elements
{
    public class DocElement: IDocElement
    {
        public List<IDocElement> Children { get; set; } = new List<IDocElement>();
    }
}
