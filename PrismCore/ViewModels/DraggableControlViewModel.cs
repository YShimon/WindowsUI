using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using Reactive.Bindings;

namespace PrismCore.ViewModels
{
    public class DraggableControlViewModel : BindableBase, IDialogAware
    {
        public ReactiveCommand DragStartThumb { get; } = new ReactiveCommand();

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DraggableControlViewModel()
        {
            DragStartThumb.Subscribe(ExecuteDragStartThumb);
        }

        /// <inheritdoc/>
        public string Title => "Draggable Control Sample View";

        /// <inheritdoc/>
        public event Action<IDialogResult> RequestClose;

        /// <inheritdoc/>
        public bool CanCloseDialog()
        {
            return true;
        }

        /// <inheritdoc/>
        public void OnDialogClosed() { }

        /// <inheritdoc/>
        public void OnDialogOpened(IDialogParameters parameters) { }

        private void ExecuteDragStartThumb(object obj)
        {
        }
    }
}
