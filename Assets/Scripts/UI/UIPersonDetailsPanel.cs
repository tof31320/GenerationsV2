using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIPersonDetailsPanel : UIMenu {

    private Person _person = null;
    public Person person
    {
        get { return _person; }
        set
        {
            _person = value;

            UpdatePanel();
        }
    }

    /// <summary>
    /// Avatar du personnage
    /// </summary>
    public Image avatarImage;

    /// <summary>
    /// Identité 
    /// </summary>
    public Text title;

    public void UpdatePanel()
    {
        if (person == null)
        {
            return;
        }
        avatarImage.sprite = _person.avatar;

        title.text = _person.firstname + " " + _person.family.name; 
    }    

    public void ShowPersonDetails(Person person)
    {
        this.person = person;

        Show();
    }
}