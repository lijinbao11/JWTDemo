using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace JWTDemo.JWT
{
    /// <summary>
    /// Jwt服务[Interface]
    /// </summary>
    public interface IJwtService
    {
        /// <summary>
        /// 生成身份信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="roleName">登录时的角色</param>
        /// <returns></returns>
        Claim[] BuildClaims(string userName, List<string> roleName);
        /// <summary>
        /// 生成JWT令牌
        /// </summary>
        /// <param name="claims">自定义的claims</param>
        /// <returns></returns>
        string BuildToken(Claim[] claims);
    }
}
