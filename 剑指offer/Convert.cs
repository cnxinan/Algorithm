/*
题目名称：
二叉搜索树与双向链表

题目描述：
输入一棵二叉搜索树，将该二叉搜索树转换成一个排序的双向链表。
要求不能创建任何新的结点，只能调整树中结点指针的指向。

代码结构：
class Solution
{
    public TreeNode Convert(TreeNode pRootOfTree)
    {
        // write code here
    }
}

补充：
二叉搜索树（Binary Search Tree）定义：
1. 可以是空树
2. 若不是空树
    若它的左子树不空，则左子树所有节点的值均小于它的根节点的值
    若它的右子树不空，则右子树所有节点的值均大于它的根节点的值
    它的左，右子树也分别为二叉搜索树   
*/
using System;
namespace Convert {

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode (int x)
        {
            val = x;
        }
    }

    class Solution {

        // public TreeNode Convert(TreeNode pRootOfTree)
        // {
        //     return ConvertImpl(pRootOfTree, false);
        // }

        // public TreeNode ConvertImpl(TreeNode pRootOfTree, bool leftTree){
        //     if(pRootOfTree == null) return null;
        //     if(pRootOfTree.left != null && (pRootOfTree.left.left != null || pRootOfTree.left.right != null))
        //         pRootOfTree.left = ConvertImpl(pRootOfTree.left, true);
        //     if(pRootOfTree.right != null && (pRootOfTree.right.left != null || pRootOfTree.right.right != null))
        //         pRootOfTree.right = ConvertImpl(pRootOfTree.right, false);
        //     if(pRootOfTree.left != null){
        //         pRootOfTree.left.right = pRootOfTree;
        //     }
        //     if(pRootOfTree.right != null){
        //         pRootOfTree.right.left = pRootOfTree;
        //     }
        //     if(leftTree)
        //         while(pRootOfTree.right != null)
        //             pRootOfTree = pRootOfTree.right;
        //     else
        //         while(pRootOfTree.left != null)
        //             pRootOfTree = pRootOfTree.left;
        //     return pRootOfTree;
        // }

        /// <summary>
        /// 解法1，递归
        /// 基本思路：
        /// 采用中序遍历，左，中，右
        /// 先将左子树转换为双向链表，再将右子树转换为双向链表
        /// 转换过程是一直使用pLast记录当前链表的末尾
        /// </summary>

        private TreeNode pLast;
        public TreeNode Convert(TreeNode pRootOfTree)
        {
            if(pRootOfTree == null) return null;
            TreeNode head = Convert(pRootOfTree.left);
            pRootOfTree.left = pLast;
            if(pLast != null)
                pLast.right = pRootOfTree;
            pLast = pRootOfTree;
            Convert(pRootOfTree.right);
            return head == null ? pRootOfTree : head;
        }

        public void Print(TreeNode root){
            TreeNode node = null;
            while(root != null){
                Console.Write(root.val + " ");
                node = root;
                root = root.right;
            }
            Console.WriteLine();
            while(node != null){
                Console.Write(node.val + " ");
                node = node.left;
            }
        }

        public void Test() {
            
            TreeNode pRootOfTree = new TreeNode(8);
            pRootOfTree.left = new TreeNode(4);
            pRootOfTree.right = new TreeNode(12);

            pRootOfTree.left.left = new TreeNode(2);
            pRootOfTree.left.right = new TreeNode(6);
            pRootOfTree.right.left = new TreeNode(10);
            pRootOfTree.right.right = new TreeNode(14);

            pRootOfTree.left.left.left = new TreeNode(0);
            pRootOfTree.left.left.right = new TreeNode(3);
            pRootOfTree.left.right.left = new TreeNode(5);
            pRootOfTree.left.right.right = new TreeNode(7);
            pRootOfTree.right.left.left = new TreeNode(9);
            // pRootOfTree = null;
           
            Print(Convert(pRootOfTree));
        }
    }
}
