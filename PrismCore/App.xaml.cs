using System.Windows;
using Prism.Ioc;
using PrismCore.ViewModels;
using PrismCore.Views;

namespace PrismCore
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<Accordion, AccordionViewModel>();
        }
    }
}
