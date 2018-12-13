using ReactiveUI;

namespace FreshMvvm.ReactiveUI.Interop
{
    public interface IFreshReactiveViewModel : IReactiveNotifyPropertyChanged<IReactiveObject>,
        IReactiveObject,
        IHandleObservableErrors
    {

    }
}