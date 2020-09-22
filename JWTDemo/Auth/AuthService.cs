using JWTDemo.JWT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JWTDemo.Auth
{
    /// <summary>
    /// 生成完整的Toke
    /// </summary>
    public class AuthService : IAuthService
    {
        private readonly IJwtService _jwtService;

        public AuthService(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }
        /// <summary>
        /// 生成令牌
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="roleCodeList"></param>
        /// <returns></returns>
        public string GetToken(string userName, List<string> roleCodeList)
        {
            //生成身份信息
            Claim[] userClaims = _jwtService.BuildClaims(userName, roleCodeList);
            //生成JWT令牌
            string tokenStr = _jwtService.BuildToken(userClaims);
            return tokenStr; //返回一个令牌

        }
    }
}
