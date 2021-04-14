using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ControleDeNivel.Business.Services
{
    public class UserFilter : IActionFilter
    {
        private StringValues _token;

        public void OnActionExecuted(ActionExecutedContext context)
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            string controllerName = Convert.ToString(context.RouteData.Values["Controller"]);
            string actionName = Convert.ToString(context.RouteData.Values["Action"]);

            if (Equals(controllerName, "LoadFile") || Equals(controllerName, "PackingList"))
            {
                var token = context.HttpContext.Request.Headers.TryGetValue("Authorization", out _token);
                var handler = new JwtSecurityTokenHandler();
                if (token)
                {
                    try
                    {
                        var securityToken = handler.ReadToken(_token);
                        if (securityToken.ValidTo < DateTime.Now)
                            context.Result = new UnauthorizedResult();

                        string[] role = securityToken.Issuer.Split("_");
                        if (!Equals(role[1], "administrator") && (Equals(controllerName, "Role") || Equals(controllerName, "User")))
                            context.Result = new UnauthorizedResult();
                    }
                    catch (Exception)
                    {
                        context.Result = new UnauthorizedResult();
                    }
                }
                else
                    context.Result = new UnauthorizedResult();
            }
        }
    }
}

