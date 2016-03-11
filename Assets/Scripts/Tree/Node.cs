using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Node : MonoBehaviour {

    public Node parent;

    public int generation = 0;

    public List<Node> children;

    public float layoutWidth = 1f;
    public float layoutHeight = 1f;    

    public void Start()
    {
        children = new List<Node>();

        for(int i = 0; i < transform.childCount; i++)
        {
            Node n = transform.GetChild(i).GetComponent<Node>();
            children.Add(n);
        }
    }

    public float GetLayoutWidth()
    {
        float width = layoutWidth;

        foreach(Node node in children)
        {
            width += node.GetLayoutWidth();
        }
        return width;
    }

    public void LayoutNode()
    {
        float width = GetLayoutWidth();
        float nodeWidth = width / children.Count;
        float xOrigin = transform.position.x - (width / 2f);
                        
        Vector3 pos = Vector3.zero;
        int i = 0;
        foreach(Node node in children)
        {
            if (Tree.instance.align == LayoutAlign.LEFT)
            {
                pos = new Vector3(transform.position.x + (i * (width / children.Count) + (i > 0 ? Tree.instance.spacingX : 0)),
                                  transform.position.y + Tree.instance.spacingY,
                                  transform.position.z);

                node.transform.position = pos;

                i++;

                node.LayoutNode();

            }else if (Tree.instance.align == LayoutAlign.CENTER)
            {
                pos = new Vector3(xOrigin + (i * nodeWidth), transform.position.y + Tree.instance.spacingY, transform.position.z);
                node.transform.position = pos;

                i++;

                node.LayoutNode();
            }
        }
    }
}
