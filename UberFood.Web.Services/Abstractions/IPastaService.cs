
using UberFood.Web.Services.Dtos;

namespace UberFood.Web.Services.Abstractions
{
    public interface IPastaService
    {
        Task<IEnumerable<PastaDto>> GetPastasAsync();
        Task<PastaDto> GetPastaByIdAsync(Guid id);
        Task CreatePastaAsync(PastaDto pasta);
        Task UpdatePastaAsync(Guid id, PastaDto pasta);
        Task DeletePastaAsync(Guid id);
    }
}
