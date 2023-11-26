using BlazorFMS.Data.BlazorFMS;
using Microsoft.EntityFrameworkCore;

namespace BlazorFMS.Data
{
    public class SucursalService
    {
        private readonly BlaFMSContext _context;
        public SucursalService(BlaFMSContext context)
        {
            _context = context;
        }
        public async Task<List<Sucursal>> GetForecastAsync(string strCurrentUser)
        {
            // Get Weather Forecasts  
            return await _context.Sucursal
                 // Only get entries for the current logged in user
                 .Where(x => x.Nombre == strCurrentUser)
                 // Use AsNoTracking to disable EF change tracking
                 // Use ToListAsync to avoid blocking a thread
                 .AsNoTracking().ToListAsync();
        }
        public Task<Sucursal> CreateForecastAsync(Sucursal obSucursal)
        {
            _context.Sucursal.Add(obSucursal);
            _context.SaveChanges();
            return Task.FromResult(obSucursal);
        }

        public Task<bool> UpdateForecastAsync(Sucursal obSucursal)
        {
            var ExistingSucursal =
                _context.Sucursal
                .Where(x => x.SucursalId == obSucursal.SucursalId)
                .FirstOrDefault();
            if (ExistingSucursal != null)
            {
                ExistingSucursal.Nombre =
                obSucursal.Nombre;
                ExistingSucursal.Ubicacion =
                obSucursal.Ubicacion;
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

        public Task<bool> DeleteForecastAsync(Sucursal obSucursal)
        {
            var ExistingSucursal =
                _context.Sucursal
                .Where(x => x.SucursalId == obSucursal.SucursalId)
                .FirstOrDefault();
            if (ExistingSucursal != null)
            {
                _context.Sucursal.Remove(ExistingSucursal);
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
