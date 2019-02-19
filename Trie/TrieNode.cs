using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trie
{
    class TrieNode
    {
        //The child nodes of this node, representing a-z
        TrieNode[] next = new TrieNode[26];
        //Whether or not ending a search on this node signifies a valid word
        public bool valid;

        public TrieNode this[int key]
        {
            get
            {
                return next[key];
            }

            set
            {
                next[key] = value;
            }
        }

        public TrieNode(bool valid = false){
            this.valid = valid;
        }
    }
}
