using CalorieCounterEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterEntity
{
    public class PhotographEntity
    {
        // Field
        private int _PhotographID;
        private string? _PhotographName;
        private string? _Photograph;

        // Relation
        private ICollection<FoodEntity>? _FoodEntity;

        // Property
        public int PhotographID { get => _PhotographID; set => _PhotographID = value; }
        public string? PhotographName { get => _PhotographName; set => _PhotographName = value; }
        public string? Photograph { get => _Photograph; set => _Photograph = value; }

        // Relation
        public ICollection<FoodEntity>? FoodEntity { get => _FoodEntity; set => _FoodEntity = value; }
        

        public PhotographEntity()
        {
            FoodEntity = new HashSet<FoodEntity>();
        }

    }
}
