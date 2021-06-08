using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI_Impacta.Interfaces
{
    public interface IUsuarioSettingsMongo
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string UsuarioCollectionName { get; set; }

    }
}
