using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterEntity
{
    public class FoodCategoryEntity
    {
        // Field
        private int _FoodCategoryID;
        private string? _FoodCategoryName;

        // Relation
        private ICollection<FoodEntity>? _FoodEntity;

        // Property
        public int FoodCategoryID { get => _FoodCategoryID; set => _FoodCategoryID = value; }
        public string? FoodCategoryName { get => _FoodCategoryName; set => _FoodCategoryName = value; }

        // Relation
        public ICollection<FoodEntity>? FoodEntity { get => _FoodEntity; set => _FoodEntity = value; }

        // Constructor
        public FoodCategoryEntity()
        {
            FoodEntity = new HashSet<FoodEntity>();
        }
    }
}
