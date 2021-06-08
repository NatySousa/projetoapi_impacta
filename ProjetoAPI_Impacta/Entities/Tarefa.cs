using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI_Impacta.Entities
{
    public class Tarefa
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string IdTarefa { get; set; }

        public string Descricao { get; set; }
        public bool Realizado { get; set; }
        public DateTime DataCadastro { get; set; }

    }
}
