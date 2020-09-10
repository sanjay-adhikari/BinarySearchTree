using System;

namespace BinarySearchTreeAll
{
    class Program
    {
        static void PrintTreeTravel(BST bst)
        {
            Console.WriteLine("Root Node: {0}", bst.GetRoot().Data);

            // pre-order traversal
            Console.WriteLine("\nPre-order Traversal:");
            bst.PreOrder(bst.GetRoot());

            // in-order traversal
            Console.WriteLine("\n\nIn-order Traversal:");
            bst.InOrder(bst.GetRoot());

            // post-order traversal
            Console.WriteLine("\n\nPost-order Traversal:");
            bst.PostOrder(bst.GetRoot());


            Console.WriteLine("\n\n");
        }
        static void Main(string[] args)
        {
            int[] arr1 = new int[] { 10, 5, 20, 8, 30 }; //output: 5, 8, 10, 20, 30
            int[] arr2 = new int[] { 9, 15, 5, 20, 16, 8, 12, 3, 6 };

            BST bst = new BST();
            
            var arr = arr2;
            foreach(var a in arr)
                bst.Insert(a); //This will make a Binary Search Tree

            //traversal display
            PrintTreeTravel(bst);

            // Search
            int searchKey = 9;
            Console.WriteLine("Searching for: {0}", searchKey);

            Node temp = bst.Search(searchKey);
            if (temp != null)
            {
                Console.WriteLine("Element found : {0}", temp.Data);
            }
            else
            {
                Console.WriteLine("Element not found");
            }


            //Recursive insert
            Console.WriteLine("\n\nRecursively Nodes Added: 50, 70, 1");
            bst.InsertRecursively(bst.GetRoot(), 50);
            bst.InsertRecursively(bst.GetRoot(), 70);
            bst.InsertRecursively(bst.GetRoot(), 1);
            PrintTreeTravel(bst);

            // Delete
            int deleteKey = 9;
            Console.WriteLine("\n\nSearching for: {0}", deleteKey);
            bst.Delete(bst.GetRoot(), deleteKey);
            PrintTreeTravel(bst);


            // BST from Preorder traversal
            Console.WriteLine("\n\nBST from Preorder: ");
            int[] pre = new int[] { 30, 20, 10, 15, 25, 40, 50, 45 };
            int n = pre.Length;

            BST bstPre = new BST();
            bstPre.CreateFromPreorder(ref pre, n);
            PrintTreeTravel(bstPre);

            Console.ReadKey();
        }
    }
}
