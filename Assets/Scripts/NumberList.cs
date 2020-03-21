using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberList
{
    public const int BOUND_LOW = 1;
    public const int BOUND_HIGH = 8;

    public LinkedList<NumberNode> numberLinkedList = new LinkedList<NumberNode>();
    public NumberNode[] numberArray;

    public int GetIndexOfNode(NumberNode node)
    {
        RefreshArray();
        for (int i = 0; i < numberArray.Length; i++)
        {
            if (numberArray[i] == node)
            {
                return i;
            }
        }
        return -1;
    }


    public void RefreshArray()
    {
        if (numberLinkedList.Count > 0)
        {
            NumberNode[] numberNodes = new NumberNode[numberLinkedList.Count];
            LinkedListNode<NumberNode> currentNode = numberLinkedList.First;
            int index = 0;
            numberNodes[index] = currentNode.Value;


            while (currentNode.Next != null)
            {
                index++;
                currentNode = currentNode.Next;
                numberNodes[index] = currentNode.Value;
            }

            this.numberArray = numberNodes;
        }
        else
        {
            throw new IndexOutOfRangeException();
        }
    }

    /**
     * Checks if a combo exists in this numberList.
     * @param startIndex the index to check from
     * @param target the target to reach
     * @return true if combo exists, false otherwise.
     */
    public bool CheckForComboAt(int startIndex, int target)
    {
        RefreshArray();
        // SumList objects store a sum and the index they're found on.
        SumList sumListLeft = new SumList(), sumListRight = new SumList();
        sumListLeft.Add(0, -1);
        sumListRight.Add(0, -1);

        /**
         * Disregard all the numbers that cannot be part of the combo and return
         * the shorter array with numbers that can.
         */
        ShortList sl = FindShortList(startIndex, target);
        NumberNode[] shortList = sl.array;

        // Set the index to start counting from for counting towards
        // left and counting towards right.
        int leftStartIndex = sl.GetStartIndex();
        int rightStartIndex = sl.GetStartIndex() + 1;

        // Create a temporary sum.
        int sum = 0;
        // Go over all numbers in the short list left of (and including) the start index
        for (int i = leftStartIndex; i > -1; i--)
        {
            // Increase the sum by the current value
            sum += shortList[i].value;
            // Store the sum and at what index in the shortList the sum occured
            sumListLeft.Add(sum, i);
        }
        // Reset the temporary sum.
        sum = 0;
        // Go over all numbers in the short list right of (and excluding) the start index
        for (int i = rightStartIndex; i < shortList.Length; i++)
        {
            // Increase the sum by the current value
            sum += shortList[i].value;
            // Store the sum and at what index in the shortList the sum occured
            sumListRight.Add(sum, i);
        }

        // For both sumlists...
        for (int sumListLeftIndex = 0; sumListLeftIndex < sumListLeft.sumList.Count; sumListLeftIndex++)
        {
            for (int sumListRightIndex = 0; sumListRightIndex < sumListRight.sumList.Count; sumListRightIndex++)
            {
                // Get the value of the currently selected sums added together
                int current_sum = sumListLeft.sumList[sumListLeftIndex] + sumListRight.sumList[sumListRightIndex];

                if (current_sum == target)
                {
                    // Found a combo!
                    // Kill all nodes that make up this combination.
                    for (int k = 0; k < sumListLeftIndex + 1; k++)
                    {
                        int index = sumListLeft.indexList[k];
                        if (index > -1)
                        {
                            shortList[index].Kill();
                        }
                    }
                    for (int k = 0; k < sumListRightIndex + 1; k++)
                    {
                        int index = sumListRight.indexList[k];
                        if (index > -1)
                        {
                            shortList[index].Kill();
                        }
                    }
                    return true;
                }
                // If the combined sum is above it's target, no combo can be found, so
                // stop looking any further.
                else if (current_sum > target)
                {
                    return false;
                }
            }
        }
        return false;
    }

    /**
     * Returns an array of the numbers that could potentially form a combo.
     * This eliminates all numbers that can not make up the combo from the original array,
     * to reduce the amount of numbers we have to consider next.
     * @param startIndex the index to look from
     * @param target the target number we're looking for
     * @return an array of the numbers that could potentially form a combo
     */
    private ShortList FindShortList(int startIndex, int target)
    {
        // Get values from the list of number nodes
        int[] values = GetValues();

        // Create the shortlist of numbers
        List<NumberNode> shortList = new List<NumberNode>();
        // Include all consecutive values to the left of startIndex until they exceed target
        int sum = 0;
        for (int i = startIndex; i > -1; i--)
        {
            // Add the current value to the sum
            NumberNode node = numberArray[i];
            sum += node.value;
            // If the sum exceeds the target, this number can't be part of the combo and we can stop looking.
            if (sum > target)
            {
                break;
            }
            // Else we add it to the shortlist
            shortList.Add(node);
        }

        int newStartIndex = shortList.Count - 1;
        // Reverse that list so it's in order of original array
        shortList.Reverse();

        // Now add the numbers right of startIndex
        sum = 0;
        for (int i = startIndex; i < numberLinkedList.Count; i++)
        {
            // Add the current value to the sum
            NumberNode node = numberArray[i];
            sum += node.value;
            // If the sum exceeds the target, this number can't extend the combo and we can stop looking.
            if (sum > target)
            {
                break;
            }
            // Else we add it to the shortlist
            // (if it's not the start index, since that's already included)
            else if (i != startIndex)
            {
                shortList.Add(node);
            }
        }

        // Now convert the ArrayList into an array of nodes
        NumberNode[] shortArray = new NumberNode[shortList.Count];
        int index = 0;
        foreach (NumberNode node in shortList)
        {
            shortArray[index++] = node;
        }
        return new ShortList(shortArray, newStartIndex);
    }

    private int[] GetValues()
    {
        int[] values;
        values = new int[numberArray.Length];

        for (int i = 0; i < numberArray.Length; i++)
        {
            values[i] = numberArray[i].value;
        }

        return values;
    }
}
