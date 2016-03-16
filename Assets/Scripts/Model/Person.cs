using UnityEngine;
using System.Collections;

/// <summary>
/// Modélise une personne du jeu
/// </summary>
public class Person : MonoBehaviour
{
    /// <summary>
    /// La famille du personnage
    /// </summary>
    public Family family;

    /// <summary>
    /// Le prénom
    /// </summary>
    public string firstname = null;

    /// <summary>
    /// Si la personne est en couple
    /// </summary>
    public Couple couple = null;

    public void Awake()
    {
        couple = GetComponentInChildren<Couple>();
        couple.personA = this;
        couple.personB = null;
    }

    /// <summary>
    /// Permet d'unir la personne avec une autre au travers d'un élément Couple
    /// Pour désunir la personne et la rendre célibataire, person == null
    /// </summary>
    /// <param name="person">La personne en couple ou null</param>
    public void SetCoupleWith(Person person)
    {       
        if (person == null)
        {
            // Si pas de personne donnée, on rend la personne célibataire
            couple.personB = null;
        }
        else
        {
            // En couple avec la personne argument
            Debug.Log("SetCoupleWith: " + person);
            couple.personA = this;
            couple.personB = person;
        }        
    }

    public Person GetPersonCouple()
    {
        return couple.personB;
    }
}
