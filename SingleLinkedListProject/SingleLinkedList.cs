using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SingleLinkedListProject
{
    class SingleLinkedList
    {
        private Node start;

        public SingleLinkedList()
        {
            start = null;
        }

        public void DisplayList()
        {
            Node p;
            if(start==null)
            {
                Console.WriteLine("List is empty");
                return;
            }
            Console.Write("List is : ");
            p = start;
            while(p!=null)
            {
                Console.Write(p.info + " ");
                p = p.link;
            }
            Console.WriteLine();
        }

        public void CountNodes()
        {
            Node p = start;
            int n = 0;
            while(p!=null)
            {
                n++;
                p = p.link;
            }
            Console.WriteLine("Number of Nodes is" + n);
        }

        public void Search(int x)
        {
            Node p = start;
            int position=0;
            while(p!=null)
            {
                if (p.info == x)
                    break;
                position++;
                p = p.link;   
            }
            if (p == null)
                Console.WriteLine(+x+ "not found in the List");
            else
                Console.WriteLine(+x+ "found in position" + position);
        }

        public void ReferenceToLastNode()
        {
            Node p = start;
            while(p.link!=null)
            {
                p = p.link;
            }
            Console.WriteLine("Reference to Last Node is:" + p);
        }

        public void ReferenceToSecondLastNode()
        {
            Node p = start;
            while(p.link.link!=null)
            {
                p = p.link;
            }
            Console.WriteLine("Reference to Second Last Node is:" + p);
        }

        public void ReferenceToNodeWithParticularInfo(int x)
        {
            Node p = start;
            while(p!=null)
            {
                if (p.info == x)
                    break;
                p = p.link;
            }
            Console.WriteLine("Reference to Node with Particular Info " + x + " is in:"+p);
        }

        public void ReferenceToPredecessorOfNodeWithParticularInfo(int x)
        {
            Node p = start;
            while(p!=null)
            {
                if (p.link.info == x)
                    break;
                p = p.link;
            }
            Console.WriteLine("Reference To Predecessor Of Node With Particular Info " + x + " is in:" + p);
        }

        //public void ReferenceToNodeAtParticularPosition()
        //{
        //    Node p = start;
        //    int i,k;
        //    if (i = 1; i < k && p != null; i++)
        //        {
        //        p = p.link;
        //    }
        //}

        public void InsertInBeginning(int data)
        {
            Node temp = new Node(data);
            temp.link = start;
            start = temp;
        }

        public void InsertInEnd(int data)
        {
            Node p;
            Node temp = new Node(data);
            
            if(start==null)
            {
                start = temp;
                return;
            }
            p = start;
            while(p.link!=null)
            {
                p = p.link;
                temp = p.link;
            }
        }

        public void CreateList()
        {
            int i, n, data;
            Console.WriteLine("Enter the number of nodes:");
            n = Convert.ToInt32(Console.ReadLine());

            if (n == 0)
                return;
            for(i=0;i<n;i++)
            {
                Console.WriteLine("Enter the element to be inserted:");
                data = Convert.ToInt32(Console.ReadLine());
                InsertInEnd(data);
            }
        }

        public void InsertANodeAfterGivenNode(int data,int x)
        {
            Node p = start;
            while(p!=null)
            {
                if (p.info == x)
                    break;
                p = p.link;
            }
            if (p == null)
                Console.WriteLine(x + " is not present in the list");
            else
            {
                Node temp = new Node(data);
                temp.link = p.link;
                p.link = temp;
            }
        }

        public void InsertANodeBeforeGivenNode(int data, int x)
        {
            Node temp;
            /*If list is empty*/
            if (start == null)
            {
                Console.WriteLine("List is empty");
                return;
            }

            /*If x is present in first node,new node is to be inserted before first node*/
            if(x==start.info)
            {
                temp = new Node(data);
                temp.link = start;
                start = temp;
                return;
            }
            
            /*Find reference to predecessor of node containing x*/
            Node p = start;
            while(p.link!=null)
            {
                if (p.link.info == x)
                    break;
                p = p.link;
            }
            if(p.link==null)
                Console.WriteLine(x + " is not present in the list");
            else
            {
                temp = new Node(data);
                temp.link = p.link;
                p.link = temp;
            }
        }

        public void InsertANodeAtGivenPosition(int data,int k)
        {
            Node temp;
            int i;

            /*Insert in first position*/
            if(k==1)
            {
                temp = new Node(data);
                temp.link = start;
                start = temp;
                return;
            }

            Node p = start;
            for(i=1;i<k-1 && p!=null;i++)
            {
                p = p.link;
            }
            if (p == null)
                Console.WriteLine("You can insert only upto " + i + "th position");
            else
            {
                temp = new Node(data);
                temp.link = p.link;
                p.link = temp;
            }
        }

        public void DeleteFirstNode()
        {
            if (start == null)
                return;
            start = start.link;
        }

        public void DeletionOfOnlyNode()
        {
            start = null;
        }

        public void DeleteEndNode()
        {
            if (start == null)
                return;
            if (start.link == null)
            {
                start = null;
                return;
            }
            Node p = start;
            while (p.link.link!= null)
            {
                p = p.link;
            }
            p.link = null;
        }

        public void DeleteNode(int x)
        {
            if (start == null)
            {
                Console.WriteLine("List is Empty");
                return;
            }

            if(start.info==x)
            {
                start = start.link;
                return;
            }

            /*Deletion in between or at the end*/

            Node p = start;
            while(p.link!=null)
            {
                if (p.link.info == x)
                    break;
                p = p.link;
            }
            if (p.link == null)
                Console.WriteLine("Element " + x + " not found in the list");
            else
                p.link = p.link.link;
        }

        public void ReverseList()
        {
            Node prev, p, next;
            prev = null;
            p = start;
            while(p!=null)
            {
                next = p.link;
                p.link = prev;
                prev = p;
                p = next;
            }
        }

        public void BubbleSortExcByData()
        {
            Node end, p, q;
            for(end=null;end!=start.link;end=p)
            {
                for(p=start;p.link!=end;p=p.link)
                {
                    q = p.link;
                    if(p.info>q.info)
                    {
                        int temp = p.info;
                        p.info = q.info;
                        q.info = temp;
                    }
                }
            }
        }

        public void BubbleSortExcByLinks()
        {
            Node end, p, q, r, temp;
            for (end = null; end != start.link; end = p)
            {
                for (r = p = start; p.link != end; r = p, p= p.link)
                {
                    q = p.link;
                    if (p.info > q.info)
                    {
                        p.link = q.link;
                        q.link = p;
                        if (p != start)
                            r.link = q;
                        else
                            start = q;
                        temp = p;
                        p = q;
                        q = temp;
                    }
                }
            }
        }

        public SingleLinkedList Merge1(SingleLinkedList list)
        {
            SingleLinkedList mergeList = new SingleLinkedList();
            mergeList.start = Merge1(start, list.start);
            return mergeList;
        }
        private Node Merge1(Node p, Node q)
        {
            Node startM;
            if (p.info <= p.info)
            {
                startM = new Node(p.info);
                p = p.link;
            }
            else
            {
                startM = new Node(q.info);
                q = q.link;
            }
            Node pm = startM;

            while (p != null && q != null)
            {
                if (p.info < q.info)
                {
                    pm.link = new Node(p.info);
                    p = p.link;
                }
                else
                {
                    pm.link = new Node(q.info);
                    q = q.link;
                }

            }

            while (p != null)
            {
                pm.link = new Node(p.info);
                p = p.link;
                pm = pm.link;
            }
            while (q != null)
            {
                pm.link = new Node(q.info);
                q = q.link;
                pm = pm.link;
            }
            return startM;
        }

        public SingleLinkedList Merge2(SingleLinkedList list)
        {
            SingleLinkedList mergelist = new SingleLinkedList();
            mergelist.start = Merge2(start, list.start);
            return mergelist;
        }
        private Node Merge2(Node p1, Node p2)
        {
            Node startM;
            if (p1.info < p2.info)
            {
                startM = p1;
                p1 = p1.link;
            }
            else
            {
                startM = p2;
                p2 = p2.link;
            }
            Node pm = startM;
            while (p1 != null && p2 != null)
            {
                if (p1.info <= p2.info)
                {
                    pm.link = p1;
                    pm = pm.link;
                    p1 = p1.link;
                }
                else
                {
                    pm.link = p2;
                    pm = pm.link;
                    p2 = p2.link;
                }
            }
            if (p1 == null)
            {
                pm.link = p2;
            }
            else
            {
                pm.link = p1;
            }
            return startM;
        }
    }
}
