namespace API.Application_.Abstractions.Storage;

public interface IStorageService : IStorage
{
    public string StorageName { get; }
}