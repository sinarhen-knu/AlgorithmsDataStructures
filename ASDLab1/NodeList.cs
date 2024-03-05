

namespace ASDLab1;
public class NodeList
{
    Node? head;
    Node? tail;
    int length = 0;
    public int Length => length;

    
    public void Add(int data)
    {
        var node = new Node(data, null);

        head ??= node;

        if (tail != null) 
        {
            tail.Next = node;
        }
        tail = node;
        length++;
    }
    public Node? GetHead()
    {
        return head;
    }
    public void RemoveLast()
    {                                     
        Node? current = head;
        while(current?.Next?.Next != null)
        {                   
            current = current.Next;
        }
        tail = current;
        if (tail != null) tail.Next = null;
        length--;

    }
    public int ElementAt(int index)
    {
        Node? current = head;
        for(int i = 0; i < index;i++)
        {
            current = current?.Next;
        }
        return current?.Value ?? default;
    }
    
    public void Print()
    {
        var current = head;
        while(current != null)
        {
            Console.Write(current.Value + "\t");
            current = current.Next;
        }
        Console.WriteLine();
    }


    public void Sort()
    {
        var current = head;
        for (var i = 0; i < length; i++)
        {
            Node? previous = null;
            for (var j = 0; j < length - 1; j++)
            {
                previous = current;
                current = current?.Next;
                if (previous != null && current != null && previous.Value > current.Value)
                {
                    (current.Value, previous.Value) = (previous.Value, current.Value);
                }
            }
            current = head;
            previous = null;
        }
    }
    
    public Node? GetNodeAtIndex(int index)
    {
        if (index < 0 || index >= length)
        {
            return null;
        }

        var current = head;
        for (var i = 0; i < index && current != null; i++)
        {
            current = current.Next;
        }
        return current;
    }
}

public class Node
{
    public Node(int value, Node? next) 
    { 
        this.Value = value;
        this.Next = next;
        next = null;
    }

    public int Value { get; set; }

    public Node? Next { get; set; }
}
