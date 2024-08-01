//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using Microsoft.AspNetCore.Mvc;

namespace ManageMe.Core.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() =>  Ok("Hello to my project");
    }
}
