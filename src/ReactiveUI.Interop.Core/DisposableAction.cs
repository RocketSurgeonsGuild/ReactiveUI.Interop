using System;

namespace ReactiveUI.Interop.Core
{
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

        /// <inheritdoc />
        public void Dispose()
        {
            _action();
        }
    }
}