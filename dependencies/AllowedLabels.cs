using Elements;
using System;
using System.Linq;
using System.Collections.Generic;
using Elements.Geometry;
namespace Elements
{
    public class AllowedLabels : Element
    {
        public List<string> Labels { get; set; } = new List<string>();
    }
}