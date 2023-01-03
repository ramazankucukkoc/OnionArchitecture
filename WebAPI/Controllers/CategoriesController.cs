﻿using Application.Features.Categories.Commands.CreateCategory;
using Application.Features.Categories.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class CategoriesController : BaseController
    {

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCategoryCommand createCategoryCommand)
        {
            CreateCategoryDto result = await Mediator.Send(createCategoryCommand);
            return Created("", result);
        }
        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] DeleteCategoryCommand deleteCategoryCommand)
        {
            DeleteCategoryDto result = await Mediator.Send(deleteCategoryCommand);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Update([FromBody] UpdateCategoryCommand updateCategoryCommand )
        {
            UpdateCategoryDto result = await Mediator.Send(updateCategoryCommand);
            return Ok(result);
        }

    }
}