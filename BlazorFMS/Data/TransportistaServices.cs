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
        public async Task<List<Transportista>> GetTransportistaAsync(string strCurrentUser)
        {
            // Get Weather Forecasts  
            return await _context.Transportista
                 // Only get entries for the current logged in user
                 .Where(x => x.UserName == strCurrentUser)
                 // Use AsNoTracking to disable EF change tracking
                 // Use ToListAsync to avoid blocking a thread
                 .AsNoTracking().ToListAsync();
        }
        public Task<Transportista> CreateTransportistaAsync(Transportista obTransportista)
        {
            _context.Transportista.Add(obTransportista);
            _context.SaveChanges();
            return Task.FromResult(obTransportista);
        }

        public Task<bool> UpdateTransportistaAsync(Transportista obTransportista)
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
                /*
                ExistingColaborador.TemperatureC =
                obColaborador.TemperatureC;
                ExistingColaborador.TemperatureF =
                obColaborador.TemperatureF;
                */
                _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }

        public Task<bool> DeleteTransportistaAsync(Transportista obTransportista)
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
