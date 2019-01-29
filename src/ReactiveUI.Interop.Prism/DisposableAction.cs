using System;

namespace Rocket.Surgery.ReactiveUI.Interop.Prism
{
    /// <summary>
    /// Object that represents an action that will dispose after use.
    /// </summary>
    /// <seealso cref="IDisposable" />
    public class DisposableAction : IDisposable
    {
        private readonly Action _action;

        /// <summary>
        /// Initializes a new instance of the <see cref="DisposableAction"/> class.
        /// </summary>
        /// <param name="action">The action.</param>
        public DisposableAction(Action action)
        {
            _action = action;
        }

        /// <inheritdoc />.
        public void Dispose()
        {
            _action();
        }
    }
}