using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StemwijzerApp.Models;

namespace StemwijzerApp.Services.Interfaces
{
    
    public interface IMatchService
    {
        //roept de functie aan voor de berekening van de resultaten op basis van de antwoorden van de gebruiker
        Task<ResultaatResponse> BerekenAsync(IReadOnlyList<Antwoord> antwoorden);
    }
}
