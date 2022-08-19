using System;
using System.Reactive;
using System.Reactive.Linq;
using Rocket.Surgery.ReactiveUI.Interop.Prism;

namespace ReactiveUI.Prism.Tests
{
    internal class TestViewModel : PrismViewModel
    {
        private string _name;
        private readonly ObservableAsPropertyHelper<int> _testProperty;

        public TestViewModel()
        {
            _testProperty = this.WhenAnyValue(x => x.Name)
               .Select(_ => 2)
               .ToProperty(this, x => x.TestProperty);

            TestCommand = ReactiveCommand.CreateFromObservable(ExecuteTest);
        }

        public string Name
        {
            get => _name;
            set => this.RaiseAndSetIfChanged(ref _name, value);
        }

        public int TestProperty => _testProperty.Value;

        public ReactiveCommand<Unit, Unit> TestCommand { get; set; }

        private IObservable<Unit> ExecuteTest() => Observable.Return(Unit.Default);
    }

    internal class TestViewModelFixture
    {
        public static implicit operator TestViewModel(TestViewModelFixture fixture) => fixture.Build();

        private TestViewModel Build() => new();
    }
}