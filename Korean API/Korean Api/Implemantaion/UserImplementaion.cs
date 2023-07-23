﻿using Korean_Api.Database;
using Korean_Api.Interface;
using Korean_Api.Models;

namespace Korean_Api.Implemantaion
{
    public class UserImplementaion : IUsers
    {
        private readonly KoreanContext _dbContext;
        public UserImplementaion(KoreanContext koreanContext)
        {
            _dbContext = koreanContext;
        }
        public Dictionary<string,string> NewUserRegistration(Users user)
        {

            Dictionary<string, string> status = new Dictionary<string, string>();

            //cheking user already exist ir not

            bool isExist = _dbContext.users.Any(x=>x.Email == user.Email);
            if (isExist)
            {
                status.Add("Status", "400");
                status.Add("Message", "Email Already Exist");

                return status;
            }
            else
            {
                //if user does not exist
                _dbContext.users.Add(user);
                _dbContext.SaveChanges();

                status.Add("Status", "200");
                status.Add("Message", "User Added Successfully");

                return status;
            }

            
        }
    }
}
