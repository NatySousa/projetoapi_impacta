using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoAPI_Impacta.Entities;
using ProjetoAPI_Impacta.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI_Impacta.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {

        private readonly UsuarioRepository _usuarioRepository;

        public UsuariosController(UsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        // GET: api/<UsuariosController>        
        [HttpGet]
        public ActionResult<List<Usuario>> Get() =>
            _usuarioRepository.Get();


        [HttpGet("{id:length(24)}", Name = "GetUsuario")]
        public ActionResult<Usuario> Get(string id)
        {
            var Usuario = _usuarioRepository.Get(id);

            if (Usuario == null)
            {
                return NotFound();
            }

            return Usuario;
        }

        [HttpPost]
        public ActionResult<Usuario> Create(Usuario Usuario)
        {
            _usuarioRepository.Create(Usuario);

            return CreatedAtRoute("GetUsuario", new { id = Usuario.IdUsuario.ToString() }, Usuario);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Usuario UsuarioIn)
        {
            var Usuario = _usuarioRepository.Get(id);

            if (Usuario == null)
            {
                return NotFound();
            }

            _usuarioRepository.Update(id, UsuarioIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var Usuario = _usuarioRepository.Get(id);

            if (Usuario == null)
            {
                return NotFound();
            }

            _usuarioRepository.Remove(Usuario.IdUsuario);

            return NoContent();
        }
    }
}
   