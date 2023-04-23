using AutoMapper;
using MacDonald.Services.ProductAPI.DbContexts;
using MacDonald.Services.ProductAPI.Models;
using MacDonald.Services.ProductAPI.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace MacDonald.Services.ProductAPI.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public ProductRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public async Task<ProductDto> CreateUpdateProduct(ProductDto productDto)
        {
            Product product = _mapper.Map<ProductDto, Product>(productDto);
            if (product.ProductId > 0)
            {
                _db.Products.Update(product);
            }
            else
            {
                _db.Products.Add(product);
            }
            await _db.SaveChangesAsync();
            ProductDto productDtoSaved = _mapper.Map<Product, ProductDto>(product);
            return productDtoSaved;
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            try
            {
                //First we retriev the product based on the ProductId
                Product product = await _db.Products.FirstOrDefaultAsync(x => x.ProductId == productId);
                if (product == null)
                {
                    return false;
                }
                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<ProductDto> GetProductById(int productId)
        {
            Product product = await _db.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
            var productMapped = _mapper.Map<ProductDto>(product);
            return productMapped;
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            IEnumerable<Product> productList = await _db.Products.ToListAsync();
            var productMapped = _mapper.Map<IEnumerable<ProductDto>>(productList);
            return productMapped;
        }
    }
}
