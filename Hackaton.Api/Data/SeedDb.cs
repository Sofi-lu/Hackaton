
using Hackaton.Shared.Enties;
using Hackaton.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Hackaton.Api.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;

        public SeedDb(DataContext context)
        {
            _context = context;
        }

        public async Task SeedAsync()

        {
            await _context.Database.EnsureCreatedAsync();
            await CheckHackatonnAsync(); //encargado de hacer el chequeo cada vez q se ejecute la app
        }

        public async Task CheckHackatonnAsync()
        {
            if (!_context.Hackatones.Any())
            {

                _context.Hackatones.Add(new Hackatonn
                {
                    NombreEvento = "Hackaton 2024",
                    FechaInicio = DateTime.Now.AddDays(30),
                    FechaFin = DateTime.Now.AddDays(60),
                    Tema = "Innovación en programas ITM",
                    Organizador = "Universidad ITM"
                });
            }

            await _context.SaveChangesAsync();


        }
    }
}

