using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyApp.Dto.Vacation;
using MyApp.Interfaces;

namespace MyApp.Controllers.Vacation
{
    [ApiController]
    [Route("api/vacation")]
    public class VacationController : ControllerBase
    {
        private readonly IVacationRepository _vacationRepo;
        public VacationController(IVacationRepository vacationRepository)
        {
            _vacationRepo = vacationRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateVacationDto createVacationDto)
        {
            var result = await _vacationRepo.Create(createVacationDto);

            return Ok(result);
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetByUserId(int userId)
        {
            var result = await _vacationRepo.GetByUserId(userId);

            return Ok(result);
        }
    }
}