using System;
using System.Collections.Generic;
using System.Text;
using HTMLDocStructure;
using HimalayaDotnet;
using Xunit;

namespace HTMLDocStructureTest
{
    public class HTMLDocStructureTests
    {
        [Fact]
        public void FromHimalayaTest()
        {
            var hElements = new List<HimalayaElement>();
            var hRoot = new HimalayaElement
            {
                Type = "element",
                TagName = "div",
            };
            hElements.Add(hRoot);
            var docStructure = DocStructure.FromHimalaya(hElements);
            Assert.NotNull(docStructure);
            Assert.Single(docStructure.Children);
        }
    }
}
