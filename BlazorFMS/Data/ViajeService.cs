using BlazorFMS.Data.BlazorFMS;

namespace BlazorFMS.Data
{
    public class ViajeService
    {
        private readonly BlaFMSContext _context;
        public ViajeService(BlaFMSContext context)
        {
            _context = context;
        }
        
        //public async Task<List<Viaje>> GetViajeAsync(string strCurrentUser)
        //{
        //    // Get Weather Forecasts  
        //    return await _context.Viaje
        //         // Only get entries for the current logged in user
        //         .Where(x => x.UserName == strCurrentUser)
        //         // Use AsNoTracking to disable EF change tracking
        //         // Use ToListAsync to avoid blocking a thread
        //         .AsNoTracking().ToListAsync();
        //}
        
        public Task<Viajes> CreateViajetAsync(Viajes obViaje)
        {
            _context.Viaje.Add(obViaje);
            _context.SaveChanges();
            return Task.FromResult(obViaje);
        }

        public Task<bool> UpdateViajeAsync(Viajes obViaje)
        {
            var ExistingViaje =
                _context.Viaje
                .Where(x => x.Id == obViaje.Id)
                .FirstOrDefault();
            if (ExistingViaje != null)
            {
                ExistingViaje.Distancia =
                obViaje.Distancia;
                ExistingViaje.Fecha =
                obViaje.Fecha;
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

        public Task<bool> DeleteViajeAsync(Viajes obViaje)
        {
            var ExistingViaje =
                _context.Viaje
                .Where(x => x.Id == obViaje.Id)
                .FirstOrDefault();
            if (ExistingViaje != null)
            {
                _context.Viaje.Remove(ExistingViaje);
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
