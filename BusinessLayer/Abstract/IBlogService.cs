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
        List<Blog> GetBlogListWitWriter(int id);
        Blog GetByID(int id);
    }
}
