using System;
using System.Collections.Generic;
using System.Text;

namespace HTMLDocStructure.elements
{
    public interface IDocElement
    {
        List<IDocElement> Children { get; set; }
    }
}
