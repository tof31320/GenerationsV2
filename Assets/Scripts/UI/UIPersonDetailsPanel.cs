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

    /// <summary>
    /// La barre de santé
    /// </summary>
    public Slider healthSlider;

    public void UpdatePanel()
    {
        if (person == null)
        {
            return;
        }
        avatarImage.sprite = _person.avatar;

        title.text = _person.firstname + " " + _person.family.name;

        healthSlider.value = _person.health / 100.0f;
    }    

    public void ShowPersonDetails(Person person)
    {
        this.person = person;

        Show();
    }

    public void UnionActionButtonClick()
    {
        UIManager.instance.personSelectionPanel.title = "Sélectionnez le couple";
        UIManager.instance.personSelectionPanel.LoadAllPersons();
        UIManager.instance.personSelectionPanel.onValidatePersonSelection = OnValidateSelectionPerson;
        UIManager.instance.personSelectionPanel.UpdatePanel();
        UIManager.instance.personSelectionPanel.Show();
    }

    public void MakeAChildButtonClick()
    {
        RandomFamily randomUtils = person.family.GetComponent<RandomFamily>();

        Person baby = randomUtils.CreatePerson(person, 1, randomUtils.RandomSexe());

        GameController.instance.cameraController.FocusOnNode(baby);
    }

    public void OnValidateSelectionPerson(Person personSelected)
    {        
        UIManager.instance.personSelectionPanel.Close();

        if (person != null)
        {
            // Création du couple
            person.SetCoupleWith(personSelected);
        }
    }
}