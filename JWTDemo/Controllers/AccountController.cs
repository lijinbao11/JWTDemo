using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWTDemo.Auth;
using JWTDemo.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTDemo
{
    [Route("api/[controller]")]
    [ApiController]
    [Route("Token")]
    //[Authorize]
    public class AccountController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService )
        {
            _authService = authService;
        }
        /// <summary>
        /// 登录获取Token
        /// </summary>
        /// <param name="userName">用户名(写死)</param>
        /// <param name="pwd">密码(写死,无限制)</param>
        /// /// <param name="pwd">身份角色</param>
        /// <returns></returns>
        [HttpGet]
        public JsonResult Login(string userName = "StuAdmin", string pwd = "123456789")
        {
            List<string> GetRoleCodeList()
            {
                switch (userName)
                {
                    case "Admin": return new List<string> { "Admin" };
                    case "StuAdmin": return new List<string> { "StudentAdmin" };
                    case "TeacherAdmin": return new List<string> { "TeacherAdmin" };
                    case "Test":
                        return new List<string> { "StuAdmin", "TeacherAdmin" };
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            string tokenStr = _authService.GetToken(userName, GetRoleCodeList());
            return new JsonResult(tokenStr);
        }
    }
}
