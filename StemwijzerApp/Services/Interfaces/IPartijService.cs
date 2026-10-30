using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StemwijzerApp.Models;

namespace StemwijzerApp.Services.Interfaces
{
    public interface IPartijService
    {
        Task<List<Partij>> GetPartijenAsync();
    }
}
