using UnityEngine;
using System.Collections;

public class RandomFamily : MonoBehaviour {

    public GameObject personPrefab;

    public Family family;

    public int nbGenerations = 4;
    public int nbChildrenMax = 4;

    public Tree tree;

	public void Start()
    {
        family = GetComponent<Family>();

        tree = GetComponent<Tree>();

        Person root = CreatePerson(null, nbGenerations);
        if (tree != null && root != null)
        {
            tree.root = root.GetComponent<Node>();
        }
    }

    public Person CreatePerson(Person parent, int generation)
    {
        GameObject g = Instantiate(personPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        if (parent != null)
        {
            g.transform.SetParent(parent.transform);
        }
        else
        {
            g.transform.SetParent(transform);
        }

        Node node = g.GetComponent<Node>();
        if (parent != null) { 
            node.parent = parent.GetComponent<Node>();
        }

        Person person = g.GetComponent<Person>();
        person.family = family;

        if (generation > 1)
        {
            int nbChildren = Random.Range(0, nbChildrenMax);
            for (int i = 0; i < nbChildren; i++)
            {
                CreatePerson(person, generation - 1);
            }
        }

        return person;
    }
}
