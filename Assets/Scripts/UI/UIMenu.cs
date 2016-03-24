using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Animator))]
public class UIMenu : MonoBehaviour {
        
    private bool _visible = false;

    [SerializeField]
    public bool visible
    {
        get { return _visible; }
        set
        {
            _visible = value;

            animator.SetBool("visible", _visible);            
        }
    }

    public Animator animator;

    public void Awake()
    {
        animator = GetComponent<Animator>();
    }	    

    public void Show()
    {
        visible = true;
    }

    public void Close()
    {
        visible = false;
    }
}
