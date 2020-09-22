﻿using JWTDemo.Auth;
using JWTDemo.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWTDemo.JWTAuthentication
{
    /// <summary>
    /// 扩展
    /// </summary>
    public static class AuthStartupExtension
    {
        public static IServiceCollection AddRayAuthService(this IServiceCollection services, JwtOption jwtOption) 
        {
            services.AddSingleton<JwtSecurityTokenHandler>();
            services.AddSingleton<IJwtService, JwtService>();

            #region 注册【认证】服务
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(o =>
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = jwtOption.Issuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtOption.SecurityKey)),

                        RequireSignedTokens = true,
                        RequireExpirationTime = true,
                        // SaveSigninToken = false,
                        // ValidateActor = false,
                        ValidateAudience = false,
                        ValidateIssuer = true,
                        ValidateIssuerSigningKey = true,
                        // ClockSkew = TimeSpan.FromSeconds(300),// 允许的服务器时间偏移量
                        ValidateLifetime = true// 是否验证Token有效期，使用当前时间与Token的Claims中的NotBefore和Expires对比
                    };
                    o.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = context =>
                        {
                            //Token expired
                            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                            {
                                context.Response.Headers.Add("Token-Expired", "true");
                            }
                            return Task.CompletedTask;
                        }
                    };
                });
            #endregion
            #region 注册【授权】服务
            /*
            services.AddAuthorization(options =>
            {
                options.AddPolicy(AuthPolicyEnum.Free.ToString(), policy => policy.AddRequirements(new RayRequirement(false)));

                options.AddPolicy(AuthPolicyEnum.RequireRoleOfClient.ToString(), policy => policy.AddRequirements(new RayRequirement("Client")));
                options.AddPolicy(AuthPolicyEnum.RequireRoleOfAdmin.ToString(), policy => policy.AddRequirements(new RayRequirement("Admin")));
                options.AddPolicy(AuthPolicyEnum.RequireRoleOfAdminOrClient.ToString(), policy => policy.AddRequirements(new RayRequirement("Admin,Client")));
            });
            */
            //services.AddSingleton<IAuthorizationPolicyProvider, RayPolicyProvider>();
            //services.AddSingleton<IAuthorizationHandler, PolicyHandler>();
            #endregion
            services.AddSingleton<IAuthService, AuthService>();
            
            return services;
        }



    }
}
