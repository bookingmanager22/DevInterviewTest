﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interview.Test
{
    [TestFixture]
    public class RepositoryTest
    {
        [TestFixtureSetUp]
        public void Init()
        {
        }

        [Test]
        public void Check_Repository_Is_Initially_Empty()
        {
            IRepository<IStoreable> repository = new Repository<IStoreable>();

            Assert.IsEmpty(repository.All());
        }

        [Test]
        public void Check_Repository_Is_Unchanged_When_Save_Called_With_Null()
        {

        }

        [TestFixtureTearDown]
        public void Dispose()
        {
        }
    }
}
