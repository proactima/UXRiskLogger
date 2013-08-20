using Ninject.Components;
using Ninject.Selection.Heuristics;
using System.Reflection;

namespace Ninject.Extensions.UXRiskLogger.Autologger
{
    public class AutomaticLoggerInjectionHeuristic : NinjectComponent, IInjectionHeuristic
    {
        public bool ShouldInject(MemberInfo member)
        {
            var info = member as PropertyInfo;

            if (member == null || info == null)
                return false;

            if (info.PropertyType == typeof(ILogger))
                return true;

            return false;
        }
    }
}
