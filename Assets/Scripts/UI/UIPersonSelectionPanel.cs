using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UIPersonSelectionPanel : UIMenu {

    public List<Person> persons = null;

    public Person personSelected;

    public Text titleText;

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
}
