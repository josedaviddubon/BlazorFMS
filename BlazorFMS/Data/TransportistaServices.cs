using BlazorFMS.Data.BlazorFMS;
using Microsoft.EntityFrameworkCore;

namespace BlazorFMS.Data
{
    public class TransportistaServices
    {
        private readonly BlaFMSContext _context;
        public TransportistaServices(BlaFMSContext context)
        {
            _context = context;
        }
        public async Task<List<Transportistas>> GetTransportistaAsync(string strCurrentUser)
        {
            // Get Weather Forecasts  
            return await _context.Transportista
                 // Only get entries for the current logged in user
                 .Where(x => x.UserName == strCurrentUser)
                 // Use AsNoTracking to disable EF change tracking
                 // Use ToListAsync to avoid blocking a thread
                 .AsNoTracking().ToListAsync();
        }
        public Task<Transportistas> CreateTransportistaAsync(Transportistas obTransportista)
        {
            _context.Transportista.Add(obTransportista);
            _context.SaveChanges();
            return Task.FromResult(obTransportista);
        }

        public Task<bool> UpdateTransportistaAsync(Transportistas obTransportista)
        {
            var ExistingTransportista =
                _context.Transportista
                .Where(x => x.TransportistaId == obTransportista.TransportistaId)
                .FirstOrDefault();
            if (ExistingTransportista != null)
            {
                ExistingTransportista.Nombre =
                obTransportista.Nombre;
                ExistingTransportista.TarifaPorKilometro =
                obTransportista.TarifaPorKilometro;
                _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }

        public Task<bool> DeleteTransportistaAsync(Transportistas obTransportista)
        {
            var ExistingTransportista =
                _context.Transportista
                .Where(x => x.TransportistaId == obTransportista.TransportistaId)
                .FirstOrDefault();
            if (ExistingTransportista != null)
            {
                _context.Transportista.Remove(ExistingTransportista);
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
