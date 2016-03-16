using UnityEngine;
using System.Collections;

public class Couple : MonoBehaviour {

    public float layoutWidth = 1f;

    public Person personA = null;
    [SerializeField]
    public Person personB = null;    

    public SpriteRenderer spriteRenderer;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        /*if (transform.parent != null)
        {
            personA = transform.parent.GetComponent<Person>();
        }
        if (transform.childCount > 0)
        {
            personB = transform.GetChild(0).GetComponent<Person>();
        }
        else
        {
            personB = null;
        }        */
    }

    public void Layout()
    {
        if (personB == null && spriteRenderer.enabled)
        {
            spriteRenderer.enabled = false;
        }
        else if(personB != null && !spriteRenderer.enabled)
        {
            spriteRenderer.enabled = true;                  
        }
        if (personA != null && spriteRenderer.enabled)
        {
            personB.transform.position = new Vector3(personA.transform.position.x + layoutWidth,
                                                      personA.transform.position.y,
                                                      personA.transform.position.z);
        }
    }

    public void Update()
    {
        Layout();
    }
}
