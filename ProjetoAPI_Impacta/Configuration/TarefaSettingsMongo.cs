using ProjetoAPI_Impacta.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoAPI_Impacta.Configuration
{
    public class TarefaSettingsMongo : ITarefaSettingsMongo
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string TarefaCollectionName { get; set; }
    }
}
