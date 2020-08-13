using MongoDB.Bson.Serialization.Attributes;
using System.Runtime.Serialization;

namespace InternetTeams.Domain.Entities
{
    public abstract class Entity
    {
        [BsonId]
        [DataMember]
        public MongoDB.Bson.ObjectId _id { get; set; }
    }
}
