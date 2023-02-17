using CalorieCounterDataAccess;
using CalorieCounterEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CalorieCounterBusiness.Services
{
    public class UserService
    {
        CalorieCounterContext _db = new CalorieCounterContext();

        // 1.Login Form Methods
        // 2.Registration Form Methods
        // 3.Change Password Form Methods

        // Login Form Methods

        /// <summary>
        /// Checks the correctness of the username and password, returns true if they are matched, else false.
        /// </summary>
        /// <param name="_UserEntity"></param>
        /// <returns></returns>
        public string UserLogin(UserEntity _UserEntity)
        {
            CalorieCounterContext _db = new CalorieCounterContext();
            // var _UserCheck = _db.UserEntityTable.Where(x => x.UserMail == _UserEntity.UserMail && x.UserPassword == _UserEntity.UserPassword).ToList();
            //var _UserCheck = _db.UserEntityTable.Any(x => x.UserMail == _UserEntity.UserMail && x.UserPassword == _UserEntity.UserPassword);

            //if (_UserCheck)
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}

            var _UserMailCheck = _db.UserEntityTable.Where(x => x.UserMail == _UserEntity.UserMail).FirstOrDefault();
            var _UserPasswordCheck = _db.UserEntityTable.Where(x => x.UserPassword == _UserEntity.UserPassword).FirstOrDefault();

            if ((_UserMailCheck != null) && (_UserPasswordCheck != null))
            {

                if (_UserPasswordCheck.UserPassword == _UserEntity.UserPassword.ToString())
                {
                    return "1";
                }
                else
                {
                    return "2";
                }
            }
            else
            {
                return "3";
            }

        }


        /// <summary>
        /// Checks the user mail extension, returns true if they are matched, else false.
        /// </summary>
        /// <param name="_UserEntity"></param>
        /// <returns></returns>
        public bool MailValidation(UserEntity _UserEntity)
        {
            string[] MailExtensionList = new string[11]
            {
                "gmail.com",
                "outlook.com",
                "aol.com",
                "titan.email",
                "icloud.com",
                "pm.com",
                "tutanota.com",
                "yandex.com",
                "gmx.com",
                "hubspot.com",
                "mail.com"
            };

            string MailExtension = _UserEntity.UserMail.Substring(_UserEntity.UserMail.LastIndexOf('@') + 1);

            if (MailExtensionList.Contains(MailExtension))
            {
                return true;
            }
            else
            {
                return false;
            }
        }



        // Registration Form Methods

        /// <summary>
        /// Adds "UserEntity" to database, return true if succeded, else false.
        /// </summary>
        /// <param name="_UserEntity"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Checks user in the database, returns true if exists, else false.
        /// </summary>
        /// <param name="_UserEntity"></param>
        /// <returns></returns>
        public bool CheckUserExistence(UserEntity _UserEntity)
        {
            var _result = _db.UserEntityTable.Where(x => x.UserMail == _UserEntity.UserMail).Count();
            if(_result != 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Change Password Form Methods

        // "ChechUserExistence" method defined in the registration form methods.

        /// <summary>
        /// Sends user password mail to user. 
        /// </summary>
        /// <param name="_UserEntity"></param>
        public void SendMail(UserEntity _UserEntity)
        {
            string _FromMail = "mucidim59@gmail.com";
            string _FromPassword = "izjudylxzdsrngvk";

            string _ToMail = _UserEntity.UserMail;
            string _ToPassword = _db.UserEntityTable.Where(x => x.UserMail == _UserEntity.UserMail)
                                                    .Select(x => x.UserPassword)
                                                    .First();

            string _MailMessage = "<!DOCTYPE html>\r\n" +
                                  "<html>\r\n  " +
                                  "<head>\r\n    " +
                                  "<meta charset=\"utf-8\">\r\n    " +
                                  "<title>Password Information</title>\r\n  " +
                                  "</head>\r\n  " +
                                  "<body>\r\n    " +
                                  "<h2>Hello Dear User,</h2>\r\n    " +
                                  $"<p>Your password is: <strong>{_ToPassword}</strong></p>\r\n    " +
                                  "<p>Have a nice day!</p>\r\n  " +
                                  "</body>\r\n" +
                                  "</html>";
            
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress(_FromMail);
            mail.To.Add(_ToMail);
            mail.Subject = "CalorieCounter Password Reminder";
            mail.IsBodyHtml = true;
            mail.Body = _MailMessage;

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(_FromMail, _FromPassword);
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
        }
    }
}
