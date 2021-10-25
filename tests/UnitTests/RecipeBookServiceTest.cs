using Core.Interfaces;
using Core.Models;
using Core.Services;
using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Text.Json;
using Xunit;

namespace UnitTests
{
    public class RecipeBookServiceTest
    {
        private IRecipeBookService _recipeBookService;
        private readonly Mock<IFileSystem> _fileSystem;

        public RecipeBookServiceTest()
        {
            _fileSystem = new Mock<IFileSystem>();
        }

        [Fact]
        public void AddRecipeBookSuccess()
        {
            // Arrange
            var recipeMock = new RecipeBookModel
            {
                Id = 1,
                Title = "Test recipe",
                Instruction = "teste"
            };

            var recipeExpected = new List<RecipeBookModel>
            {
                recipeMock
            };

            _fileSystem.Setup(f => f.File.ReadAllText(It.IsAny<string>())).Returns("[]");
            _fileSystem.Setup(f => f.File.WriteAllText(It.IsAny<string>(), It.IsAny<string>()));
            _recipeBookService = new RecipeBookService(_fileSystem.Object);

            // Act
            var result = _recipeBookService.Add(recipeMock);

            // Assert
            Assert.Equal(recipeExpected, result);

            _fileSystem.Verify(x => x.File.WriteAllText(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void GetAllRecipeBookSuccess()
        {
            // Arrange
            var recipeMock =
                new List<RecipeBookModel>
                {
                    new RecipeBookModel
                    {
                        Id = 1,
                        Title = "test1",
                        Ingredients = new List<IngredientModel>(),
                        Instruction = "test1"
                    },
                    new RecipeBookModel
                    {
                        Id = 2,
                        Title = "test2",
                        Ingredients = new List<IngredientModel>(),
                        Instruction = "test2"
                    }
                };

            _fileSystem.Setup(f => f.File.ReadAllText(It.IsAny<string>())).Returns("[{\"Id\":1,\"Title\":\"test1\",\"Ingredients\":[],\"Instruction\":\"test1\"},{\"Id\":2,\"Title\":\"test2\",\"Ingredients\":[],\"Instruction\":\"test2\"}]");
            _recipeBookService = new RecipeBookService(_fileSystem.Object);

            // Act
            var result = _recipeBookService.GetAll();

            // Assert
            recipeMock.Should().BeEquivalentTo(result);
        }

        [Fact]
        public void RemoveRecipeBookSuccess()
        {
            // Arrange
            var recipeMock =
                 new List<RecipeBookModel>
                 {
                    new RecipeBookModel
                    {
                        Id = 1,
                        Title = "test1",
                        Ingredients = new List<IngredientModel>(),
                        Instruction = "test1"
                    }
                 };

            var result = JsonSerializer.Serialize(recipeMock);

            _fileSystem.Setup(f => f.File.ReadAllText(It.IsAny<string>())).Returns("[{\"Id\":1,\"Title\":\"test1\",\"Ingredients\":[],\"Instruction\":\"test1\"},{\"Id\":2,\"Title\":\"test2\",\"Ingredients\":[],\"Instruction\":\"test2\"}]");
            _fileSystem.Setup(f => f.File.WriteAllText(It.IsAny<string>(), result));
            _recipeBookService = new RecipeBookService(_fileSystem.Object);

            // Act
            _recipeBookService.Remove(2);

            // Assert
            _fileSystem.Verify(x => x.File.WriteAllText(It.IsAny<string>(), result), Times.Once);
        }

        [Fact]
        public void UpdateRecipeBookSuccess()
        {
            // Arrange
            var recipeMock =
                new RecipeBookModel
                {
                    Id = 1,
                    Title = "test1",
                    Ingredients = new List<IngredientModel>(),
                    Instruction = "test1"
                };

            _fileSystem.Setup(f => f.File.ReadAllText(It.IsAny<string>())).Returns("[{\"Id\":1,\"Title\":\"\",\"Ingredients\":[],\"Instruction\":\"test1\"}]");
            _fileSystem.Setup(f => f.File.WriteAllText(It.IsAny<string>(), It.IsAny<string>()));
            _recipeBookService = new RecipeBookService(_fileSystem.Object);

            // Act
            var result = _recipeBookService.Update(1, recipeMock);

            //Assert
            recipeMock.Should().BeEquivalentTo(result);

            _fileSystem.Verify(x => x.File.WriteAllText(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }
    }
}
