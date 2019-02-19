# Trie
A trie data structure that stores and searches through a 10000 word dictionary

## How It Works
A trie has a similar structure to a tree, with nodes storing the data and a separate class storing all of the nodes along with the add and searching function. <br />
The node itself stores two pieces of data:
* A boolean value
* An array of 26 other trie nodes <br />

The boolean value tells the search function whether this node marks the end of a valid word if the search ends on it. <br />
The array represents the valid next letters that can be moved to from this one <br /> <br />
The trie class contains the head trie node and 3 functions

* AddItem: Adds a given string to the trie
* Contains: Checks to see if the trie contains a given string
* GetValue: Translates a given lowercase letter into a corresponding number between 0 and 25

### Adding a new item
Starting at the head node, translates each letter of the word into an integer using GetValue and checks to see if the node at that index in that trie node's array. <br />
If it doesn't, creates a new node at the given index. <br />
It then goes to the node at the index and does the same check again for the next letter in the word. <br />
Once it can created all the necessary nodes, it marks the final node it ends on as valid to show that it is the ending letter of a valid word. <br />

### Searching for an item
Starting at the head node, translates each letter of the word into an integer using GetValue and tries to access that index in that trie node's array. <br />
If there is a valid trie node there it goes to that node and checks for the next letter. <br />
If there is not a valid trie node there then the word doesn't exist in the trie. <br /> <br />
If the search gets to the last letter of the word successfully it checks the boolean value contained in the last trie node. <br />
The word exists in this trie if the boolean is set to true.

### GetValue
Takes the integer representation of the character (97 to 122 for the lowercase alphabet) and subtracts 97 from it to get a value range starting at zero.
