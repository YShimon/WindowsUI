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
        /// <summary>
        /// シェル生成
        /// </summary>
        /// <returns>生成したWindow</returns>
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        /// <inheritdoc/>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<Expander, ExpanderViewModel>();
            containerRegistry.RegisterDialog<ControlTemplate, ControlTemplateViewModel>();
        }
    }
}
