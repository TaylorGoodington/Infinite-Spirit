using System;
using System.Collections.Generic;
using UnityEngine;
using static Utility;

public class TreeNodeDatabase : MonoBehaviour
{
    public static TreeNodeDatabase Instance { get; set; }
    public List<TreeNode> treeNodeDatabase;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        treeNodeDatabase = new List<TreeNode>()
        {
            new TreeNode(1, TreeNodeType.Compiler, 1),
            new TreeNode(2, TreeNodeType.Defense_Matrix, 1),
            new TreeNode(3, TreeNodeType.Predictive_Algorithms, 1),
            new TreeNode(4, TreeNodeType.Core_Firewall, 1),
            new TreeNode(5, TreeNodeType.Skill, 3)
        };
    }
}

[Serializable]
public struct TreeNode
{
    public int nodeId;
    public TreeNodeType nodeType;
    public int nodeValue;

    public TreeNode(int nodeId, TreeNodeType nodeType, int nodeValue)
    {
        this.nodeId = nodeId;
        this.nodeType = nodeType;
        this.nodeValue = nodeValue;
    }
}