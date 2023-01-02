using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace TestCustomAuth.Filters;

public class CustomAuthorize : Attribute, IActionFilter
{
    public void OnActionExecuting(ActionExecutingContext context)
    {
        var host = context.HttpContext.RequestServices.GetService<IHostEnvironment>();
        var config = context.HttpContext.RequestServices.GetService<IConfiguration>();

        bool isDev = host.IsDevelopment();

        //if (isDev)
        if (false)
        {
            var userName = config.GetSection("DefaultUser").GetSection("UserName");
            var email = config.GetSection("DefaultUser").GetSection("Email");

            context.HttpContext.Items.Add("UserName", userName);
            context.HttpContext.Items.Add("Email", email);

            return;
        }


        var token = context.HttpContext.Request.Headers["Bearer"];

        if (token.IsNullOrEmpty())
        {
            context.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
            return;
        }

        var key = config.GetSection("AuthSecret").Value;

        var result = Jose.JWT.Decode(token, Encoding.UTF8.GetBytes(key));

        var deserialized = JsonConvert.DeserializeObject<Dictionary<string, object>>(result);

        if (deserialized == null)
        {
            context.Result = new StatusCodeResult(StatusCodes.Status403Forbidden);
            return;
        }

        foreach (var item in deserialized)
        {
            context.HttpContext.Items.Add(item.Key, item.Value);
        }
    }

    public void OnActionExecuted(ActionExecutedContext context)
    {
    }
}