using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Agile09.Common;
using Agile09.EF;
using System.Data.Entity.Validation;

namespace Agile09.DAO
{
    public class UserDAO 
    {
        ShopOnlineDb db = null;
        public UserDAO()
        {
            db = new ShopOnlineDb();
        }
        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.ID);
                user.Name = entity.Name;
                if (!string.IsNullOrEmpty(entity.Password))
                {
                    user.Password = entity.Password;
                }
                else
                {
                    user.Password = user.Password;
                }
                user.Address = entity.Address;
                user.Phone = entity.Phone;
                user.Email = entity.Email;
                user.Status = entity.Status;
                user.ModifiedDate = DateTime.Now;
                user.ModifiedBy = entity.ModifiedBy;
                db.SaveChanges();
                return true;
            }
            catch (Exception er)
            {
                return false;
            }
        }

        public IEnumerable<User> ListAllPaging(string searchString, int page, int pageSize)
        {
            // SearchString và phân trang
            //IQueryable<User> model = db.Users;
            //if (!string.IsNullOrEmpty(searchString))
            //{
            //model = model.Where(x => x.UserName.Contains(searchString) || x.Name.Contains(searchString));
            //}
            //return db.Users.OrderByDescending(x=>x.CreatedDate).ToPagedList(searchString, page, pageSize);
            return db.Users;
        }
        public User GetByID(string userName)
        {
            return db.Users.SingleOrDefault(x => x.UserName == userName);
        }
        public User ViewDetail(int id)
        {
            return db.Users.Find(id);
        }
        public int Login(string userName, string password)
        {
            var result = db.Users.SingleOrDefault(x => x.UserName == userName);
            if (result == null)
            {
                return 0; //Tài khoản không tồn tại
            }
            else
            {
                if (result.Status == false)
                {
                    return -1; // Tài khoản bị khóa
                }
                else
                {
                    if (result.Password == password)
                    {
                        return 1;
                    }
                    else
                    {
                        return -2;
                    }
                }
            }
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception er)
            {
                return false;
            }
        }
        public bool ChangeStatus(long id)
        {
            var user = db.Users.Find(id);
            user.Status = !user.Status;
            db.SaveChanges();
            return user.Status;
        }
        public bool CheckUserName(string name)
        {
            return db.Users.Count(x => x.UserName == name) > 0;
        }
        public bool CheckEmail(string email)
        {
            return db.Users.Count(x => x.Email == email) > 0;
            ;
        }
        public long InsertForFacebook(User entity)
        {
            var user = db.Users.SingleOrDefault(x => x.UserName == entity.UserName);
            if (user == null)
            {
                db.Users.Add(entity);
                //db.SaveChanges();
                return entity.ID;
            }
            else
            {
                return user.ID;
            }
        }
        public long InsertForGoogle(User entity)
        {
            var user = db.Users.SingleOrDefault(x => x.UserName == entity.UserName);
            if (user == null)
            {
                db.Users.Add(entity);
                //db.SaveChanges();
                return entity.ID;
            }
            else
            {
                return user.ID;
            }
        }
    }
}