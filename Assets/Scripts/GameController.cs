using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Gestion principale du jeu
/// </summary>
public class GameController : MonoBehaviour {

    /// <summary>
    /// Singleton, accessible facilement dans tous les scripts
    /// </summary>
    private static GameController _instance = null;
    public static GameController instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
            }
            return _instance;                    
        }
    }

    #region PREFABS
    public GameObject linkPrefab;
    public GameObject personPrefab;
    #endregion

    #region SPRITES
    // Sprites
    public Sprite defaultMaleAvatarSprite;
    public Sprite defaultFemaleAvatarSprite;
    #endregion

    #region MODEL
    /// <summary>
    /// Le personnage qu'incarne actuellement le joueur
    /// </summary>
    public Person player;

    /// <summary>
    ///  Toutes les familles en jeu
    /// </summary>
    public List<Family> families = new List<Family>();

    /// <summary>
    /// Toutes les personnes en jeu
    /// </summary>
    public List<Person> persons = new List<Person>();

    /// <summary>
    /// La personne actuellement sélectionnée par le joueur
    /// </summary>
    public Person personSelected = null;
    #endregion

    // Use this for initialization
    void Start () {
        // Au démarrage du jeu
        LoadFamilies();
	}

    /// <summary>
    /// Recharge la liste des familles en jeu à partir des objets chargés 
    /// </summary>
    public void LoadFamilies()
    {
        families = new List<Family>();

        GameObject[] gos = GameObject.FindGameObjectsWithTag("Family");
        for(int i = 0; i < gos.Length; i++)
        {
            Family family = gos[i].GetComponent<Family>();
            if (family != null)
            {
                families.Add(family);
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
       
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
	}
}
