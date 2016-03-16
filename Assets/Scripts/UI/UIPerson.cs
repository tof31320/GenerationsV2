using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Interface propre à une personne
/// </summary>
public class UIPerson : MonoBehaviour {

    /// <summary>
    /// La personne 
    /// </summary>
    public Person person;

    /// <summary>
    /// Nom et prénom de la personne
    /// </summary>
    public Text txtName;

	// Use this for initialization
	void Start () {
        person = GetComponentInParent<Person>();
	}
	
	// Update is called once per frame
	void Update () {

        txtName.text = person.firstname;
	}
}
