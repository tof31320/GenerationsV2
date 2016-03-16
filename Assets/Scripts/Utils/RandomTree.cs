using UnityEngine;
using System.Collections;

public class RandomTree : MonoBehaviour {

    public GameObject personGameObject;

    public Tree tree;

	// Use this for initialization
	void Start () {
        tree = GetComponent<Tree>();

        tree.root = CreateNodeWithChildren(tree.transform, 3);
        tree.root.gameObject.name = "Root";     
	}	

    private Node CreateNodeWithChildren(Transform parent, int nbGenerations)
    {
        GameObject g = Instantiate(personGameObject, Vector3.zero, Quaternion.identity) as GameObject;
        g.transform.SetParent(parent);
        Node node = g.GetComponent<Node>();
        node.parent = parent.GetComponent<Node>();

        Person person = g.GetComponent<Person>();
        if (nbGenerations == 3)
        {
            person.SetCoupleWith(RandomPerson(tree.transform));
        }

        if (nbGenerations > 1)
        {
            int nbChildren = Random.Range(0, 4);
            for(int i = 0; i < nbChildren; i++)
            {
                CreateNodeWithChildren(node.transform, nbGenerations - 1);
            }
        }
        return node;
    }

    public Person RandomPerson(Transform parent)
    {
        GameObject g = Instantiate(personGameObject, Vector3.zero, Quaternion.identity) as GameObject;
        g.name = "RandomPerson";
        g.transform.SetParent(parent);
        Node node = g.GetComponent<Node>();
        node.parent = parent.GetComponent<Node>();
        Person person = g.GetComponent<Person>();
        return person;
    }
}
