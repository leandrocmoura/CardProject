using System.Collections.Generic;
using System.Threading.Tasks;
using CardApplication.Dtos;
using CardApplication.Interfaces;
using CardDomain.Entities;
using CardDomain.Enums;



namespace CardApplication.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;

        public CardService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public async Task<IEnumerable<CardDto>> GetCardsAsync(string filter, int pageSize)
        {
            var cards = await _cardRepository.GetAllCardsAsync(filter);

            return cards.Select(c => new CardDto
            {
                Id = c.Id,
                Title = c.Title,
                Status = ((int)c.Status).ToString(),
                PhotoBase64 = c.Photo.Base64Image
            });
        }

        public async Task CreateCardAsync(CreateCardDto cardDto)
        {
            var card = new Card
            {
                Id = Guid.NewGuid(),
                Title = cardDto.Title,
                Status = CardStatus.Active,
                Photo = new Photo { Id = Guid.NewGuid(), Base64Image = cardDto.PhotoBase64 }
            };

            await _cardRepository.AddCardAsync(card);
        }

        public async Task UpdateCardAsync(UpdateCardDto cardDto)
        {
            var card = await _cardRepository.GetCardByIdAsync(cardDto.Id);
            card.Title = cardDto.Title;
            card.Photo.Base64Image = cardDto.PhotoBase64;
            await _cardRepository.UpdateCardAsync(card);
        }

        public async Task DeleteCardAsync(Guid id)
        {
            await _cardRepository.DeleteCardAsync(id);
        }
    }
}
