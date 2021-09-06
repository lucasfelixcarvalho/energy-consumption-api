using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using Castle.DynamicProxy;
using log4net;
using Newtonsoft.Json;

namespace EnergyApp.Domain.Logger
{
    public class Logger : IInterceptor
    {
        private static string CurrentDir = AppDomain.CurrentDomain.BaseDirectory;
        private static readonly string LOG_CONFIG_FILE = @$"/Documents/Git/energy-consumption-api/EnergyApp/EnergyApp.Domain/log4net.config";
        private static readonly log4net.ILog _Log = GetLogger(typeof(Logger));  

        public Logger()
        {
            SetLog4NetConfiguration();
        }

        public static ILog GetLogger(Type type)  
        {  
            return LogManager.GetLogger(type);  
        } 

        public void Intercept(IInvocation invocation)
        {
            var methodName = $"{invocation.Method.DeclaringType}.{invocation.Method.Name}";
            var args = JsonConvert.SerializeObject(invocation.Arguments);

            _Log.Debug($"Calling: {methodName} with arguments: {args}");

            var timeToProcess = Stopwatch.StartNew();
            invocation.Proceed();
            timeToProcess.Stop();

            var returnData = JsonConvert.SerializeObject(invocation.ReturnValue);

            _Log.Debug($"Done. Result was {returnData} in {timeToProcess.ElapsedMilliseconds} ms");
        }

        private static void SetLog4NetConfiguration()  
        {
            XmlDocument log4netConfig = new XmlDocument();  
            log4netConfig.Load(File.OpenRead(LOG_CONFIG_FILE));  
    
            var repo = LogManager.CreateRepository(Assembly.GetEntryAssembly(), typeof(log4net.Repository.Hierarchy.Hierarchy));  
    
            log4net.Config.XmlConfigurator.Configure(repo, log4netConfig["log4net"]);  
        } 
    }
}
