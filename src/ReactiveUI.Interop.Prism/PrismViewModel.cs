using System;
using System.ComponentModel;
using ReactiveUI;

namespace Rocket.Surgery.ReactiveUI.Interop.Prism
{
    /// <summary>
    /// Object that abstracts <see cref="T:ReactiveUI.ReactiveObject" /> for use with Prism.
    /// </summary>
    /// <seealso cref="T:ReactiveUI.ReactiveObject" />
    public abstract class PrismViewModel : IPrismViewModel
    {
        private readonly PrismReactiveObject _reactiveObject = new();

        /// <inheritdoc />
        public virtual void Destroy() { }

        /// <inheritdoc />
        public virtual IDisposable SuppressChangeNotifications()
        {
            var suppressor = _reactiveObject.SuppressChangeNotifications();

            return new DisposableAction(() => suppressor.Dispose());
        }

        /// <inheritdoc />
        public IObservable<IReactivePropertyChangedEventArgs<IReactiveObject>> Changing =>
            _reactiveObject.Changing;

        /// <inheritdoc />
        public IObservable<IReactivePropertyChangedEventArgs<IReactiveObject>> Changed => _reactiveObject.Changed;

        /// <inheritdoc />
        public event PropertyChangedEventHandler PropertyChanged
        {
            add => _reactiveObject.PropertyChanged += value;
            remove => _reactiveObject.PropertyChanged -= value;
        }

        /// <inheritdoc />
        public event PropertyChangingEventHandler PropertyChanging
        {
            add => _reactiveObject.PropertyChanging += value;
            remove => _reactiveObject.PropertyChanging -= value;
        }

        /// <inheritdoc />
        public void RaisePropertyChanging(PropertyChangingEventArgs args) =>
            _reactiveObject.RaisePropertyChanging(args.PropertyName);

        /// <inheritdoc />
        public void RaisePropertyChanged(PropertyChangedEventArgs args) =>
            _reactiveObject.RaisePropertyChanged(args.PropertyName);

        /// <inheritdoc />
        public IObservable<Exception> ThrownExceptions => _reactiveObject.ThrownExceptions;
    }
}