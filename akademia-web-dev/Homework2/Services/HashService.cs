namespace akademia_web_dev.Services
{
    public class HashService
    {
        private readonly HashidsNet.Hashids _hashIds = new HashidsNet.Hashids(minHashLength: 5);

        public string GenerateHash(int urlId)
        {
            return _hashIds.Encode(urlId);
        }
    }
}
