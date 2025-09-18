using Autofac;
using Autofac.Core;
using SmartPlugins.BoxInfo.Data;
using SmartPlugins.BoxInfo.Domain;
using SmartPlugins.BoxInfo.Services;
using SmartStore.Core.Data;
using SmartStore.Core.Infrastructure;
using SmartStore.Core.Infrastructure.DependencyManagement;
using SmartStore.Data;

namespace SmartPlugins.BoxInfo
{
	public class DependencyRegistrar : IDependencyRegistrar
    {
		public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder, bool isActiveModule)
        {
			if (isActiveModule)
			{
				builder.RegisterType<BoxInfoService>().As<IBoxInfoService>().InstancePerRequest();
				//register named context
				builder.Register<IDbContext>(c => new BoxInfoObjectContext(DataSettings.Current.DataConnectionString))
					.Named<IDbContext>(BoxInfoObjectContext.ALIASKEY)
					.InstancePerRequest();
				//override required repository with our custom context
				builder.RegisterType<EfRepository<BoxInfoRecord>>()
					.As<IRepository<BoxInfoRecord>>()
					.WithParameter(ResolvedParameter.ForNamed<IDbContext>(BoxInfoObjectContext.ALIASKEY))
					.InstancePerRequest();

			}
		}

        public int Order
        {
            get { return 1; }
        }
    }
}
