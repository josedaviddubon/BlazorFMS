using BlazorFMS.Data.BlazorFMS;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorFMS.Data
{
    public class ColaboradorServices
    {
        private readonly BlaFMSContext _context;
        public ColaboradorServices(BlaFMSContext context)
        {
            _context = context;
        }
        public async Task<List<Colaboradores>> GetColaboradorAsync(string strCurrentUser)
        {
            // Get Weather Forecasts  
            return await _context.Colaborador
                 // Only get entries for the current logged in user
                 .Where(x => x.UserName == strCurrentUser)
                 // Use AsNoTracking to disable EF change tracking
                 // Use ToListAsync to avoid blocking a thread
                 .AsNoTracking().ToListAsync();
        }
        public Task<Colaboradores> CreateColaboradorAsync(Colaboradores objColaborador)
        {
            _context.Colaborador.Add(objColaborador);
            _context.SaveChanges();
            return Task.FromResult(objColaborador);
        }

        public Task<bool> UpdateColaboradorAsync(Colaboradores objColaborador)
            {
                var ExistingColaborador =
                    _context.Colaborador
                    .Where(x => x.ColaboradorId == objColaborador.ColaboradorId)
                    .FirstOrDefault();
                if (ExistingColaborador != null)
                {
                    ExistingColaborador.Nombre =
                    objColaborador.Nombre;
                    ExistingColaborador.DireccionCasa =
                    objColaborador.DireccionCasa;
                    _context.SaveChanges();
                }
                else
                {
                    return Task.FromResult(false);
                }
                return Task.FromResult(true);
            }

        public Task<bool> DeleteColaboradorAsync(Colaboradores objColaborador)
            {
                var ExistingColaborador =
                    _context.Colaborador
                    .Where(x => x.ColaboradorId == objColaborador.ColaboradorId)
                    .FirstOrDefault();
                if (ExistingColaborador != null)
                {
                    _context.Colaborador.Remove(ExistingColaborador);
                    _context.SaveChanges();
                }
                else
                {
                    return Task.FromResult(false);
                }
                return Task.FromResult(true);
            }
        
    }
}
