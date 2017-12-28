using System;

namespace BlockchainDemo.Models
{
    /// <summary>
    /// Block model
    /// </summary>
    public class Block
    {
        /// <summary>
        /// Conctructor
        /// </summary>
        /// <param name="index">Block index</param>
        /// <param name="confirmNumber">Block confirm number</param>
        /// <param name="previousHash">Previous block hash</param>
        /// <param name="timestamp">Block timestamp</param>
        /// <param name="data">Block data</param>
        /// <param name="hash">Block hash</param>
        public Block(long index, long confirmNumber, string previousHash, long timestamp, string data, string hash)
        {
            Index = index;
            PreviousHash = previousHash;
            Hash = hash;
            Data = data;
            Timestamp = timestamp;
            ConfirmNumber = confirmNumber;
        }

        /// <summary>
        /// Block index
        /// </summary>
        public long Index { get; }

        /// <summary>
        /// Previous block hash
        /// </summary>
        public string PreviousHash { get; }

        /// <summary>
        /// Block hash, used as block UID
        /// </summary>
        public string Hash { get; }

        /// <summary>
        /// Block data.
        /// Type can be changed to any, f.e. to array of transactions or some single event
        /// </summary>
        public string Data { get; }

        /// <summary>
        /// Block timestamp
        /// </summary>
        public long Timestamp { get; }

        /// <summary>
        /// Block confirm number
        /// </summary>
        public long ConfirmNumber { get; }
    }
}
