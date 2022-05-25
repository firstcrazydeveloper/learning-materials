using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingInterview.Helper.Trie
{
    public class Node
    {
        public int Length { get; set; }
        public Node[] children;
        public bool IsLeaf { get; set; }

        public Node()
        {
            this.IsLeaf = false;
            this.Length = 26;
            children = new Node[this.Length];
            for (int i = 0; i < this.Length; i++)
            {
                children[i] = null;
            }
        }
    }

    public class TrieNode
    {
        char Value;
        bool isEnd;
        Dictionary<char, TrieNode> Children;

        public TrieNode()
        {

        }
        public TrieNode(char ch)
        {
            this.Value = ch;
            this.isEnd = false;
            this.Children = new Dictionary<char, TrieNode>();
        }

        public Dictionary<char, TrieNode> GetChildren()
        {
            return this.Children;
        }

        public char GetValue()
        {
            return this.Value;
        }

        public void SetIsEnd(bool isEnd)
        {
            this.isEnd = isEnd;
        }

        public bool IsEnd()
        {
            return this.isEnd;
        }
    }
}
