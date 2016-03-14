using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Node : MonoBehaviour {

    public Node parent;

    public int generation = 0;

    public List<Node> children;

    public float layoutWidth = 1f;
    public float layoutHeight = 1f;

    public LineRenderer line;

    public float nodeWidth = 0f;

    public void Start()
    {
        line = GetComponent<LineRenderer>();
        parent = transform.parent.GetComponent<Node>();

        children = new List<Node>();

        for(int i = 0; i < transform.childCount; i++)
        {
            Node n = transform.GetChild(i).GetComponent<Node>();
            children.Add(n);
        }
    }

    public float GetLayoutWidth()
    {
        float width = layoutWidth + Tree.instance.spacingX;
        float childrenWidth = 0f;
        foreach(Node node in children)
        {
            childrenWidth += node.GetLayoutWidth();
        }

        if (childrenWidth > width)
        {
            return childrenWidth;
        }

        return width;
    }

    public void LayoutNode()
    {
        // Largeur totale du noeud parent avec ses enfants
        float width = GetLayoutWidth();

        // Largeur proportionnelle entre deux enfants
        float nodeWidth = width / children.Count;

        float xOrigin = transform.position.x - (width / 2f);
                        
        Vector3 pos = new Vector3(transform.position.x, transform.position.y +Tree.instance.spacingY, transform.position.z);
        int i = 0;
        float widthPrec = 0f;
        foreach(Node node in children)
        {           
            if (Tree.instance.align == LayoutAlign.LEFT)
            {
                //pos = new Vector3(transform.position.x + (i * (width / children.Count) + (i > 0 ? Tree.instance.spacingX : 0)),                
                pos = new Vector3(pos.x + widthPrec + (i > 0 ? Tree.instance.spacingX : 0),
                                  pos.y,
                                  pos.z);

                node.transform.position = Vector3.Lerp(node.transform.position, pos, Time.deltaTime);

                i++;
                widthPrec = node.GetLayoutWidth();
                nodeWidth = widthPrec;
                node.LayoutNode();

            }else if (Tree.instance.align == LayoutAlign.CENTER)
            {
                pos = new Vector3(xOrigin + (i * nodeWidth), transform.position.y + Tree.instance.spacingY, transform.position.z);
                node.transform.position = pos;

                i++;

                node.LayoutNode();
            }
        }

        // Link With Parent
        
        if (parent != null)
        {
            line.SetPosition(0, transform.parent.position);
            line.SetPosition(1, transform.position);
        }       
    }
}
