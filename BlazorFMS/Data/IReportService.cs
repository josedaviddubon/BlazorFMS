using BlazorFMS.Pages;

namespace BlazorFMS.Data
{
    public interface IReportService
    {
        Task<List<Viaje>> ObtenerDetalleViajes(DateTime? fechaInicio, DateTime? fechaFin);
        Task<ResumenCostos> ObtenerResumenCostos(DateTime? fechaInicio, DateTime? fechaFin);
    }


}
