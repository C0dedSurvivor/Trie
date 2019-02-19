using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//List of Words from:
//https://github.com/dwyl/english-words/blob/master/words_alpha.txt

namespace Trie
{
    class Program
    {
        static void Main(string[] args)
        {
            Trie MyTrie = new Trie();
            string line;
            StreamReader file = new StreamReader("words.txt");
            //Grabs the words one by one from words.txt and adds them to the trie
            while ((line = file.ReadLine()) != null)
            {
                MyTrie.AddItem(line);
            }
            file.Close();

            Console.WriteLine("Finished Loading.\nEnter a word to search or /q to quit");
            string input = Console.ReadLine();
            while(input != "/q"){
                //Makes sure the input is only letters, which is the only valid format for this trie
                if (input.All(char.IsLetter))
                {
                    //Checks if the trie contains the given value and outputs the result
                    Console.WriteLine("Does the trie contain " + input + ": " + MyTrie.Contains(input));
                }
                else
                    Console.WriteLine("Invalid input, this trie only supports the basic english alphabet.");
                Console.WriteLine("Enter a word to search or /q to quit");
                input = Console.ReadLine();
            }
        }
    }
}
