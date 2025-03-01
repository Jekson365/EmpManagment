using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyApp.Dto.Vacation;
using MyApp.Models.Vacations;

namespace MyApp.Mappers
{
    public static class VacationMappers
    {
        public static Vacation ToVacationModel(this CreateVacationDto createVacationDto)
        {
            return new Vacation
            {
                StartDate = createVacationDto.FromDate,
                EndDate = createVacationDto.ToDate,
                CreatedById = createVacationDto.CreatedById,
                AssignedUserId = createVacationDto.AssignedUserId
            };
        }
    }
}