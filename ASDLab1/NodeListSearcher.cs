namespace ASDLab1;
public class NodeListSearcher : Searcher
{
    private readonly NodeList _list;

    public NodeListSearcher(NodeList list)
    {
        _list = list;
    }

    public override int BinarySearch(int target)
    {
        int left = 0, right = _list.Length - 1;
        while (left <= right)
        {
            var mid = (left + right) / 2;
            var midNode = GetNodeAtIndex(_list, mid);

            if (midNode == null || midNode.Value == target) return mid;
            if (midNode.Value < target) left = mid + 1;
            else right = mid - 1;
        }
        return -1;
    }

    public override int LinearSearch(int target)
    {
        var current = _list.GetHead();
        for (var i = 0; i < _list.Length; i++)
        {
            if (current == null || current.Value == target)
                return i;
            current = current?.Next;
        }
        return -1;
    }

    public override int GoldenRatioSearch(int target)
    {
        int left = 0, right = _list.Length - 1;
        while (left <= right)
        {
            var mid = Convert.ToInt32((right - left) / 1.618 + left);
            var midNode = GetNodeAtIndex(_list, mid);

            if (midNode == null || midNode.Value == target) return mid;
            if (midNode.Value < target) left = mid + 1;
            else right = mid - 1;
        }
        return -1;
    }

    public override int BarrierSearch(int target)
    {
        var i = 0;
        for (; _list.ElementAt(i) != target; i++)
        {}
        return i;
    }

    private static Node? GetNodeAtIndex(NodeList list, int index)
    {
        return list.GetNodeAtIndex(index); 
    }
}
