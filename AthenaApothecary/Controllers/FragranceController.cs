using AthenaApothecary.Filters.ActionFilters;
using AthenaApothecary.Models;
using AthenaApothecary.Models.Respositories;
using Microsoft.AspNetCore.Mvc;

namespace AthenaApothecary.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FragrancesController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetFragrances()
        {
            List<Fragrance> fragrances = FragranceRepository.GetFragrances();
            return Ok(fragrances);
        }

        [HttpGet("{id}")]
        [Fragrance_ValidateFragranceIdFilter]
        public IActionResult GetFragranceById(int id)
        {
            Fragrance? fragrance = FragranceRepository.GetFragranceById(id);

            if (fragrance == null)
            {
                return NotFound();
            }

            return Ok(fragrance);
        }

        [HttpPost]
        public IActionResult CreateFragrance([FromBody] Fragrance fragrance)
        {
            if (fragrance == null)
            {
                return BadRequest();
            }

            FragranceRepository.AddFragrance(fragrance);

            return CreatedAtAction(nameof(GetFragranceById), new { id = fragrance.Id }, fragrance);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFragrance(int id, [FromBody] Fragrance updatedFragrance)
        {
            Fragrance? fragrance = FragranceRepository.GetFragranceById(id);

            if (fragrance == null)
            {
                return NotFound();
            }

            FragranceRepository.UpdateFragrance(updatedFragrance);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFragrance(int id)
        {
            Fragrance? fragrance = FragranceRepository.GetFragranceById(id);

            if (fragrance == null)
            {
                return NotFound();
            }

            FragranceRepository.DeleteFragrance(id);

            return Ok(fragrance);
        }
    }
}
