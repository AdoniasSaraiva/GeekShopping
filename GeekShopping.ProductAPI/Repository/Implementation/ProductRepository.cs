using AutoMapper;
using GeekShopping.ProductAPI.Data.ValueObjects;
using GeekShopping.ProductAPI.model;
using GeekShopping.ProductAPI.model.Context;
using Microsoft.EntityFrameworkCore;

namespace GeekShopping.ProductAPI.Repository.Implementation
{
    public class ProductRepository : IProductRepository
    {

        private readonly ContextDb _db;
        private IMapper _mapper;

        public ProductRepository(ContextDb db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ProductVO> Create(ProductVO productVO)
        {
            var product = _mapper.Map<Product>(productVO);
            _db.Products.Add(product);
            await _db.SaveChangesAsync();
            return _mapper.Map<ProductVO>(product);
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                var product = await _db.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
                if (product == null)
                    return false;

                _db.Products.Remove(product);
                await _db.SaveChangesAsync();

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<IEnumerable<ProductVO>> FindAll()
        {
            var products = await _db.Products.ToListAsync();
            return _mapper.Map<List<ProductVO>>(products);
        }

        public async Task<ProductVO> FindById(long id)
        {
            var product = await _db.Products.Where(p => p.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<ProductVO>(product);
        }

        public async Task<ProductVO> Update(ProductVO productVO)
        {
            var product = _mapper.Map<Product>(productVO);
            _db.Products.Update(product);
            await _db.SaveChangesAsync();
            return _mapper.Map<ProductVO>(product);
        }
    }
}
