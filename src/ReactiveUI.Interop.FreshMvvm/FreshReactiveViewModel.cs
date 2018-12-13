using ReactiveUI;
using ReactiveUI.Interop.Core;
using System;
using System.ComponentModel;
using PropertyChangingEventArgs = ReactiveUI.PropertyChangingEventArgs;
using PropertyChangingEventHandler = ReactiveUI.PropertyChangingEventHandler;

namespace FreshMvvm.ReactiveUI.Interop
{
    /// <summary>
    /// Object that handles inter operability between a FreshMvvm page model and ReactiveUI view model.
    /// </summary>
    /// <seealso cref="FreshMvvm.FreshBasePageModel" />
    /// <seealso cref="FreshMvvm.ReactiveUI.Interop.IFreshReactiveViewModel" />
    public class FreshReactiveViewModel : FreshBasePageModel, IFreshReactiveViewModel
    {
        private readonly FreshReactiveObject _freshReactiveObject = new FreshReactiveObject();
        private bool _suppressNpc;

        /// <inheritdoc />
        public IObservable<IReactivePropertyChangedEventArgs<IReactiveObject>> Changed => _freshReactiveObject.Changed;

        /// <inheritdoc />
        public IObservable<IReactivePropertyChangedEventArgs<IReactiveObject>> Changing =>
            _freshReactiveObject.Changing;

        /// <inheritdoc />
        public IObservable<Exception> ThrownExceptions => _freshReactiveObject.ThrownExceptions;

        /// <inheritdoc />
        public event PropertyChangingEventHandler PropertyChanging
        {
            add => _freshReactiveObject.PropertyChanging += value;
            remove => _freshReactiveObject.PropertyChanging -= value;
        }

        /// <inheritdoc />
        public void RaisePropertyChanged(PropertyChangedEventArgs args)
        {
            _freshReactiveObject.RaisePropertyChanged(args.PropertyName);
        }

        /// <inheritdoc />
        public void RaisePropertyChanging(PropertyChangingEventArgs args)
        {
            _freshReactiveObject.RaisePropertyChanging(args.PropertyName);
        }

        /// <inheritdoc />
        public IDisposable SuppressChangeNotifications()
        {
            _suppressNpc = true;

            var suppressor = _freshReactiveObject.SuppressChangeNotifications();

            return new DisposableAction(() =>

            {
                _suppressNpc = false;

                suppressor.Dispose();
            });
        }
    }
}