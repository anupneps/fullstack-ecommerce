namespace backend.src.Services.ServiceHash
{
    public class ServiceHash : IServiceHash
    {
        public bool CompareHashData(string input, byte[] inputHash, byte[] inputSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(inputSalt))
            {
                var computedInput = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input));
                return computedInput.SequenceEqual(inputHash);
            }
        }

        public void CreateHashData(string input, out byte[] inputHash, out byte[] inputSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                inputHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(input));
                inputSalt = hmac.Key;
            }
        }
    }
}
