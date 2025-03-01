using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp.Dto.Vacation;

namespace MyApp.Interfaces
{
    public interface IVacationRepository
    {
        Task<CreateVacationDto> Create(CreateVacationDto createVacationDto);
        Task<List<IndexVacationDto>> GetByUserId(int userId);
    }
}