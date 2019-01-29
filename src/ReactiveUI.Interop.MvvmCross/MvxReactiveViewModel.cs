using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MvvmCross.ViewModels;
using ReactiveUI;
using PropertyChangingEventArgs = ReactiveUI.PropertyChangingEventArgs;
using PropertyChangingEventHandler = ReactiveUI.PropertyChangingEventHandler;

namespace Rocket.Surgery.ReactiveUI.Interop.MvvmCross
{
    /// <summary>
    /// Object that handles inter operability between a MvvmCross and ReactiveUI view model.
    /// </summary>
    public class MvxReactiveViewModel : MvxViewModel, IMvxReactiveViewModel
    {
        private readonly MvxReactiveObject _reactiveObj = new MvxReactiveObject();

        private bool _suppressNpc;

        /// <inheritdoc />
        public IObservable<IReactivePropertyChangedEventArgs<IReactiveObject>> Changed => _reactiveObj.Changed;

        /// <inheritdoc />
        public IObservable<IReactivePropertyChangedEventArgs<IReactiveObject>> Changing => _reactiveObj.Changing;

        /// <inheritdoc />
        public IObservable<Exception> ThrownExceptions => _reactiveObj.ThrownExceptions;

        /// <inheritdoc />
        public new event PropertyChangedEventHandler PropertyChanged
        {
            add => _reactiveObj.PropertyChanged += value;
            remove => _reactiveObj.PropertyChanged -= value;
        }

        /// <inheritdoc />
        public new event PropertyChangingEventHandler PropertyChanging
        {
            add => _reactiveObj.PropertyChanging += value;
            remove => _reactiveObj.PropertyChanging -= value;
        }

        /// <inheritdoc />
        public new void RaisePropertyChanged(PropertyChangedEventArgs args)
        {
            _reactiveObj.RaisePropertyChanged(args.PropertyName);
        }

        /// <inheritdoc />
        public void RaisePropertyChanging(PropertyChangingEventArgs args)
        {
            _reactiveObj.RaisePropertyChanging(args.PropertyName);
        }

        /// <summary>
        /// Sets the property raising the change event and setting a newer value.
        /// </summary>
        /// <param name="storage"></param>
        /// <param name="value"></param>
        /// <param name="propertyName"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public new bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            var original = storage;

            IReactiveObjectExtensions.RaiseAndSetIfChanged(this, ref storage, value, propertyName);

            return !EqualityComparer<T>.Default.Equals(original, value);
        }

        /// <inheritdoc />
        public IDisposable SuppressChangeNotifications()
        {
            _suppressNpc = true;

            var suppressor = _reactiveObj.SuppressChangeNotifications();

            return new DisposableAction(() =>
            {
                _suppressNpc = false;

                suppressor.Dispose();
            });
        }

        /// <inheritdoc />
        protected override MvxInpcInterceptionResult InterceptRaisePropertyChanged(PropertyChangedEventArgs changedArgs)
        {
            if (_suppressNpc)
            {
                return MvxInpcInterceptionResult.DoNotRaisePropertyChanged;
            }

            return base.InterceptRaisePropertyChanged(changedArgs);
        }
    }
}