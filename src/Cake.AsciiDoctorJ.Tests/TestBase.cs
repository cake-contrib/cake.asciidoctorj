using AutoFixture;
using AutoFixture.AutoNSubstitute;
using System;

namespace Cake.AsciiDoctorJ.Tests
{
    public abstract class TestBase
    {
        protected IFixture Fixture;

        protected void SetupFixture(Action<IFixture> modifications = null)
        {
            Fixture = new Fixture().Customize(new AutoNSubstituteCustomization());
            modifications?.Invoke(Fixture);
        }
    }
}