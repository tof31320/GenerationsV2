using UnityEngine;
using System.Collections;

public enum LayoutAlign
{
    LEFT,
    CENTER,
    RIGHT
}

public class Tree : MonoBehaviour {

    private static Tree _instance = null;
    public static Tree instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindGameObjectWithTag("Tree").GetComponent<Tree>();
            }
            return _instance;
        }
    }

    // Layouts
    public float spacingX = 0.5f;
    public float spacingY = -3f;
    public LayoutAlign align = LayoutAlign.LEFT;

    private Node _root = null;
    public Node root
    {
        get
        {
            return _root;
        }
        set
        {
            _root = value;

            Layout();
        }
    }

    public void Start()
    {
        root = transform.GetChild(0).GetComponent<Node>();
    }

    public void Layout()
    {
        LayoutNode(root);
    }

    public void LayoutNode(Node node)
    {
        if (node != null)
        {
            node.transform.position = transform.position;

            node.LayoutNode();
        }
    }

    public void Update()
    {
        Layout();
    }
}
