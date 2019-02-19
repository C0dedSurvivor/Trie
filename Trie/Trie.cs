using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trie
{
    class Trie
    {
        //The starting node for the trie, all others branch off of this
        TrieNode head = new TrieNode();

        public Trie() { }

        /// <summary>
        /// Adds a new word to the trie, including any intermediary storage necessary
        /// </summary>
        /// <param name="item">The word to be added</param>
        public void AddItem(string item)
        {
            //Starts tracing the word at the head node
            TrieNode node = head;
            //Turns the item lowercase for simplicity
            item = item.ToLower();
            //Stores the numerical representation of the current letter to check for
            int value;
            //Run for every character in the string except the last one
            for(int place = 0; place < item.Length; place++)
            {
                //Grab the numerical representation of the current letter to check for
                value = GetValue(item[place]);
                //If the node that represents the next letter in the sequence doesn't exist, create it
                if (node[value] == null)
                    node[value] = new TrieNode();
                //Go to the next node in the sequence
                node = node[value];
            }
            //Marks the final node as a valid word ending
            //Marking it as valid says that if a search ends on this node the word you were searching for is a valid word
            node.valid = true;
        }

        /// <summary>
        /// Checks to see if a given word exists in the trie
        /// </summary>
        /// <param name="item">Word to check for</param>
        /// <returns>Returns whether or not the word exists in the trie</returns>
        public bool Contains(string item)
        {
            //Starts tracing the word at the head node
            TrieNode node = head;
            //Turns the item lowercase for simplicity
            item = item.ToLower();
            //Run for every character in the string except the last one
            for (int place = 0; place < item.Length; place++)
            {
                Console.Write(item[place] + "->");
                //If the node representing the next letter in the sequence doesn't exist, the word doesn't exist in the trie
                if (node[GetValue(item[place])] == null)
                {
                    Console.Write("Doesn't Exist\n");
                    return false;
                }
                //Grabs the node that represents the next letter in the sequence
                node = node[GetValue(item[place])];
            }
            //Checks the final letter's node to see if it is a valid word end
            if (node.valid)
            {
                Console.Write("Exists\n");
                return true;
            }
            //If the final node isn't valid
            Console.Write("Doesn't Exist\n");
            return false;
        }

        //Translates a lower-case letter into an integer representation in the range 0-25
        public static int GetValue(char c)
        {
            return c - 97;
        }
    }
}
