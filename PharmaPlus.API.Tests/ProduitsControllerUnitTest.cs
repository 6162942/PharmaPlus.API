using Microsoft.AspNetCore.Mvc;
using Moq;
using PharmaPlus.API.UI.Applications.DTOs;
using PharmaPlus.API.UI.Controllers;
using PharmaPlus.Core.Framework;
using PharmaPlus.Core.Produits.Domain;
using System;
using System.Collections.Generic;
using Xunit;

namespace PharmaPlus.API.Tests
{
    public class ProduitsControllerUnitTest
    {
        #region Public methods
        [Fact]
        public void ShouldAddOneProduit()
        {
            //Arrange
            Produit produit = new Produit();
            var repositoryMock = new Mock<IProduitsRepository>();
            repositoryMock.Setup(item => item.unitOfWork).Returns(new Mock<IUnitOfWork>().Object);
            repositoryMock.Setup(item => item.AddOne(It.IsAny<Produit>())).Returns(new Produit() { Id = 4 });
            //Act
            var controller = new ProduitsController(repositoryMock.Object, null);
            var result = controller.AddOne(produit);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result);

            OkObjectResult okResult = result as OkObjectResult;
            Assert.NotNull(okResult);
            var addedProduit = okResult.Value as Produit;
            Assert.NotNull(addedProduit);
            Assert.True(addedProduit.Id > 0);
        }

        [Fact]
        public void ShouldReturnListOfProduits()
        {
            var expectedList = new List<Produit>() 
            {
                new Produit(),
                new Produit()
            };

            //ARRANGE
            var repositoryMock = new Mock<IProduitsRepository>();
            repositoryMock.Setup(item => item.GetAll(It.IsAny<int>())).Returns(expectedList);
            var controller = new ProduitsController(repositoryMock.Object, null);
            //ACT
            var result = controller.GetAll(); //simuler l'url
            //ASSERT
            Assert.NotNull(result);
            
            Assert.IsType<OkObjectResult>(result);
            OkObjectResult okResult = result as OkObjectResult;

            Assert.NotNull(okResult);
            Assert.IsType<List<Produit>>(okResult.Value);
            List<Produit> list = okResult.Value as List<Produit>;
            Assert.True(list.Count == expectedList.Count);
            //Assert.True(result.GetEnumerator().MoveNext());
        }

        #endregion
    }
}
