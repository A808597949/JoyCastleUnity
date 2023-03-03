using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeNode//使用结构体定义会报错，因为结构体是值类型，导致结构体嵌套，循环依赖
{
    public int val;
    public TreeNode left;
    public TreeNode right;

    public TreeNode(int t)
    {
        this.val=t;
        left = null;
        right = null;
    }
}
public class PrintLeftMost : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
        TreeNode node = new TreeNode(2);
        node.left = new TreeNode(11);
        node.right = new TreeNode(23);
        node.left.left = new TreeNode(10);
        node.left.right = new TreeNode(15);
        node.right.left = new TreeNode(7);
        node.right.right = new TreeNode(14);
        node.right.left.right = new TreeNode(12);
        node.right.left.right.left = new TreeNode(13);
        FindLeftNode(node);

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void FindLeftNode(TreeNode root)
    {
        string output="[";
        Queue<TreeNode> queue = new Queue<TreeNode>();
        queue.Enqueue(root);
        while (queue.Count !=0)
        {
            int size = queue.Count;
            for (int i=0;i<size;i++)
            {
                
                TreeNode node = queue.Dequeue();
                if (i == 0)
                {
                    output+=node.val.ToString()+",";
                }
                if (node.left != null)
                {
                    queue.Enqueue(node.left);
                }
                if(node.right != null)
                {
                    queue.Enqueue(node.right);
                }
            }
        }
        output=output.Remove(output.Length-1);
        output += "]";
        Debug.Log(output);
    }
}
