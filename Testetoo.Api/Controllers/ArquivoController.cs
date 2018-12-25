using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Testetoo.Application.Interfaces;
using Testetoo.Application.ViewModels.Arquivo;
using Testetoo.Domain.ValueObjects;

namespace Testetoo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArquivoController : ControllerBase
    {
        private readonly IArquivoAppService _arquivoAppService;

        public ArquivoController(IArquivoAppService arquivoAppService)
        {
            _arquivoAppService = arquivoAppService;

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        // GET api/arquivo
        [HttpGet]
        public IEnumerable<ArquivoListaItemViewModel> Get()
        {
            OperationResultListVo<ArquivoListaItemViewModel> model = _arquivoAppService.ListAll();

            return model.Value;
        }

        // GET api/arquivo/5
        [HttpGet("{id:guid}")]
        public ActionResult<ArquivoViewModel> Get(Guid id)
        {
            OperationResultVo<ArquivoViewModel> model = _arquivoAppService.GetById(id);

            return File(model.Value.Bytes, "image/jpeg");
        }

        // POST api/arquivo
        [HttpPost]
        public async Task<IActionResult> Post(IFormFile arquivo)
        {
            OperationResultVo<Guid> operation;

            try
            {
                if (arquivo != null && arquivo.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        arquivo.CopyTo(ms);
                        byte[] fileBytes = ms.ToArray();

                        ArquivoViewModel vm = new ArquivoViewModel
                        {
                            Nome = arquivo.FileName,
                            Bytes = fileBytes
                        };

                        operation = _arquivoAppService.Add(vm);
                    }

                    return Ok(operation);
                }
                else
                {
                    return Ok(new OperationResultVo("Sem arquivo para salvar!"));
                }
            }
            catch (Exception ex)
            {
                return Ok(new OperationResultVo(ex.Message));
            }
        }
    }
}
