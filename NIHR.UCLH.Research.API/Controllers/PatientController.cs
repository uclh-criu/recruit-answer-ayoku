﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NIHR.UCLH.Research.DAL.DataService.Interface;
using NIHR.UCLH.Research.Domain;

namespace NIHR.UCLH.Research.API.Controllers
{
    [Route("Admission")]    
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IDataService _dataService;
        public PatientController(IDataService dataService)
        {
            this._dataService = dataService;
        }

        //[HttpGet]
        //[Route("all")]
        //public async Task<ActionResult<IList<AdmissionDTO>>> GetAllAppointments()
        //{
        //    var appointmentList = await _dataService.GetAllAdmissionAsync();

        //    return await Task.FromResult(appointmentList.ToList());

        //}

        [HttpGet]
        [Route("ethincity")]
        public async Task<ActionResult<IList<EthincityDTO>>> GetAppointmentsByEthincity(string origin)
        {
            var appointmentList = await _dataService.GetAdmissionByEthincityAsync(origin);

            return  await Task.FromResult(appointmentList.ToList());
        }


        [HttpGet]
        [Route("gender")]
        public async Task<ActionResult<IList<GenderDTO>>> GetAppointmentsByGender(string gender)
        {
            var appointmentList = await _dataService.GetAdmissionBySexAsync(gender);

            return await Task.FromResult(appointmentList.ToList());
        }

        [HttpGet]
        [Route("age")]
        public async Task<ActionResult<IList<AgeDTO>>> GetAppointmentsByAge(int age)
        {
            var appointmentList = await _dataService.GetAdmissionByAgeAsync(age);

            return await Task.FromResult(appointmentList.ToList());
        }

    }
}
