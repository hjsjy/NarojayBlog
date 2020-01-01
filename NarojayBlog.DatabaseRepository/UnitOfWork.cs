using NarojayBlog.DatabaseRepository.DbContext;

namespace NarojayBlog.DatabaseRepository
{
    public class UnitOfWork : IUnitOfWork
    {
        public NarojayContext Context { get; }

        public UnitOfWork(NarojayContext context)
        {
            Context = context;
        }
        public void Commit()
        {
            Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();

        }
    }
}
