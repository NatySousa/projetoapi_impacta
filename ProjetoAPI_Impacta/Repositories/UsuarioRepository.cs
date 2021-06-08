using MongoDB.Driver;
using ProjetoAPI_Impacta.Entities;
using ProjetoAPI_Impacta.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI_Impacta.Repositories
{
    public class UsuarioRepository
    {

        private readonly IMongoCollection<Usuario> _usuarios;

        public UsuarioRepository (IUsuarioSettingsMongo settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _usuarios = database.GetCollection<Usuario>(settings.UsuarioCollectionName);
        }

        public List<Usuario> Get() =>
            _usuarios.Find(Usuario => true).ToList();

        public Usuario Get(string id) =>
            _usuarios.Find<Usuario>(usuario => usuario.IdUsuario == id).FirstOrDefault();

        public Usuario Create(Usuario usuario)
        {
            _usuarios.InsertOne(usuario);
            return usuario;
        }

        public void Update(string id, Usuario usuario) =>
            _usuarios.ReplaceOne(_usuario => _usuario.IdUsuario == id, usuario);

        public void Remove(string id) =>
            _usuarios.DeleteOne(usuario => usuario.IdUsuario == id);
    }
}

  