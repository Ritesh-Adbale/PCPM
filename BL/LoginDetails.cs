using PCPM.IBll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PCPM.Model;
using PCPM.Data;
using AutoMapper;

namespace BL
{
    public class LoginDetails : ILogin
    {
        PCPMContext _dbContext = new PCPMContext();

        public  bool login(string username,string password)
        {
            try
            {
                var auth = _dbContext.Logins.Where(a => a.Username == username && a.Password == password).FirstOrDefault();
                if (auth !=null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {

                throw ex;
            }
          
        }

        public bool SaveLoginUser(LoginDetailsModel loginentry)
        {
            try
            {
                if (loginentry !=null)
                {
                    Login ln = new Login();
                    ln.Username = loginentry.Username;
                    ln.Password = loginentry.Password;
                    _dbContext.Logins.Add(ln);
                    _dbContext.SaveChanges();
                    return true;
                }
                return false;
              
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool deleteUser(int id)
        {
            try
            {
                if (id !=null)
                {
                    var Deleteuserbyid = _dbContext.Logins.Where(u => u.LoginId == id).FirstOrDefault();
                    _dbContext.Logins.Remove(Deleteuserbyid);
                    _dbContext.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {

                throw;
            }
            
            
            return false;
        }
        public List<LoginDetailsModel> showdetails()
        {
            try
            {
                List<LoginDetailsModel> loginlist = new List<LoginDetailsModel>();

                var details = _dbContext.Logins;
                if (details != null)
                {
                   
                    foreach (var item in details)
                    {
                        LoginDetailsModel ldm = new LoginDetailsModel();
                        ldm.LoginId = item.LoginId;
                        ldm.Username = item.Username;
                        ldm.Password = item.Password;
                        loginlist.Add(ldm);
                    }
                    return loginlist;
                }
                else
                {
                    return loginlist;
                }

               
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}
