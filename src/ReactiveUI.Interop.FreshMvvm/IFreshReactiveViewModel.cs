using ReactiveUI;

namespace FreshMvvm.ReactiveUI.Interop
{
    /// <summary>
    /// Interface that represents a FreshMvvm ReactiveUI inter operable view model.
    /// </summary>
    /// <seealso cref="IReactiveObject" />
    /// <seealso cref="IReactiveObject" />
    /// <seealso cref="IHandleObservableErrors" />
    public interface IFreshReactiveViewModel : IReactiveNotifyPropertyChanged<IReactiveObject>,
        IReactiveObject,
        IHandleObservableErrors
    {
    }
}