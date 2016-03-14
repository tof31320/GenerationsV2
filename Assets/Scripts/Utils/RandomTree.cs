using UnityEngine;
using System.Collections;

public class RandomTree : MonoBehaviour {

    public GameObject nodeGameObject;

    public Transform tree;

	// Use this for initialization
	void Start () {

        CreateNodeWithChildren(tree, 4);
	}	

    private Node CreateNodeWithChildren(Transform parent, int nbGenerations)
    {
        GameObject g = Instantiate(nodeGameObject, Vector3.zero, Quaternion.identity) as GameObject;
        g.transform.SetParent(parent);
        Node node = g.GetComponent<Node>();
        node.parent = parent.GetComponent<Node>();

        if (nbGenerations > 1)
        {
            int nbChildren = Random.Range(0, 6);
            for(int i = 0; i < nbChildren; i++)
            {
                CreateNodeWithChildren(node.transform, nbGenerations - 1);
            }
        }
        return node;
    }
}
