using System;
using System.Windows.Input;

namespace ProyectoFinal.Commands
{
    /// <summary>
    /// Clase abstract base para los comandos, la cual se extiende por cada comando requerido por ventana.
    /// </summary>
    public abstract class BaseCommand : ICommand
    {
        /// <summary>
        /// Evento para indicar que se ha cambiado el estado de ejecución del bóton.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// Indicador si el comando se puede ejecutar o no.
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// Función extendible para poder ejecutar el comando.
        /// </summary>
        /// <param name="parameter"></param>
        public abstract void Execute(object parameter);

        /// <summary>
        /// Función ejecutable al momento de indicar que el estado del ejecución ha cambiado y llamar la función
        /// de CanExecute.
        /// </summary>
        protected void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
