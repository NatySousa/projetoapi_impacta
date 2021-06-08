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
    public class TarefasController : ControllerBase
    {

        private readonly TarefaRepository _tarefaRepository;

        public TarefasController(TarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }


        // GET: api/<TarefasController>        
        [HttpGet]
        public ActionResult<List<Tarefa>> Get() =>
            _tarefaRepository.Get();


        [HttpGet("{id:length(24)}", Name = "GetTarefa")]
        public ActionResult<Tarefa> Get(string id)
        {
            var Tarefa = _tarefaRepository.Get(id);

            if (Tarefa == null)
            {
                return NotFound();
            }

            return Tarefa;
        }

        [HttpPost]
        public ActionResult<Tarefa> Create(Tarefa tarefa)
        {
            //tarefa.DataCadastro = DateTime.Now;
            _tarefaRepository.Create(tarefa);

            return CreatedAtRoute("GetTarefa", new { id = tarefa.IdTarefa.ToString() }, tarefa);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Tarefa TarefaIn)
        {
            var Tarefa = _tarefaRepository.Get(id);

            if (Tarefa == null)
            {
                return NotFound();
            }

            _tarefaRepository.Update(id, TarefaIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var Tarefa = _tarefaRepository.Get(id);

            if (Tarefa == null)
            {
                return NotFound();
            }

            _tarefaRepository.Remove(Tarefa.IdTarefa);

            return NoContent();
        }
    }
}
  