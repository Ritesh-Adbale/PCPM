using PCPM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using PCPM.IBll;

namespace PCPMWEBAPI.Controllers
{
    [RoutePrefix("api/Login")]
    public class LoginController : ApiController
    {
        private readonly ILogin login;

        
        public LoginController(ILogin login)
        {
            this.login = login;
        }


        [HttpGet]
        [Route("logindetails")]
        public Task<HttpResponseMessage> LoginShowList() //we can use only Task (we have to use "Task.FromResult" for returning) or async Task
        {
          

            var details =login.showdetails();
            if (details !=null)
            {
                return Task.FromResult(Request.CreateResponse(HttpStatusCode.OK, details));

            }
            return Task.FromResult(Request.CreateResponse(HttpStatusCode.NotFound, "Error"));
            

        }

        [HttpGet]
        [Route("login")]

        public async Task<HttpResponseMessage> Login(string username="",string password="")
        {
            var ifconnected =  login.login(username, password);
            if (ifconnected == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "Login successfully");
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Entered Username/Password is InCorrect");
        }


        [HttpPost]
        [Route("enterlogindetails")]
        public async Task<HttpResponseMessage> LoginEnter(LoginDetailsModel loginentry)
        {
            var logindata = login.SaveLoginUser(loginentry);
            if (logindata==true)
            {
                return Request.CreateResponse(HttpStatusCode.OK,"Data Save Successfull");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

        [HttpPost]
        [Route("deleteuser")]
        public async Task<HttpResponseMessage> LoginRemove(int id)
        {
            var logindata = login.deleteUser(id);
            if (logindata == true)
            {
                return Request.CreateResponse(HttpStatusCode.OK, "User Deleted Successfully");
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);
        }

    }
}
