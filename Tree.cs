using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPractise
{
    internal class Tree
    {
        class Node
        {
            public Node? LtNode { get; set; }
            public Node? RtNode { get; set; }
            public int Data { get; set; }
        }

        class BinaryTree
        {
            public Node? Root { get; set; }

            public bool Insert(int value)
            {
                Node before = null, after = this.Root;

                while (after != null)
                {
                    before = after;

                    if (value < after.Data) //Is new node in left tree?
                        after = after.LtNode;
                    else if (value > after.Data) //Is new node in right tree?
                        after = after.RtNode;
                    else //Exist same value
                        return false;
                }

                Node newNode = new Node();
                newNode.Data = value;
                if (this.Root == null) //Tree is empty
                    this.Root = newNode;
                else
                {
                    if (value < before.Data)
                        before.LtNode = newNode;
                    else
                        before.RtNode = newNode;
                }

                return true;
            }

            public Node Search(int value)
            {
                return this.Search(value, this.Root);
            }

            public void Delete(int value)
            {
                this.Root = Delete(this.Root, value);
            }

            private Node Delete(Node parent, int key)
            {

                if (parent == null) return parent;

                if (key < parent.Data) parent.LtNode = Delete(parent.LtNode, key);
                else if (key > parent.Data)

                    parent.RtNode = Delete(parent.RtNode, key);

                // if the value is the same as the parent's value, then this node is to be deleted  

                else

                {

                    // the node with one or no child  

                    if (parent.LtNode == null)

                        return parent.RtNode;

                    else if (parent.RtNode == null)

                        return parent.LtNode;

                    // node with two children: Get the inorder successor (smallest in the right subtree)  

                    parent.Data = MinValue(parent.RtNode);

                    // Delete the inorder successor  

                    parent.RtNode = Delete(parent.RtNode, parent.Data);

                }

                return parent;

            }

            private int MinValue(Node node)
            {
                int minv = node.Data;
                while (node.LtNode != null)
                {
                    minv = node.LtNode.Data;
                    node = node.LtNode;
                }

                return minv;
            }

            private Node Search(int value, Node parent)
            {
                if (parent != null)
                {
                    if (value == parent.Data) return parent;

                    if (value < parent.Data)
                        return Search(value, parent.LtNode);
                    else
                        return Search(value, parent.RtNode);
                }

                return null;
            }

            public int GetDepth()
            {
                return this.GetDepth(this.Root);
            }

            private int GetDepth(Node parent)
            {
                return parent == null ? 0 : Math.Max(GetDepth(parent.LtNode), GetDepth(parent.RtNode)) + 1;
            }

            public void PreOrder(Node parent)
            {
                if (parent != null)
                {
                    Console.Write(parent.Data + " ");
                    PreOrder(parent.LtNode);
                    PreOrder(parent.RtNode);
                }
            }

            public void InOrder(Node parent)
            {
                if (parent != null)
                {
                    InOrder(parent.LtNode);
                    Console.Write(parent.Data + " ");
                    InOrder(parent.RtNode);
                }
            }

            public void PostOrder(Node parent)
            {
                if (parent != null)
                {

                    PostOrder(parent.LtNode);
                    PostOrder(parent.RtNode);
                    Console.Write(parent.Data + " ");
                }
            }
        }

        public static void TreeConstruct()
        {

            BinaryTree binTree = new BinaryTree();

            binTree.Insert(11);

            binTree.Insert(21);

            binTree.Insert(78);

            binTree.Insert(31);

            binTree.Insert(101);

            binTree.Insert(51);

            binTree.Insert(82);

            Node node = binTree.Search(51);

            int depth = binTree.GetDepth();

            Console.WriteLine("PreOrder Traversal:");

            binTree.PreOrder(binTree.Root);

            Console.WriteLine();

            Console.WriteLine("InOrder Traversal:");

            binTree.InOrder(binTree.Root);

            Console.WriteLine();

            Console.WriteLine("PostOrder Traversal:");

            binTree.PostOrder(binTree.Root);

            Console.WriteLine();

            binTree.Delete(78);

            binTree.Delete(82);

            Console.WriteLine("After Remove Operation, Preorder Traversal:");

            binTree.PreOrder(binTree.Root);

            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
