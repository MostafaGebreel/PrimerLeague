using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrimerLeague.DTOs;
using PrimerLeague.Models;

namespace PrimerLeague.Controllers
{
    public class TeamController : Controller
    {   
       private readonly PremierLeagueContext context;
        private readonly IMapper _mapper;
        public TeamController(PremierLeagueContext _context,IMapper mapper) {
            context = _context;
            _mapper = mapper;
        }
        public async Task<IActionResult> index()
        {
            var teams = await context.Team.ToListAsync();
            var res = _mapper.Map<List<TeamDTO>>(teams);
            return View(res);
        }
        public async Task<IActionResult> Details(int id)
        {
            var team = await context.Team
                .Include(t => t.PlayerProfile)
                .FirstOrDefaultAsync(t => t.TeamId == id);
            var res = _mapper.Map<TeamDTO>(team);
            return View(res);
        }
    }
}
