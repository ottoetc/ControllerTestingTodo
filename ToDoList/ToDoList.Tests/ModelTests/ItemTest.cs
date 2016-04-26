using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoList.Models;
using Xunit;

namespace ToDoList.Tests
{
    public class ItemTest
    {
        [Fact]
        public void GetDescriptionTest()
        {
            //arrange
            var item = new Item();
            item.Description = "Wash the dog";

            //act
            var result = item.Description;

            //assert
            Assert.Equal("Wash the dog", result);
        }
    }
}
