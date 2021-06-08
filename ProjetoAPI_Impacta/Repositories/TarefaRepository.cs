using MongoDB.Driver;
using ProjetoAPI_Impacta.Entities;
using ProjetoAPI_Impacta.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI_Impacta.Repositories
{
    public class TarefaRepository
    {

        private readonly IMongoCollection<Tarefa> _tarefas;

        public TarefaRepository(ITarefaSettingsMongo settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _tarefas = database.GetCollection<Tarefa>(settings.TarefaCollectionName);
        }

        public List<Tarefa> Get() =>
            _tarefas.Find(Tarefa => true).ToList();

        public Tarefa Get(string id) =>
            _tarefas.Find<Tarefa>(Tarefa => Tarefa.IdTarefa == id).FirstOrDefault();

        public Tarefa Create(Tarefa tarefa)
        {
            _tarefas.InsertOne(tarefa);
            return tarefa;
        }

        public void Update(string id, Tarefa tarefa) =>
            _tarefas.ReplaceOne(Tarefa => Tarefa.IdTarefa == id, tarefa);

        public void Remove(string id) =>
            _tarefas.DeleteOne(Tarefa => Tarefa.IdTarefa == id);
    }
}

   