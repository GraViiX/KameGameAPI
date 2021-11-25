using KameGameAPI.Database;
using KameGameAPI.Interfaces;
using KameGameAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KameGameAPI.Repo
{
    public class CardRepo : ControllerBase, ICardRepo
    {
        private readonly DatabaseContext _context;
        public CardRepo(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<ActionResult<CardModel>> CreateCardRepo(CardModel card)
        {
            _context.cards.Add(card);
            try
            {
                await _context.SaveChangesAsync();
                
            } catch
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
