using System;
using Cake.Core;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace Cake.AsciiDoctorJ.Tests
{
    [TestFixture]
    [TestOf(typeof(AsciiDoctorJAliases))]
    public class AsciiDoctorJAliasesTests
    {
        private ICakeContext context;

        [SetUp]
        public void Setup()
        {
            context = new Mock<ICakeContext>().Object; // TODO: Is there nothin in Cake.Testing?!
        }

        [Test]
        public void Should_Throw_If_Settings_Are_Null()
        {
            Action action = () => AsciiDoctorJAliases.AsciiDoctorJ(context, (AsciiDoctorJRunnerSettings)null);
            action.Should().Throw<ArgumentNullException>().WithMessage("*settings");
        }
    }
}
