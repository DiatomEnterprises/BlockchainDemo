using System;
using System.Security.Cryptography;
using System.Text;

namespace BlockchainDemo.Helpers
{
    /// <summary>
    /// Hash helper
    /// </summary>
    public static class Hash
    {
        /// <summary>
        /// Calculate hash for confirmation number and block hash
        /// </summary>
        /// <param name="number">Confirmation number</param>
        /// <param name="hash">Block hash</param>
        /// <returns>SHA256 hash</returns>
        public static string GetHash(long number, string hash)
        {
            return GetHash(number.ToString() + hash);
        }

        /// <summary>
        /// Calculate hash for block
        /// </summary>
        /// <param name="index">Block index</param>
        /// <param name="previousHash">Previous block hash</param>
        /// <param name="timestamp">Block timestamp</param>
        /// <param name="data">Block data</param>
        /// <returns>SHA256 hash</returns>
        public static string GetHash(long index, string previousHash, long timestamp, string data)
        {
            return GetHash(index.ToString() + previousHash + timestamp + data);
        }

        /// <summary>
        /// Calculate hash for string
        /// </summary>
        /// <param name="src">Input string</param>
        /// <returns>SHA256 hash</returns>
        public static string GetHash(string src)
        {
            using (var crypt = new SHA256Managed())
            {
                var hash = new StringBuilder();
                byte[] bytes = crypt.ComputeHash(Encoding.UTF8.GetBytes(src), 0, Encoding.UTF8.GetByteCount(src));
                foreach (byte b in bytes)
                {
                    hash.Append(b.ToString("x2"));
                }
                return hash.ToString();
            }
        }
    }
}
