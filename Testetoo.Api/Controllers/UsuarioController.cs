﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Testetoo.Application.Interfaces;
using Testetoo.Application.ViewModels.Usuario;

namespace Testetoo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public UsuarioController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings()
            {
                DateFormatString = "yyyy-MM-dd",
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
        }

        // GET api/usuario
        [HttpGet]
        public IEnumerable<UsuarioViewModel> Get()
        {
            var model = _usuarioAppService.GetAll();

            return model.Value;
        }

        // GET api/usuario/5
        [HttpGet("{id:guid}")]
        public ActionResult<UsuarioViewModel> Get(Guid id)
        {
            var model = _usuarioAppService.GetById(id);

            var json = JsonConvert.SerializeObject(model);

            return Content(json, "application/json");
        }

        // POST api/usuario
        [HttpPost]
        public IActionResult Post([FromBody] UsuarioViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var operation = _usuarioAppService.Add(vm);

            return Ok(operation);
        }

        // PUT api/usuario/5
        [HttpPut("{id:guid}")]
        public IActionResult Put(Guid id, [FromBody] UsuarioViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != vm.Id)
            {
                return BadRequest();
            }

            var operation = _usuarioAppService.Update(vm);

            return Ok(operation);
        }

        // DELETE api/usuario/5
        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var operation = _usuarioAppService.Remove(id);

            return Ok(operation);
        }
    }
}
