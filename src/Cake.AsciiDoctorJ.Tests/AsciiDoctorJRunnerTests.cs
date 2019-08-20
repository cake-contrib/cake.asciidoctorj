namespace Cake.AsciiDoctorJ.Tests
{
    using System;
    using Cake.Core;
    using Cake.Testing;
    using FluentAssertions;
    using NUnit.Framework;

    [TestFixture]
    [TestOf(typeof(AsciiDoctorJRunner))]
    public class AsciiDoctorJRunnerTests
    {
        [Test]
        public void Should_Throw_If_AsciiDoctorJ_Executable_Was_Not_Found()
        {
            var fixture = new AsciiDoctorJRunnerFixture();
            fixture.GivenDefaultToolDoNotExist();
            const string expectedMessage = "Could not locate executable";

            Action result = () => fixture.Run();
            result.Should().Throw<CakeException>().Where(ex => ex.Message.Contains(expectedMessage));
        }
    }
}
