using System.Data.Entity;
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
