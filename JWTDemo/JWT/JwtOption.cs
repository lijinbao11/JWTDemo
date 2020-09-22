using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTDemo.JWT
{
    /// <summary>
    /// JWT配置
    /// </summary>
    public class JwtOption
    {
        /// <summary>
        /// 颁发者
        /// </summary>
        //[JsonProperty("Issuer")]
        public string Issuer { get; set; }

        /// <summary>
        /// 受众
        /// </summary>
        //[JsonProperty("Audience")]
        public string Audience { get; set; }

        /// <summary>
        /// 安全密钥
        /// </summary>
        //[JsonProperty("SecurityKey")]
        public string SecurityKey { get; set; }

        /// <summary>
        /// Web端过期时间
        /// </summary>
        //[JsonProperty("WebExp")]
        public double WebExp { get; set; }

        /// <summary>
        /// 移动端过期时间
        /// </summary>
        //[JsonProperty("AppExp")]
        public double AppExp { get; set; }

        /// <summary>
        /// 小程序过期时间
        /// </summary>
        //[JsonProperty("MiniProgramExp")]
        public double MiniProgramExp { get; set; }

        /// <summary>
        /// 其他端过期时间
        /// </summary>
        //[JsonProperty("OtherExp")]
        public double OtherExp { get; set; }
    }
}
