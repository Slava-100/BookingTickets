using BookingTickets.Core.Models.API;
using BookingTickets.Core.Models.BLL;
using Microsoft.AspNetCore.Mvc;
using System;

namespace BookingTickets.Core.Contracts;
public interface ISessionManager
{
    Task<List<Session>> GetSessionsByFilmIdAsync([FromRoute] Guid id, DateTime? dateTime);
}

