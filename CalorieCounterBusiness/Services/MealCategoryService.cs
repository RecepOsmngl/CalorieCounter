using CalorieCounterDataAccess;
using CalorieCounterEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterBusiness.Services
{
    public class MealCategoryService
    {
        CalorieCounterContext _db = new CalorieCounterContext();

        /// <summary>
        /// Returns mealcategoryentity table as a list
        /// </summary>
        /// <returns></returns>
        public List<MealCategoryEntity> MealCategories()
        {
            using (_db = new CalorieCounterContext())
            {
                return _db.MealCategoryEntityTable.ToList();
            }
        }

        /// <summary>
        /// Add mealcategoryentity to database, return true if succeded, else false.
        /// </summary>
        /// <param name="_mealCategory"></param>
        /// <returns></returns>
        public bool _MealCategoryAdd(MealCategoryEntity _mealCategory)
        {
            using (_db = new CalorieCounterContext())
            {
                _db.MealCategoryEntityTable.Add(_mealCategory);
                int count = _db.SaveChanges();
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Checks mealcategory in database, return true if not exists, else false. 
        /// </summary>
        /// <param name="_mealCategory"></param>
        /// <returns></returns>
        public bool _MealCategoryAddIsCheck(MealCategoryEntity _mealCategory)
        {
            using (_db = new CalorieCounterContext())
            {
                MealCategoryEntity mealCategory = _db.MealCategoryEntityTable.FirstOrDefault(x => x.MealCategoryName == _mealCategory.MealCategoryName);
                if (mealCategory == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Edit meal category name in database, return true if saved, else false.
        /// </summary>
        /// <param name="_mealCategory"></param>
        /// <returns></returns>
        public bool _MealCategoryEdit(MealCategoryEntity _mealCategory)
        {
            using (_db = new CalorieCounterContext())
            {
                MealCategoryEntity _mealCategoryEntity = _db.MealCategoryEntityTable.Find(_mealCategory.MealCategoryID);
                _mealCategoryEntity.MealCategoryName = _mealCategory.MealCategoryName;
                int count = _db.SaveChanges();
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Delete meal category in database, return true if saved, else false.
        /// </summary>
        /// <param name="_mealCategory"></param>
        /// <returns></returns>
        public bool _MealCategoryDelete(MealCategoryEntity _mealCategory)
        {
            using (_db = new CalorieCounterContext())
            {
                MealCategoryEntity _mealCategoryEntity = _db.MealCategoryEntityTable.FirstOrDefault(x => x.MealCategoryName == _mealCategory.MealCategoryName);
                _db.MealCategoryEntityTable.Remove(_mealCategoryEntity);
                int count = _db.SaveChanges();
                if (count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// checks food category in database, return it as a list if exists, else empty list.
        /// </summary>
        /// <param name="_mealCategory"></param>
        /// <returns></returns>
        public List<MealCategoryEntity> _MealCategorySearch(MealCategoryEntity _mealCategory)
        {
            using (_db = new CalorieCounterContext())
            {
                List<MealCategoryEntity> _categories = new List<MealCategoryEntity>();
                MealCategoryEntity _mealCategoryEntity = _db.MealCategoryEntityTable.FirstOrDefault(x => x.MealCategoryName == _mealCategory.MealCategoryName);
                if (_mealCategoryEntity != null)
                {
                    _categories.Clear();
                    _categories.Add(_mealCategoryEntity);
                    return _categories;
                }
                else
                {
                    return _categories;
                }
            }
        }
    }
}
