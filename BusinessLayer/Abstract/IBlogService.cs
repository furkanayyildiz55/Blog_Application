using EntityLayer.Concrete;


namespace BusinessLayer.Abstract
{
    public interface IBlogService
    {
        void BlogAdd(Blog blog);
        void BlogDelete(Blog blog);
        void BlogUpdate(Blog blog);
        List<Blog> GetList();
        List<Blog> GetBlogListWithCategory();
        Blog GetByID(int id);
    }
}
