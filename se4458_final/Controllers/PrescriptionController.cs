using Microsoft.AspNetCore.Mvc;
using se4458_final.Models.Dto;
using se4458_final.Source.Svc;
using se4458_final.Models;
using System.Net;

namespace se4458_final.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiVersion("1.0")]
    public class PrescriptionController : Controller
    {

        IPrescriptionService _createPrescriptionService;


        public PrescriptionController(IPrescriptionService createPrescriptionService)
        {
            _createPrescriptionService = createPrescriptionService;

        }



        [HttpPost("create")]
        [MapToApiVersion("1.0")]
        public ActionResult<APIResponse> CreatePrescription([FromBody] PrescriptionDto prescriptionDto)
        {
            if (prescriptionDto == null)
            {
                return BadRequest(new APIResponse
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Status = "FAILURE",
                    IsSuccess = false,
                    ErrorMessage = "Prescription data is missing.",
                });
            }

            try
            {
                int createdPrescriptionId = _createPrescriptionService.CreatePrescription(prescriptionDto);

                return Ok(new APIResponse
                {
                    StatusCode = HttpStatusCode.OK,
                    Result = new { PrescriptionId = createdPrescriptionId },
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new APIResponse
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Status = "FAILURE",
                    IsSuccess = false,
                    ErrorMessage = $"An error occurred: {ex.Message}",
                });
            }
        }


        [HttpPut("update/{id}")]
        [MapToApiVersion("1.0")]
        public ActionResult<APIResponse> UpdatePrescription(int id, [FromBody] PrescriptionDto updatedPrescriptionDto)
        {
            if (updatedPrescriptionDto == null)
            {
                return BadRequest(new APIResponse
                {
                    StatusCode = HttpStatusCode.BadRequest,
                    Status = "FAILURE",
                    IsSuccess = false,
                    ErrorMessage = "Updated prescription data is missing.",
                });
            }

            try
            {
                updatedPrescriptionDto.Id = id;
                _createPrescriptionService.UpdatePrescription(updatedPrescriptionDto);

                return Ok(new APIResponse
                {
                    StatusCode = HttpStatusCode.OK,
                    Result = "Prescription updated successfully.",
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new APIResponse
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Status = "FAILURE",
                    IsSuccess = false,
                    ErrorMessage = $"An error occurred: {ex.Message}",
                });
            }
        }

        [HttpDelete("delete/{id}")]
        [MapToApiVersion("1.0")]
        public ActionResult<APIResponse> DeletePrescription(int id)
        {
            try
            {
                _createPrescriptionService.DeletePrescription(id);

                return Ok(new APIResponse
                {
                    StatusCode = HttpStatusCode.OK,
                    Result = "Prescription deleted successfully.",
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new APIResponse
                {
                    StatusCode = HttpStatusCode.InternalServerError,
                    Status = "FAILURE",
                    IsSuccess = false,
                    ErrorMessage = $"An error occurred: {ex.Message}",
                });
            }
        }
    }
}
