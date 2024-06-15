using JIJI_API.Data;
using JIJI_API.Models;
using JIJI_API.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace JIJI_API.Service.Provider
{
    public class ProductsPgDbService : IProductsService

    {

        private readonly JijiDbContext _context;
        public ProductsPgDbService(JijiDbContext context)
        {
            _context = context;
        }

        public async Task<ApiResponseCart<Cart>> AddToCart(Cart cartItem)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponseCart<Cart>> GetCart()
        {
            try
            {
                var product = _context.Cart;
                if (product == null)
                {
                    return new ApiResponseCart<Cart>
                    {
                        Code = $"{(int)HttpStatusCode.NotFound}",
                        Message = "No Records Found",

                    };
                }

                await Task.CompletedTask;
                return new ApiResponseCart<Cart>
                {
                    Code = $"{(int)HttpStatusCode.OK}",
                    Message = $"Query successful",
                    Data = product
                };
            }
            catch (Exception ex)
            {
                return new ApiResponseCart<Cart>
                {
                    Code = $"{(int)HttpStatusCode.InternalServerError}",
                    Message = $"Error getting Product records, {ex.Message}"

                };
            }
        }

        public async Task<ApiResponseProducts<Products>> GetProduct(int id)
        {
            try
            {
                var product = _context.Products.Find(id);
                if (product == null)
                {
                    return new ApiResponseProducts<Products>
                    {
                        Code = $"{(int)HttpStatusCode.NotFound}",
                        Message = "No Records Found",

                    };
                }

                await Task.CompletedTask;
                return new ApiResponseProducts<Products>
                {
                    Code = $"{(int)HttpStatusCode.OK}",
                    Message = $"Query with parameters Id: {id}",
                    Data = product
                };
            }
            catch (Exception ex)
            {
                return new ApiResponseProducts<Products>
                {
                    Code = $"{(int)HttpStatusCode.InternalServerError}",
                    Message = $"Error getting Product records, {ex.Message}"

                };
            }
        }

       

        //Get All Products
        public async Task<ApiResponseProducts<Products>> GetProducts([FromQuery] int? categoryId, [FromQuery] int? regionId, [FromQuery] decimal? minPrice, [FromQuery] decimal? maxPrice)
        {
            try 
            {
                var query = _context.Products.AsQueryable();
                if (categoryId != null)
                {
                    query = query.Where(p => p.category_id == categoryId);
                }

                if (regionId != null) 
                {
                    query = query.Where(p=>p.region_id == regionId);
                }
                if(minPrice != null)
                {
                    query = query.Where(p=>p.price >= minPrice);
                }
                if(maxPrice != null)
                {
                    query = query.Where((p)=>p.price <= maxPrice);
                }
                if(query == null)
                {
                    return new ApiResponseProducts<Products>
                    {
                        Code = $"{(int)HttpStatusCode.NotFound}",
                        Message = "No Records Found",

                    };
                }
                var products = query;
                await Task.CompletedTask;
                return new ApiResponseProducts<Products>
                {
                    Code = $"{(int)HttpStatusCode.OK}",
                    Message = $"Query with parameters regionId: {regionId}",
                    Data = (Products)query,
                };
                //var products = query.ToList();
            }catch (Exception ex) 
            {
                return new ApiResponseProducts<Products>
                {
                    Code = $"{(int)HttpStatusCode.InternalServerError}",
                    Message = $"Error getting Product records, {ex.Message}"

                };
            }
        }

        public async Task<ApiResponseCart<Cart>> RemoveFromCart(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ApiResponseCart<Cart>> UpdateCart(int id, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}
