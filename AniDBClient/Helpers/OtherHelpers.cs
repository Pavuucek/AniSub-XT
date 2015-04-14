using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AniDBClient.Helpers
{
    public static class OtherHelpers
    {
        //Přidání uzlu
        public static TreeNode AddNode(TreeNode node, string key, string key2, bool key3)
        {
            if (key3)
            {
                if (node.Nodes.ContainsKey(key2))
                {
                    return node.Nodes[key2];
                }
                else
                {
                    return node.Nodes.Add(key2, key);
                }
            }
            else
            {
                if (node.Nodes.ContainsKey(key))
                {
                    return node.Nodes[key];
                }
                else
                {
                    return node.Nodes.Add(key, key);
                }
            }
        }
    }
}
