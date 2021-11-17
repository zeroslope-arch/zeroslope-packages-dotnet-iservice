using System.Reflection;
using Scrutor;

namespace ZeroSlope.Packages.DotNet.IService.Installers
{
    public class IServiceInstaller
    {
        private readonly Type _typeInit;

        public IServiceInstaller(Type initType)
        {
            _typeInit = initType;
        }

        public void Install(ITypeSourceSelector scan)
        {
            var ServiceAssembly = _typeInit.GetTypeInfo().Assembly;
			scan.FromAssemblies(ServiceAssembly)
				.AddClasses(classes => classes.AssignableTo<IService>())
				.AsSelf()
				.WithScopedLifetime();
        }
    }
}
