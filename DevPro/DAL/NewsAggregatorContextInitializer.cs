using System.Data.Entity;

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
