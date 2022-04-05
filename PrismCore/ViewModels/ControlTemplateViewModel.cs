using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using Reactive.Bindings;

namespace PrismCore.ViewModels
{
    /// <summary>
    /// ControlTemplateサンプル画面のViewModel
    /// </summary>
    public class ControlTemplateViewModel : BindableBase, IDialogAware
    {
        /// <summary>
        /// サンプルコマンド1
        /// </summary>
        public ReactiveCommand Sample1 { get; } = new ReactiveCommand();

        /// <summary>
        /// サンプルコマンド2
        /// </summary>
        public ReactiveCommand Sample2 { get; } = new ReactiveCommand();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ControlTemplateViewModel()
        {
            Sample1.Subscribe(ExecutionSample1);
            Sample2.Subscribe(ExecutionSample2);
        }

        /// <summary>
        /// Expander Sample View Title
        /// </summary>
        public string Title => "ControlTemplate Sample View";

        /// <inheritdoc/>
        public event Action<IDialogResult> RequestClose;

        /// <inheritdoc/>
        public bool CanCloseDialog()
        {
            return true;
        }

        /// <inheritdoc/>
        public void OnDialogClosed()
        {
        }

        /// <inheritdoc/>
        public void OnDialogOpened(IDialogParameters parameters)
        {
        }

        /// <summary>
        /// Sample1の処理
        /// </summary>
        /// <param name="obj">コマンドパラメータ</param>
        private void ExecutionSample1(object obj)
        {
            MessageBox.Show("ExecutionSample1");
        }

        /// <summary>
        /// Sample2の処理
        /// </summary>
        /// <param name="obj">コマンドパラメータ</param>
        private void ExecutionSample2(object obj)
        {
            MessageBox.Show("ExecutionSample2");
        }
    }
}
