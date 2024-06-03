using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private const string user = "usuario";
    private const string password = "facundo";

    public class CredencialesModel
    {
        public string usuario { get; set; }
        public string password { get; set; }
    }

    [HttpPost("Session")]
    public IActionResult Session([FromBody] CredencialesModel credenciales)
    {
        if (credenciales.usuario == user && VerificarContraseñaMd5(credenciales.password))
        {
            return Ok("Credenciales válidas");
        }
        else
        {
            return Unauthorized("Credenciales inválidas");
        }
    }

    private bool VerificarContraseñaMd5(string passwordMd5)
    {
        return passwordMd5 == ObtenerHashMd5(password);
    }

    private string ObtenerHashMd5(string input)
    {
        using (MD5 md5 = MD5.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("x2"));
            }
            return sb.ToString();
        }
    }
}