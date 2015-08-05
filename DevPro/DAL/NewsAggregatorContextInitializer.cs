using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NewsAggregatorContextInitializer : DropCreateDatabaseAlways<NewsAggregatorContext>
    {
        protected override void Seed(NewsAggregatorContext context)
        {
            #region Resource
            #endregion
            context.SaveChanges();

            #region Feed
            #endregion
            context.SaveChanges();
        }
    }
}
