namespace GrupoAox.Estagio.Domain.Interfaces.Servicos
{
    public interface IEntitySerializationServices<T>
        where T : class
    {
        T Deserialize(string text);
        string Serialize(T entity);
    }
}
