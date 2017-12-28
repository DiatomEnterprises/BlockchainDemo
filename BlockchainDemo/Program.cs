using BlockchainDemo.Managers;
using System;

namespace BlockchainDemo
{
    /// <summary>
    /// Main class
    /// </summary>
    public sealed class Program
    {
        /// <summary>
        /// Main function
        /// </summary>
        public static void Main()
        {
            //generate block1
            var block1 = BlockchainManager.GenerateNextBlock("test1");
            Console.WriteLine($"Block {block1.Hash} generated with data \"{block1.Data}\"");

            //generate block2
            var block2 = BlockchainManager.GenerateNextBlock("test2");
            Console.WriteLine($"Block {block2.Hash} generated with data \"{block2.Data}\"");

            //dump and output all data
            var allBlocks = BlockchainManager.DumpBlockchain();
            Console.WriteLine();
            Console.WriteLine("Dump:");
            foreach (var b in allBlocks)
            {
                Console.WriteLine($"{b.Hash}: \"{b.Data}\"");
            }

            Console.ReadLine();
        }
    }
}
