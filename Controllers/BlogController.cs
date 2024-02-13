using AutoMapper;
using FinancialTamkeen_BlogAPI.Dto;
using FinancialTamkeen_BlogAPI.interfaces.Repositories;
using FinancialTamkeen_BlogAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FinancialTamkeen_BlogAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogController : ControllerBase
    {
        private readonly IBlogRepository BlogRepository;
        private readonly IMapper mapper;

        public BlogController(IBlogRepository productRepository,IMapper mapper)
        {
            this.BlogRepository = productRepository;
            this.mapper = mapper;
        }

        [HttpGet("all")]
        public ActionResult ListAllProducts()
        {

            var blog = this.BlogRepository.All();

            if(blog == null)
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(blog);
        }

        [HttpGet("{id}")]
        public ActionResult SingleBlog(int id)
        {
            if (!this.BlogRepository.BlogExists(id))
                return NotFound();

            var category = this.BlogRepository.GetById(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(category);
        }

        [HttpPost("create")]
        public ActionResult Createblog([FromBody] BlogDto dto)
        {
            if (dto == null)
                return BadRequest(ModelState);


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var blogMap = this.mapper.Map<Blog>(dto);

            if(!this.BlogRepository.Create(blogMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");        }

        [HttpPut("{id}/update")]
        public ActionResult Updateblog(int id, [FromBody] BlogDto dto)
        {
            if (dto == null)
                return BadRequest(ModelState);

            if (!this.BlogRepository.BlogExists(id))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var productMap = this.mapper.Map<Blog>(dto);

            if (!this.BlogRepository.Update(id,productMap))
            {
                ModelState.AddModelError("", "Something went wrong updating category");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }


    }
}