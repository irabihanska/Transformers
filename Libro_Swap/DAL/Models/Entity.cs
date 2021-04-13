using DAL.Interfaces;

namespace DAL.Models
{
    public abstract class Entity : IEntity
    {
        public int Id { get; set; }
    }
}