using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyApp.Data;
using MyApp.Dto.Vacation;
using MyApp.Interfaces;
using MyApp.Mappers;
using MyApp.Models.Vacations;

namespace MyApp.Repositories
{
    public class VacationRepository : IVacationRepository
    {
        public ApplicationDbContext _context;
        public VacationRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<CreateVacationDto> Create(CreateVacationDto createVacationDto)
        {
            var vacationDto = new CreateVacationDto
            {
                FromDate = createVacationDto.FromDate,
                ToDate = createVacationDto.ToDate,
                CreatedById = createVacationDto.CreatedById,
                AssignedUserId = createVacationDto.AssignedUserId,
            };

            var vacationModel = vacationDto.ToVacationModel();
            vacationModel.StatusId = 1;
            await _context.vacations.AddAsync(vacationModel);
            await _context.SaveChangesAsync();

            return vacationDto;
        }

        public async Task<List<IndexVacationDto>> GetByUserId(int userId)
        {
            var result = await _context.vacations
                .Include(v => v.User)
                .Where(v => v.CreatedById == userId)
                .Select(v => new IndexVacationDto
                {
                    Id = v.Id,
                    FromDate = v.StartDate,
                    ToDate = v.EndDate,
                    AssignedToUser = new UserDto {
                        Name = v.AssignedUser.Name,
                        Surname = v.AssignedUser.Surname
                    },
                    CreatedByUser = new UserDto
                    {
                        Name = v.User.Name,
                        Surname = v.User.Surname
                    }
                }).ToListAsync();

            return result;
        }
    }
}