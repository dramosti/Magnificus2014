﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace HLP.Comum.View.Components
{
    public class CustomDockPanelSplitter : Control
    {
        static CustomDockPanelSplitter()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomDockPanelSplitter),
                new FrameworkPropertyMetadata(typeof(CustomDockPanelSplitter)));

            // override the Background property
            BackgroundProperty.OverrideMetadata(typeof(CustomDockPanelSplitter), new FrameworkPropertyMetadata(Brushes.Transparent));

            // override the Dock property to get notifications when Dock is changed
            DockPanel.DockProperty.OverrideMetadata(typeof(CustomDockPanelSplitter),
                new FrameworkPropertyMetadata(Dock.Left, new PropertyChangedCallback(DockChanged)));
        }

        /// <summary>
        /// Resize the target element proportionally with the parent container
        /// Set to false if you don't want the element to be resized when the parent is resized.
        /// </summary>
        public bool ProportionalResize
        {
            get { return (bool)GetValue(ProportionalResizeProperty); }
            set { SetValue(ProportionalResizeProperty, value); }
        }

        public static readonly DependencyProperty ProportionalResizeProperty =
            DependencyProperty.Register("ProportionalResize", typeof(bool), typeof(CustomDockPanelSplitter),
            new UIPropertyMetadata(true));

        /// <summary>
        /// Height or width of splitter, depends of orientation of the splitter
        /// </summary>
        public double Thickness
        {
            get { return (double)GetValue(ThicknessProperty); }
            set { SetValue(ThicknessProperty, value); }
        }

        public static readonly DependencyProperty ThicknessProperty =
            DependencyProperty.Register("Thickness", typeof(double), typeof(CustomDockPanelSplitter),
            new UIPropertyMetadata(4.0, ThicknessChanged));


        #region Private fields
        private FrameworkElement element;     // element to resize (target element)
        private double width;                 // current desired width of the element, can be less than minwidth
        private double height;                // current desired height of the element, can be less than minheight
        private double previousParentWidth;   // current width of parent element, used for proportional resize
        private double previousParentHeight;  // current height of parent element, used for proportional resize
        #endregion

        public CustomDockPanelSplitter()
        {
            Loaded += DockPanelSplitterLoaded;
            Unloaded += DockPanelSplitterUnloaded;

            UpdateHeightOrWidth();
        }

        void DockPanelSplitterLoaded(object sender, RoutedEventArgs e)
        {
            Panel dp = Parent as Panel;
            if (dp == null) return;

            // Subscribe to the parent's size changed event
            dp.SizeChanged += ParentSizeChanged;

            // Store the current size of the parent DockPanel
            previousParentWidth = dp.ActualWidth;
            previousParentHeight = dp.ActualHeight;

            // Find the target element
            UpdateTargetElement();

        }

        void DockPanelSplitterUnloaded(object sender, RoutedEventArgs e)
        {
            Panel dp = Parent as Panel;
            if (dp == null) return;

            // Unsubscribe
            dp.SizeChanged -= ParentSizeChanged;
        }

        private static void DockChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((CustomDockPanelSplitter)d).UpdateHeightOrWidth();
        }

        private static void ThicknessChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((CustomDockPanelSplitter)d).UpdateHeightOrWidth();
        }

        private void UpdateHeightOrWidth()
        {
            if (IsHorizontal)
            {
                Height = Thickness;
                Width = double.NaN;
            }
            else
            {
                Width = Thickness;
                Height = double.NaN;
            }
        }

        public bool IsHorizontal
        {
            get
            {
                Dock dock = DockPanel.GetDock(this);
                return dock == Dock.Top || dock == Dock.Bottom;
            }
        }

        /// <summary>
        /// Update the target element (the element the DockPanelSplitter works on)
        /// </summary>
        private void UpdateTargetElement()
        {
            Panel dp = Parent as Panel;
            if (dp == null) return;

            int i = dp.Children.IndexOf(this);

            // The splitter cannot be the first child of the parent DockPanel
            // The splitter works on the 'older' sibling 
            if (i > 0 && dp.Children.Count > 0)
            {
                element = dp.Children[i - 1] as FrameworkElement;
            }
        }

        private void SetTargetWidth(double newWidth)
        {
            if (newWidth < element.MinWidth)
                newWidth = element.MinWidth;
            if (newWidth > element.MaxWidth)
                newWidth = element.MaxWidth;

            Panel dp = Parent as Panel;
            Dock dock = DockPanel.GetDock(this);
            MatrixTransform t = element.TransformToAncestor(dp) as MatrixTransform;
            if (dock == Dock.Left && newWidth > dp.ActualWidth - t.Matrix.OffsetX - Thickness)
                newWidth = dp.ActualWidth - t.Matrix.OffsetX - Thickness;

            element.Width = newWidth;
        }

        private void SetTargetHeight(double newHeight)
        {
            if (newHeight < element.MinHeight)
                newHeight = element.MinHeight;
            if (newHeight > element.MaxHeight)
                newHeight = element.MaxHeight;

            Panel dp = Parent as Panel;
            Dock dock = DockPanel.GetDock(this);
            MatrixTransform t = element.TransformToAncestor(dp) as MatrixTransform;
            if (dock == Dock.Top && newHeight > dp.ActualHeight - t.Matrix.OffsetY - Thickness)
                newHeight = dp.ActualHeight - t.Matrix.OffsetY - Thickness;

            element.Height = newHeight;
        }

        private void ParentSizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (!ProportionalResize) return;

            DockPanel dp = Parent as DockPanel;
            if (dp == null) return;

            double sx = dp.ActualWidth / previousParentWidth;
            double sy = dp.ActualHeight / previousParentHeight;

            if (!double.IsInfinity(sx))
                SetTargetWidth(element.Width * sx);
            if (!double.IsInfinity(sy))
                SetTargetHeight(element.Height * sy);

            previousParentWidth = dp.ActualWidth;
            previousParentHeight = dp.ActualHeight;

        }

        double AdjustWidth(double dx, Dock dock)
        {
            if (dock == Dock.Right)
                dx = -dx;

            width += dx;
            SetTargetWidth(width);

            return dx;
        }

        double AdjustHeight(double dy, Dock dock)
        {
            if (dock == Dock.Bottom)
                dy = -dy;

            height += dy;
            SetTargetHeight(height);

            return dy;
        }

        Point StartDragPoint;

        protected override void OnMouseEnter(MouseEventArgs e)
        {
            base.OnMouseEnter(e);
            if (!IsEnabled) return;
            Cursor = IsHorizontal ? Cursors.SizeNS : Cursors.SizeWE;
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            if (!IsEnabled) return;

            if (!IsMouseCaptured)
            {
                StartDragPoint = e.GetPosition(Parent as IInputElement);
                UpdateTargetElement();
                if (element != null)
                {
                    width = element.ActualWidth;
                    height = element.ActualHeight;
                    CaptureMouse();
                }
            }

            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (IsMouseCaptured)
            {
                Point ptCurrent = e.GetPosition(Parent as IInputElement);
                Point delta = new Point(ptCurrent.X - StartDragPoint.X, ptCurrent.Y - StartDragPoint.Y);
                Dock dock = DockPanel.GetDock(this);

                if (IsHorizontal)
                    delta.Y = AdjustHeight(delta.Y, dock);
                else
                    delta.X = AdjustWidth(delta.X, dock);

                bool isBottomOrRight = (dock == Dock.Right || dock == Dock.Bottom);

                // When docked to the bottom or right, the position has changed after adjusting the size
                if (isBottomOrRight)
                    StartDragPoint = e.GetPosition(Parent as IInputElement);
                else
                    StartDragPoint = new Point(StartDragPoint.X + delta.X, StartDragPoint.Y + delta.Y);
            }
            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            if (IsMouseCaptured)
            {
                ReleaseMouseCapture();
            }
            base.OnMouseUp(e);
        }

    }
}
