using System;
using System.Reactive;
using System.Reactive.Linq;
using FluentAssertions;
using Xunit;

namespace ReactiveUI.FreshMvvm.Tests
{
    public sealed class FreshMvvmViewModelTests
    {
        public class TheChangedProperty
        {
            [Fact]
            public void Should_Tick_Changed()
            {
                // Given
                var actual = false;
                TestViewModel sut = new TestViewModelFixture();
                sut.Changed.Subscribe(_ => { actual = true; });

                // When
                sut.Name = "name";

                // Then
                actual.Should().BeTrue();
            }
        }

        public class TheChangingProperty
        {
            [Fact]
            public void Should_Tick_Changing()
            {
                // Given
                var actual = false;
                TestViewModel sut = new TestViewModelFixture();
                sut.Changing.Subscribe(_ => { actual = true; });

                // When
                sut.Name = "name";

                // Then
                actual.Should().BeTrue();
            }
        }

        public class TheThrownExceptionsProperty
        {
            [Fact]
            public void Should_Tick_Exception()
            {
                // Given
                var actual = false;
                TestViewModel sut = new TestViewModelFixture();
                sut.Changed.Subscribe(_ => throw new Exception());
                sut.ThrownExceptions.Subscribe(_ =>
                {
                    actual = true;
                });

                // When
                sut.Name = "name";

                // Then
                actual.Should().BeTrue();
            }
        }
    }
}