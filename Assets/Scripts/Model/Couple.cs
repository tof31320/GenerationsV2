using UnityEngine;
using System.Collections;

public class Couple : MonoBehaviour {

    private Person _personA = null;
    public Person personA
    {
        get { return _personA; }
        set
        {
            _personA = value;
            if (_personA != null)
            {
                _personA.transform.parent = transform.parent;
            }
        }
    }

    private Person _personB = null;
    public Person personB
    {
        get { return _personB; }
        set
        {
            _personB = value;
            if (_personB != null)
            {
                _personB.transform.parent = transform.parent;
            }
        }
    }

	// Use this for initialization
	void Start () {

        if (transform.childCount >= 1)
        {
            personA = transform.GetChild(0).GetComponent<Person>();
        }
        if (transform.childCount >= 2)
        {
            personB = transform.GetChild(1).GetComponent<Person>();
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
