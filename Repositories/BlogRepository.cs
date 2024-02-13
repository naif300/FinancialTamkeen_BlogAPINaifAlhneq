using FinancialTamkeen_BlogAPI.Data;
using FinancialTamkeen_BlogAPI.interfaces.Repositories;
using FinancialTamkeen_BlogAPI.Models;

namespace FinancialTamkeen_BlogAPI.Repositories
{
    public class BlogRepository : IBlogRepository
    {
        private readonly DataContext context;

        public BlogRepository(DataContext context)
        {
            this.context = context;
        }
        public bool BlogExists(int id)
        {
            return this.context.Blog.Any(c => c.id == id);
        }
        public ICollection<Blog> All()
        {
            return this.context.Blog.ToList();
        }

        public Blog GetById(int id)
        {
            return this.context.Blog.Find(id);
        }

        public bool Create(Blog Blog)
        {
            this.context.Blog.Add(Blog);
            return this.context.SaveChanges() > 0 ? true : false;
        }


        public bool Update(int id,Blog Blog)
        {
            var existingBlog = this.context.Blog.Find(id);
            if (existingBlog != null)
            {
                existingBlog.title = Blog.title;
                existingBlog.content = Blog.content;
                this.context.Blog.Update(existingBlog);
                return this.context.SaveChanges() > 0;
            }
            return false;
        }
    }
}