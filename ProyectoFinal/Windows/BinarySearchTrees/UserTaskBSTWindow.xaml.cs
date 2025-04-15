using ProyectoFinal.Models.BinarySearchTrees;
using ProyectoFinal.Models.LinkedLists;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace ProyectoFinal.Windows.BinarySearchTrees
{
    /// <summary>
    /// Interaction logic for UserTaskBSTWindow.xaml
    /// </summary>
    public partial class UserTaskBSTWindow : Window
    {
        private TaskBinarySearchTree _bst;

        private int _radius = 20;

        public UserTaskBSTWindow(Window owner, LinkListWithActions<UserTask> tasks)
        {
            Owner = owner;
            InitializeComponent();
            InitTree(tasks);
        }

        /// <summary>
        /// Iniciamos el ABB y calculamos los pesos de las tareas para poder generar el mismo.
        /// </summary>
        /// <param name="tasks"></param>
        private void InitTree(LinkListWithActions<UserTask> tasks)
        {
            _bst = new TaskBinarySearchTree();

            foreach (UserTask task in tasks.LinkList)
            {
                task.CalculateWeight();
                _bst.Insert(task);
            }
        }

        /// <summary>
        /// Al cargar la ventana dibujamos el arbol en un Canvas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Clear the canvas and start drawing from the root.
            canvas.Children.Clear();
            double startX = canvas.ActualWidth / 2;
            double startY = 40;
            double horizontalSpacing = canvas.ActualWidth / 4;
            DrawTree(_bst.Root, startX, startY, horizontalSpacing);
        }

        /// <summary>
        /// Dibujamos de forma recursiva el arbol binario.
        /// </summary>
        /// <param name="node">Nodo a dibujar.</param>
        /// <param name="x">Coordenadas en x del nodo.</param>
        /// <param name="y">Coordenadas en y del nodo.</param>
        /// <param name="horizontalSpacing">Horizontal spacing to use for child nodes.</param>
        private void DrawTree(TaskNode node, double x, double y, double horizontalSpacing)
        {
            if (node == null)
                return;

            // Creamos un nodo en forma de una elipse de 40x40.
            Ellipse ellipse = new Ellipse
            {
                Width = _radius * 2,
                Height = _radius * 2,
                Fill = Brushes.LightBlue,
                Stroke = Brushes.Black,
                StrokeThickness = 1,
            };

            // Centramos el nodo en (x,y)
            Canvas.SetLeft(ellipse, x - _radius);
            Canvas.SetTop(ellipse, y - _radius);
            canvas.Children.Add(ellipse);

            // Agregamos un textblock con el nombre de la tarea dentro del elipse.
            TextBlock textBlock = new TextBlock
            {
                Text = $"{node.Task.Title:F2}",
                Foreground = Brushes.Black,
                FontWeight = FontWeights.Bold
            };

            // Posicionamos el texto en el centro.
            Canvas.SetLeft(textBlock, x - 15);
            Canvas.SetTop(textBlock, y - 10);
            canvas.Children.Add(textBlock);

            // Definimos el espacio vertical entre los niveles es de.
            double childY = y + 60;

            // Validamos existe un arbol izquierdo y lo dibujamos en el canvas de forma recursiva.
            if (node.Left != null)
            {
                double leftX = x - horizontalSpacing;
                DrawTreeAndNode(x, y, leftX, childY, node.Left, horizontalSpacing);
            }

            // Validamos existe arbol derecho y lo dibujamos en el canvas de forma recursiva.
            if (node.Right != null)
            {
                double rightX = x + horizontalSpacing;
                DrawTreeAndNode(x, y, rightX, childY, node.Right, horizontalSpacing);
            }
        }

        /// <summary>
        /// Generar nodo actual y sus hijos.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <param name="node"></param>
        /// <param name="horizontalSpacing"></param>
        private void DrawTreeAndNode(double x, double y, double x2, double y2, TaskNode node, double horizontalSpacing)
        {
            /**
             * Calculamos de la distancia de las tangentes de dos circulos.
             */
            
            double dx = x2 - x;
            double dy = y2 - y;
            double distance = Math.Sqrt(Math.Pow(dx, 2) + Math.Pow(dy, 2));

            double startX = x + (dx / distance) * _radius;
            double startY = y + (dy / distance) * _radius;
            double endX = x2 - (dx / distance) * _radius;
            double endY = y2 - (dy / distance) * _radius;

            // Dibujamos una linea del nodo actual al siguiente nodo.
            Line rightLine = new Line
            {
                X1 = startX,
                Y1 = startY,
                X2 = endX,
                Y2 = endY,
                Stroke = Brushes.Black,
                StrokeThickness = 1
            };
            canvas.Children.Add(rightLine);

            // Dibujamos el arbol recursivamente.
            DrawTree(node, x2, y2, horizontalSpacing / 2);

        }
    }
}
