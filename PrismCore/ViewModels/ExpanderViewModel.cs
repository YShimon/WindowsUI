using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;

namespace PrismCore.ViewModels
{
    /// <summary>
    /// Expanderサンプル画面のViewModel
    /// </summary>
    public class ExpanderViewModel : BindableBase, IDialogAware
    {
        /// <summary>
        /// Expander Sample View Title
        /// </summary>
        public string Title => "Expander Sample View";

        /// <inheritdoc/>
        public event Action<IDialogResult> RequestClose;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public ExpanderViewModel() { }

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
    }
}
