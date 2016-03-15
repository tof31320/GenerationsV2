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

	// Use this for initialization
	void Start () {
	    // Au démarrage du jeu
	}
	
	// Update is called once per frame
	void Update () {
	    
	}
}
