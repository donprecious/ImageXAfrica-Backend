using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ImageAfricaProject.Dto.category;
using ImageAfricaProject.Dto.image;
using ImageAfricaProject.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ImageAfricaProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
       
        private readonly IMapper _mapper;
        private ICategoryRepository _categoryRepository;
        public CategoryController( IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var category = await _categoryRepository.GetAll()
                .ToListAsync();
            var mapped = _mapper.Map<List<CategoryDto>>(category);
            return Ok(mapped);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var category = await _categoryRepository.GetById(id)
                ;
            var mapped = _mapper.Map<CategoryDto>(category);
            return Ok(mapped);
        }
    }
}