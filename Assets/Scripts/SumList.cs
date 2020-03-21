using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * A SumList stores an array of sums and their respective indexes.
 */
public class SumList
{
    public List<int> sumList;
    public List<int> indexList;

    public SumList()
    {
        sumList = new List<int>();
        indexList = new List<int>();
    }

    /**
     * Add a sum and it's respective index in the o
     * @param sum the sum to be added
     * @param index
     */
    public void Add(int sum, int index)
    {
        sumList.Add(sum);
        indexList.Add(index);
    }
}
