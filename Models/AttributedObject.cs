using dwweb_rhino.Models.Three;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dwweb_rhino.Models
{
    public class AttributedObject
    {
        public Guid Id { get; set; }
        public string Type { get; set; }

        public ThreeModel Geometry { get; set; }

        public List<Parameter> Parameters  { get; set; }
    }
}
