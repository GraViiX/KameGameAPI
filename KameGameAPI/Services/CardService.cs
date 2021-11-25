using KameGameAPI.DTOs;
using KameGameAPI.Interfaces;
using KameGameAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KameGameAPI.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepo _context;

        public CardService(ICardRepo context)
        {
            _context = context;
        }

        public async Task<ActionResult<CardModel>> CreateCardService(CardModel card)
        {
            return await _context.CreateCardRepo(card); 
        }
    }
}
