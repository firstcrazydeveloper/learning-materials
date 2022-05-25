using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CodingInterview.Helper.Trie;

namespace CodingInterview.Interview
{
    public class Trie
    {
        public Node Root;
        public TrieNode trieRoot;

        public Trie()
        {
            this.Root = new Node();
            this.trieRoot = new TrieNode((char)0);
        }

        public void Insert(string key)
        {
            Node trieCrawl = Root;

            for (int level = 0; level < key.Length; level++)
            {
                int index = key.ElementAt(level) - 'a';

                if (trieCrawl.children[index] == null)
                    trieCrawl.children[index] = new Node();
                trieCrawl = trieCrawl.children[index];
            }

            trieCrawl.IsLeaf = true;
        }

        public bool Search(string key)
        {
            Node trieCrawl = Root;
            for (int level = 0; level < key.Length; level++)
            {
                int index = key.ElementAt(level) - 'a';

                if (trieCrawl.children[index] == null)
                    return false;

                trieCrawl = trieCrawl.children[index];
            }

            return (trieCrawl != null && trieCrawl.IsLeaf);

        }

        public void TrieInsert(string word)
        {
            var crawl = this.trieRoot;
            for (int i = 0; i < word.Length; i++)
            {
                Dictionary<char, TrieNode> child = crawl.GetChildren();
                char c = word.ElementAt(i);
                if (child.ContainsKey(c))
                    crawl = child[c];
                else
                {
                    TrieNode tempNode = new TrieNode(c);
                    child.Add(c, new TrieNode());
                    child[c] = tempNode;
                    
                    crawl = tempNode;
                }

            }

            crawl.SetIsEnd(true);
        }

        public string GetMatchingPrefix(string input)
        {
            string result = string.Empty;
            TrieNode crawl = this.trieRoot;
            int prevMatch = 0;

            for (int i = 0; i < input.Length; i++)
            {
                char c = input.ElementAt(i);
                Dictionary<char, TrieNode> child = crawl.GetChildren();

                if (child.ContainsKey(c))
                {
                    result = result + c;
                    crawl = child[c];

                    if (crawl.IsEnd())
                        prevMatch = i + 1;
                }
                else
                    break;

            }

            if (!crawl.IsEnd())
                return result.Substring(0, prevMatch);
            else
                return result;
        }
    }

}
