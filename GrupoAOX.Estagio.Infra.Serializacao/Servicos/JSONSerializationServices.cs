using GrupoAox.Estagio.Domain.Interfaces.Servicos;
using Newtonsoft.Json;

namespace GrupoAOX.Estagio.Infra.Serializacao.Servicos
{
    public class JSONSerializationServices<T> : IEntitySerializationServices<T>
        where T : class
    {
        public T Deserialize(string text)
        {
            return JsonConvert.DeserializeObject<T>(text,
              new JsonSerializerSettings()
              {
                  ContractResolver = new AllPropertiesResolver(),
                  ReferenceLoopHandling = ReferenceLoopHandling.Ignore
              });
        }

        public string Serialize(T entity)
        {
            return JsonConvert.SerializeObject(entity,
               new JsonSerializerSettings()
               {
                   ContractResolver = new AllPropertiesResolver(),
                   ReferenceLoopHandling = ReferenceLoopHandling.Ignore
               });
        }
    }
}
