using FinancialTamkeen_BlogAPI.Models;

namespace FinancialTamkeen_BlogAPI.interfaces.Repositories
{
    public interface IBlogRepository
    {
        public bool BlogExists(int id);
        ICollection<Blog> All();
        Blog GetById(int id);
        bool Create(Blog Blog);
        bool Update(int id,Blog Blog);


    }
}