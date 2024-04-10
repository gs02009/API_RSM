using Microsoft.AspNetCore.Mvc;
using RSMEnterpriseIntegrationsAPI.Application.DTOs;
using RSMEnterpriseIntegrationsAPI.Application.Services;
using RSMEnterpriseIntegrationsAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RSMEnterpriseIntegrationsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateProductDto dto)
        {
            try
            {
                var productId = await _productService.CreateProduct(dto);
                return CreatedAtAction(nameof(GetById), new { id = productId }, productId);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while creating the product.", details = ex.Message });
            }
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _productService.DeleteProduct(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while deleting the product.", details = ex.Message });
            }
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<GetProductDto>> GetAll()
        {
            return await _productService.GetAllProducts();
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var product = await _productService.GetProductById(id);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while retrieving the product.", details = ex.Message });
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateProductDto dto)
        {
            try
            {
                await _productService.UpdateProduct(dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred while updating the product.", details = ex.Message });
            }
        }
    }
}
