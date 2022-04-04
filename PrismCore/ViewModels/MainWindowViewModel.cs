using System;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using PrismCore.Views;
using Reactive.Bindings;

namespace PrismCore.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;
        private readonly IDialogService dialogService;

        /// <summary>
        /// タイトル
        /// </summary>
        public ReactiveProperty<string> Title { get; } 
            = new ReactiveProperty<string> { Value = "UI Sample Based On .Net Core with Prism" };

        public ReactiveCommand ShowAcordionView { get; } = new ReactiveCommand();

        public MainWindowViewModel(IRegionManager region, IDialogService dialog)
        {
            regionManager = region;
            dialogService = dialog;

            ShowAcordionView.Subscribe(ExecuteShowAcordionView);
        }

        private void ExecuteShowAcordionView()
        {
            dialogService.ShowDialog(nameof(Accordion), null, null);
        }
    }
}
