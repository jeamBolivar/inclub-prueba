namespace CompraAPI.Interfaces
{
    public interface IPasswordHasher
    {
        string Hash(string password);
    }
}