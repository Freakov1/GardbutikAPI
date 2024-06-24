using GårdbutikAPI.Managers;
using GårdbutikAPI.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;



namespace GårdbutikAPI.Controllers
{
    [EnableCors("AllowAll")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManagerDB _manager;

        private static User loggedinuser = null;


        public UserController(GårdbutikContext _context)
        {
            _manager = new UserManagerDB(_context);
        }

        //Get all users as a list//
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetAll()
        {
            IEnumerable<User> list = _manager.GetAll();
            if (list == null || list.Count() == 0)
            {
                return NoContent();
            }
            else
            {
                return Ok(list);
            }
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("getuser/{id}")]
        public ActionResult<User> Get(int id)
        {
            User founduser = _manager.GetById(id);
            if (founduser == null)
            {
                return NotFound();
            }
            else
            {
                loggedinuser = founduser;
                return Ok(founduser);
                
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("getcurrentuser")]
        public ActionResult<User> GetLoggedInUser()
        {
            return Ok(loggedinuser);
        }



        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<User> Post([FromBody] User newuser)
        {
            
            try
            {
                loggedinuser = null;
                User createduser = _manager.Add(newuser);
                return Created("/" + createduser.Id, createduser);
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
    }
}
