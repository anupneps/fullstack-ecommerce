using AutoMapper;
using System.Text;

namespace backend.src.Helpers
{
    public class StringToByteArrayConverter : ITypeConverter<string, byte[]>
    {
        public byte[] Convert(string source, byte[] destination, ResolutionContext context)
        {
            if(string.IsNullOrEmpty(source)) { return null!; }
            return Encoding.UTF8.GetBytes(source);
        }
    }
}
