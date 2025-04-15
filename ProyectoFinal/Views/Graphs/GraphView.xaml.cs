using ProyectoFinal.Models.Graphs;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ProyectoFinal.Views.Graphs
{
    /// <summary>
    /// Interaction logic for GraphView.xaml
    /// </summary>
    public partial class GraphView : UserControl
    {
        private bool _isDragging;

        private GraphNode _draggedNode;

        private Point _dragStartPoint;

        public GraphView()
        {
            InitializeComponent();
        }

        private void Canvas_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            try
            {

                var st = GraphCanvas.LayoutTransform as ScaleTransform ?? new ScaleTransform(1, 1);
                double zoom = e.Delta > 0 ? .2 : -.2;

                double amount = st.ScaleX;
                amount += zoom;

                if (Math.Round(amount , 2) == 0)
                {
                    return;
                }

                st.ScaleX += zoom;
                st.ScaleY += zoom;


                GraphCanvas.LayoutTransform = st;
            }
            catch (Exception ex)
            {

            }
        }

        private void Ellipse_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is FrameworkElement element && element.DataContext is GraphNode node)
            {
                _isDragging = true;
                _draggedNode = node;
                _dragStartPoint = e.GetPosition(GraphCanvas);
                element.CaptureMouse();
            }
        }

        private void Ellipse_MouseMove(object sender, MouseEventArgs e)
        {
            if (_isDragging && _draggedNode != null)
            {
                Point currentPosition = e.GetPosition(GraphCanvas);
                double offsetX = currentPosition.X - _dragStartPoint.X;
                double offsetY = currentPosition.Y - _dragStartPoint.Y;

                _draggedNode.X += offsetX;
                _draggedNode.Y += offsetY;

                _dragStartPoint = currentPosition;
            }
        }

        private void Ellipse_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (_isDragging)
            {
                _isDragging = false;
                _draggedNode = null;
                if (sender is FrameworkElement element)
                {
                    element.ReleaseMouseCapture();
                }
            }
        }
    }
}
