using Interview.Test.Helpers;
using NUnit.Framework;
using System;
using System.Linq;

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
        public void Check_Items_Are_Saved_Into_Repository()
        {
            IRepository<IStoreable> repository = new Repository<IStoreable>();
            IStoreable storeable6 = StoreableHelper.GetAStoreable().WithBook(BookHelper.GetABookWithId(6));
            IStoreable storeable9 = StoreableHelper.GetAStoreable().WithBook(BookHelper.GetABookWithId(9));

            repository.Save(storeable6);
            repository.Save(storeable9);

            Assert.IsNotEmpty(repository.All());
            Assert.AreEqual(2, repository.All().Count(), "Invalid number of items in repository.");
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

        [Test]
        public void Check_Only_One_Record_Created_When_Same_Item_Is_Saved_Twice()
        {
            IRepository<IStoreable> repository = new Repository<IStoreable>();
            IStoreable storeable6 = StoreableHelper.GetAStoreable().WithBook(BookHelper.GetABookWithId(6));

            repository.Save(storeable6);
            repository.Save(storeable6);

            Assert.IsNotEmpty(repository.All());
            Assert.AreEqual(1, repository.All().Count(), "Invalid number of items in repository.");
        }

        [Test]
        public void Check_Items_Are_Deleted_From_Repository()
        {
            IRepository<IStoreable> repository = new Repository<IStoreable>();
            IStoreable storeable6 = StoreableHelper.GetAStoreable().WithBook(BookHelper.GetABookWithId(6));
            IStoreable storeable9 = StoreableHelper.GetAStoreable().WithBook(BookHelper.GetABookWithId(9));

            repository.Save(storeable6);
            repository.Save(storeable9);
            repository.Delete(storeable6.Id);

            Assert.IsNotEmpty(repository.All());
            Assert.AreSame(storeable9, repository.All().Single(), "Item is not deleted.");
        }

        [Test]
        public void Check_Repository_Is_Unchanged_When_Delete_Called_With_Null()
        {
            IRepository<IStoreable> repository = new Repository<IStoreable>();
            IStoreable storeable6 = StoreableHelper.GetAStoreable().WithBook(BookHelper.GetABookWithId(6));
            IStoreable storeable9 = StoreableHelper.GetAStoreable().WithBook(BookHelper.GetABookWithId(9));

            repository.Save(storeable6);
            repository.Save(storeable9);
            repository.Delete(null);

            Assert.IsNotEmpty(repository.All());
            Assert.AreEqual(2, repository.All().Count(), "Invalid number of items in repository.");
        }

        [Test]
        public void Check_Repository_Is_Unchanged_When_Delete_Called_For_Unknown_Data()
        {
            IRepository<IStoreable> repository = new Repository<IStoreable>();
            IStoreable storeable6 = StoreableHelper.GetAStoreable().WithBook(BookHelper.GetABookWithId(6));
            IStoreable storeable9 = StoreableHelper.GetAStoreable().WithBook(BookHelper.GetABookWithId(9));

            repository.Save(storeable6);
            repository.Delete(storeable9.Id);

            Assert.IsNotEmpty(repository.All());
            Assert.AreSame(storeable6, repository.All().Single(), "Wrong item deleted from the repository.");
        }

        [Test]
        public void Check_Item_Is_Returned_When_Finding_Existing_Record()
        {
            IRepository<IStoreable> repository = new Repository<IStoreable>();
            IStoreable storeable6 = StoreableHelper.GetAStoreable().WithBook(BookHelper.GetABookWithId(6));
            IStoreable storeable9 = StoreableHelper.GetAStoreable().WithBook(BookHelper.GetABookWithId(9));

            repository.Save(storeable6);
            repository.Save(storeable9);
            IStoreable result = repository.FindById(storeable9.Id);

            Assert.AreSame(storeable9, result, "Wrong item returned from the repository.");
        }

        [Test]
        public void Check_Null_Is_Returned_When_Finding_Unknown_Record()
        {
            IRepository<IStoreable> repository = new Repository<IStoreable>();
            IStoreable storeable6 = StoreableHelper.GetAStoreable().WithBook(BookHelper.GetABookWithId(6));
            IStoreable storeable9 = StoreableHelper.GetAStoreable().WithBook(BookHelper.GetABookWithId(9));

            repository.Save(storeable6);
            IStoreable result = repository.FindById(storeable9.Id);

            Assert.IsNull(result);
        }

        [Test]
        public void Check_Null_Is_Returned_When_Find_Called_With_Null()
        {
            IRepository<IStoreable> repository = new Repository<IStoreable>();
            IStoreable storeable6 = StoreableHelper.GetAStoreable().WithBook(BookHelper.GetABookWithId(6));
            IStoreable storeable9 = StoreableHelper.GetAStoreable().WithBook(BookHelper.GetABookWithId(9));

            repository.Save(storeable6);
            repository.Save(storeable9);
            IStoreable result = repository.FindById(null);

            Assert.IsNull(result);
        }

        [Test]
        public void Check_Item_Is_Returned_When_Finding_Existing_Record_With_Different_Types_In_Repository()
        {
            IRepository<IStoreable> repository = new Repository<IStoreable>();
            IStoreable storeable6 = StoreableHelper.GetAStoreable().WithBook(BookHelper.GetABookWithId(6));
            IStoreable storeable9 = StoreableHelper.GetAStoreable().WithEmployee(EmployeeHelper.GetAnEmployeeWithId(9));

            repository.Save(storeable6);
            repository.Save(storeable9);
            IStoreable result = repository.FindById(storeable9.Id);

            Assert.AreSame(storeable9, result, "Wrong item returned from the repository.");
        }

        [TestFixtureTearDown]
        public void Dispose()
        {
        }
    }
}
