using Microsoft.AspNetCore.Mvc;
using se4458_final.Models;
using se4458_final.Models.Dto;
using se4458_final.Source.Svc;

namespace se4458_final.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    public class MedicineQueryController : Controller
    {
        IMedicineService _medicineService;

        public MedicineQueryController(IMedicineService medicineService)
        {
            _medicineService = medicineService;
        }


        [HttpGet("GetMedicines")]
        [MapToApiVersion("1.0")]
        [ResponseCache(CacheProfileName = "Default30")]
        public ActionResult<APIResponse> GetMedicines(string name)
        {
            var response = new APIResponse();

            try
            {

                List<string> medicineNames = _medicineService.GetMedicineByName(name);



                response.Result = medicineNames;
            }
            catch (Exception ex)
            {

                response.Status = "ERROR";
                response.IsSuccess = false;
                response.ErrorMessage = ex.Message;
                response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
            }

            return response;
        }

        [HttpGet("GetMedicinesByPaging")]
        [MapToApiVersion("1.0")] 
        [ResponseCache(CacheProfileName = "Default30")]
        public ActionResult<APIResponse> GetMedicinesWithPaging([FromQuery] MedicineWithPagingDto pagingDto)
        {
            var response = new APIResponse();

            try
            {
                List<string> query = _medicineService.GetMedicineByName(pagingDto.MedicineName);
                
                if (pagingDto.PageNumber <= 0 || pagingDto.PageSize <= 0)
                {
                    response.Status = "ERROR";
                    response.IsSuccess = false;
                    response.ErrorMessage = "Invalid paging parameters.";
                    response.StatusCode = System.Net.HttpStatusCode.BadRequest;

                    return BadRequest(response);
                }

                
                int skip = (pagingDto.PageNumber - 1) * pagingDto.PageSize;

                
                List<string> medicineNames = query
                    .Skip(skip)
                    .Take(pagingDto.PageSize)
                    .ToList();

                response.Result = medicineNames;
            }
            catch (Exception ex)
            {
                response.Status = "ERROR";
                response.IsSuccess = false;
                response.ErrorMessage = ex.Message;
                response.StatusCode = System.Net.HttpStatusCode.InternalServerError;
            }

            return response;
        }


    }
}
