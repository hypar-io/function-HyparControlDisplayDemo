using Elements;
using System;
using System.Linq;
using System.Collections.Generic;
using Elements.Geometry;
using Elements.Geometry.Solids;
using Newtonsoft.Json;

namespace Elements
{
    public class DemoElement : GeometricElement
    {
        public string? Label { get; set; }
        public Profile? Profile { get; set; }

        [JsonProperty("Add Id")]
        public string? AddId { get; set; }

        public override void UpdateRepresentations()
        {
            if (Profile == null)
            {
                return;
            }
            Representation = new Extrude(Profile, 0.1, Vector3.ZAxis, false);
        }
    }
}