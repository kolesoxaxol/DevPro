using System.Data.Entity;

namespace DAL
{
    public class NewsAggregatorContextInitializer : DropCreateDatabaseIfModelChanges<NewsAggregatorContext>
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
