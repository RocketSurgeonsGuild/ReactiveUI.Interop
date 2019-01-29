using System;
using System.Reactive;
using System.Reactive.Linq;
using Rocket.Surgery.ReactiveUI.Interop.MvvmCross;

namespace ReactiveUI.MvvmCross.Tests
{
    internal class TestViewModel : MvxReactiveViewModel
    {
        private string _name;
        private readonly ObservableAsPropertyHelper<int> _testProperty;

        public string Name
        {
            get => _name;
            set => this.RaiseAndSetIfChanged(ref _name, value);
        }

        public int TestProperty => _testProperty.Value;

        public ReactiveCommand<Unit, Unit> TestCommand { get; set; }

        public TestViewModel()
        {
            _testProperty = this.WhenAnyValue(x => x.Name)
                .Select(x => 2)
                .ToProperty(this, x => x.TestProperty);
            TestCommand = ReactiveCommand<Unit, Unit>.CreateFromObservable(ExecuteTest);
        }

        private IObservable<Unit> ExecuteTest()
        {
            return Observable.Return(Unit.Default);
        }
    }

    internal class TestViewModelFixture
    {
        public static implicit operator TestViewModel(TestViewModelFixture fixture) => fixture.Build();

        private TestViewModel Build() => new TestViewModel();
    }
}