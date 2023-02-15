using CalorieCounterDataAccess;
using CalorieCounterEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterBusiness.Services
{
    public class FoodCategoryService
    {
        CalorieCounterContext _db = new CalorieCounterContext();

        // Değişiklikler
        // List<FoodCategoryEntity> foodCategoryEntities = new List<FoodCategoryEntity>();
        // Food Search'ün içinde, başka yerde foodentities kullanılmıyor zaten.

        // Burayı silek ctorunda gerek yok zaten using ile method içinde kullanıyoruz. food ekleme ıd ile alakası yok sanırım.
        public FoodCategoryService()
        {
            _db = new CalorieCounterContext();
        }

        // FoodCategory tablosundanki tüm veriyi liste halinde sqlden çağıran method.

        /// <summary>
        /// Returns foodcategoryentity table as a list
        /// </summary>
        /// <returns></returns>
        public List<FoodCategoryEntity> FoodCategoryEntitie()
        {
            using (_db = new CalorieCounterContext())
            {
                return _db.FoodCategoryEntityTable.ToList();
            }
        }

        //Yemek kategorisini database ekleyen method.

        /// <summary>
        /// Add foodcategoryentity to database, return true if succeded, else false.
        /// </summary>
        /// <param name="food"></param>
        /// <returns></returns>
        public bool FoodCategoryAdd(FoodCategoryEntity food)
        {
            using (_db = new CalorieCounterContext())
            {
                _db.FoodCategoryEntityTable.Add(food);
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

        // Eklenmek istenen yemeğin databasede olup olmadığını sorgulayan method.

        /// <summary>
        /// Checks foodcategory in database, return true if not exists, else false. 
        /// </summary>
        /// <param name="food"></param>
        /// <returns></returns>
        public bool FoodCategoryAddIsCheck(FoodCategoryEntity food)
        {
            using (_db = new CalorieCounterContext())
            {
                FoodCategoryEntity foodCategoryEntity = _db.FoodCategoryEntityTable.FirstOrDefault(x => x.FoodCategoryName == food.FoodCategoryName);
                if (foodCategoryEntity == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        //Kategori adı değişen yemeği database işleyen method.

        /// <summary>
        /// Edit food category name in database, return true if saved, else false.
        /// </summary>
        /// <param name="food"></param>
        /// <returns></returns>
        public bool FoodCategoryEdit(FoodCategoryEntity food)
        {
            using (_db = new CalorieCounterContext())
            {
                FoodCategoryEntity foodCategoryEntity = _db.FoodCategoryEntityTable.Find(food.FoodCategoryID);
                foodCategoryEntity.FoodCategoryName = food.FoodCategoryName;
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

        // kategoriyi databaseden silen method.

        /// <summary>
        /// Delete food category in database, return true if saved, else false.
        /// </summary>
        /// <param name="food"></param>
        /// <returns></returns>
        public bool FoodCategoryDelete(FoodCategoryEntity food)
        {
            using (_db = new CalorieCounterContext())
            {
                FoodCategoryEntity foodCategoryEntity = _db.FoodCategoryEntityTable.Find(food.FoodCategoryID);
                _db.FoodCategoryEntityTable.Remove(foodCategoryEntity);
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

        // Aranan kategorinin databasede sorgulamasını yapan method.

        /// <summary>
        /// checks food category in database, return it as a list if exists, else empty list.
        /// </summary>
        /// <param name="food"></param>
        /// <returns></returns>
        public List<FoodCategoryEntity> FoodCategorySearch(FoodCategoryEntity food)
        {
            using (_db = new CalorieCounterContext())
            {
                List<FoodCategoryEntity> foodCategoryEntities = new List<FoodCategoryEntity>();
                FoodCategoryEntity foodEntity = _db.FoodCategoryEntityTable.FirstOrDefault(x => x.FoodCategoryName == food.FoodCategoryName);
                if (foodEntity != null)
                {
                    foodCategoryEntities.Clear();
                    foodCategoryEntities.Add(foodEntity);
                    return foodCategoryEntities;
                }
                else
                {
                    foodCategoryEntities.Clear();
                    return foodCategoryEntities;
                }
            }
        }
        //foodcategoryservice
    }
}
