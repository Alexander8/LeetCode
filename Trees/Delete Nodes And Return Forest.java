/**
 * Definition for a binary tree node.
 * public class TreeNode {
 *     int val;
 *     TreeNode left;
 *     TreeNode right;
 *     TreeNode() {}
 *     TreeNode(int val) { this.val = val; }
 *     TreeNode(int val, TreeNode left, TreeNode right) {
 *         this.val = val;
 *         this.left = left;
 *         this.right = right;
 *     }
 * }
 */
class Solution {
    public List<TreeNode> delNodes(TreeNode root, int[] to_delete) {
        
        List<TreeNode> result = new ArrayList<>();
        if (root == null) return result;
        
        Set<Integer> set = new HashSet<>();
        
        for (int num : to_delete) 
            set.add(num);
        
        if (!set.contains(root.val))
            result.add(root);
        
        delNodes(root, null, false, set, result);
        
        return result;        
    }
    
    private static void delNodes(TreeNode current, TreeNode parent, boolean isLeft, Set<Integer> to_delete, List<TreeNode> result) {
        
        if (current == null) return;
        
        if (to_delete.contains(current.val)) {
            if (parent != null) {
                if (isLeft) parent.left = null;
                else parent.right = null;
            }
            
            if (current.left != null) {
                delNodes(current.left, current, true, to_delete, result);
                if (current.left != null)
                    result.add(current.left);
                current.left = null;
            }
            
            if (current.right != null) {
                delNodes(current.right, current, false, to_delete, result);
                if (current.right != null)
                    result.add(current.right);
                current.right = null;
            }          
        }
        
        delNodes(current.left, current, true, to_delete, result);
        delNodes(current.right, current, false, to_delete, result);
    }
}