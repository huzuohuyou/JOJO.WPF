using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Threading;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.ComponentModel.Composition.Primitives;
using System.Windows;
using Panuon.UI;
using JOJO.UC;
using Sugar.WPF.ViewModels.Account;

namespace Sugar.WPF
{
    public class AppBootstrapper : BootstrapperBase
    {
        private CompositionContainer container;

        public AppBootstrapper()
        {
            Initialize();
        }
        protected override void Configure()
        {
            container = new CompositionContainer(new AggregateCatalog(
                    AssemblySource.Instance.Select(x => new AssemblyCatalog(x)).OfType<ComposablePartCatalog>()));

            var batch = new CompositionBatch();
            batch.AddExportedValue<IWindowManager>(new WindowManager());
            batch.AddExportedValue<IEventAggregator>(new EventAggregator());
            batch.AddExportedValue(container);

            container.Compose(batch);
        }

        protected override void OnUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            base.OnUnhandledException(sender, e);
            PUMessageBox.ShowDialog("异常：" + e.Exception.Message);
            e.Handled = true;
        }
        protected override object GetInstance(Type serviceType, string key)
        {
            string contract = string.IsNullOrEmpty(key) ? AttributedModelServices.GetContractName(serviceType) : key;
            var exports = container.GetExportedValues<object>(contract);

            if (exports.Any())
                return exports.First();

            throw new Exception($"找不到实例 {contract}。");
        }

        protected override IEnumerable<object> GetAllInstances(Type serviceType)
        {
            return container.GetExportedValues<object>(AttributedModelServices.GetContractName(serviceType));
        }

        protected override void BuildUp(object instance)
        {
            container.SatisfyImportsOnce(instance);
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            //Application.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            //var viewModel = IoC.Get<LoginViewModel>();
            //IWindowManager windowManager;
            //try
            //{
            //    windowManager = IoC.Get<IWindowManager>();
            //}
            //catch
            //{
            //    windowManager = new WindowManager();
            //}
            //var ok = windowManager.ShowDialog(viewModel);
            //if (ok.HasValue && ok.Value)
            //{
            //    Application.Current.ShutdownMode = ShutdownMode.OnMainWindowClose;
                DisplayRootViewFor<IShell>();
            //}
        }
    }
}
