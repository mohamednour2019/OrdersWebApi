using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SharedHelpers.DatabaseHelpers
{
    public static class IndexGenerationHelper
    {
        public static int GetRepresentativeId(Guid guid1, Guid guid2)
        {
            // Concatenate the GUID strings
            string combinedGuids = guid1.ToString() + guid2.ToString();

            // Calculate the SHA256 hash
            byte[] hashBytes;
            using (SHA256 sha256 = SHA256.Create())
            {
                hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(combinedGuids));
            }

            // Convert the hash to an integer
            int representativeNumber = BitConverter.ToInt32(hashBytes, 0);

            return representativeNumber;
        }

        public static int GetRepresentativeId(Guid guid)
        {
            // Concatenate the GUID strings
            string combinedGuids = guid.ToString();

            // Calculate the SHA256 hash
            byte[] hashBytes;
            using (SHA256 sha256 = SHA256.Create())
            {
                hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(combinedGuids));
            }

            // Convert the hash to an integer
            int representativeNumber = BitConverter.ToInt32(hashBytes, 0);

            return representativeNumber;
        }
    }
}
