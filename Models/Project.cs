using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dwweb_rhino.Models
{
    public class Project
    {
        public string Name { get; set; }

        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public List<AttributedObject> Objects { get; set; }
    }
}
