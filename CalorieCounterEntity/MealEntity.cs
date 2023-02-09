using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterEntity
{
    public class MealEntity
    {
        // Field
        private int _MealID;
        private int _MealCategoryID;
        private int _UserID;
        private int _FoodID;
        private int _FoodPortion;
        private int _FoodTotalCalorie;
        private DateTime _MealTime;

        // Relation
        private MealCategoryEntity? _MealCategoryEntity;
        private UserEntity? _UserEntity;
        private FoodEntity? _FoodEntity;

        // Property
        public int MealID { get => _MealID; set => _MealID = value; }
        public int MealCategoryID { get => _MealCategoryID; set => _MealCategoryID = value; }
        public int UserID { get => _UserID; set => _UserID = value; }
        public int FoodID { get => _FoodID; set => _FoodID = value; }
        public int FoodPortion { get => _FoodPortion; set => _FoodPortion = value; }
        public int FoodTotalCalorie { get => _FoodTotalCalorie; set => _FoodTotalCalorie = value; }
        public DateTime MealTime { get => _MealTime; set => _MealTime = value; }

        // Relation
        public MealCategoryEntity? MealCategoryEntity { get => _MealCategoryEntity; set => _MealCategoryEntity = value; }
        public UserEntity? UserEntity { get => _UserEntity; set => _UserEntity = value; }
        public FoodEntity? FoodEntity { get => _FoodEntity; set => _FoodEntity = value; }

        // Constructor
        public MealEntity()
        {

        }
    }
}
