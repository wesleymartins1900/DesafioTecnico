using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MSFilmes.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class FilmeController
    {
    }
}