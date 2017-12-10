using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Srx.Util
{
    public static class HttpContext
    {
        private static IHttpContextAccessor _accessor;

        public static Microsoft.AspNetCore.Http.HttpContext Current => _accessor.HttpContext;

        internal static void Configure(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }

        //public static IServiceProvider ServiceProvider = new ServiceCollection().BuildServiceProvider();

        //public static Microsoft.AspNetCore.Http.HttpContext Current
        //{
        //    get
        //    {
        //        object factory = ServiceProvider.GetService(typeof(Microsoft.AspNetCore.Http.IHttpContextAccessor));
        //        Microsoft.AspNetCore.Http.HttpContext context = ((Microsoft.AspNetCore.Http.HttpContextAccessor)factory).HttpContext;
        //        return context;

        //    }
        //}

    }
}
