using System;
using System.Collections.Generic;

namespace Model.Entities
{
    public class Resource : IGenericModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Linq { get; set; }
        public string Tag { get; set; }
        public DateTime LastUpdateDate { get; set; }

        public virtual ICollection<Feed> Feed { get; set; }

    }
}
