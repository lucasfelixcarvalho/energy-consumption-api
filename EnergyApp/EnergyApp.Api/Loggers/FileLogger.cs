using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Xml;
using Castle.DynamicProxy;
using log4net;
using Newtonsoft.Json;

namespace EnergyApp.Api.Loggers
{
    public class FileLogger : IInterceptor
    {
        private static readonly string LOG_CONFIG_FILE = @$"/Documents/Git/energy-consumption-api/EnergyApp/EnergyApp.Api/Loggers/log4net.config";
        private static readonly log4net.ILog _Log = GetLogger(typeof(FileLogger));  

        public FileLogger()
        {
            SetLog4NetConfiguration();
        }

        public static ILog GetLogger(Type type)  
        {  
            return LogManager.GetLogger(type);  
        } 

        public void Intercept(IInvocation invocation)
        {
            try
            {
                LogInterceptedInvocation(invocation);
            }
            catch (Exception ex)
            {
                HandleExceptionOnInterceptedInvocation(ex);
            }            
        }

        private void LogInterceptedInvocation(IInvocation invocation)
        {
            string methodName = $"{invocation.Method.DeclaringType}.{invocation.Method.Name}";
            string args = JsonConvert.SerializeObject(invocation.Arguments);

            _Log.Debug($"Calling: {methodName} with arguments: {args}");

            var timeToProcess = Stopwatch.StartNew();
            invocation.Proceed();
            timeToProcess.Stop();

            string returnData = JsonConvert.SerializeObject(invocation.ReturnValue);

            _Log.Debug($"Call to: {methodName} - done. Result was {returnData} in {timeToProcess.ElapsedMilliseconds} ms");
        }

        private void HandleExceptionOnInterceptedInvocation(Exception ex)
        {
            _Log.Error($"Exception message: {ex.Message}, Stack: {ex.StackTrace}");
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
