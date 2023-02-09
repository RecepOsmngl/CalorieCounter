using CalorieCounterDataAccess;
using CalorieCounterEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterBusiness.Services
{
    public class UserService
    {
        CalorieCounterContext _db = new CalorieCounterContext();

        // Login Form Methods
        public bool UserLogin(UserEntity _UserEntity)
        {
            var _UserCheck = _db.UserEntityTable.Where(x => x.UserMail == _UserEntity.UserMail && x.UserPassword == _UserEntity.UserPassword).ToList();

            if (_UserCheck.Count != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        // Registration Form Methods
        public bool AddUser(UserEntity _UserEntity)
        {
            _db.UserEntityTable.Add(_UserEntity);

            int _count = _db.SaveChanges();
            if (_count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckUserExistence(UserEntity _UserEntity)
        {
            var _result = _db.UserEntityTable.Where(x => x.UserMail == _UserEntity.UserMail).Count();
            if(_result == 0)
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
