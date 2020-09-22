using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JWTDemo.JWT
{
    /// <summary>
    /// JWT服务
    /// </summary>
    public class JwtService : IJwtService
    {
        private readonly JwtOption _jwtConfig;
        public JwtService(JwtOption jwtConfig)
        {
            _jwtConfig = jwtConfig;
        }
        /// <summary>
        /// 生成身份信息
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="roleName">登录时的角色</param>
        /// <returns></returns>
        public Claim[] BuildClaims(string userName, List<string> roleName)
        {
            // 配置用户标识
            var userClaims = new Claim[]
            {
                new Claim(ClaimTypes.Name,userName),
                new Claim(ClaimTypes.Role,string.Join(',', roleName)),
                new Claim(JwtRegisteredClaimNames.Iss,_jwtConfig.Issuer),
                new Claim(JwtRegisteredClaimNames.Aud,_jwtConfig.Audience),
                new Claim(ClaimTypes.Expiration,_jwtConfig.WebExp.ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds().ToString())
            };
            /*
             iss (issuer)：签发人
             exp (expiration time)：过期时间
             sub (subject)：主题
             aud (audience)：受众
             nbf (Not Before)：生效时间
             iat (Issued At)：签发时间
             jti (JWT ID)：编号
             */
            return userClaims;
        }
        /// <summary>
        /// 生成JWT令牌
        /// </summary>
        /// <param name="claims">自定义的claims</param>
        /// <returns></returns>
        public string BuildToken(Claim[] claims)
        {
            //加密的签名
            var creds = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.SecurityKey)), SecurityAlgorithms.HmacSha256); ;
            JwtSecurityToken tokenkey = new JwtSecurityToken(
                issuer: _jwtConfig.Issuer,  //jWT 签发者,非必须
                audience: _jwtConfig.Audience, // JWT的接受者,非必须
                claims: claims, //声明集合
                expires: DateTime.UtcNow.AddMinutes(_jwtConfig.WebExp),//指定ToKen的生命周期,Unix时间戳格式,非必须
                signingCredentials: creds   //使用私钥进行签名加密
                );
            string tokenStr = "";
            try
            {
                tokenStr = new JwtSecurityTokenHandler().WriteToken(tokenkey);//生成最后的JWT字符串
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return tokenStr;
        }
    }
}
