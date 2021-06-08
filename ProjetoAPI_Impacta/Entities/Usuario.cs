using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI_Impacta.Entities
{
    public class Usuario
    { 
        
            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string IdUsuario { get; set; }
            public string Nome { get; set; }
            public string Email { get; set; }
            public string Permissao { get; set; }
            public string Senha { get; set; }
        
    }
}
