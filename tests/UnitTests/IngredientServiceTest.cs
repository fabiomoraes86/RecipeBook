using Core.Interfaces;
using Core.Models;
using Core.Services;
using Moq;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Text.Json;
using Xunit;

namespace UnitTests
{
    public class IngredientServiceTest
    {
        private IIngredientService _recipeBookService;
        private IIngredientService _ingredientService;
        private readonly Mock<IFileSystem> _fileSystem;
        private readonly Mock<IFileSystem> _fileSystem2;

        public IngredientServiceTest()
        {
            _fileSystem = new Mock<IFileSystem>();
            _fileSystem2 = new Mock<IFileSystem>();
        }

        [Fact]
        public void AddIngredientSuccess()
        {
            // Arrange
            var ingredientMock = new IngredientModel
            {
                Id = 1,
                Name = "Ingredient"
            };

            var IngredientExpected = ingredientMock;

            _fileSystem.Setup(f => f.File.ReadAllText(It.IsAny<string>())).Returns("[]");
            _fileSystem.Setup(f => f.File.WriteAllText(It.IsAny<string>(), It.IsAny<string>()));
            _ingredientService = new IngredientService(_fileSystem.Object);

            // Act
            var result = _ingredientService.Add(1, ingredientMock);

            // Assert
            Assert.Equal(IngredientExpected, result);

            _fileSystem.Verify(x => x.File.WriteAllText(It.IsAny<string>(), It.IsAny<string>()), Times.Once);
        }

        [Fact]
        public void RemoveIngredientSuccess()
        {
            var ingredientMock = new List<IngredientModel>();

            var recipeBookModel = new List<RecipeBookModel>
            {
                new RecipeBookModel
                {
                    Id = 1,
                    Title = "test1",
                    Ingredients = ingredientMock,
                    Instruction = "test1"
                }
            };

            var result = JsonSerializer.Serialize(recipeBookModel);

            _fileSystem.Setup(f => f.File.ReadAllText(It.IsAny<string>())).Returns("[{\"Id\":1,\"Title\":\"test1\",\"Ingredients\":[{\"Id\":1,\"Name\":\"Ingredient\"}],\"Instruction\":\"test1\"}]");
            _fileSystem.Setup(f => f.File.WriteAllText(It.IsAny<string>(), result));
            _ingredientService = new IngredientService(_fileSystem.Object);

            // Act
            _ingredientService.Remove(1, 1);

            // Assert
            _fileSystem.Verify(x => x.File.WriteAllText(It.IsAny<string>(), result), Times.Once);
        }
    }
}
