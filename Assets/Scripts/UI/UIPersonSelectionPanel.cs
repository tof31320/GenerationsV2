using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIPersonSelectionPanel : UIMenu {

    public List<Person> persons = null;

    public int currentIndex = 0;

    public Text titleText;

    public Image personAvatar;
    public Text personName;

    public Person currentPersonSelected
    {
        get
        {
            if (currentIndex >= persons.Count)
            {
                return null;
            }
            return persons[currentIndex];
        }
    }

    private string _title = "";
    public string title
    {
        get { return _title; }
        set
        {
            _title = value;

            titleText.text = _title;
        }
    }

    /// <summary>
    /// Les actions déléguées possibles lorsque le joueur clique sur OK
    /// </summary>
    public delegate void OnValidatePersonSelection(Person person);
    public OnValidatePersonSelection onValidatePersonSelection;

    public void UpdatePanel()
    {
        Person currentPerson = currentPersonSelected;
        if (currentPerson != null)
        {
            personAvatar.gameObject.SetActive(true);
            personAvatar.sprite = currentPerson.avatar;
            personName.text = currentPerson.firstname + " " + currentPerson.family.lastname;
        }
        else
        {
            personAvatar.gameObject.SetActive(false);
            personName.text = "Aucune personne !";
        }
    }

    private bool _dataLoaded = false;
    public void LoadAllPersons()
    {
        persons = new List<Person>();

        foreach(Family family in GameController.instance.families)
        {
            persons.AddRange(family.persons);
        }

        _dataLoaded = true;
    }

    public void PreviousButtonClick()
    {
        if (currentIndex > 0)
        {
            currentIndex--;

            UpdatePanel();
        }
    }

    public void NextButtonClick()
    {
        if (currentIndex < persons.Count - 1)
        {
            currentIndex++;

            UpdatePanel();
        }
    }

    public void ValidateButtonClick()
    {
        if (onValidatePersonSelection != null && currentPersonSelected != null)
        {
            onValidatePersonSelection(currentPersonSelected);
        }        
    }
}
