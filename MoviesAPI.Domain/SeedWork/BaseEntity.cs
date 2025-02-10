using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MoviesAPI.Domain.SeedWork
{
    /// <summary>
    /// Representa a entidade base para todas as entidades do domínio, fornecendo um identificador único.
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Obtém ou define o identificador único da entidade.
        /// No MongoDB, este campo é usado como o _id e armazenado como uma string legível.
        /// </summary>
        [BsonId] // Indica que esse campo será usado como _id no MongoDB
        [BsonRepresentation(BsonType.String)] // Armazena o GUID como string no MongoDB para evitar problemas de conversão
        public Guid Id { get; protected set; }

        /// <summary>
        /// Nome da entidade.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Inicializa uma nova instância da entidade base com um identificador único.
        /// </summary>
        protected BaseEntity() => Id = Guid.NewGuid();
    }
}
