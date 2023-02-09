using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterEntity
{
    public class UserEntity
    {
        // Field
        private int _UserID;
        private string _UserMail;
        private string _UserPassword;
        private string? _UserName;
        private string? _UserSurname;
        private int? _UserHeight;
        private int? _UserWeight;
        private string? _UserGender;

        // Relation
        private ICollection<MealEntity>? _MealEntity;

        // Property
        public int UserID { get => _UserID; set => _UserID = value; }
        public string UserMail { get => _UserMail; set => _UserMail = value; }
        public string UserPassword { get => _UserPassword; set => _UserPassword = value; }
        public string? UserName { get => _UserName; set => _UserName = value; }
        public string? UserSurname { get => _UserSurname; set => _UserSurname = value; }
        public int? UserHeight { get => _UserHeight; set => _UserHeight = value; }
        public int? UserWeight { get => _UserWeight; set => _UserWeight = value; }
        public string? UserGender { get => _UserGender; set => _UserGender = value; }

        // Relation
        public ICollection<MealEntity>? MealEntity { get => _MealEntity; set => _MealEntity = value; }

        // Constructor
        public UserEntity()
        {
            _UserMail = string.Empty;
            _UserPassword = string.Empty;
            _UserName = string.Empty;
            _UserSurname = string.Empty;
            _UserHeight = 0;
            _UserWeight = 0;
            _UserGender = string.Empty;

            MealEntity = new HashSet<MealEntity>();
        }
        
    }
}
