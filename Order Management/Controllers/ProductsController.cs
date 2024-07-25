using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Order_Management.Dto;
using Order_Management.Errors;
using OrderManagement.Core.Entities;
using OrderManagement.Services;

namespace Order_Management.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProduct() 
        {
            var products = await _productService.GetAllProductsAsync();
            var productMapped = _mapper.Map<IEnumerable<ProductDto>>(products);
            return Ok(productMapped);
        }

        [HttpGet("productId")]
        public async Task<IActionResult> GetProductById(int productId)
        {
            var product = await _productService.GetProductByIdAsync(productId);
            if(product == null)
            {
                return BadRequest(error: new ApiResponse(statusCode: 400));
            }
            var productDto= _mapper.Map<ProductDto>(product);
            return Ok(productDto);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddProduct([FromBody] ProductDto productDto)
        {
            if (productDto == null)
            {
                return BadRequest(error: new ApiResponse(statusCode: 400));
            }
            var product = _mapper.Map<Product>(productDto);
            var createProduct = await _productService.GetProductByIdAsync(product.ProductId);
            var createdProductDto = _mapper.Map<ProductDto>(createProduct);
            return Ok(createdProductDto);

        }


        [HttpPut("{productId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateProduct(int productId, [FromBody] ProductDto productDto)
        {
            if (productId == null && productDto == null)
            {
                return BadRequest(error: new ApiResponse(statusCode: 400));
            }
            var product = await _productService.GetProductByIdAsync(productId);
            if (product == null)
            {
                return NotFound();
            }
            var productMapped = _mapper.Map(productDto, product);
            var updatedProduct = await _productService.UpdateProductAsync(productMapped);
            var updatedProductDtos = _mapper.Map<ProductDto>(updatedProduct);
            return Ok(updatedProductDtos);


        }


    }
}
