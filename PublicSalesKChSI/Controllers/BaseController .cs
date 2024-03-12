using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PublicSalesKChSI.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        
    }
}
