using EBuy.DAL.Models.EF_Models;
using EBuy.DAL.Models.Results;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBuy.DAL
{
    public class Identity
    {
        Context db = new Context();

        public UserResult RegisterUser(User user)
        {
            try
            {
                UserResult userResult = new UserResult();

                var userInDb = GetUserByEmail(user.Email);

                if (userInDb != null)
                {
                    return userResult;
                }

                db.Users.Add(user);
                db.SaveChanges();

                var a = user.Id;
                if (user.RoleId == 1)
                {
                    db.Brands.Add(new Brand { BrandName = "dummyBrandName", UserId = user.Id });
                }
                else if (user.RoleId == 2)
                {
                    db.Customers.Add(new Customer { UserId = user.Id });
                }
                db.SaveChanges();

                userResult.Succeeded = true;
                userResult.User = user;

                return userResult;
            }
            catch(Exception ex)
            {
                throw new Exception();
            }

        }

        public UserResult Login(User user)
        {
            try
            {
                UserResult userResult = new UserResult();

                var userInDb = GetUserByEmail(user.Email);

                if (userInDb != null && userInDb.Password == user.Password)
                {
                    userResult.User = userInDb;
                    userResult.Succeeded = true;

                    return userResult;
                }

                return userResult;
            }
            catch
            {
                throw new Exception();
            }

        }

        public User GetUserByEmail(string email)
        {
            try
            {
                var user = db.Users.FirstOrDefault(x => x.Email == email);
                return user;
            }
            catch
            {
                throw new Exception();
            }
        }

        public List<RoleResult> GetAllRoles()
        {
            List<RoleResult> roles = db.Roles.Select(x => new RoleResult() { Id = x.Id, RoleName = x.RoleName }).ToList();
            return roles;
        }


    }
}
