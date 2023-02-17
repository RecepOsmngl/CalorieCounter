using CalorieCounterDataAccess;
using CalorieCounterEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterBusiness.Services
{
    public class AdminStatsService
    {
        CalorieCounterContext _db;
        UserEntity _userEntity;
        public List<UserEntity> UserServiceFill()
        {
            using (_db = new CalorieCounterContext())
            {

                return _db.UserEntityTable.ToList();

            }



        }
        public int BreakfastTotalCalorie(UserEntity user)
        {
            using (_db = new CalorieCounterContext())
            {
                int TotalCalorie = _db.MealEntityTable.Where(x => x.UserID == user.UserID && x.MealCategoryID == 1 && x.MealTime==DateTime.Today )
                .Sum(x => x.FoodTotalCalorie);
                return TotalCalorie;
            }

        }
        public int LunchTotalCalorie(UserEntity user)
        {
            using (_db = new CalorieCounterContext())
            {
                int TotalCalorie = _db.MealEntityTable.Where(x => x.UserID == user.UserID && x.MealCategoryID == 2 && x.MealTime == DateTime.Today)
                .Sum(x => x.FoodTotalCalorie);
                return TotalCalorie;
            }
        }
        public int DinnerTotalCalorie(UserEntity user)
        {
            using (_db = new CalorieCounterContext())
            {
                int TotalCalorie = _db.MealEntityTable.Where(x => x.UserID == user.UserID && x.MealCategoryID == 3 && x.MealTime == DateTime.Today)
                .Sum(x => x.FoodTotalCalorie);
                return TotalCalorie;
            }
        }
        public int SnackTotalCalorie(UserEntity user)
        {
            using (_db = new CalorieCounterContext())
            {
                int TotalCalorie = _db.MealEntityTable.Where(x => x.UserID == user.UserID && x.MealCategoryID == 4 && x.MealTime == DateTime.Today)
                .Sum(x => x.FoodTotalCalorie);
                return TotalCalorie;
            }
        }
    }
}
