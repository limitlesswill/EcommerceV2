﻿using EcommerceWebSite.App.Contract;
using EcommerceWebSite.Context;
using EcommerceWebSite.Domain.DTOs;
using EcommerceWebSite.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceWebSite.Infrastractions.Repositores
{
    public class CategoryRepository : BaseRepository<Category, int>, ICategoryRepository
    {
        private readonly EcommerceContext context;

        public CategoryRepository(EcommerceContext _context) : base(_context)
        {
            context = _context;
        }

        public async Task<IQueryable<GetAllCategoryDTO>> getallCategoryWithSubCategory()
        {
            return  context.categories.Include(c => c.SubCategories).Select(c => new GetAllCategoryDTO() { Id = c.Id, Name = c.Name, subCategories = c.SubCategories.ToList() });
        }



    }
}
