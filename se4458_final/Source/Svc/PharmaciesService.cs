using Microsoft.IdentityModel.Tokens;
using se4458_final.Context;
using se4458_final.Models.Dto;

using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace se4458_final.Source.Svc
{
    public class PharmaciesService : IPharmaciesService
    {
        private readonly PharmacyDbContext _pharmacyDb;
        private string secretKey;

        public PharmaciesService(PharmacyDbContext pharmacyDb, IConfiguration configuration)
        {
            _pharmacyDb = pharmacyDb;
            secretKey = configuration.GetValue<string>("ApiSettings:Secret");

        }
        public LoginResponseDTO Login(LoginReguestDTO loginReguestDTO)
        {
            var user = _pharmacyDb.Pharmacies.FirstOrDefault(u => u.UserName == loginReguestDTO.UserName && u.Password == loginReguestDTO.Password);

            if (user == null)
            {
                return new LoginResponseDTO()
                {
                    Token = "",
                    APIUser = null
                };
            }

            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name,user.Id.ToString()),
                    
                }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            LoginResponseDTO loginResponseDTO = new LoginResponseDTO()
            {
                Token = tokenHandler.WriteToken(token),
                APIUser = user,
            };

            return loginResponseDTO;
        }
    }
}
