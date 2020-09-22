using Microsoft.Extensions.Configuration;

namespace JWTDemo.Config
{
    /// <summary>
    /// 获取appsettings.json中的JWT配置
    /// </summary>
    public class JwtAuthConfigModel
    {
        private readonly IConfigurationSection _configSection;

        /// <summary>
        /// JWT配置
        /// </summary>
        /// <param name="configuration"></param>
        public JwtAuthConfigModel(IConfiguration configuration )
        {
            _configSection = configuration.GetSection("JwtAuth");
        }

    }
}