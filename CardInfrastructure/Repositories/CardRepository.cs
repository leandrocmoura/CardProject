using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CardDomain.Entities;
using CardApplication.Interfaces;
using Microsoft.EntityFrameworkCore;
using CardInfrastructure.Data;

namespace CardInfrastructure.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly CardDbContext _context;

        public CardRepository(CardDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Card>> GetAllCardsAsync(string filter)
        {
            var query = await _context.Card
                .Include(c => c.Photo)
                .Where(c => c.Title.Contains(filter))
                .ToListAsync();

            return query;
        }

        public async Task<Card> GetCardByIdAsync(Guid id)
        {
            var query = await _context.Card
                .Include(c => c.Photo)
                .FirstOrDefaultAsync(c => c.Id == id);

            return query;
        }

        public async Task AddCardAsync(Card card)
        {
            await _context.Card.AddAsync(card);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCardAsync(Card card)
        {
            _context.Card.Update(card);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCardAsync(Guid id)
        {
            var card = await _context.Card.FindAsync(id);
            _context.Card.Remove(card);
            await _context.SaveChangesAsync();
        }
    }
}
