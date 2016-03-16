using UnityEngine;
using System.Collections;

public class Couple : MonoBehaviour {

    public float layoutWidth = 1f;

    public Person personA = null;
    [SerializeField]
    private Person _personB = null;
    public Person personB
    {
        get { return _personB; }
        set
        {            
            if (_personB != null)
            {
                _personB.visible = false;
            }
            _personB = value;
            if (_personB != null)
            {
                _personB.visible = true;
            }
        }
    }  

    public SpriteRenderer spriteRenderer;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();        
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
            personB.transform.position = Vector3.Lerp(personB.transform.position, 
                                                    new Vector3(personA.transform.position.x + layoutWidth,
                                                      personA.transform.position.y,
                                                      personA.transform.position.z), 
                                                    Time.deltaTime);
        }
    }

    public void Update()
    {
        Layout();
    }
}
