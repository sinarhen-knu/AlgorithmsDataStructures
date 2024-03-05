namespace ASDLab1
{
    public abstract class Searcher 
    {
        public abstract int LinearSearch(int target);

        public abstract int BinarySearch(int target);

        public abstract int GoldenRatioSearch(int target);
        
        public abstract int BarrierSearch(int target);
    }
}