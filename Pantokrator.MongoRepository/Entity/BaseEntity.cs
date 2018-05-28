using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Pantokrator.MongoRepository.Entity
{

    [BsonIgnoreExtraElements(Inherited = true)]
    public abstract class BaseEntity : IEntity
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public virtual string Id { get; set; }
    }
}