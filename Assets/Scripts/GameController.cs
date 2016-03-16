using UnityEngine;
using System.Collections;

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

    // Prefabs 
    public GameObject linkPrefab;
    public GameObject personPrefab;

    // Sprites
    public Sprite defaultMaleAvatarSprite;
    public Sprite defaultFemaleAvatarSprite;

    public Person player;
    public Person personToUnion;

    // Use this for initialization
    void Start () {
	    // Au démarrage du jeu
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.U))
        {
            player.SetCoupleWith(personToUnion);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            player.SetCoupleWith(null);
        }
	}
}
