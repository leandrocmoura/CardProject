using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CardDomain.Entities;

namespace CardApplication.Interfaces
{
    public interface ICardRepository
    {
        Task<IEnumerable<Card>> GetAllCardsAsync(string filter);
        Task<Card> GetCardByIdAsync(Guid id);
        Task AddCardAsync(Card card);
        Task UpdateCardAsync(Card card);
        Task DeleteCardAsync(Guid id);
    }
}
