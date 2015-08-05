using System;
using System.Reflection.Emit;

namespace Model.Entities
{
    public class Resource
    {
        public string Name { get; set; }
        public string Linq { get; set; }
        public string Tag { get; set; }
        public DateTime LastUpdateDate { get; set; }

        public virtual Feed Feed { get; set; }

    }
}
