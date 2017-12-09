using Interview.Test.Helpers;
using NUnit.Framework;
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
        public void Check_Repository_Handles_Save_Called_With_Null()
        {
            // Arrange
            IRepository<IStoreable> repository = new Repository<IStoreable>();

            //Act
            repository.Save(null);

            //Assert
            Assert.IsEmpty(repository.All());
        }

        [Test]
        public void Check_Repository_Is_Unchanged_When_Save_Called_With_Null()
        {
            IRepository<IStoreable> repository = new Repository<IStoreable>();
            IStoreable storeable6 = StoreableHelper.GetAStoreable().WithBook(BookHelper.GetABookWithId(6));
            IStoreable storeable9 = StoreableHelper.GetAStoreable().WithBook(BookHelper.GetABookWithId(9));

            repository.Save(storeable6);
            repository.Save(storeable9);
            repository.Save(null);

            Assert.IsNotEmpty(repository.All());
            Assert.AreEqual(2, repository.All().Count(), "Invalid number of items in repository.");
        }

        [TestFixtureTearDown]
        public void Dispose()
        {
        }
    }
}
