using Microsoft.AspNetCore.Mvc;
using se4458_final.Models;
using se4458_final.Models.Dto;
using se4458_final.Source.Svc;
using se4458_final.Models.Dto;
using System.Net;

namespace se4458_final.Controllers
{
    [Route("api/Pharmacie")]
    [ApiController]
    
    //[ApiVersion("1.0")]
    //[ApiVersion("2.0")]
    public class LoginController : Controller
    {
        private IPharmaciesService _pharmacieService;
        protected APIResponse _response;
        public LoginController(IPharmaciesService pharmacieService)
        {
            _pharmacieService = pharmacieService;
            _response = new();
        }

        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginReguestDTO loginReguestDTO)
        {
            var loginResponse = _pharmacieService.Login(loginReguestDTO);
            if(loginResponse.APIUser == null || string.IsNullOrEmpty(loginResponse.Token))
            {
                _response.StatusCode = HttpStatusCode.BadRequest;
                _response.IsSuccess = false;
                _response.Status = "Fail";
                _response.ErrorMessage = "Username or password is invalid";
                return BadRequest(_response);
            }

            _response.StatusCode = HttpStatusCode.OK;
            _response.IsSuccess = true;
            _response.Result = loginResponse;
            return Ok(_response);
        }

        


    }
}
