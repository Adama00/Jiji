using System;
using System.Collections.Generic;
using System.Linq;
using JIJI_API.Data;
using JIJI_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace JIJI_API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class JijiController : ControllerBase
    {
        private readonly JijiDbContext _context;

        public JijiController(JijiDbContext context)
        {
            _context = context;
        }

        [HttpGet("allProducts")]
        public IActionResult GetAllProducts()
        {
            try
            {
                var products = _context.Products.ToList();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving products: {ex.Message}");
            }
        }

        [HttpGet("products")]
        public IActionResult GetProducts([FromQuery] int? categoryId, [FromQuery] int? regionId, [FromQuery] decimal? minPrice, [FromQuery] decimal? maxPrice)
        {
            try
            {
                var query = _context.Products.AsQueryable();

                if (categoryId.HasValue)
                {
                    query = query.Where(p => p.category_id == categoryId.Value);
                }

                if (regionId.HasValue)
                {
                    query = query.Where(p => p.region_id == regionId.Value);
                }

                if (minPrice.HasValue)
                {
                    query = query.Where(p => p.price >= minPrice.Value);
                }

                if (maxPrice.HasValue)
                {
                    query = query.Where(p => p.price <= maxPrice.Value);
                }

                var products = query.ToList();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving products: {ex.Message}");
            }
        }

        [HttpGet("products/{id}")]
        public IActionResult GetProduct(int id)
        {
            try
            {
                var product = _context.Products.Find(id);
                if (product == null)
                {
                    return NotFound("Product not found");
                }

                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while retrieving product details: {ex.Message}");
            }
        }

        [HttpPost("cart")]
        public IActionResult AddToCart([FromBody] Cart cartItem)
        {
            try
            {
                _context.Cart.Add(cartItem);
                _context.SaveChanges();
                return Ok("Product added to cart successfully");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while adding product to cart: {ex.Message}");
            }
        }

        // Implement other endpoints here...

    }

}
