using System;

using Cake.AsciiDoctorJ.Tests.Fixtures;
using Cake.Core;
using Cake.Testing;

using FluentAssertions;

using Xunit;

namespace Cake.AsciiDoctorJ.Tests
{
    public class AsciiDoctorJRunnerTests
    {
        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            var fixture = new AsciiDoctorJRunnerFixture();
            fixture.GivenSettingsIsNull();

            Action result = () =>
            {
                fixture.Run();
            };

            result.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public void Should_throw_if_asciidoctorj_executable_was_not_found()
        {
            var fixture = new AsciiDoctorJRunnerFixture();
            fixture.GivenDefaultToolDoNotExist();
            const string expectedMessage = "Could not locate executable";

            Action result = () => fixture.Run();
            result.Should().Throw<CakeException>().Where(ex => ex.Message.Contains(expectedMessage));
        }

        [Fact]
        public void Should_not_throw_if_asciidoctorj_executable_was_found()
        {
            var fixture = new AsciiDoctorJRunnerFixture();

            var actual = fixture.RunFluent(x => { });

            actual.Args.Should().Be("");
        }

        [Fact]
        public void Should_not_throw_if_settings_are_null_on_fluent_invocation()
        {
            var fixture = new AsciiDoctorJRunnerFixture();
            fixture.GivenSettingsIsNull();

            var actual = fixture.RunFluent(x => { });

            actual.Args.Should().Be("");
        }

        [Fact]
        public void Should_not_throw_if_settings_and_action_are_null_on_fluent_invocation()
        {
            var fixture = new AsciiDoctorJRunnerFixture
            {
                Settings = null
            };

            var actual = fixture.RunFluent(null);

            actual.Args.Should().Be("");
        }
    }
}
