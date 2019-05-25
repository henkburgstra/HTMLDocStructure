using System;
using System.Collections.Generic;
using System.Text;

namespace HTMLDocStructure.elements
{
    public enum FormattingType
    {
        Normal, Bold, Underline, Italic
    }
    public class DocStyle: DocElement
    {
        public FormattingType FormattingType { get; set; } = FormattingType.Normal;
    }
}
