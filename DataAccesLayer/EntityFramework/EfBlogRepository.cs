﻿using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using DataAccesLayer.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccesLayer.EntityFramework
{
    public class EfBlogRepository : GenericRepository<Blog>, IBlogDal
    {
        /// <summary>
        /// Liste içerisindeki her bir Blog nesnesine ilişkili Category nesnesi de dahil edilerek çağrılır.
        /// </summary>
        /// <returns></returns>
        public List<Blog> GetListWithCategory()
        {
            using (var c= new Context())
            {
                return c.Blogs.Include(x => x.Category).ToList();
            }
        }

        public List<Blog> GetListWithCategoryByWriter(int WriterId)
        {
            using (var c = new Context())
            {
                return c.Blogs.Include(x => x.Category).Where(x=>x.WriterID == WriterId).ToList();
            }
        }
    }
}
