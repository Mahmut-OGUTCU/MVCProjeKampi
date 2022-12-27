using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDAL _categoryDal;

        public CategoryManager(ICategoryDAL categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void CategoryAdd(Category p)
        {
            _categoryDal.Insert(p);
        }

        public void CategoryDelete(Category p)
        {
            _categoryDal.Delete(p);
        }

        public Category CategoryGetByID(int id)
        {
            return _categoryDal.Get(x => x.CategoryID == id && x.CategoryisActive == true);
        }

        public List<Category> CategoryGetList()
        {
            return _categoryDal.List(x => x.CategoryisActive == true);
        }

        public void CategoryUpdate(Category p)
        {
            _categoryDal.Update(p);
        }
    }
}
