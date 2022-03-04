using PCPM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCPM.IBll
{
    public interface ILogin
    {
        List<LoginDetailsModel> showdetails();
        bool login(string username, string password);

        bool SaveLoginUser(LoginDetailsModel loginentry);

        bool deleteUser(int id);


    }
}
