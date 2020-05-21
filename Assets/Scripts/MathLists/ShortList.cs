using Nodes;

namespace MathLists 
{
    /**
     * A ShortList contains a list of NumberNodes that are to be considered
     * when looking whether a combo has been found.
     * It also stores the index that it starts at.
     */
    public class ShortList
    {

        public NumberNode[] nodeArray;
        public int startIndex;

        public ShortList(NumberNode[] nodeArray, int startIndex)
        {
            this.nodeArray = nodeArray;
            this.startIndex = startIndex;
        }

        public int GetStartIndex()
        {
            return startIndex;
        }
    }
}


