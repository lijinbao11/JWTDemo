using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTDemo.Swagger
{
    public static class ApplicationBuilderExtension
    {
        public static void UseSwaggerService(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v3/swagger.json", "接口文档");
            });
        }

    }
}
