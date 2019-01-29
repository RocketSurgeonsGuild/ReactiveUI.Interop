using MvvmCross.ViewModels;
using ReactiveUI;

namespace Rocket.Surgery.ReactiveUI.Interop.MvvmCross
{
    /// <summary>
    /// Interface that represents a MvvmCross ReactiveUI inter operable view model.
    /// </summary>
    public interface IMvxReactiveViewModel : IMvxViewModel,
        IReactiveNotifyPropertyChanged<IReactiveObject>,
        IReactiveObject,
        IHandleObservableErrors
    {
    }

    /// <summary>
    /// Interface that represents a MvvmCross ReactiveUI inter operable view model.
    /// </summary>
    /// <typeparam name="TParameter"></typeparam>
    public interface IMvxReactiveViewModel<TParameter> : IMvxViewModel<TParameter>, IMvxReactiveViewModel
    {
    }

    /// <summary>
    /// Interface that represents a MvvmCross ReactiveUI inter operable view model.
    /// </summary>
    /// <typeparam name="TParameter">The type of the parameter.</typeparam>
    /// <typeparam name="TResult">The type of the result.</typeparam>
    /// <seealso cref="T:MvvmCross.ViewModels.IMvxViewModel" />
    /// <seealso cref="T:ReactiveUI.IReactiveObject" />
    public interface IMvxReactiveViewModel<TParameter, TResult> : IMvxViewModel<TParameter, TResult>,
        IMvxReactiveViewModel
    {
    }
}