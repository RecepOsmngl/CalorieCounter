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
        public dynamic UserServiceFill()
        {
            using (_db = new CalorieCounterContext())
            {

                var UserServiceFill = _db.UserEntityTable.Select(x => new
                {
                    UserId=x.UserID,
                    UserMail = x.UserMail,
                    UserName = x.UserName,
                    UserSurname = x.UserSurname
                }).ToList();
                return UserServiceFill;
            }
        }

    
        public int BreakfastTotalCalorie(UserEntity user)
        {
            using (_db = new CalorieCounterContext())
            {
                int TotalCalorie = _db.MealEntityTable.Where(x => x.UserID == user.UserID && x.MealCategoryID == 1 && x.MealTime== DateTime.Today)
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

        public dynamic BreakfastFoodList(UserEntity selectedUser)
        {
            using (_db = new CalorieCounterContext())
            {
                var breakfastFoodList = _db.MealEntityTable.Where(x => x.MealCategoryEntity.MealCategoryID == 1 && x.UserID == selectedUser.UserID).GroupBy(x => x.FoodEntity.FoodName).Select(x => new
                {
                    FoodName = x.Key,
                    SumFoodCount = x.Sum(x => x.FoodPortion)
                }).OrderByDescending(x => x.SumFoodCount).ToList();
                return breakfastFoodList;
            }
        }
        public dynamic LunchFoodList(UserEntity selectedUser)
        {
            using (_db = new CalorieCounterContext())
            {
                var lunchFoodList = _db.MealEntityTable.Where(x => x.MealCategoryEntity.MealCategoryID == 2 && x.UserID == selectedUser.UserID).GroupBy(x => x.FoodEntity.FoodName).Select(x => new
                {
                    FoodName = x.Key,
                    SumFoodCount = x.Sum(x => x.FoodPortion)
                }).OrderByDescending(x => x.SumFoodCount).ToList();
                return lunchFoodList;
            }
        }
        public dynamic DinnerFoodList(UserEntity selectedUser)
        {
            using (_db = new CalorieCounterContext())
            {
                var dinnerFoodList = _db.MealEntityTable.Where(x => x.MealCategoryEntity.MealCategoryID == 3 && x.UserID == selectedUser.UserID).GroupBy(x => x.FoodEntity.FoodName).Select(x => new
                {
                    FoodName = x.Key,
                    SumFoodCount = x.Sum(x => x.FoodPortion)
                }).OrderByDescending(x => x.SumFoodCount).ToList();
                return dinnerFoodList;
            }
        }
        public dynamic SnacksFoodList(UserEntity selectedUser)
        {
            using (_db = new CalorieCounterContext())
            {
                var snacksFoodList = _db.MealEntityTable.Where(x => x.MealCategoryEntity.MealCategoryID == 4 && x.UserID == selectedUser.UserID).GroupBy(x => x.FoodEntity.FoodName).Select(x => new
                {
                    FoodName = x.Key,
                    SumFoodCount = x.Sum(x => x.FoodPortion)
                }).OrderByDescending(x => x.SumFoodCount).ToList();
                return snacksFoodList;
            }
        }
        DateTime oneWeekAgo = DateTime.Today.AddDays(-7);
        DateTime oneMonthAgo = DateTime.Today.AddMonths(-1);
        public dynamic BreakfastWeeklyMealCompareList(UserEntity selectedUser)
        {
            using (_db = new CalorieCounterContext())
            {
                var BreakfastCompareList = _db.MealEntityTable.Where(x => x.MealCategoryEntity.MealCategoryID == 1 && (oneWeekAgo <= x.MealTime && x.MealTime <= DateTime.Today)).GroupBy(x => x.MealCategoryID).Select(x => new
                {
                    TotalUserBreakfastCalori = x.Where(x => x.UserID == selectedUser.UserID).Sum(x => x.FoodTotalCalorie),
                    AverageBreakfastCalori = x.Average(x => x.FoodTotalCalorie)
                }).ToList();
                return BreakfastCompareList;
            }
        }
        public dynamic LunchWeeklyMealCompareList(UserEntity selectedUser)
        {
            using (_db = new CalorieCounterContext())
            {
                var LunchCompareList = _db.MealEntityTable.Where(x => x.MealCategoryEntity.MealCategoryID == 2 && (oneWeekAgo <= x.MealTime && x.MealTime <= DateTime.Today)).GroupBy(x => x.MealCategoryID).Select(x => new
                {
                    TotalUserLunchCalori = x.Where(x => x.UserID == selectedUser.UserID).Sum(x => x.FoodTotalCalorie),
                    AverageLunchCalori = x.Average(x => x.FoodTotalCalorie)
                }).ToList();
                return LunchCompareList;
            }
        }
        public dynamic DinnerWeeklyMealCompareList(UserEntity selectedUser)
        {
            using (_db = new CalorieCounterContext())
            {
                var DinnerCompareList = _db.MealEntityTable.Where(x => x.MealCategoryEntity.MealCategoryID == 3 && (oneWeekAgo <= x.MealTime && x.MealTime <= DateTime.Today)).GroupBy(x => x.MealCategoryID).Select(x => new
                {
                    TotalUserDinnerCalori = x.Where(x => x.UserID == selectedUser.UserID).Sum(x => x.FoodTotalCalorie),
                    AverageDinnerCalori = x.Average(x => x.FoodTotalCalorie)
                }).ToList();
                return DinnerCompareList;
            }
        }
        public dynamic SnacksWeeklyMealCompareList(UserEntity selectedUser)
        {
            using (_db = new CalorieCounterContext())
            {
                var SnacksCompareList = _db.MealEntityTable.Where(x => x.MealCategoryEntity.MealCategoryID == 4 && (oneWeekAgo <= x.MealTime && x.MealTime <= DateTime.Today)).GroupBy(x => x.MealCategoryID).Select(x => new
                {
                    TotalUserSnacksCalori = x.Where(x => x.UserID == selectedUser.UserID).Sum(x => x.FoodTotalCalorie),
                    AverageSnacksCalori = x.Average(x => x.FoodTotalCalorie)
                }).ToList();
                return SnacksCompareList;
            }
        }
        public dynamic BreakfastMonthlyMealCompareList(UserEntity selectedUser)
        {
            using (_db = new CalorieCounterContext())
            {
                var BreakfastCompareList = _db.MealEntityTable.Where(x => x.MealCategoryEntity.MealCategoryID == 1 && (oneMonthAgo <= x.MealTime && x.MealTime <= DateTime.Today)).GroupBy(x => x.MealCategoryID).Select(x => new
                {
                    TotalUserBreakfastCalori = x.Where(x => x.UserID == selectedUser.UserID).Sum(x => x.FoodTotalCalorie),
                    AverageBreakfastCalori = x.Average(x => x.FoodTotalCalorie)
                }).ToList();
                return BreakfastCompareList;
            }
        }
        public dynamic LunchMonthlyMealCompareList(UserEntity selectedUser)
        {
            using (_db = new CalorieCounterContext())
            {
                var LunchCompareList = _db.MealEntityTable.Where(x => x.MealCategoryEntity.MealCategoryID == 2 && (oneMonthAgo <= x.MealTime && x.MealTime <= DateTime.Today)).GroupBy(x => x.MealCategoryID).Select(x => new
                {
                    TotalUserLunchCalori = x.Where(x => x.UserID == selectedUser.UserID).Sum(x => x.FoodTotalCalorie),
                    AverageLunchCalori = x.Average(x => x.FoodTotalCalorie)
                }).ToList();
                return LunchCompareList;
            }
        }
        public dynamic DinnerMonthlyMealCompareList(UserEntity selectedUser)
        {
            using (_db = new CalorieCounterContext())
            {
                var DinnerCompareList = _db.MealEntityTable.Where(x => x.MealCategoryEntity.MealCategoryID == 3 && (oneMonthAgo <= x.MealTime && x.MealTime <= DateTime.Today)).GroupBy(x => x.MealCategoryID).Select(x => new
                {
                    TotalUserDinnerCalori = x.Where(x => x.UserID == selectedUser.UserID).Sum(x => x.FoodTotalCalorie),
                    AverageDinnerCalori = x.Average(x => x.FoodTotalCalorie)
                }).ToList();
                return DinnerCompareList;
            }
        }
        public dynamic SnacksMonthlyMealCompareList(UserEntity selectedUser)
        {
            using (_db = new CalorieCounterContext())
            {
                var SnacksCompareList = _db.MealEntityTable.Where(x => x.MealCategoryEntity.MealCategoryID == 4 && (oneMonthAgo <= x.MealTime && x.MealTime <= DateTime.Today)).GroupBy(x => x.MealCategoryID).Select(x => new
                {
                    TotalUserSnacksCalori = x.Where(x => x.UserID == selectedUser.UserID).Sum(x => x.FoodTotalCalorie),
                    AverageSnacksCalori = x.Average(x => x.FoodTotalCalorie)
                }).ToList();
                return SnacksCompareList;
            }
        }
    }
}
