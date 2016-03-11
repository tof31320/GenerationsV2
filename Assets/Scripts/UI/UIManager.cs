using UnityEngine;
using System.Collections;

public class UIManager : MonoBehaviour {

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

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
