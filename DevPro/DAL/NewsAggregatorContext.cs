using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Entities;

namespace DAL
{
    public class NewsAggregatorContext : DbContext
    {
        public IDbSet<Resource> Resources { get; set; }

        public IDbSet<Feed> Feeds { get; set; }

        public NewsAggregatorContext()
            : base("NewsAggregatorContext")
        {
        }

    }
}
