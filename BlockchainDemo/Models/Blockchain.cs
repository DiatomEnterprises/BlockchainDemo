using BlockchainDemo.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BlockchainDemo.Models
{
    /// <summary>
    /// Blockchain database model
    /// </summary>
    public class Blockchain
    {
        /// <summary>
        /// Conctructor
        /// </summary>
        public Blockchain()
        {
            Database = new List<Block>();
            Database.Add(GenerateGenesisBlock());
        }

        /// <summary>
        /// Generate first block in chain
        /// </summary>
        /// <returns>Genesis block</returns>
        private Block GenerateGenesisBlock()
        {
            var firstIndex = 0;
            var firstTimestamp = DateTime.Now.Ticks;
            var zeroHash = Hash.GetHash("0");
            var firstData = "Genesis Block";
            var firstHash = Hash.GetHash(firstIndex, zeroHash, firstTimestamp, firstData);
            var firstConfirmNumber = Confirmation.FindConfirmNumber(firstHash);
            var genesisBlock = new Block(firstIndex, firstConfirmNumber, zeroHash, firstTimestamp, firstData, firstHash);
            return genesisBlock;
        }

        /// <summary>
        /// Blockchain database
        /// </summary>
        public List<Block> Database { get; }

        /// <summary>
        /// Get last block
        /// </summary>
        /// <returns>Last block</returns>
        public Block GetLastBlock()
        {
            return Database.Last();
        }

        /// <summary>
        /// Get last block by hash
        /// </summary>
        /// <returns>Block</returns>
        public Block GetBlock(string hash)
        {
            return Database.FirstOrDefault(b => b.Hash == hash);
        }

        /// <summary>
        /// Add new block
        /// </summary>
        /// <param name="block">Block</param>
        public void AddBlock(Block block)
        {
            Database.Add(block);
        }
    }
}
