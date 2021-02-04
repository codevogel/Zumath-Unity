
using System.Collections.Generic;

namespace MathLists
{
    /**
     * A SumList stores an array of sums and their respective indexes.
     */
    public class SumList
    {
        public List<int> sumList;
        public List<int> correspondingIndexList;

        public SumList()
        {
            sumList = new List<int>();
            correspondingIndexList = new List<int>();
        }

        /**
         * Add a sum and it's respective index in the o
         * @param sum the sum to be added
         * @param index
         */
        public void Add(int sum, int correspondingIndex)
        {
            sumList.Add(sum);
            correspondingIndexList.Add(correspondingIndex);
        }
    }

}
