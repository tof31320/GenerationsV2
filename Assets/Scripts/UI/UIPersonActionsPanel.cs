using UnityEngine;
using UnityEngine.UI;
using System.Collections;

/// <summary>
/// Gère les boutons actions affichés lorsque le perso est sélectionné
/// </summary>
public class UIPersonActionsPanel : MonoBehaviour {

    /// <summary>
    /// Le personnage associé
    /// </summary>
    public Person person;

    #region Actions buttons
    /// <summary>
    /// Le joueur souhaite unir le perso à un autre
    /// </summary>    
    public Button unionButton;

    /// <summary>
    /// Affiche les détails du perso
    /// </summary>
    public Button moreDetailsButton;
    #endregion

    void Start()
    {       
    }

    public void Open()
    {

    }

    public void Close()
    {

    }
    	
	// Update is called once per frame
	void Update () {
	
	}

    public void UnionButtonClick()
    {
        Debug.Log("Union de " + person);
    }

    public void MoreDetailsButtonClick()
    {
        Debug.Log("Détails de " + person);
    }
}
