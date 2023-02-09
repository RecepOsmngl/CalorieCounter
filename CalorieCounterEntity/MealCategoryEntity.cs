using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterEntity
{
    public class MealCategoryEntity
    {
        // Field
        private int _MealCategoryID;
        private string? _MealCategoryName;

        // Relation
        private ICollection<MealEntity>? _MealEntity;

        // Property
        public int MealCategoryID { get => _MealCategoryID; set => _MealCategoryID = value; }
        public string? MealCategoryName { get => _MealCategoryName; set => _MealCategoryName = value; }

        // Relation
        public ICollection<MealEntity>? MealEntity { get => _MealEntity; set => _MealEntity = value; }

        // Constructor
        public MealCategoryEntity()
        {
            MealEntity = new HashSet<MealEntity>();
        }
    }
}
