using System;

using Cake.AsciiDoctorJ.Tests.Fixtures;

using FluentAssertions;

using Xunit;

namespace Cake.AsciiDoctorJ.Tests
{
    public class AsciiDoctorJAliasesTests
    {
        [Fact]
        public void Should_throw_if_settings_are_null()
        {
            var fixture = new AsciiDoctorJAliasesFixture();
            fixture.GivenSettingsIsNull();

            Action action = () => fixture.Run();
            action.Should().Throw<ArgumentNullException>().WithMessage("*settings");
        }

        [Fact]
        public void Should_not_throw_if_settings_are_set()
        {
            var fixture = new AsciiDoctorJAliasesFixture();

            var actual = fixture.Run();

            actual.Args.Should().Be("");
        }

        [Fact]
        public void Should_not_throw_if_settings_are_null_but_called_fluently()
        {
            var fixture = new AsciiDoctorJAliasesFixture();
            fixture.GivenSettingsIsNull();

            var actual = fixture.RunFluent(x => { });

            actual.Args.Should().Be("");
        }

        [Fact]
        public void Should_throw_if_context_is_null()
        {
            var fixture = new AsciiDoctorJAliasesFixture();
            fixture.GivenContextIsNull();

            Action action = () => fixture.Run();
            action.Should().Throw<ArgumentNullException>().WithMessage("*context");
        }

        [Fact]
        public void Should_throw_if_context_is_null_called_fluently()
        {
            var fixture = new AsciiDoctorJAliasesFixture();
            fixture.GivenContextIsNull();

            Action action = () => fixture.RunFluent(x => { });
            action.Should().Throw<ArgumentNullException>().WithMessage("*context");
        }
    }
}
