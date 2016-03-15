using UnityEngine;
using System.Collections;

/// <summary>
/// Gestionnaire principale de l'interface utilisateur
/// </summary>
public class UIManager : MonoBehaviour {

    /// <summary>
    /// Singleton
    /// </summary>
    private static UIManager _instance = null;
    public static UIManager instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindGameObjectWithTag("UIManager").GetComponent<UIManager>();
            }
            return _instance;
        }
    }    
}
