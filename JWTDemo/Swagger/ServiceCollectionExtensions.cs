using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace JWTDemo.Swagger
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSwaggerService(this IServiceCollection services) 
        {
            var apiInfo = new OpenApiInfo
            {
                Version = "v3",
                Title = "接口文档",
                Description = "基于.NET Core3.1的接口框架",
                Contact = new OpenApiContact
                {
                    Name = "相关文档",
                    Email = "1969184224@qq.com",
                    Url = new Uri("http://www.cnblogs.com/RayWang")
                }
            };

            #region 注册Swagger服务
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v3", apiInfo);

                //添加注释
                try
                {
                    c.IncludeXmlComments(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "RayPI.OpenApi.xml"), true);
                    c.IncludeXmlComments(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "RayPI.AppService.xml"));
                }
                catch (Exception)
                {
                    //todo:记录日志
                }


                //添加控制器注释
                //c.DocumentFilter<SwaggerDocTag>();

                //添加header验证信息
                //c.OperationFilter<SwaggerHeader>();
                //var security = new Dictionary<string, IEnumerable<string>> { { "Bearer", new string[] { } }, };

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "Please enter into field the word 'Bearer' followed by a space and the JWT value",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference()
                        {
                            Id = "Bearer",
                            Type = ReferenceType.SecurityScheme
                        }
                    }, Array.Empty<string>() }
                });
            });
            #endregion
            return services;

        }
    }
}
