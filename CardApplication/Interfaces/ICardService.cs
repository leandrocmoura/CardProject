using System.Collections.Generic;
using System.Threading.Tasks;
using CardApplication.Dtos;

namespace CardApplication.Interfaces
{
    public interface ICardService
    {
        Task<IEnumerable<CardDto>> GetCardsAsync(string filter);
        Task CreateCardAsync(CreateCardDto cardDto);
        Task UpdateCardAsync(UpdateCardDto cardDto);
        Task DeleteCardAsync(Guid id);
    }
}
