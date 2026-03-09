using System;
using System.ComponentModel;
using FreshMvvm;
using ReactiveUI;

namespace Rocket.Surgery.ReactiveUI.Interop.FreshMvvm
{
    /// <summary>
    /// Object that handles inter operability between a FreshMvvm page model and ReactiveUI view model.
    /// </summary>
    /// <seealso cref="FreshBasePageModel" />
    /// <seealso cref="IFreshReactiveViewModel" />
    public class FreshReactiveViewModel : FreshBasePageModel, IFreshReactiveViewModel
    {
        private readonly FreshReactiveObject _reactiveObject = new();
        private bool _suppressNpc;

        /// <inheritdoc />
        public IObservable<IReactivePropertyChangedEventArgs<IReactiveObject>> Changed => _reactiveObject.Changed;

        /// <inheritdoc />
        public IObservable<IReactivePropertyChangedEventArgs<IReactiveObject>> Changing =>
            _reactiveObject.Changing;

        /// <inheritdoc />
        public IObservable<Exception> ThrownExceptions => _reactiveObject.ThrownExceptions;

        /// <inheritdoc />
        public event PropertyChangingEventHandler? PropertyChanging
        {
            add => _reactiveObject.PropertyChanging += value;
            remove => _reactiveObject.PropertyChanging -= value;
        }

        /// <inheritdoc />
        public void RaisePropertyChanged(PropertyChangedEventArgs args) => _reactiveObject.RaisePropertyChanged(args.PropertyName);

        /// <inheritdoc />
        public void RaisePropertyChanging(PropertyChangingEventArgs args) => _reactiveObject.RaisePropertyChanging(args.PropertyName);

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
    }
}