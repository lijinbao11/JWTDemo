using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTDemo.Config
{
    /// <summary>
    /// 获取本地配置  JWT或则数据库配置都在这里面写
    /// </summary>
    public class AllConfigModel
    {
        private readonly IConfiguration _configuration;

        public AllConfigModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// JWT配置
        /// </summary>
        public JwtAuthConfigModel JwtAuthConfigModel => new JwtAuthConfigModel(_configuration);


    }
}
