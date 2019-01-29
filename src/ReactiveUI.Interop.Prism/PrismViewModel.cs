using System;
using System.ComponentModel;
using Prism.Navigation;
using ReactiveUI;
using PropertyChangingEventArgs = ReactiveUI.PropertyChangingEventArgs;
using PropertyChangingEventHandler = ReactiveUI.PropertyChangingEventHandler;

namespace Rocket.Surgery.ReactiveUI.Interop.Prism
{
    /// <summary>
    /// Object that abstracts <see cref="T:ReactiveUI.ReactiveObject" /> for use with Prism.
    /// </summary>
    /// <seealso cref="T:ReactiveUI.ReactiveObject" />
    public abstract class PrismViewModel : IPrismViewModel
    {
        private readonly PrismReactiveObject _reactiveObject = new PrismReactiveObject();
        private bool _suppressNpc;

        /// <inheritdoc />
        public virtual void Destroy() { }

        /// <inheritdoc />
        public virtual void OnNavigatedFrom(INavigationParameters parameters) { }

        /// <inheritdoc />
        public virtual void OnNavigatedTo(INavigationParameters parameters) { }

        /// <inheritdoc />
        public virtual void OnNavigatingTo(INavigationParameters parameters) { }

        /// <inheritdoc />
        public virtual IDisposable SuppressChangeNotifications()
        {
            _suppressNpc = true;

            var suppressor = _reactiveObject.SuppressChangeNotifications();

            return new DisposableAction(() =>
            {
                _suppressNpc = false;

                suppressor.Dispose();
            });
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