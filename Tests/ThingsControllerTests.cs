using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using MVC.Controllers;
using MVC.DataAccess;
using MVC.Entities;
using MVC.Models;

namespace Tests
{
    public class ThingsControllerTests
    {
        private readonly ThingsController controller;
        private readonly Mock<IUnitOfWork> unitOfWorkMock;
        private readonly Mock<IMapper> mapperMock;

        private readonly IList<Thing> things;
        private readonly IList<ThingViewModel> thingVModels;

        public ThingsControllerTests()
        {
            unitOfWorkMock = new Mock<IUnitOfWork>();
            mapperMock = new Mock<IMapper>();
            controller = new ThingsController(unitOfWorkMock.Object, mapperMock.Object);
            things = GetThings();
            thingVModels = GetThingsModels();
        }

        [Fact]
        public void Index_ShouldReturnView_WithThings()
        {
            // Arrange
            unitOfWorkMock.Setup(u => u.ThingsRepository.GetAllWithCategory()).Returns(things);
            mapperMock.Setup(m => m.Map<IEnumerable<ThingViewModel>>(things)).Returns(thingVModels);

            // Act
            var result = controller.Index();

            // Assert
            result.Should().BeOfType<ViewResult>();
            var viewResult = result.As<ViewResult>();
            viewResult.Should().NotBeNull();
            viewResult!.Model.Should().BeOfType<List<ThingViewModel>>();
        }

        [Fact]
        public void Details_ShouldReturnNotFound_WhenIdIsNull()
        {
            var result = controller.Details(null);

            result.Should().BeOfType<NotFoundObjectResult>();
        }

        [Fact]
        public void Details_ShouldReturnNotFound_WhenThingIsNull()
        {
            unitOfWorkMock.Setup(u => u.ThingsRepository.GetByIdWithCategory(It.IsAny<int>())).Returns((Thing)null!);

            var result = controller.Details(1);

            result.Should().BeOfType<NotFoundObjectResult>();
        }

        [Fact]
        public void Details_ShouldReturnView_WithThing()
        {
            unitOfWorkMock.Setup(u => u.ThingsRepository.GetByIdWithCategory(It.IsAny<int>())).Returns(things.First());
            mapperMock.Setup(m => m.Map<ThingViewModel>(things.First())).Returns(thingVModels.First());

            var result = controller.Details(1);

            result.Should().BeOfType<ViewResult>();
            var viewResult = result.As<ViewResult>();
            viewResult.Should().NotBeNull();
            viewResult!.Model.Should().BeOfType<ThingViewModel>();
        }

        [Fact]
        public void Create_ShouldReturnView()
        {
            unitOfWorkMock.Setup(u => u.CategoriesRepository.GetAll()).Returns(GetCategories());

            var result = controller.Create();

            result.Should().BeOfType<ViewResult>();
        }

        [Fact]
        public void Create_ShouldReturnView_WhenModelStateIsInvalid()
        {
            controller.ModelState.AddModelError("Name", "Name is required");

            var result = controller.Create(new CreateThingViewModel());

            result.Should().BeOfType<ViewResult>();
        }

        [Fact]
        public void Create_ShouldReturnRedirectToIndex_WhenModelStateIsValid()
        {
            unitOfWorkMock.Setup(u => u.CategoriesRepository.GetById(It.IsAny<int>())).Returns(GetCategories().First());
            unitOfWorkMock.Setup(u => u.ThingsRepository.Create(It.IsAny<Thing>()));
            var createThingViewModel = new CreateThingViewModel
            {
                Description = "Thing 1",
                CategoryId = 1
            };

            var result = controller.Create(createThingViewModel);

            controller.ModelState.IsValid.Should().BeTrue();
            result.Should().BeOfType<RedirectToActionResult>();
            var redirectToActionResult = result.As<RedirectToActionResult>();
            redirectToActionResult.Should().NotBeNull();
            redirectToActionResult!.ActionName.Should().Be("Index");
        }

        [Fact]
        public void Edit_ShouldReturnNotFound_WhenIdIsNull()
        {
            var result = controller.Edit(null);

            result.Should().BeOfType<NotFoundObjectResult>();
        }

        [Fact]
        public void Edit_ShouldReturnNotFound_WhenThingIsNull()
        {
            unitOfWorkMock.Setup(u => u.ThingsRepository.GetById(It.IsAny<int>())).Returns((Thing)null!);

            var result = controller.Edit(1);

            result.Should().BeOfType<NotFoundObjectResult>();
        }

        [Fact]
        public void Edit_ShouldReturnView_WithThing()
        {
            unitOfWorkMock.Setup(u => u.ThingsRepository.GetByIdWithCategory(It.IsAny<int>())).Returns(things.First());
            mapperMock.Setup(m => m.Map<CreateThingViewModel>(things.First())).Returns(new CreateThingViewModel());
            unitOfWorkMock.Setup(u => u.CategoriesRepository.GetAll()).Returns(GetCategories());

            var result = controller.Edit(1);

            result.Should().BeOfType<ViewResult>();
            var viewResult = result.As<ViewResult>();
            viewResult.Should().NotBeNull();
            viewResult!.Model.Should().BeOfType<CreateThingViewModel>();
        }

        [Fact]
        public void Edit_ShouldReturnView_WhenModelStateIsInvalid()
        {
            unitOfWorkMock.Setup(u => u.ThingsRepository.GetByIdWithCategory(It.IsAny<int>())).Returns(things.First());
            controller.ModelState.AddModelError("Name", "Name is required");

            var result = controller.Edit(1, new CreateThingViewModel());

            result.Should().BeOfType<ViewResult>();
        }

        [Fact]
        public void Edit_ShouldReturnRedirectToIndex_WhenModelStateIsValid()
        {
            unitOfWorkMock.Setup(u => u.CategoriesRepository.GetById(It.IsAny<int>())).Returns(GetCategories().First());
            unitOfWorkMock.Setup(u => u.ThingsRepository.GetByIdWithCategory(It.IsAny<int>())).Returns(things.First());
            var createThingViewModel = new CreateThingViewModel
            {
                Description = "Thing 1",
                CategoryId = 1
            };

            var result = controller.Edit(1, createThingViewModel);

            controller.ModelState.IsValid.Should().BeTrue();
            result.Should().BeOfType<RedirectToActionResult>();
            var redirectToActionResult = result.As<RedirectToActionResult>();
            redirectToActionResult.Should().NotBeNull();
            redirectToActionResult!.ActionName.Should().Be("Index");
        }

        [Fact]
        public void Delete_ShouldReturnNotFound_WhenIdIsNull()
        {
            var result = controller.Delete(null);

            result.Should().BeOfType<NotFoundObjectResult>();
        }

        [Fact]
        public void Delete_ShouldReturnNotFound_WhenThingIsNull()
        {
            unitOfWorkMock.Setup(u => u.ThingsRepository.GetByIdWithCategory(It.IsAny<int>())).Returns((Thing)null!);

            var result = controller.Delete(1);

            result.Should().BeOfType<NotFoundObjectResult>();
        }

        [Fact]
        public void Delete_ShouldReturnView_WithThing()
        {
            unitOfWorkMock.Setup(u => u.ThingsRepository.GetByIdWithCategory(It.IsAny<int>())).Returns(things.First());
            mapperMock.Setup(m => m.Map<ThingViewModel>(things.First())).Returns(thingVModels.First());

            var result = controller.Delete(1);

            result.Should().BeOfType<ViewResult>();
            var viewResult = result.As<ViewResult>();
            viewResult.Should().NotBeNull();
            viewResult!.Model.Should().BeOfType<ThingViewModel>();
        }

        [Fact]
        public void DeleteConfirmed_ShouldReturnRedirectToIndex()
        {
            unitOfWorkMock.Setup(u => u.ThingsRepository.GetByIdWithCategory(It.IsAny<int>())).Returns(things.First());

            var result = controller.DeleteConfirmed(1);

            result.Should().BeOfType<RedirectToActionResult>();
            var redirectToActionResult = result.As<RedirectToActionResult>();
            redirectToActionResult.Should().NotBeNull();
            redirectToActionResult!.ActionName.Should().Be("Index");
        }

        private static IList<Thing> GetThings()
        {
            return new List<Thing>
            {
                new Thing{
                    Id = 1,
                    Description = "Thing 1",
                    CategoryId = 1,
                    Category = new Category
                    {
                        Id = 1,
                        Description = "Category 1"
                    }
                },
                new Thing{
                    Id = 2,
                    Description = "Thing 2",
                    CategoryId = 2,
                    Category = new Category
                    {
                        Id = 2,
                        Description = "Category 2"
                    }
                }
            };
        }

        private static IList<ThingViewModel> GetThingsModels()
        {
            return new List<ThingViewModel> {
                new ThingViewModel {
                    Id = 1,
                    Description = "Thing 1",
                    Category = new MVC.Dto.CategoryResponse
                    {
                        Id = 1,
                        Description = "Category 1"
                    }
                },
                new ThingViewModel {
                    Id = 2,
                    Description = "Thing 2",
                    Category = new MVC.Dto.CategoryResponse
                    {
                        Id = 2,
                        Description = "Category 2"
                    }
                }
            };
        }

        private static IList<Category> GetCategories()
        {
            return new List<Category>
            {
                new Category
                {
                    Id = 1,
                    Description = "Category 1"
                },
                new Category
                {
                    Id = 2,
                    Description = "Category 2"
                }
            };
        }

    }
}