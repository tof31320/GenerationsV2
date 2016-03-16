using UnityEngine;
using System.Collections;

/// <summary>
/// Garcon ou fille
/// </summary>
public enum Sexe
{
    MALE,
    FEMALE
}

/// <summary>
/// Modélise une personne du jeu
/// </summary>
public class Person : MonoBehaviour
{
    /// <summary>
    /// Identifiant unique dans le jeu
    /// </summary>
    public long id = 0;

    /// <summary>
    /// La famille du personnage
    /// </summary>
    public Family family;

    /// <summary>
    /// Le prénom
    /// </summary>
    public string firstname = null;

    /// <summary>
    /// Garçon ou fille
    /// </summary>
    public Sexe sexe = Sexe.MALE;

    /// <summary>
    /// Si la personne est en couple
    /// </summary>
    public Couple couple = null;

    /// <summary>
    /// Numéro du tour de jeu durant lequel la personne est née
    /// </summary>
    public int birthDate = 0;

    /// <summary>
    /// Avatar de la personne affiché dans le jeu
    /// </summary>
    private Sprite _avatar = null;
    public Sprite avatar
    {
        get { return _avatar; }
        set
        {
            _avatar = value;            
            spriteRenderer.sprite = _avatar;
        }
    }

    /// <summary>
    /// Affichage de l'avatar
    /// </summary>
    private SpriteRenderer spriteRenderer;

    /// <summary>
    /// Gestion de la visibilité de l'avatar dans le jeu
    /// </summary>
    [SerializeField]
    private bool _visible = true;
    public bool visible
    {
        get { return _visible; }
        set
        {
            _visible = value;
            spriteRenderer.enabled = _visible;
        }
    }

    public void Awake()
    {
        couple = GetComponentInChildren<Couple>();
        couple.personA = this;
        couple.personB = null;

        spriteRenderer = GetComponent<SpriteRenderer>();
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
            couple.personA = this;
            couple.personB = person;
        }        
    }

    public Person GetPersonCouple()
    {
        return couple.personB;
    }

    public void OnMouseOverTrigger()
    {
        /*iTween.PunchScale(gameObject, iTween.Hash(
            "amount", new Vector3(2f, 2f, 2f),
            "time", Time.deltaTime
            ));*/        
    }

    public void OnMouseExitTrigger()
    {

    }
}
