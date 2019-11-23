using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeopleViewer.Common;
using System.Linq;

namespace PeopleViewer.Presentation.Tests
{
    [TestClass]
    public class PeopleViewModelTests
    {
        [TestMethod]
        public void People_OnRefreshPeople_IsPopulated()
        {
            IPersonReader reader = new FakeReader();
            var viewModel = new PeopleViewModel(reader);
            viewModel.RefreshPeople();

            Assert.IsNotNull(viewModel.People);
            Assert.AreEqual(2, viewModel.People.Count());
        }

        [TestMethod]
        public void People_OnClearPeople_IsEmpty()
        {
            IPersonReader reader = new FakeReader();
            var viewModel = new PeopleViewModel(reader);
            viewModel.RefreshPeople();
            Assert.AreNotEqual(0, viewModel.People.Count());
            viewModel.ClearPeople();
            Assert.AreEqual(0, viewModel.People.Count());

        }
    }
}
