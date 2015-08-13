using System;
using System.Collections.Generic;

namespace Model.Entities
{
    public class Resource : IGenericModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Tag { get; set; }
        public DateTime LastUpdateDate { get; set; }

        public string xPathBody { get; set; }
        public string xPathAuthor { get; set; }
        public string xPathDate { get; set; }
        public string xPathTitle { get; set; }
        public string xPathFeed { get; set; }
        public virtual ICollection<Feed> Feed { get; set; }

    }
}
