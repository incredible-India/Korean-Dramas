﻿using Korean_Api.Models;

namespace Korean_Api.Interface
{
    public interface IUsers
    {
        //Registration of the new user
        public Dictionary<string, string> NewUserRegistration(Users user);
    }
}
