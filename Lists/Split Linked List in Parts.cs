/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int val=0, ListNode next=null) {
 *         this.val = val;
 *         this.next = next;
 *     }
 * }
 */
public class Solution 
{
    public ListNode[] SplitListToParts(ListNode root, int k) 
    {
        var length = 0;
        var tmp = root;
        
        while (tmp != null)
        {
            ++length;
            tmp = tmp.next;
        }
        
        var partSizes = GetPartSizes(length, k);
        var result = new ListNode[partSizes.Length];
        
        for (var i = 0; i < partSizes.Length; ++i)
        {
            ListNode part = null, next = null;
            
            if (root == null)
                break;     
            
            for (var j = 0; j < partSizes[i]; ++j)
            {
                if (root == null)
                    break;

                if (part == null)
                {
                    part = new ListNode(root.val);
                    next = part;
                }
                else
                {
                    next.next = new ListNode(root.val);
                    next = next.next;
                }
                
                root = root.next;
            }
                
            result[i] = part;            
        }
        
        return result;
    }
    
    private static int[] GetPartSizes(int length, int k)
    {
        var sizes = new int[k];
        
        if (k >= length)
        {
            for (var i = 0; i < length; ++i)
                sizes[i] = 1;
            
            return sizes;
        }

        var remainder = length % k;
        if (remainder == 0)
        {
            Array.Fill(sizes, length / k);
            return sizes;
        }
        
        var partSize = length / k;
        for (var i = 0; i < k; ++i)
        {
            sizes[i] = partSize;
            if (i < remainder)
                sizes[i] += 1;
        }
            
        return sizes;
    }
}