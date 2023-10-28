using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace COOLAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IRepository<Player> _playerRepository;

        public HomeController(IRepository<Player> playerRepository)
        {
            _playerRepository = playerRepository;
        }

        [EnableCors("MyPolicy")]
        [HttpGet]
        public async Task<ActionResult> GetAll() 
        {
            IEnumerable<Player> players = await _playerRepository.GetAllAsync();
            List<Player> playerList = players.ToList();
            return Ok(playerList);
        }

        [EnableCors("MyPolicy")]
        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetById(long id)
        {
            try
            {
                var player = await _playerRepository.GetByIdAsync(id);

                if (player == null)
                {
                    return NotFound(); 
                }

                return Ok(player);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                throw;
            }
        }

        [EnableCors("MyPolicy")]
        [HttpPost]
        public async Task<IActionResult> CreateUser(Player player)
        {
            try
            {
                await _playerRepository.AddAsync(player);
                return CreatedAtAction(nameof(GetById), new { id = player.Id }, player);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                throw;
            }
        }

        [EnableCors("MyPolicy")]
        [HttpPut("{id}")]
        public async Task<ActionResult<Player>> Update(Player player)
        {
            try
            {

                var existingPlayer = await _playerRepository.GetByIdAsync(player.Id);
             
                if (existingPlayer == null)
                {
                    return NotFound();
                }

                existingPlayer.Name = player.Name;
                existingPlayer.Level = player.Level;

                await _playerRepository.UpdateAsync(existingPlayer);
                return Ok(existingPlayer);
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                throw;
            }
        }

        [EnableCors("MyPolicy")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            try
            {
                var player = await _playerRepository.GetByIdAsync(id);
                Console.WriteLine(player);
                if (player == null)
                {
                    return NotFound();
                }

                await _playerRepository.DeleteAsync(id);
                return NoContent(); // 204 No Content response
            }
            catch (Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.Message);
                throw;
            }
        }
    }
}