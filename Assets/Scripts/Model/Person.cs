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
    private Family _family = null;
    public Family family
    {
        get { return _family; }
        set
        {
            _family = value;
            if (_family != null)
            {
                transform.SetParent(_family.transform);
            }            
        }
    }

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
    /// La gestion de l'interface pour la personne
    /// </summary>
    public UIPerson ui;

    /// <summary>
    /// Affichage de l'avatar
    /// </summary>
    private SpriteRenderer spriteRenderer;

    /// <summary>
    /// Gestion des évènements de la souris
    /// </summary>
    private bool _isMouseOver = false;
    private Vector3 _defaultScale = Vector3.zero;
    private float _scaleEffectTime = 0.6f;
    private Vector3 _amountMouseOver = new Vector3(0.2f, 0.2f, 0.2f);

    /// <summary>
    /// Est-ce que cette personne est la
    /// </summary>
    public bool selected
    {
        get
        {
            return GameController.instance.personSelected == this;
        }
        set
        {
            if (value)
            {
                GameController.instance.personSelected = this;
            }
            else if(GameController.instance.personSelected == this)
            {
                GameController.instance.personSelected = null;
            }            
        }
    }

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
            ui.gameObject.SetActive(_visible);
            spriteRenderer.enabled = _visible;
        }
    }

    public void Awake()
    {
        // Associe les composants
        ui = GetComponentInChildren<UIPerson>();

        couple = GetComponentInChildren<Couple>();
        couple.personA = this;
        couple.personB = null;

        spriteRenderer = GetComponent<SpriteRenderer>();

        // Inscription de l'objet au refresh du jeu
        GameSpeedController.instance.onUpdateGame += UpdateGame;

        _defaultScale = transform.localScale;        
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

    public void UpdateGame()
    {
        //Debug.Log(this + "UpdateGame()");
    }

    public void Update()
    {        
        if (_isMouseOver)
        {
            //iTween.PunchScale(gameObject, new Vector3(10f, 1f, 1f), Time.deltaTime);
            transform.localScale = Vector3.Lerp(transform.localScale, _defaultScale + _amountMouseOver, _scaleEffectTime);
        }
        else
        {
            transform.localScale = Vector3.Lerp(transform.localScale, _defaultScale, _scaleEffectTime);
        }        
    }

    public void OnMouseEnter()
    {
        _isMouseOver = true;        
    }

    public void OnMouseExit()
    {
        _isMouseOver = false;        
    }

    public void OnMouseDown()
    {
        GameController.instance.personSelected = this;
    }
}
