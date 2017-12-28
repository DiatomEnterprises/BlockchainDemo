using System;

namespace BlockchainDemo.Helpers
{
    /// <summary>
    /// Confirmation helper
    /// </summary>
    public static class Confirmation
    {
        /// <summary>
        /// Find confirmation number for block hash
        /// </summary>
        /// <param name="hash">Block hash</param>
        /// <returns>Confirmation number</returns>
        public static long FindConfirmNumber(string hash)
        {
            long n = 0;
            while (!IsConfirmNumberValid(hash, n))
            {
                n++;
            }
            return n;
        }

        /// <summary>
        /// Check if confirmation number is valid
        /// </summary>
        /// <param name="hash">Block hash</param>
        /// <param name="n">Confirmation numbe</param>
        /// <returns>True if confirmation number is valid</returns>
        public static bool IsConfirmNumberValid(string hash, long n)
        {
            //
            return Hash.GetHash(hash + n.ToString()).Substring(0, 4) == "0000";
        }
    }
}
