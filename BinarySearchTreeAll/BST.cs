using System;
using System.Collections.Generic;
using System.Linq;

namespace BinarySearchTreeAll
{
    public class BST
    {
        public Node root;

        public BST()
        {
            root = null;
        }

        public Node GetRoot() { return root; }

        public void Insert(int key)
        {
            Node tailNode = root;
            Node tempParentNode = new Node();

            //create root with key 
            Node newNodeWithData = new Node
            {
                Data = key,
                Left = null,
                Right = null
            };

            if (root == null)
            {
                //Create root with the given key as a Root Node
                root = newNodeWithData;
            }

            
            while (tailNode != null) //tailNode keep on moving down from the rootNode.
            {
                tempParentNode = tailNode; // tempParentNode follows tailNode. when tailNode gets null, our desired parent node will be tempParentNode

                if (key < tailNode.Data)
                    tailNode = tailNode.Left;
                else if (key > tailNode.Data)
                    tailNode = tailNode.Right;
                else
                    break; //stop if Key element is found
            }

            //if key is less than the value at tempParent Node, add that node as a Left of the tree, else set Right of that tree

            if (key < tempParentNode.Data)
                tempParentNode.Left = newNodeWithData;
            else
                tempParentNode.Right = newNodeWithData;
        }

        public Node InsertRecursively(Node newNodeWithData, int key)
        {
            Node tailNode;
            if (newNodeWithData == null)
            {
                tailNode = new Node
                {
                    Data = key,
                    Left = null,
                    Right = null
                };
                return tailNode;
            }

            if (key < newNodeWithData.Data)
            {
                newNodeWithData.Left = InsertRecursively(newNodeWithData.Left, key);
            }
            else if (key > newNodeWithData.Data)
            {
                newNodeWithData.Right = InsertRecursively(newNodeWithData.Right, key);
            }
            return newNodeWithData;  // key == p->data?
        }

        public Node Search(int key)
        {
            Node tailNode = root;

            while (tailNode != null)
            {
                if (key == tailNode.Data)
                {
                    return tailNode;
                }
                else if (key < tailNode.Data)
                {
                    tailNode = tailNode.Left;
                }
                else
                {
                    tailNode = tailNode.Right;
                }
            }
            return null;
        }
        
        public Node Delete(Node p, int key)
        {
            Node q;

            if (p == null)
            {
                return null;
            }

            if (p.Left == null && p.Right == null)
            {
                if (p == root)
                {
                    root = null;
                }
               
                return null;
            }

            if (key < p.Data)
            {
                p.Left = Delete(p.Left, key);
            }
            else if (key > p.Data)
            {
                p.Right = Delete(p.Right, key);
            }
            else
            {
                if (Height(p.Left) > Height(p.Right)) //we can take either InOrderPredecessor or InOrderSuccessor- but I am taking based on the height
                {
                    q = InOrderPredecessor(p.Left); //rightmost leaf Node of the LeftNode
                    p.Data = q.Data;
                    p.Left = Delete(p.Left, q.Data);
                }
                else
                {
                    q = InOrderSuccessor(p.Right); //leftmost leaf Node of the RightNode
                    p.Data = q.Data;
                    p.Right = Delete(p.Right, q.Data);
                }
            }
            return p;
        }
        private int Height(Node p)
        {
            int x, y;
            
            if (p == null)
            {
                return 0;
            }
            x = Height(p.Left);
            y = Height(p.Right);

            return x > y ? x + 1 : y + 1;
        }
        public Node InOrderPredecessor(Node p) //Rightmost leaf
        {
            while (p.Right != null)
            {
                p = p.Right;
            }
            return p;
        }
        public Node InOrderSuccessor(Node p) //LeftMost leaf
        {
            while (p.Left!= null)
            {
                p = p.Left;
            }
            return p;
        }

        public void InOrder(Node node)
        {
            if (node != null)
            {
                InOrder(node.Left);

                Console.Write("{0}  ", node.Data);
                
                InOrder(node.Right);
            }
        }

        public void PreOrder(Node node)
        {
            if (node != null)
            {
                Console.Write("{0}  ", node.Data);

                PreOrder(node.Left);

                PreOrder(node.Right);
            }
        }

        public void PostOrder(Node node)
        {
            if (node != null)
            {
                PostOrder(node.Left);

                PostOrder(node.Right);

                Console.Write("{0}  ", node.Data);
            }
        }

        //Create BSt FROM PREORDER traversal
        public void CreateFromPreorder(ref int[] pre, int n)
        {

            // Create root node
            int i = 0;
            root = new Node
            {
                Data = pre[i++],
                Left = null,
                Right = null
            };

            // Iterative steps
            Node t;
            Node p = root;
            Stack<Node> stk = new Stack<Node>();

            while (i < n)
            {
                // Left child case
                if (pre[i] < p.Data)
                {
                    t = new Node
                    {
                        Data = pre[i++],
                        Left = null,
                        Right = null
                    };
                    p.Left = t;
                    stk.Push(p);
                    p = t;
                }
                else
                {
                    // Right child cases
                    var checkValueOnTheTopOfStack = (stk.Count() == 0) ? int.MaxValue : stk.Peek().Data; //if stack empty, make it maximum value

                    if (pre[i] > p.Data && pre[i] < checkValueOnTheTopOfStack)
                    {
                        t = new Node
                        {
                            Data = pre[i++],
                            Left = null,
                            Right = null
                        };
                        p.Right = t;
                        p = t;
                    }
                    else
                    {
                        p = stk.Peek();
                        stk.Pop();
                    }
                }
            }
        }
    }
}
