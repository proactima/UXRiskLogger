using Ninject.Modules;
using Ninject.Selection;

namespace Ninject.Extensions.UXRiskLogger.Autologger
{
    public class AutomaticLoggingInjectionModule : NinjectModule
    {
        public override void Load()
        {
            Kernel.Components.Get<ISelector>().InjectionHeuristics.Add(new AutomaticLoggerInjectionHeuristic());
        }
    }
}
