using Microsoft.AspNetCore.Mvc;
using MVC.DataAccess;
using MVC.Dto;
using MVC.Entities;

namespace MVC.ExtensionMethods
{
    public static class Extensions
    {
        //public static ObjectResult Validate(this Category cat, IUnitOfWork unitOfWork)
        //{
        //    if (cat is null)
        //        return new NotFoundObjectResult("Category not found");

        //    if (String.IsNullOrWhiteSpace(cat.Description))
        //        return new BadRequestObjectResult("Description is required");

        //    var catExists = unitOfWork.CategoryRepository.Exists(c => c.Description == cat.Description);
        //    if (catExists)
        //        return new BadRequestObjectResult("Category already exist");
        //    return new OkObjectResult(cat);
        //}
    }
}
