using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Given a linked list where every node represents a linked list and contains two pointers of its type:
//(i) Pointer to next node in the main list (we call it ‘right’ pointer in below code)
//(ii) Pointer to a linked list where this node is head (we call it ‘down’ pointer in below code).
//All linked lists are sorted. See the following example

//       5 -> 10 -> 19 -> 28
//       |    |     |     |
//       V    V     V     V
//       7    20    22    35
//       |          |     |
//       V          V     V
//       8          50    40
//       |                |
//       V                V
//       30               45
//Write a function flatten() to flatten the lists into a single linked list. 
// The flattened linked list should also be sorted. For example, for the above input list, 
// output list should be 5->7->8->10->19->20->22->28->30->35->40->45->50.

namespace FlattenLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            Node n1 = new Node(5);
            Node n2 = new Node(10);
            Node n3 = new Node(15);
            Node n4 = new Node(20);

            n1.Down = n2;
            n1.Next = n3;
            n3.Down = n4;

            Node result = FlattenList(n1);

            Node current = result;

            Console.WriteLine("Flattend linked list is");
            while (current != null)
            {
                Console.Write(current.Data + " ");
                current = current.Down;
            }
        }

        static Node FlattenList(Node n)
        {
            if (n == null || n.Next == null)
            {
                return n;
            }

            return Merge(n, FlattenList(n.Next));
        }

        static Node Merge(Node a, Node b)
        {
            if (a == null)
            {
                return b;
            }

            if (b == null)
            {
                return a;
            }

            Node result = null;

            if (a.Data < b.Data)
            {
                result = a;
                result.Down = Merge(a.Down, b);
            }
            else
            {
                result = b;
                result.Down = Merge(a, b.Down);
            }

            return result;
        }
    }

    class Node
    {
        public Node(int data)
        {
            Data = data;
        }

        public int Data { get; set; }

        public Node Next { get; set; }

        public Node Down { get; set; }
    }
}
