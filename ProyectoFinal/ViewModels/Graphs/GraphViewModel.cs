using ProyectoFinal.Commands.Graphs;
using ProyectoFinal.Models.Graphs;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace ProyectoFinal.ViewModels
{
    public class GraphViewModel : BaseViewModel
    {
        /// <summary>
        /// Variable del ViewModel principal del programa para hacer llamados necesarios desde el ViewModel actual.
        /// </summary>
        public MainViewModel MainVm { get; set; }

        /// <summary>
        /// 
        /// </summary>
        private ObservableCollection<GraphNode> _nodes;

        /// <summary>
        /// Colección de las definiciones de los nodos.
        /// </summary>
        public IList<GraphNode> Nodes => _nodes;

        /// <summary>
        /// Colección privada de las aristas de los nodos.
        /// </summary>
        private ObservableCollection<GraphEdge> _edges;

        /// <summary>
        /// Colección de las definiciones de las artias de los nodos.
        /// </summary>
        public IList<GraphEdge> Edges => _edges;

        private string _name;

        /// <summary>
        /// Nombre de la ubicación a agregar.
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        /// <summary>
        /// Comando para agregar un nuevo nodo al canvas.
        /// </summary>
        public ICommand AddNode { get; set; }

        /// <summary>
        /// Comando para agregar conexión de un nodo a otro.
        /// </summary>
        public ICommand AddEdge { get; set; }

        /// <summary>
        /// Comando para editar conexión de un nodo a otro.
        /// </summary>
        public ICommand EditEdge { get; set; }

        /// <summary>
        /// Comando para eliminar conexíón de un nodo a otro.
        /// </summary>
        public ICommand DeleteEdge { get; set; }

        /// <summary>
        /// Comando para eliminar un nodo al canvas.
        /// </summary>
        public ICommand DeleteNode { get; set; }

        /// <summary>
        /// Comando para buscar la distancia más corta entre dos nodos.
        /// </summary>
        public ICommand FindDistance { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="mainVm"></param>
        public GraphViewModel(MainViewModel mainVm)
        {
            MainVm = mainVm;

            /**
             * Datos dummy.
             */
            GraphNode a = new GraphNode("A", 150, 50, Brushes.Red);
            GraphNode b = new GraphNode("B", 250, 150, Brushes.Green);
            GraphNode c = new GraphNode("C", 350, 50, Brushes.Blue);

            _nodes = new ObservableCollection<GraphNode>
            {
                a, b, c,
            };

            _edges = new ObservableCollection<GraphEdge>
            {
                new GraphEdge(Nodes[0], Nodes[1], 10),
                new GraphEdge(Nodes[1], Nodes[2], 5),
            };

            AddNode = new AddLocationCmd(this);
            AddEdge = new OpenEdgeCmd(this);
            EditEdge = new EditEdgeCmd(this);
            DeleteEdge = new DeleteEdgeCmd(this);
            DeleteNode = new DeleteLocationCmd(this);
            FindDistance = new OpenFindDistanceCmd(this);
        }

        /// <summary>
        /// Buscar la ruta más cercana al ejecutar el comando.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        public void SearchRoute(GraphNode from, GraphNode to)
        {
            foreach (GraphEdge edge in Edges)
            {
                edge.IsHighLighted = false;
            }

            List<GraphNode> route = DijkstraSearch(from, to);

            if (route == null)
            {
                MessageBox.Show($"No se pudo encontrar una ruta de {from.Text} a {to.Text}.",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
                return;
            }

            HighLightNodes(route);
        }

        /// <summary>
        /// Aplicación del algoritmo de Dijkstra para buscar la ruta más corta.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        private List<GraphNode> DijkstraSearch(GraphNode from, GraphNode to)
        {
            // Generamos un diccionario de los nodos y distancias, primero se inicializan con infinito positivo.
            Dictionary<GraphNode, double> distances = Nodes.ToDictionary(x => x, x => double.PositiveInfinity);
            // Generamos un diccionario de los previos.
            Dictionary<GraphNode, GraphNode> previousNodes = new Dictionary<GraphNode, GraphNode>();
            // Generamos un hashset de los nodos no visitados, se inicializa con todos los nodos ya que no hemos visitado alguno todavía.
            HashSet<GraphNode> unvisited = new HashSet<GraphNode>(Nodes);

            // Inicializamos el primer nodo con una distancia de 0.
            distances[from] = 0;

            // Recorremos todos los nodos no visitados hasta visitarlos a todos.
            while (unvisited.Any())
            {
                GraphNode current = unvisited.OrderBy(x => distances[x]).First();

                // Si la distancia restante es infinito eso significa que el nodo no se está conectado, por ende, debemos salir.
                if (distances[current] == double.PositiveInfinity)
                {
                    break;
                }
            
                // Si el nodo es el final de la ruta terminamos la búsqueda.
                if (current == to)
                {
                    List<GraphNode> path = new List<GraphNode>();

                    // Iteramos la lista de nodos previos para generar la lista de resultados.
                    while (previousNodes.ContainsKey(current))
                    {
                        path.Insert(0, current);
                        current = previousNodes[current];
                    }

                    path.Insert(0, from);
                    return path;
                }

                // Eliminamos el nodo actual del hashset de no visitados.
                unvisited.Remove(current);

                // Retiramos una lista de las aristas en el que el nodo actual sea el parte del inicio o fin de la conexión.
                IList<GraphEdge> edges = Edges.Where(x => x.From == current || x.To == current).ToList();

                foreach (GraphEdge edge in Edges.Where(x => x.From == current || x.To == current))
                {
                    // Buscamos el vecino para ir al siguiente nodo.
                    GraphNode neighbor = edge.From == current ? edge.To : edge.From;
                    
                    // Si el nodo ya se visito se ignora.
                    if (!unvisited.Contains(neighbor))
                    {
                        continue;
                    }

                    double alt = distances[current] + edge.Distance;

                    // Si la distancia actual + la de la arista es menor que la distancia de los vecinos entonces lo agregamos.
                    if (alt < distances[neighbor])
                    {
                        distances[neighbor] = alt;
                        previousNodes[neighbor] = current;
                    }
                }
            }

            // No se encontró una ruta del nodo inicial al final.
            return null;
        }

        /// <summary>
        /// Resaltar las conexiones entre nodos si esta dentro de la ruta más corta.
        /// </summary>
        /// <param name="nodes"></param>
        private void HighLightNodes(List<GraphNode> nodes)
        {
            for (int i = 0; i < nodes.Count - 1; i++)
            {
                GraphNode from = nodes[i];
                GraphNode to = nodes[i + 1];

                GraphEdge edge = Edges.FirstOrDefault(x => (x.From == from && x.To == to) || (x.From == to && x.To == from));

                if (edge == null)
                {
                    continue;
                }

                edge.IsHighLighted = true;
            }
        }
    }
}
