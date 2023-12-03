using BlazorFMS.Data.BlazorFMS;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorFMS.Data
{
    public class AdministrarSucursalesServices
    {
        private readonly BlaFMSContext _context;
        public AdministrarSucursalesServices(BlaFMSContext context)
        {
            _context = context;
        }

        public async Task<List<SucursalDetalles>> GetDetalleAsync(string strCurrentUser)
        {
            // Get Weather Forecasts  
            return await _context.SucursalDetalle
                 // Only get entries for the current logged in user
                 .Where(x => x.UserName == strCurrentUser)
                 // Use AsNoTracking to disable EF change tracking
                 // Use ToListAsync to avoid blocking a thread
                 .AsNoTracking().ToListAsync();
        }

        public async Task<List<Sucursales>> GetSucursalesAsync(string strCurrentUser)
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


        public Task<SucursalDetalles> CreateDetalleAsync(SucursalDetalles objSucursalDetalles)
        {
            _context.SucursalDetalle.Add(objSucursalDetalles);
            _context.SaveChanges();
            return Task.FromResult(objSucursalDetalles);
        }

        public Task<bool> UpdateDetalleAsync(SucursalDetalles objSucursalDetalles)
        {
            var DetalleExiste =
                _context.SucursalDetalle
                .Where(x => x.SucursalDetalleId == objSucursalDetalles.SucursalDetalleId)
                .FirstOrDefault();
            if (DetalleExiste != null)
            {
                DetalleExiste.DistanciaKilometros =
                    objSucursalDetalles.DistanciaKilometros;
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
