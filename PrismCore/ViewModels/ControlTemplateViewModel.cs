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

        public string Title => throw new NotImplementedException();

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {
        }

        private void ExecutionSample1(object obj)
        {
            MessageBox.Show("ExecutionSample1");
        }

        private void ExecutionSample2(object obj)
        {
            MessageBox.Show("ExecutionSample2");
        }
    }
}
