using BlazorFMS.Data.BlazorFMS;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorFMS.Data
{
    public class SucursalService
    {
        private readonly BlaFMSContext _context;
        public SucursalService(BlaFMSContext context)
        {
            _context = context;
        }
        public async Task<List<Sucursales>> GetSucursalAsync(string strCurrentUser)
        {
            // Get Weather Forecasts  
            return await _context.Sucursal
                 // Only get entries for the current logged in user
                 .Where(x => x.UserName == strCurrentUser)

                 .AsNoTracking().ToListAsync();
        }

        public async Task<List<Colaboradores>> GetColaboradoresAsync(string strCurrentUser)
        {
            return await _context.Colaborador
                .Where(x => x.UserName == strCurrentUser)
                .AsNoTracking()
                .ToListAsync();
        }


        public Task<Sucursales> CreateSucursalAsync(Sucursales objSucursales)
        {
            _context.Sucursal.Add(objSucursales);
            _context.SaveChanges();
            return Task.FromResult(objSucursales);
        }

       
        public Task<bool> UpdateSucursalAsync(Sucursales objSucursales)
        {
            var ExistingSucursal =
                _context.Sucursal
                .Where(x => x.SucursalId == objSucursales.SucursalId)
                .FirstOrDefault();
            if (ExistingSucursal != null)
            {
                ExistingSucursal.Nombre =
                objSucursales.Nombre;
                ExistingSucursal.Ubicacion =
                objSucursales.Ubicacion;

                _context.SaveChanges();
            }
            else
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }


        public Task<bool> DeleteSucursalAsync(Sucursales objSucursales)
        {
            var ExistingSucursal =
                _context.Sucursal
                .Where(x => x.SucursalId == objSucursales.SucursalId)
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
