using AutoMapper;
using Web_API_Clinica.DTOs;
using Web_API_Clinica.DTOs.MedicosAcciones;
using Web_API_Clinica.Models;
using Web_API_Clinica.Repository;
using Web_API_Clinica.Services.CommonServices;

namespace Web_API_Clinica.Services
{
    public class MedicoService : ICommonServiceMedico<MedicoDto,MedicoInsertDto,MedicoUpdateDto>
    {
        private IRepositoryMedico<Medico> _medicoRepository;
        private IMapper _mapper;

        public MedicoService(IRepositoryMedico<Medico> medicoRepository, IMapper mapper)
        {
            _medicoRepository = medicoRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MedicoDto>> Get()
        {
            var medicos = await _medicoRepository.Get();
            return medicos.Select(m => _mapper.Map<MedicoDto>(m));
        }

        public async Task<MedicoDto> GetById(int id)
        {
            var medico = await _medicoRepository.GetById(id);
            
            if(medico!=null)
            {
                var medicoDto= _mapper.Map<MedicoDto>(medico);
                return medicoDto;
            }
            return null;
        }

        public async Task<MedicoDto> Add(MedicoInsertDto medicoInsertDto)
        {
            var medico = _mapper.Map<Medico>(medicoInsertDto);

            await _medicoRepository.Add(medico);
            await _medicoRepository.Save();

            var medicoDto = _mapper.Map<MedicoDto>(medico);
            return medicoDto;
        }

        public async Task<MedicoDto> Update(int id, MedicoUpdateDto medicoUpdateDto)
        {
            var medico = await _medicoRepository.GetById(id);

            if(medico!=null)
            {
                medico = _mapper.Map<MedicoUpdateDto, Medico>(medicoUpdateDto, medico);

                _medicoRepository.Update(medico);
                await _medicoRepository.Save();

                var medicoDto = _mapper.Map<MedicoDto>(medico);

                return medicoDto;
            }
            return null;
        }

        public async Task<MedicoDto> Delete(int id)
        {
            var medico = await _medicoRepository.GetById(id);

            if(medico!=null)
            {
                var medicoDto = _mapper.Map<MedicoDto>(medico);

                _medicoRepository.Delete(medico);
                await _medicoRepository.Save();

                return medicoDto;
            }
            return null;
        }

        
    }
}
