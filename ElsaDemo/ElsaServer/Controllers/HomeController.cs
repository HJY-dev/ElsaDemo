using Elsa;
using ElsaServer.Data;
using ElsaServer.Workflows;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ElsaServer.Controllers
{
    [Route("files")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IFileReceivedInvoker _invoker;

        public HomeController(IFileReceivedInvoker invoker)
        {
            _invoker = invoker;
        }

        [HttpPost]
        public async Task<IActionResult> Handle()
        {
            var collectedWorkflows = await _invoker.DispatchWorkflowsAsync();
            return Ok(collectedWorkflows.ToList());
        }


        [HttpPost]
        public async Task<IActionResult> Handle(IFormFile file)
        {
            var fileModel = new FileModel
            {
                FileName = Path.GetFileName(file.FileName),
                Content = await file.OpenReadStream().ReadBytesToEndAsync(),
                MimeType = file.ContentType
            };

            var collectedWorkflows = await _invoker.DispatchWorkflowsAsync(fileModel);
            return Ok(collectedWorkflows.ToList());
        }
    }
}
