
using System.Collections.Generic;
using System.Threading.Tasks;
using ClientConvertisseur.Models;

namespace WSConvertisseur.Services
{
    public interface IService
    {
        Task<List<Devise>> GetDevisesAsync(string nomControleur);
    }
}
