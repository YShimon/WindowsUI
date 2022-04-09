using System;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using PrismCore.Views;
using Reactive.Bindings;

namespace PrismCore.ViewModels
{
    /// <summary>
    /// MainWindowのViewModel
    /// </summary>
    public class MainWindowViewModel : BindableBase
    {
        /// <summary>
        /// 領域マネージャ
        /// </summary>
        private readonly IRegionManager regionManager;

        /// <summary>
        /// ダイアログサービス
        /// </summary>
        private readonly IDialogService dialogService;

        /// <summary>
        /// タイトル
        /// </summary>
        public ReactiveProperty<string> Title { get; } 
            = new ReactiveProperty<string> { Value = "UI Sample Based On .Net Core with Prism" };

        /// <summary>
        /// Expanderコントロールサンプル画面表示コマンド
        /// </summary>
        public ReactiveCommand ShowExpanderView { get; } = new ReactiveCommand();

        /// <summary>
        /// ControlTemplateサンプル画面表示コマンド
        /// </summary>
        public ReactiveCommand ShowControlTemplateView { get; } = new ReactiveCommand();

        /// <summary>
        /// ドラッグ可能コントロールのサンプル画面表示コマンド
        /// </summary>
        public ReactiveCommand ShowDraggableControlView { get; } = new ReactiveCommand();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="region">領域マネージャ</param>
        /// <param name="dialog">ダイアログサービス</param>
        public MainWindowViewModel(IRegionManager region, IDialogService dialog)
        {
            regionManager = region;
            dialogService = dialog;

            ShowExpanderView.Subscribe(ExecuteShowExpanderView);
            ShowControlTemplateView.Subscribe(ExecuteShowControlTemplateView);
            ShowDraggableControlView.Subscribe(ExecuteShowDraggableControlView);
        }

        /// <summary>
        /// Expanderコントロールサンプル画面表示処理
        /// </summary>
        private void ExecuteShowExpanderView()
        {
            dialogService.ShowDialog(nameof(Expander), null, null);
        }

        /// <summary>
        /// ControlTemplateサンプル画面表示処理
        /// </summary>
        private void ExecuteShowControlTemplateView()
        {
            dialogService.ShowDialog(nameof(ControlTemplate), null, null);
        }

        /// <summary>
        /// ドラッグ可能コントロールのサンプル画面表示処理
        /// </summary>
        private void ExecuteShowDraggableControlView()
        {
            dialogService.ShowDialog(nameof(DraggableControl), null, null);
        }
    }
}
