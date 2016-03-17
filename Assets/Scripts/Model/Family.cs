using UnityEngine;
using System.Collections;

/// <summary>
/// Modélise une famille de personnnes du jeu
/// Le jeu contient plusieurs famille. Le joueur est toujours associé à une famille
/// </summary>
public class Family : MonoBehaviour {

    /// <summary>
    /// Gestion de l'identifiant des familles
    /// </summary>
    private static int _nextId = 1;
    public static int nextId
    {
        get
        {
            return _nextId++;
        }
        set
        {
            _nextId = value;
        }
    }

    /// <summary>
    /// Identifiant unique dans le jeu
    /// </summary>
    public long id = 0;

    /// <summary>
    /// Nom de famille
    /// </summary>
    public string lastname = "";

    /// <summary>
    /// Le patriarche qui a fondé la famille
    /// </summary>
    public Person root;

    public void Awake()
    {
        id = Family.nextId;
    }
}
