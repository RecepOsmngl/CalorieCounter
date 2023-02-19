using CalorieCounterDataAccess;
using CalorieCounterEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterBusiness.Services
{
    public class ComparisonService
    {
        CalorieCounterContext _db;
        UserEntity _userEntity;

        // *********************
        public dynamic UserWeeklyFill(UserEntity userEntity)
        {
            using (_db = new CalorieCounterContext())
            {
                var oneWeekAgo = DateTime.Today.AddDays(-7);
                var averages = _db.MealEntityTable
                    .Where(m => m.MealTime >= oneWeekAgo) // son bir hafta 
                    .GroupBy(m => new { m.MealCategoryID, m.UserID }) // kategori ve kullanıcıya
                    .Select(g => new { UserId = g.Key.UserID, CategoryId = g.Key.MealCategoryID, AverageCalories = g.Average(m => m.FoodTotalCalorie) }) // her kategorideki yemeklerin ortalama kalori tüketimini hesaplayalım
                    .ToList();             
                return averages;
            }
        }

        public dynamic UserWeeklyFill2(UserEntity userEntity)
        {
            using (_db = new CalorieCounterContext())
            {
                var oneWeekAgo = DateTime.Today.AddDays(-7);
                var averages = _db.MealEntityTable
                    .Where(m => m.MealTime >= oneWeekAgo && m.UserID == userEntity.UserID) // son bir hafta 
                    .GroupBy(m => new { m.MealCategoryID, m.UserID }) // kategori ve kullanıcıya
                    .Select(g => new { UserId = g.Key.UserID, CategoryId = g.Key.MealCategoryID, UserCalories = g.Sum(g=>g.FoodTotalCalorie) }) // her kategorideki yemeklerin ortalama kalori tüketimini hesaplayalım
                    .ToList();
                return averages;
            }
        }

        // *********************
        public dynamic UserMonthlyFill(UserEntity userEntity)
        {
            using (_db = new CalorieCounterContext())
            {
                var oneMonthAgo = DateTime.Today.AddDays(-30);
                var averages = _db.MealEntityTable
                    .Where(m => m.MealTime >= oneMonthAgo) // son bir hafta 
                    .GroupBy(m => new { m.MealCategoryID, m.UserID }) // kategori ve kullanıcıya
                    .Select(g => new { UserId = g.Key.UserID, CategoryId = g.Key.MealCategoryID, AverageCalories = g.Average(m => m.FoodTotalCalorie) }) // her kategorideki yemeklerin ortalama kalori tüketimini hesaplayalım
                    .ToList();
                return averages;
            }
        }

        // *********************
        public dynamic UserMontlyhFill2(UserEntity userEntity)
        {
            using (_db = new CalorieCounterContext())
            {
                using (_db = new CalorieCounterContext())
                {
                    var oneMonthAgo = DateTime.Today.AddDays(-30);
                    var averages = _db.MealEntityTable
                        .Where(m => m.MealTime >= oneMonthAgo && m.UserID == userEntity.UserID) // son bir hafta 
                        .GroupBy(m => new { m.MealCategoryID, m.UserID }) // kategori ve kullanıcıya
                        .Select(g => new { UserId = g.Key.UserID, CategoryId = g.Key.MealCategoryID, UserCalories = g.Sum(g => g.FoodTotalCalorie) }) // her kategorideki yemeklerin ortalama kalori tüketimini hesaplayalım
                        .ToList();
                    return averages;
                }
            }
        }


    }
}
