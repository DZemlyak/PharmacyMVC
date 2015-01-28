using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Microsoft.Practices.ServiceLocation;
using Pharmacy.BusinesLogic.Manager;
using Pharmacy.BusinesLogic.Validators;
using Pharmacy.Contracts.Manager;
using Pharmacy.Contracts.Repository;
using Pharmacy.Contracts.Validator;
using Pharmacy.Core;
using Pharmacy.Data;
using Pharmacy.WEB.Core.ViewModelCreator;

namespace Pharmacy.CastleWindsor.Installers
{
    public class AdminInstaller : IWindsorInstaller
    {
        private const string WebAssemblyName = "Pharmacy.WEB";

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromAssemblyNamed(WebAssemblyName)
                .BasedOn<IController>()
                .LifestyleTransient()
                .Configure(x => x.Named(x.Implementation.Name)));

            container.Register(
                Component.For<IWindsorContainer>().Instance(container),
                Component.For<WindsorControllerFactory>());

            container.Register(Component.For<DataContext>().LifestyleSingleton());
            container.Register(
                Component.For(typeof (IRepository<>)).ImplementedBy(typeof (Repository<>)).LifestyleTransient());
            container.Register(Component.For(typeof (IManager<>)).ImplementedBy(typeof (Manager<>)).LifestyleTransient());
            container.Register(
                Component.For(typeof (IValidator<Core.Pharmacy>))
                    .ImplementedBy(typeof (PharmacyValidator))
                    .LifestylePerWebRequest());
            container.Register(
                Component.For(typeof(IValidator<Medcine>))
                    .ImplementedBy(typeof(MedcineValidator))
                    .LifestylePerWebRequest());
            container.Register(
                Component.For(typeof(IValidator<MedcinePriceHistory>))
                    .ImplementedBy(typeof(MedcinePriceHistoryValidator))
                    .LifestylePerWebRequest());
            container.Register(
                Component.For(typeof(IValidator<Order>))
                    .ImplementedBy(typeof(OrderValidator))
                    .LifestylePerWebRequest());
            container.Register(
                Component.For(typeof(IValidator<OrderDetails>))
                    .ImplementedBy(typeof(OrderDetailsValidator))
                    .LifestylePerWebRequest());
            container.Register(
                Component.For(typeof (IValidator<Storage>))
                    .ImplementedBy(typeof (StorageValidator))
                    .LifestylePerWebRequest());

            container.Register(
                Component.For(typeof(StorageViewModelCreator))
                .LifestyleTransient());

            container.Register(
                Component.For(typeof(OrderViewModelCreator))
                .LifestyleTransient());

            container.Register(
                Component.For(typeof(OrderDetailsViewModelCreator))
                .LifestyleTransient());

            var controllerFactory = new WindsorControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
            ServiceLocator.SetLocatorProvider(() => new WindsorServiceLocator(container));
        }
    }
}
