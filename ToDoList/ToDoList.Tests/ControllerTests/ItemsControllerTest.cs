using Microsoft.AspNet.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Controllers;
using ToDoList.Models;
using Xunit;

namespace ToDoList.Tests.ControllerTests
{
    public class ItemsControllerTest : IDisposable
    {
        Mock<IItemRepository> mock = new Mock<IItemRepository>();
        EFItemRepository db = new EFItemRepository(new TestDbContext());

        private void DbSetup()
        {
            mock.Setup(m => m.Items).Returns(new Item[]
            {
                new Item {ItemId = 1, Description = "Wash the dog" },
                new Item {ItemId = 2, Description = "Do the dishes" },
                new Item {ItemId = 3, Description = "Sweep the floor" }
            }.AsQueryable());
        }

        [Fact]
        public void Mock_GetViewResultIndex_Test()
        {
            // Arrange
            DbSetup();
            ItemsController controller = new ItemsController(mock.Object);

            // Act
            var result = controller.Index();

            // Assert
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void Mock_IndexListOfItems_Test()
        {
            DbSetup();
            ViewResult indexView = new ItemsController(mock.Object).Index() as ViewResult;

            var result = indexView.ViewData.Model;

            Assert.IsType<List<Item>>(result);
        }

        [Fact]
        public void Mock_ConfirmEntry_Test()
        {
            DbSetup();
            ItemsController controller = new ItemsController(mock.Object);
            Item testItem = new Item();
            testItem.Description = "Wash the dog";
            testItem.ItemId = 1;

            ViewResult indexView = controller.Index() as ViewResult;
            var collection = indexView.ViewData.Model as IEnumerable<Item>;

            Assert.Contains<Item>(testItem, collection);
        }

        [Fact]
        public void DB_CreateNewEntry_Test()
        {
            ItemsController controller = new ItemsController(db);
            Category testCategory = new Category();
            Item testItem = new Item();
            testItem.CategoryId = 1;
            testItem.ItemId = 1;
            testItem.Description = "TestDb Item";

            controller.Create(testItem);
            var collection = (controller.Index() as ViewResult).ViewData.Model as IEnumerable<Item>;

            Assert.Contains<Item>(testItem, collection);
        }

        public void Dispose()
        {
            db.DeleteAll();
        }
    }
}
