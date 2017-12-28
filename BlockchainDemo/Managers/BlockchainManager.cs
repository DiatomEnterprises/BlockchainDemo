using BlockchainDemo.Helpers;
using BlockchainDemo.Models;
using System;
using System.Linq;

namespace BlockchainDemo.Managers
{
    /// <summary>
    /// Blockchain manager
    /// </summary>
    public static class BlockchainManager
    {
        /// <summary>
        /// Blockchain database
        /// </summary>
        private static Blockchain Database { get; }

        /// <summary>
        /// Lock block generation
        /// </summary>
        private static object Lock1 = new object();

        /// <summary>
        /// Lock block add
        /// </summary>
        private static object Lock2 = new object();

        /// <summary>
        /// Static constructor
        /// </summary>
        static BlockchainManager()
        {
            Database = new Blockchain();
        }

        /// <summary>
        /// Get last block
        /// </summary>
        /// <returns>Last block</returns>
        public static Block GetLastBlock()
        {
            return Database.GetLastBlock();
        }

        /// <summary>
        /// Get last block by hash
        /// </summary>
        /// <returns>Block</returns>
        public static Block GetBlock(string hash)
        {
            return Database.GetBlock(hash);
        }

        /// <summary>
        /// Generate new confirmed block
        /// </summary>
        /// <param name="data">Input data</param>
        /// <returns>Block</returns>
        public static Block GenerateNextBlock(string data)
        {
            lock (Lock1)
            {
                var previousBlock = GetLastBlock();
                var nextIndex = previousBlock.Index + 1;
                var nextTimestamp = DateTime.Now.Ticks;
                var nextHash = Hash.GetHash(nextIndex, previousBlock.Hash, nextTimestamp, data);
                var nextConfirmNumber = Confirmation.FindConfirmNumber(nextHash);
                var block = new Block(nextIndex, nextConfirmNumber, previousBlock.Hash, nextTimestamp, data, nextHash);
                AddNewBlock(block);
                return block;
            }
        }

        /// <summary>
        /// Validate and add new block
        /// </summary>
        /// <param name="block">Block</param>
        /// <returns>True if block is valid</returns>
        public static bool AddNewBlock(Block block)
        {
            lock (Lock2)
            {
                if (IsBlockValid(block))
                {
                    Database.AddBlock(block);
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Check if block is valid
        /// </summary>
        /// <param name="block">Block</param>
        /// <returns>True if block is valid</returns>
        public static bool IsBlockValid(Block block)
        {
            var previousBlock = GetBlock(block.PreviousHash);
            return previousBlock != null && previousBlock.Hash == block.PreviousHash && previousBlock.Index + 1 == block.Index
                && Database.Database.All(b => b.Index != block.Index)
                && Hash.GetHash(block.Index, previousBlock.Hash, block.Timestamp, block.Data) == block.Hash
                && Confirmation.IsConfirmNumberValid(block.Hash, block.ConfirmNumber);
        }

        /// <summary>
        /// Dump blockchain
        /// </summary>
        /// <returns>Array or blocks</returns>
        public static Block[] DumpBlockchain()
        {
            return Database.Database
                .Select(b => new Block(b.Index, b.ConfirmNumber, b.PreviousHash, b.Timestamp, b.Data, b.Hash))
                .ToArray();
        }
    }
}
