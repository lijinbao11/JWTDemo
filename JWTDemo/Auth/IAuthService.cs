using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTDemo.Auth
{
    /// <summary>
    /// 生成完整的Toke
    /// </summary>
    public interface IAuthService
    {
        string GetToken(string userName, List<string> roleCodeList);

    }
}
