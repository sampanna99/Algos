using System;
using System.Collections.Generic;
using System.Text;

namespace testingreferenceandvalue.Algos
{
    public class NormalBstToBalancedBST
    {
        void Main()
        {
            BinaryTree tree = new BinaryTree();
            tree.root = new Node(10);
            tree.root.left = new Node(8);
            tree.root.left.left = new Node(7);
            tree.root.left.left.left = new Node(6);
            tree.root.left.left.left.left = new Node(5);

            //tree.root = tree.buildTree(tree.root);
        }

        public virtual Node buildTreeUtil(List<Node> nodes, int start, int end)
        {
            // base case
            if (start > end)
            {
                return null;
            }

            /* Get the middle element and make it root */
            int mid = (start + end) / 2;
            Node node = nodes[mid];

            /* Using index in Inorder traversal, construct
               left and right subtress */
            node.left = buildTreeUtil(nodes, start, mid - 1);
            node.right = buildTreeUtil(nodes, mid + 1, end);

            return node;
        }

        public virtual Node buildTree(Node root)
        {
            // Store nodes of given BST in sorted order
            List<Node> nodes = new List<Node>();
            storeBSTNodes(root, nodes);

            // Constructs BST from nodes[]
            int n = nodes.Count;
            return buildTreeUtil(nodes, 0, n - 1);
        }

        public virtual void storeBSTNodes(Node root, List<Node> nodes)
        {
            // Base case
            if (root == null)
            {
                return;
            }

            // Store nodes in Inorder (which is sorted
            // order for BST)
            storeBSTNodes(root.left, nodes);
            nodes.Add(root);
            storeBSTNodes(root.right, nodes);
        }

    }

    public class Node
    {
        public int data;
        public Node left, right;

        public Node(int data)
        {
            this.data = data;
            left = right = null;
        }
    }

    public class BinaryTree
    {
        public Node root;

        /* This function traverse the skewed binary tree and
           stores its nodes pointers in vector nodes[] */
        public virtual void storeBSTNodes(Node root, List<Node> nodes)
        {
            // Base case
            if (root == null)
            {
                return;
            }

            // Store nodes in Inorder (which is sorted
            // order for BST)
            storeBSTNodes(root.left, nodes);
            nodes.Add(root);
            storeBSTNodes(root.right, nodes);
        }
    }
}
