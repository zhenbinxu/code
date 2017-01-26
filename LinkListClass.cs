using System;
using System.Collections.Generic;



public class LinkListClass<T>
    where T : struct
{
    #region embedded class
    public class ListNode<U>
        where U : struct
    {
        public U Val;
        public ListNode<U> Next;
    }
    #endregion 
    
    private ListNode<T> m_listSentinel;

    public LinkListClass()
    {
        m_listSentinel = new ListNode<T>();
    }

    public ListNode<T> CreateList(IEnumerable<T> valList)
    {
        ListNode<T> last = m_listSentinel;

        foreach (T val in valList)
        {
            last.Next = new ListNode<T> { Val = val, Next = null };
            last = last.Next;
        }

        return List;
    }

    public ListNode<T> Append(T val)
    {
        ListNode<T> last = m_listSentinel;
        while (last.Next != null) {
            last = last.Next;
        }
        last.Next = new ListNode<T> { Val = val, Next = null};
        return last.Next;
    }

    public ListNode<T> List
    {
        get
        {
            return m_listSentinel.Next;
        }
    }


    public ListNode<T> ReverseList(ListNode<T> head)
    {
        ListNode<T> sentinel = new ListNode<T>();
        sentinel.Next = head;

        ListNode<T> p = sentinel;
        while (head != null && head.Next != null) {
            ListNode<T> t = head.Next.Next;

            // P  H N  T
            // P  N H  T
            //      P  H
            p.Next = head.Next;
            head.Next.Next = head;
            head.Next = t;
            
            // Move to next group
            p = head;
            head = t;
        }
    
        return sentinel.Next;
    }

    public void PrintList(ListNode<T> head)
    {
        Console.Write("List: ");
        while (head != null)
        {
            Console.Write(head.Val + " ");
            head = head.Next; 
        }
        Console.WriteLine();
    }
}
