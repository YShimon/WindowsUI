using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using Reactive.Bindings;

namespace PrismCore.ViewModels
{
    public class DragAndDropViewModel : BindableBase, IDialogAware
    {
        private bool isDragging = false;

        public ReactiveCommand<DragEventArgs> OnDrop { get; private set; } = new ReactiveCommand<DragEventArgs>();

        // TODO:名称変更
        public ReactiveCommand<DragEventArgs> OnDragEnter { get; private set; } = new ReactiveCommand<DragEventArgs>();

        public ReactiveCommand<DragEventArgs> OnDragMove { get; private set; } = new ReactiveCommand<DragEventArgs>();

        public DragAndDropViewModel()
        {
            OnDrop.Subscribe(e => ExecuteOnDrop(e));
            OnDragEnter.Subscribe(e => ExecuteOnDragEnter(e));
            OnDragMove.Subscribe(e => ExecuteOnDragMove(e));
        }

        public string Title => "Drag and Drop Sample View";

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

        private void ExecuteOnDrop(DragEventArgs e)
        {
            if (e == null)
            {
                MessageBox.Show("DragEventArgs is null");
                return;
            }

            // コントロールにドロップしたファイル名（コレクションで）を取得
            // TODO:ファイルではない場合（コントロールをドロップした場合等）どうする？
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                var dropFile = e.Data.GetData(DataFormats.FileDrop, false) as string[];
                MessageBox.Show($"File Dropped:{dropFile.FirstOrDefault()}");
            }
        }

        private void ExecuteOnDragEnter(DragEventArgs e)
        {
            isDragging = true;
        }

        private void ExecuteOnDragMove(DragEventArgs e)
        {
            if (!isDragging) return;

            Mouse.OverrideCursor = Cursors.Hand;
        }
    }
}
