// Copyright (c) Duende Software. All rights reserved.
// See LICENSE in the project root for license information.

// Original file: https://github.com/DuendeSoftware/IdentityServer.Quickstart.UI
// Modified by Jan Škoruba

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using IdentityService.STS.Identity.Helpers;
using IdentityService.STS.Identity.ViewModels.Diagnostics;
using System.Collections.Generic;

namespace IdentityService.STS.Identity.Controllers
{
    [SecurityHeaders]
    [Authorize]
    public class DiagnosticsController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var remoteIps = new List<string>();
            for (int i = 0; i < 256; i++)
            {
                remoteIps.Add($"::ffff:172.{i}.0.1");
            }
            remoteIps.Add("127.0.0.1");
            remoteIps.Add("::1");
            remoteIps.Add(HttpContext.Connection.LocalIpAddress.ToString());
            var localAddresses = remoteIps.ToArray();
            if (!localAddresses.Contains(HttpContext.Connection?.RemoteIpAddress?.ToString()))
            {
                return NotFound();
            }

            var model = new DiagnosticsViewModel(await HttpContext.AuthenticateAsync());
            return View(model);
        }
    }
}







