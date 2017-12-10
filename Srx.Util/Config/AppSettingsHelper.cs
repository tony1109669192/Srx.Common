using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;

namespace Srx.Util.Config
{
    public class AppSettingsHelper
    {
        
        //public T GetAppSettings<T>(string key) where T : class, new()
        //{
        //    var baseDir = AppContext.BaseDirectory;
        //    var indexSrc = baseDir.IndexOf("bin");
        //    var RootPath = baseDir.Substring(0, indexSrc);

        //    IConfiguration config = new ConfigurationBuilder()
        //        .SetBasePath(RootPath)
        //        .Add(new JsonConfigurationSource { Path = "appsettings.json", Optional = false, ReloadOnChange = true })
        //        .Build();

        //    var appconfig = new ServiceCollection()
        //        .AddOptions()
        //        .Configure<T>(config.GetSection(key))
        //        .BuildServiceProvider()
        //        .GetService<IOptions<T>>()
        //        .Value;

        //    return appconfig;
        //}
    }
}
