using Web_API_Clinica.DTOs;
using Web_API_Clinica.DTOs.PacientesAcciones;
using Web_API_Clinica.Models;

namespace Web_API_Clinica.Services
{
    public interface ICommonServicePaciente<T, TI, TU>
    {
        Task<IEnumerable<T>> Get();
        Task<T> GetById(int id);
        Task<T> Add(TI pacienteInsertDto);
        Task<T> Update(int id, TU pacienteUpdateDto);
        Task<T> Delete(int id);
    }
}
