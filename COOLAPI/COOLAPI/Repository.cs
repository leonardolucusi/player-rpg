using COOLAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace COOLAPI
{
    public class Repository : IRepository<Player>
    {
        private readonly Context _context;

        public Repository(Context context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<Player>> GetAllAsync()
        {
            return await _context.Players.ToListAsync();
        }
        
        public async Task<Player> GetByIdAsync(long? id)
        {
            var player = await _context.Players.FindAsync(id);
            if (player == null)
            {
                throw new Exception("Jogador não encontrado");
            }
            return player;
        }
        
        public async Task AddAsync(Player player)
        {
            _context.Players.Add(player);
            await _context.SaveChangesAsync();
        }
        
        public async Task UpdateAsync(Player player)
        {
            _context.Players.Entry(player).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(long id)
        {
            var player = await _context.Players.FindAsync(id);
            if(player != null)
            {
                _context.Players.Remove(player);
                await _context.SaveChangesAsync();
            }
        }
    }
}
