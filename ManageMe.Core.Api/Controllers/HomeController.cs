//===========================
// Copyright (c) YaqubAliy Developer
// Manage your academy easily
//===========================

using Microsoft.AspNetCore.Mvc;

namespace ManageMe.Core.Api.Controllers
{
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return Ok("Welcome to MasterStream Project");
        }
    }
}
