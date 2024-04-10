namespace RSMEnterpriseIntegrationsAPI.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    using RSMEnterpriseIntegrationsAPI.Application.DTOs;
    using RSMEnterpriseIntegrationsAPI.Domain.Interfaces;

    [Route("api/proCategory")]
    [ApiController]
    public class ProductCategoryController : ControllerBase
    {
        private readonly IProCategoryService _service;

        public ProductCategoryController(IProCategoryService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.GetAll());
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            return Ok(await _service.GetProCategoryById(id));
        }

        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _service.DeleteProCategory(id));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CreateProCategoryDto dto)
        {
            return Ok(await _service.CreateProCategory(dto));
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(UpdateProCateogoryDto dto)
        {
            return Ok(await _service.UpdateProCategory(dto));
        }
    }
}
