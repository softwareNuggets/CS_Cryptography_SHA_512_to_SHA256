using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DigitalSignatureMaker
{
    internal class OneWayEncyption
    {
        public string Sha512(string text)
        {
            if (text.Trim().Length > 0)
            {
                using (SHA512 s512 = SHA512.Create())
                {
                    string hash = GetHash(s512, text);

                    if (VerifyHash(s512, text, hash))
                    {
                        return (hash);
                    }
                }
            }

            return "no value";
        }

        public string Sha384(string text)
        {
            if (text.Trim().Length > 0)
            {
                using (SHA384 s384 = SHA384.Create())
                {
                    string hash = GetHash(s384, text);

                    if (VerifyHash(s384, text, hash))
                    {
                        return (hash);
                    }
                }
            }

            return "no value";
        }

        public string Sha256(string text)
        {
            if (text.Trim().Length > 0)
            {
                using (SHA256 s256 = SHA256.Create())
                {
                    string hash = GetHash(s256, text);

                    if (VerifyHash(s256, text, hash))
                    {
                        return (hash);
                    }
                }

            }

            return "no value";
        }

        private string GetHash(HashAlgorithm hashAlgorithm, string text)
        {

            byte[] bytes = Encoding.ASCII.GetBytes(text);
            byte[] data = hashAlgorithm.ComputeHash(bytes);

            var sb = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sb.Append($"{data[i]:x2}");
                //sb.Append(string.Format("{0:x2}",data[i]));
            }

            return sb.ToString();
        }

        private bool VerifyHash(HashAlgorithm hashAlgorithm, string text, string hash)
        {
            // Hash the input.
            var hashOfInput = GetHash(hashAlgorithm, text);

            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return comparer.Compare(hashOfInput, hash) == 0;
        }

    }

}
