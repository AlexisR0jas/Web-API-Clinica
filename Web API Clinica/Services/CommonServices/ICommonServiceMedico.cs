namespace Web_API_Clinica.Services.CommonServices
{
    public interface ICommonServiceMedico<T,TI,TU>
    {
        Task<IEnumerable<T>> Get();
        Task<T> GetById(int id);
        Task<T> Add(TI medicoInsertDto);
        Task<T> Update(int id, TU medicoUpdateDto);
        Task<T> Delete(int id);
    }
}
