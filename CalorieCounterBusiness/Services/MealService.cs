using CalorieCounterDataAccess;
using CalorieCounterEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterBusiness.Services
{
    public class MealService
    {
        CalorieCounterContext _db;



        public dynamic MealEntitie(int userid)
        {
            using (_db = new CalorieCounterContext())
            {
               var MealEntitieTable= _db.MealEntityTable.Where(x => x.UserID == userid).Select(x => new
               {
                   UserId=x.UserID,
                   UserName=x.UserEntity.UserName,
                   FoodName=x.FoodEntity.FoodName,
                   MealCategoryName=x.MealCategoryEntity.MealCategoryName,
                   FoodPortion=x.FoodPortion,
                   FoodTotalCalorie=x.FoodTotalCalorie,
                   MealTime=x.MealTime
               }).OrderByDescending(x=>x.MealTime).ToList();
                return MealEntitieTable;
            }
        }
        public List<MealCategoryEntity> MealCategoryEntitie()
        {
            using (_db = new CalorieCounterContext())
            {
                return _db.MealCategoryEntityTable.ToList();
            }
        }
        public int FoodIdAdd(FoodEntity food)
        {
            using (_db = new CalorieCounterContext())
            {
                int FoodId = _db.FoodEntityTable.Where(x => x.FoodName == food.FoodName).Select(x => x.FoodID).First();
                //int FoodEntity= FoodCategoryEntity.FoodCategoryID;
                return FoodId;
            }
        }
        public int FoodCalorie(FoodEntity food)
        {
            using (_db = new CalorieCounterContext())
            {
               int FoodCalorie = (int)_db.FoodEntityTable.Where(x => x.FoodName == food.FoodName).Select(x => x.FoodCalorie).First();
                //int FoodEntity= FoodCategoryEntity.FoodCategoryID;
                return FoodCalorie;
            }
        }
        public bool MealAdd(MealEntity meal)
        {
            using (_db = new CalorieCounterContext())
            {
                _db.MealEntityTable.Add(meal);
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
    }
}
