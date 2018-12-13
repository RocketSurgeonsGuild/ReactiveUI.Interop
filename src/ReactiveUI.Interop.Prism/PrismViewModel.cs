using System;
using Prism.Navigation;

namespace ReactiveUI.Interop.Prism
{
    /// <summary>
    /// Object that abstracts <see cref="T:ReactiveUI.ReactiveObject" /> for use with MvvmCross.
    /// </summary>
    /// <seealso cref="T:ReactiveUI.ReactiveObject" />
    public abstract class PrismViewModel : ReactiveObject, IPrismViewModel
    {
        /// <inheritdoc />
        public virtual void OnNavigatedFrom(INavigationParameters parameters) { }

        /// <inheritdoc />
        public virtual void OnNavigatedTo(INavigationParameters parameters) { }

        /// <inheritdoc />
        public virtual void OnNavigatingTo(INavigationParameters parameters) { }

        /// <inheritdoc />
        public virtual void Destroy() { }
    }
}
