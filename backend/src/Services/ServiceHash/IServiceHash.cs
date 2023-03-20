namespace backend.src.Services.ServiceHash
{
    public interface IServiceHash
    {
        void CreateHashData(string input, out byte[] inputHash, out byte[] inputSalt);
        bool CompareHashData(string input, byte[] inputHash, byte[] inputSalt);
    }
}
