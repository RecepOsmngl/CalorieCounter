using CalorieCounterDataAccess;
using CalorieCounterEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterBusiness.Services
{
    public class FoodService
    {
        CalorieCounterContext _db = new CalorieCounterContext();

        // Yemek listesini databaseden liste halinde getiren ve liste olarak döndüren method.

        /// <summary>
        /// Returns foodentity table as a list
        /// </summary>
        /// <returns></returns>
        public dynamic FoodEntitie()
        {
            using (_db = new CalorieCounterContext())
            {
             var FoodList=_db.FoodEntityTable.Select(x => new
                {
                 FoodId=x.FoodID,
                    FoodName = x.FoodName,
                    FoodCategoryId=x.FoodCategoryID,
                    FoodCategoryName = x.FoodCategoryEntity.FoodCategoryName,
                    PhotographId = x.PhotographID,
                    FoodCalorie = x.FoodCalorie,
                    Photograph=x.PhotographEntity.Photograph
                }).OrderBy(x=>x.FoodName).ToList();
                return FoodList;
            }
        }
        public int FoodPhotographIdAdd(PhotographEntity photograph)
        {
            using(_db=new CalorieCounterContext())
            {
                int FoodPhotographId = _db.PhotographEntityTable.Where(x => x.Photograph == photograph.Photograph).Select(x => x.PhotographID).First();
                //int FoodEntity= FoodCategoryEntity.FoodCategoryID;
                return FoodPhotographId;
            }
        }
        public int FoodIdAdd(FoodCategoryEntity food)
        {
            using(_db=new CalorieCounterContext())
            {
                int FoodCategoryId = _db.FoodCategoryEntityTable.Where(x=>x.FoodCategoryName==food.FoodCategoryName).Select(x=>x.FoodCategoryID).First();
                 //int FoodEntity= FoodCategoryEntity.FoodCategoryID;
                return FoodCategoryId;
            }
        }


        //Yemeği database ekleyen method.

        /// <summary>
        /// Add FoodEntity to database, return true if succeded, else false.
        /// </summary>
        /// <param name="food"></param>
        /// <returns></returns>
        public bool FoodAdd(FoodEntity food)
        {
            using (_db = new CalorieCounterContext())
            {
                _db.FoodEntityTable.Add(food);
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
        public bool PhotographAdd(PhotographEntity photograph)
        {
            using (_db = new CalorieCounterContext())
            {
                _db.PhotographEntityTable.Add(photograph);
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


        // Yemeğin databasede olup olmadığını sorgulayan method.

        /// <summary>
        /// Checks food in database, return true if not exists, else false. 
        /// </summary>
        /// <param name="food"></param>
        /// <returns></returns>
        public bool FoodAddIsCheck(FoodEntity food)
        {
            using (_db = new CalorieCounterContext())
            {
                FoodEntity foodEntity = _db.FoodEntityTable.FirstOrDefault(x => x.FoodName == food.FoodName);
                if (foodEntity == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        // Yemeğin isminin,kategorisinin ve kalorisinin güncellemesini yapan method.

        /// <summary>
        /// Edit food name, food category ID, food calorie in database, return true if saved, else false.
        /// </summary>
        /// <param name="food"></param>
        /// <returns></returns>
        public bool FoodEdit(FoodEntity food)
        {
            using (_db = new CalorieCounterContext())
            {
                FoodEntity foodEntity = _db.FoodEntityTable.Find(food.FoodID);
                foodEntity.FoodName = food.FoodName;
                foodEntity.FoodCategoryID = food.FoodCategoryID;
                foodEntity.FoodCalorie = food.FoodCalorie;
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
        public bool PhotographEdit(PhotographEntity photograph)
        {
            using (_db = new CalorieCounterContext())
            {
                PhotographEntity photographEntity = _db.PhotographEntityTable.Where(x=>x.Photograph==photograph.Photograph).FirstOrDefault();
                photographEntity.PhotographName =photograph.PhotographName;
                photographEntity.PhotographID = photograph.PhotographID;
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

        //Yemeği databaseden silen method.

        /// <summary>
        /// Delete food in database, return true if saved, else false.
        /// </summary>
        /// <param name="food"></param>
        /// <returns></returns>
        public bool FoodDelete(FoodEntity food)
        {
            using (_db = new CalorieCounterContext())
            {
                FoodEntity foodEntity = _db.FoodEntityTable.Find(food.FoodID);
                _db.FoodEntityTable.Remove(foodEntity);
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

        // Yemeğin databasede sorgulamasını yapan ve sonucu liste olarak döndüren method.

        /// <summary>
        /// checks food in database, return it as a list if exists, else empty list.
        /// </summary>
        /// <param name="food"></param>
        /// <returns></returns>
        public dynamic FoodSearch(FoodEntity food)
        {
            using (_db = new CalorieCounterContext())
            {
                
               var foodEntity = _db.FoodEntityTable.Where(x => x.FoodName == food.FoodName).Select(x => new
                {
                    FoodId = x.FoodID,
                    FoodName = x.FoodName,
                    FoodCategoryId = x.FoodCategoryID,
                    FoodCategoryName = x.FoodCategoryEntity.FoodCategoryName,
                    PhotographId = x.PhotographID,
                    FoodCalorie = x.FoodCalorie,
                    Photograph = x.PhotographEntity.Photograph

                }).ToList();

              
                    return foodEntity;
           

            }
        }
        /// <summary>
        /// FoodcategoryId ile arama yapıp geriye string tipinde foodcategoryname döndüren method
        /// </summary>
        /// <param name="categoryid"></param>
        /// <returns></returns>
        public string ComeFoodCategoryName(int foodcategoryid)
        {
            using(_db=new CalorieCounterContext())
            {
                return _db.FoodCategoryEntityTable.Where(x => x.FoodCategoryID == foodcategoryid).Select(x => x.FoodCategoryName).First();
            }
          
        }
    }
}
