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
            //Run for every character in the string
            foreach(char c in item)
            {
                //Grab the numerical representation of the current letter to check for
                value = GetValue(c);
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
            //Run for every character in the string
            foreach (char c in item)
            {
                Console.Write(c + "->");
                //If the node representing the next letter in the sequence doesn't exist, the word doesn't exist in the trie
                if (node[GetValue(c)] == null)
                {
                    Console.Write("Doesn't Exist\n");
                    return false;
                }
                //Grabs the node that represents the next letter in the sequence
                node = node[GetValue(c)];
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

        /// <summary>
        /// Gets a list of all words with a given prefix in the trie
        /// </summary>
        /// <param name="prefix">The prefix to search for</param>
        /// <returns>The list of words with the given prefix</returns>
        public List<string> GetAllWithPrefix(string prefix)
        {
            //Starts tracing the prefix at the head node
            TrieNode node = head;
            //Turns the item lowercase for simplicity
            prefix = prefix.ToLower();
            //Run for every character in the prefix
            foreach (char c in prefix)
            {
                //If the node representing the next letter in the sequence doesn't exist, the prefix doesn't exist in the trie
                if (node[GetValue(c)] == null)
                {
                    return new List<string>() { "No words with this prefix exist in the given trie." };
                }
                //Grabs the node that represents the next letter in the sequence
                node = node[GetValue(c)];
            }
            //Grabs the list of all valid words beyond this in the trie
            List<string> children = GetAllValidChildren(node, prefix);
            //If there are no valid words after the search, let the player know
            if(children.Count == 0)
                children.Add("No words with this prefix exist in the given trie.");
            return children;
        }

        /// <summary>
        /// Gets all the valid words that are linked to a given node
        /// </summary>
        /// <param name="node">The node to search from</param>
        /// <param name="start">What this node represents in the overall tree</param>
        /// <returns>The list of words beyond this node in the trie</returns>
        private List<string> GetAllValidChildren(TrieNode node, string start)
        {
            List<string> list = new List<string>();
            //Checks this word's node to see if it is a valid word end
            if (node.valid)
                list.Add(start);
            //For each node in this one's array
            for(int i = 0; i < 26; i++)
            {
                if(node[i] != null)
                {
                    //Calls this function for all of this node's children and adds what it returns to the master list
                    List<string> children = GetAllValidChildren(node[i], start + GetChar(i));
                    foreach (string s in children)
                    {
                        list.Add(s);
                    }
                }
            }
            return list;
        }
        
        /// <summary>
        /// Translates a lower-case letter into an integer representation in the range 0-25
        /// </summary>
        /// <param name="c">The character to translate</param>
        /// <returns>An integer between 0-25 inclusive</returns>
        public static int GetValue(char c)
        {
            return c - 97;
        }

        /// <summary>
        /// Translates a number in the range 0-25 back into its character equivalent
        /// </summary>
        /// <param name="i">The integer to translate</param>
        /// <returns>A character in the range a-z</returns>
        public static char GetChar(int i)
        {
            return (char)(i + 97);
        }
    }
}
