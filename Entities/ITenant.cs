namespace Entities;

public interface ITenant : IEntity
{
    bool IsWhitelisted { get; set; }
}

