using Agile09.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Agile09.DAO
{
    public class AdminDAO
    {
        // GET: AdminDAO
        ShopOnlineDb db = null;
        public AdminDAO()
        {
            db = new ShopOnlineDb();
        }
        public long Insert(Admin entity)
        {
            db.Admins.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(Admin entity)
        {
            try
            {
                var user = db.Admins.Find(entity.ID);
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
        public IEnumerable<Admin> ListAllPaging()
        {
            return db.Admins;
        }
        public Admin GetByID(string userName)
        {
            return db.Admins.SingleOrDefault(x => x.UserName == userName);
        }
        public Admin ViewDetail(int id)
        {
            return db.Admins.Find(id);
        }
        public int Login(string userName, string password)
        {
            var result = db.Admins.SingleOrDefault(x => x.UserName == userName);
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
                var user = db.Admins.Find(id);
                db.Admins.Remove(user);
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
            var user = db.Admins.Find(id);
            user.Status = !user.Status;
            db.SaveChanges();
            return user.Status;
        }
        public bool CheckUserName(string name)
        {
            return db.Admins.Count(x => x.UserName == name) > 0;
        }
        public bool CheckEmail(string email)
        {
            return db.Admins.Count(x => x.Email == email) > 0;
            ;
        }
    }
}