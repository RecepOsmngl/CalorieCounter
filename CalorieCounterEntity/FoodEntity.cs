using CalorieCounterEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterEntity
{
    public class FoodEntity
    {
        // Field
        private int _FoodID;
        private string? _FoodName;
        private int? _FoodCategoryID;
        private int? _PhotographID;
        private int? _FoodCalorie;

        // Relation
        private ICollection<MealEntity>? _MealEntity;
        private FoodCategoryEntity? _FoodCategoryEntity;
        private PhotographEntity? _PhotographEntity;

        // Property
        public int FoodID { get => _FoodID; set => _FoodID = value; }
        public string? FoodName { get => _FoodName; set => _FoodName = value; }
        public int? FoodCategoryID { get => _FoodCategoryID; set => _FoodCategoryID = value; }
        public int? PhotographID { get => _PhotographID; set => _PhotographID = value; }
        public int? FoodCalorie { get => _FoodCalorie; set => _FoodCalorie = value; }

        // Relation
        public ICollection<MealEntity>? MealEntity { get => _MealEntity; set => _MealEntity = value; }
        public FoodCategoryEntity? FoodCategoryEntity { get => _FoodCategoryEntity; set => _FoodCategoryEntity = value; }
        public PhotographEntity? PhotographEntity { get => _PhotographEntity; set => _PhotographEntity = value; }

        // Constructor
        public FoodEntity()
        {
            MealEntity = new HashSet<MealEntity>();
        }
    }
}
