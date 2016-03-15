using UnityEngine;
using System.Collections;

/// <summary>
/// Modélise un couple de deux personnes
/// </summary>
public class Couple : MonoBehaviour {

    /// <summary>
    /// 1ere personne du couple
    /// </summary>
    private Person _personA = null;
    public Person personA
    {
        get { return _personA; }
        set
        {
            _personA = value;
            if (_personA != null)
            {
                // Déplace la personne dans la hierarchie de la scene
                _personA.transform.parent = transform.parent;
            }
        }
    }

    /// <summary>
    /// 2e personne du couple
    /// </summary>
    private Person _personB = null;
    public Person personB
    {
        get { return _personB; }
        set
        {
            _personB = value;
            if (_personB != null)
            {
                // Déplace la personne dans la hierarchie de la scene
                _personB.transform.parent = transform.parent;
            }
        }
    }

	// Use this for initialization
	void Start () {

        // Recherche les éventuelles personnes formant le couple à la création 
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
