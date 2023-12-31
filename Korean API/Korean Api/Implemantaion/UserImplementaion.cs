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

        //deleting the user
        public int DeleteUserById(int id)
        {
            var user = _dbContext.users.Where(x => x.id == id).FirstOrDefault();

            if (user != null)
            {
                //if user exist
                _dbContext.Remove(user);
                _dbContext.SaveChanges();
                return 1;

            }
            else
            {
                return 0;
            }

        }

        public dynamic Login(string email, string password)
        {
            //checking the email
            Users? users = _dbContext.users.Where(m => m.Email == email).FirstOrDefault();

            if (users != null)
            {
                //if email exist then check for the password
                if (users.Password == password)
                {
                    //if password is correct send the user information
                    return users;
                }
                else
                {
                    return null;
                }

            }
            else
            {
                return null;
            }
        }

        public Dictionary<string, string> NewUserRegistration(Users user)
        {

            Dictionary<string, string> status = new Dictionary<string, string>();

            //cheking user already exist ir not

            bool isExist = _dbContext.users.Any(x => x.Email == user.Email);
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

        public List<Users> GetUsers()
        {
            return _dbContext.users.ToList();
        }
        //adding the Actor 
        public int AddfavActor(FavLead fa)
        {
            //first check the user exist or not 
            bool isUserExist = _dbContext.users.Where(x => x.id == fa.UserId).Any();
            if (isUserExist)
            {
                //then check actor exist or not
                bool isActorExist = _dbContext.ActorsTable.Where(x => x.Id == fa.ActorId).Any();
                if (isActorExist)
                {
                    //if user and actor both exist then save the in database
                    FavLead fv = new FavLead()
                    {
                        ActorId = fa.ActorId,
                        UserId = fa.UserId,
                    };
                    _dbContext.favActor.Add(fv);
                    _dbContext.SaveChanges();
                    return 1;

                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
        //get user by Id
        public Users GetUserById(int id)
        {
            return _dbContext.users
                .Where(x => x.id == id).FirstOrDefault();
        }



    }
}
