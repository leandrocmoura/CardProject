using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CardApplication.Dtos;
using CardApplication.Interfaces;

namespace CardApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {
        private readonly ICardService _cardService;
        private readonly ICardRepository _cardRepository;

        public CardController(ICardService cardService, ICardRepository cardRepository)
        {
            _cardService = cardService;
            _cardRepository = cardRepository;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CardDto>>> GetCards([FromQuery] string filter = "", [FromQuery] int pageSize = 0)
        {
            var cards = await _cardService.GetCardsAsync(filter, pageSize);
            return Ok(cards);
        }

  
        [HttpGet("{id}")]
        public async Task<ActionResult<CardDto>> GetCard(Guid id)
        {
            var card = await _cardRepository.GetCardByIdAsync(id);
            if (card == null) return NotFound();

            return Ok(card);
        }


        [HttpPost]
        public async Task<ActionResult> CreateCard([FromBody] CreateCardDto cardDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _cardService.CreateCardAsync(cardDto);
            return Ok();
        }

  
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCard(Guid id, [FromBody] UpdateCardDto cardDto)
        {
            if (id != cardDto.Id) return BadRequest("ID Não encontrado.");
            if (!ModelState.IsValid) return BadRequest(ModelState);

            await _cardService.UpdateCardAsync(cardDto);
            return Ok();
        }

  
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCard(Guid id)
        {
            await _cardService.DeleteCardAsync(id);
            return Ok();
        }
    }
}
