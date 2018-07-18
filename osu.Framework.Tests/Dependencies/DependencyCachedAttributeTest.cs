// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu-framework/master/LICENCE

using NUnit.Framework;
using osu.Framework.Allocation;

namespace osu.Framework.Tests.Dependencies
{
    [TestFixture]
    public class DependencyCachedAttributeTest
    {
        [Test]
        public void TestCacheCtor()
        {
            IReadOnlyDependencyContainer dependencies = new DependencyContainer();

            var provider = new Provider1();

            dependencies = DependencyActivator.BuildDependencies(provider, dependencies);

            Assert.AreEqual(provider, dependencies.Get<Provider1>());
        }

        [Test]
        public void TestCacheCtorAsBase()
        {
            IReadOnlyDependencyContainer dependencies = new DependencyContainer();

            var provider = new Provider2();

            dependencies = DependencyActivator.BuildDependencies(provider, dependencies);

            Assert.AreEqual(provider, dependencies.Get<object>());
        }

        [DependencyCached]
        private class Provider1
        {
        }

        [DependencyCached(typeof(object))]
        private class Provider2
        {
        }
    }
}
