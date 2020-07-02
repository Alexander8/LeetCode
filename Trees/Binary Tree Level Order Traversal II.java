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
    public List<List<Integer>> levelOrderBottom(TreeNode root) {
        
        var result = new ArrayList<List<Integer>>();
        
        levelOrderBottom(root, 1, result);
        
        Collections.reverse(result);
        
        return result;        
    }
    
    private static void levelOrderBottom(TreeNode root, int depth, ArrayList<List<Integer>> result) {
        if (root == null) return;
        
        if (result.size() < depth) {
            var list = new ArrayList<Integer>();
            result.add(list);
        }
        
        result.get(depth - 1).add(root.val);
        
        levelOrderBottom(root.left, depth + 1, result);
        levelOrderBottom(root.right, depth + 1, result);
    }
}