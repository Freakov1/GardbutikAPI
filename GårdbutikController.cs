using GårdbutikAPI.Managers;
using GårdbutikAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;



namespace GårdbutikAPI.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    [ApiController]
    public class GårdbutikController : ControllerBase
    {

        private readonly GårdbutikManagerDB _manager;

        public GårdbutikController(GårdbutikContext _context)
        {
            _manager = new GårdbutikManagerDB(_context);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<IEnumerable<Gårdbutik>> GetAll()
        {
            IEnumerable<Gårdbutik> list = _manager.GetAll();
            return Ok(list);
            
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<Gårdbutik> Get(int id)
        {
            Gårdbutik foundGård = _manager.GetById(id);
            if (foundGård == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(foundGård);
            }
        }

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Gårdbutik> Post([FromBody] Gårdbutik newGård)
        {
            try
            {
               Gårdbutik createdGård = _manager.Add(newGård);
                return Created("/" + createdGård.Id, createdGård);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }



        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult<Gårdbutik> Put(int id, [FromBody] Gårdbutik updates)
        {
            try
            {
                Gårdbutik updatedGård = _manager.Update(id, updates);
                if (updatedGård == null)
                {
                    return NotFound();
                }
                return Ok(updatedGård);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<Gårdbutik> Delete(int id)
        {
            Gårdbutik deletedGård = _manager.Delete(id);
            if (deletedGård == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(deletedGård);
            }
        }
    }
}
