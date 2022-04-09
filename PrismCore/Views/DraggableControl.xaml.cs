using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Media;

namespace PrismCore.Views
{
    /// <summary>
    /// Interaction logic for DraggableControl
    /// </summary>
    public partial class DraggableControl : UserControl
    {
        /// <summary>
        /// マウス押下中フラグ
        /// </summary>
        private bool _isMouseDown;
        private bool _isMouseDown2;

        /// <summary>
        /// マウスの移動が開始されたときの座標
        /// </summary>
        private Point _startPoint;
        private Point _startPoint2;

        /// <summary>
        /// マウスの現在位置座標
        /// </summary>
        private Point _currentPoint;
        private Point _currentPoint2;

        public DraggableControl()
        {
            InitializeComponent();
        }

        private void Thumb_DragStarted(object sender, DragStartedEventArgs e)
        {
            var thumb = sender as Thumb;
            if (null != thumb)
            {
                var border = thumb.Template.FindName("Thumb_Border", thumb) as Border;
                if (null != border)
                {
                    border.BorderThickness = new Thickness(1);
                }
            }
        }

        private void Thumb_DragCompleted(object sender, DragCompletedEventArgs e)
        {
            var thumb = sender as Thumb;
            if (null != thumb)
            {
                var border = thumb.Template.FindName("Thumb_Border", thumb) as Border;
                if (null != border)
                {
                    border.BorderThickness = new Thickness(1);
                }
            }
        }

        private void Thumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            var thumb = sender as Thumb;
            if (null != thumb)
            {
                var x = Canvas.GetLeft(thumb) + e.HorizontalChange;
                var y = Canvas.GetTop(thumb) + e.VerticalChange;

                var canvas = thumb.Parent as Canvas;
                if (null != canvas)
                {
                    x = Math.Max(x, 0);
                    y = Math.Max(y, 0);
                    x = Math.Min(x, canvas.ActualWidth - thumb.ActualWidth);
                    y = Math.Min(y, canvas.ActualHeight - thumb.ActualHeight);
                }

                Canvas.SetLeft(thumb, x);
                Canvas.SetTop(thumb, y);
            }
        }

        private void Target_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // フラグを"マウス押下中"にする
            _isMouseDown = true;

            // GetPositionメソッドで現在のマウス座標を取得し、マウス移動開始点を更新
            // （マウス座標は、OperationAreaからの相対的な位置とする）
            _startPoint = e.GetPosition(OperationArea);

            // イベントを処理済みとする（当イベントがこの先伝搬されるのを止めるため）
            e.Handled = true;
        }

        private void Target_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // マウス押下中フラグを落とす
            _isMouseDown = false;

            e.Handled = true;
        }

        private void Target_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            // マウス押下中でなければドラッグ操作ではないのでメソッドを抜ける
            if (!_isMouseDown)
            {
                return;
            }

            // マウスの現在位置座標を取得（OperationAreaからの相対位置）
            _currentPoint = e.GetPosition(OperationArea);
            Debug.WriteLine($"CurrentPoint:(X,Y)=({_currentPoint.X},{_currentPoint.Y})");

            //移動開始点と現在位置の差から、MouseMoveイベント1回分の移動量を算出
            double offsetX = _currentPoint.X - _startPoint.X;
            double offsetY = _currentPoint.Y - _startPoint.Y;

            // 動かす対象の図形からMatrixオブジェクトを取得
            // このMatrixオブジェクトを用いて図形を描画上移動させる
            Matrix matrix = ((MatrixTransform)Target.RenderTransform).Matrix;

            // TranslateメソッドにX方向とY方向の移動量を渡し、移動後の状態を計算
            matrix.Translate(offsetX, offsetY);

            // 移動後の状態を計算したMatrixオブジェクトを描画に反映する
            Target.RenderTransform = new MatrixTransform(matrix);

            // 移動開始点を現在位置で更新する
            // （今回の現在位置が次回のMouseMoveイベントハンドラで使われる移動開始点となる）
            _startPoint = _currentPoint;

            e.Handled = true;
        }

        private void OperationArea_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            _isMouseDown = false;

            e.Handled = true;
        }

        private void Target2_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // フラグを"マウス押下中"にする
            _isMouseDown2 = true;

            // GetPositionメソッドで現在のマウス座標を取得し、マウス移動開始点を更新
            // （マウス座標は、OperationAreaからの相対的な位置とする）
            _startPoint2 = e.GetPosition(StackArea);

            // イベントを処理済みとする（当イベントがこの先伝搬されるのを止めるため）
            e.Handled = true;
        }

        private void Target2_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // マウス押下中フラグを落とす
            _isMouseDown2 = false;

            e.Handled = true;
        }

        private void Target2_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            // マウス押下中でなければドラッグ操作ではないのでメソッドを抜ける
            if (!_isMouseDown2)
            {
                return;
            }

            // マウスの現在位置座標を取得（OperationAreaからの相対位置）
            _currentPoint2 = e.GetPosition(StackArea);
            Debug.WriteLine($"CurrentPoint:(X,Y)=({_currentPoint2.X},{_currentPoint2.Y})");

            //移動開始点と現在位置の差から、MouseMoveイベント1回分の移動量を算出
            double offsetX = _currentPoint2.X - _startPoint2.X;
            double offsetY = _currentPoint2.Y - _startPoint2.Y;

            // 動かす対象の図形からMatrixオブジェクトを取得
            // このMatrixオブジェクトを用いて図形を描画上移動させる
            Matrix matrix = ((MatrixTransform)Target2.RenderTransform).Matrix;

            // TranslateメソッドにX方向とY方向の移動量を渡し、移動後の状態を計算
            matrix.Translate(offsetX, offsetY);

            // 移動後の状態を計算したMatrixオブジェクトを描画に反映する
            Target2.RenderTransform = new MatrixTransform(matrix);

            // 移動開始点を現在位置で更新する
            // （今回の現在位置が次回のMouseMoveイベントハンドラで使われる移動開始点となる）
            _startPoint2 = _currentPoint2;

            e.Handled = true;
        }

        private void StackArea_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            //MessageBox.Show("AAA");
            _isMouseDown2 = false;

            e.Handled = true;
        }
    }
}
