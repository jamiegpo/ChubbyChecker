using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace myClassLibrary
{
    public class myTreeView
    {

        List<Node> _groupNodeList = new List<Node>();

        //public List<GroupNode> GetTreeViewToList (TreeView _treeview)
        public List<Node> GetTreeViewToList(TreeView treeview, List<LdapGroup> ldapGroupList)
        {
            //List<Node> _groupNodeList = new List<Node>();

            var root = treeview.Nodes[0];
            Node _rootNode = new Node() { Name = root.Name, NodePath = root.FullPath, NodeType = NodeType.RootUser};
            _groupNodeList.Add(_rootNode);
            
            foreach (TreeNode _node in treeview.Nodes[0].Nodes)
            {
                Node _thisNode = new Node() { Name = _node.Name, NodePath = _node.FullPath, NodeType = NodeType.Group, Checked = _node.Checked };
                _groupNodeList.Add(_thisNode);

                if (_node.Nodes.Count != 0)
                {
                    foreach (TreeNode _treeNode in _node.Nodes)
                    {
                        RecurseNode(_treeNode, ldapGroupList);
                    }  
                }
            }

            return _groupNodeList;

        }

        private void RecurseNode (TreeNode treeNode, List<LdapGroup> ldapGroupList)
        {
            Node _thisNode = new Node() { Name = treeNode.Name, NodePath = treeNode.FullPath, NodeType = NodeType.Group, Checked = treeNode.Checked };
            _groupNodeList.Add(_thisNode);

            if (treeNode.Nodes.Count != 0)
            {
                foreach (TreeNode _treeNode in treeNode.Nodes)
                {
                    RecurseNode(_treeNode, ldapGroupList);
                }
            }

        }

        private string GetGroupNameFromNode (string nodeName)
        {
            string _regex = @"\s\(\d+\s+\d+\)";
            string _return = Regex.Replace(nodeName, _regex, "");
            return _return;
        }
    }

    public class Node
    {
        public string Name { get; set; }
        public NodeType NodeType { get; set; }
        public string NodePath { get; set; }
        public bool Checked { get; set; }
    }

    public enum NodeType
    {
        RootUser = 1,
        Group = 2
    }
}
