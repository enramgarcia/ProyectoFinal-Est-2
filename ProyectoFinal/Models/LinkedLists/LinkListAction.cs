using ProyectoFinal.Enums.LinkedLists;

namespace ProyectoFinal.Models.LinkedLists
{
    /// <summary>
    /// Clase para manejar las acciones ejecutadas por el usuario y llevar un registro para poder deshacer y rehacer tareas.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkListAction<T>
    {
        /// <summary>
        /// Acción ejectuada por el usuario (Agregar, Editar, Quitar).
        /// </summary>
        public LinkListActionType Action { get; set; }

        /// <summary>
        /// Valor previo a la acción.
        /// </summary>
        public T OldValue { get; set; }

        /// <summary>
        /// Valor posterior a la acción.
        /// </summary>
        public T NewValue { get; set; }

        /// <summary>
        /// Indice del registro al ejecutar la acción.
        /// </summary>
        public int Index { get; set; }
    }
}
