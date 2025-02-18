﻿namespace RSMEnterpriseIntegrationsAPI.Infrastructure.Repositories
{
    using Microsoft.EntityFrameworkCore;

    using RSMEnterpriseIntegrationsAPI.Domain.Interfaces;
    using RSMEnterpriseIntegrationsAPI.Domain.Models;

    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ProCategoryRepository : IProCategoryRepository
    {
        private readonly AdvWorksDbContext _context;
        public ProCategoryRepository(AdvWorksDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateProCategory(ProductCategory productCategory)
        {
            await _context.AddAsync(productCategory);

            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteProCategory(ProductCategory productCategory)
        {
            _context.Remove(productCategory);

            return await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ProductCategory>> GetAllProCategory()
        {
            return await _context.Set<ProductCategory>()
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<ProductCategory?> GetProCategoryById(int id)
        {
            return await _context.ProductCategories
                .AsNoTracking()
                .FirstOrDefaultAsync(d => d.ProductCategoryID == id);
        }

        public async Task<int> UpdateProCategory(ProductCategory productCategory)
        {
            _context.Update(productCategory);

            return await _context.SaveChangesAsync();
        }
    }
}
