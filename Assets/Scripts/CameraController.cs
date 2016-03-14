using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class CameraController : MonoBehaviour
{

    public Vector2 margin = new Vector2(10f, 10f);

    public float scrollSpeed = 1f;

    public float damp = 1f;

    //private Vector3 direction = Vector3.zero;
    public Vector3 view = new Vector3(0f, 0f, -10f);
    public bool useBorders = true;
    public bool useDampView = true;

    public float zoomSize = 0f;

    public bool dragging = false;
    public Vector3 dragPosition = Vector3.zero;
    public Vector3 deltaMove = Vector3.zero;

    public bool auto = false;

    void Start()
    {
        zoomSize = GetComponent<Camera>().orthographicSize;
    }

    public void Update()
    {
        transform.position = Vector3.Lerp(transform.position, view, damp);
        GetComponent<Camera>().orthographicSize = Mathf.Lerp(GetComponent<Camera>().orthographicSize, zoomSize, damp);
        if (auto)
        {
            if (Vector3.Distance(transform.position, view) < 0.1f)
            {
                auto = false;
            }
        }
        if (EventSystem.current.IsPointerOverGameObject() || auto)
        {
            return;
        }

        // Zoom
        if ((Input.GetKeyDown(KeyCode.Z) && zoomSize < 10f)
            || Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            ZoomIn();

        }
        else if ((Input.GetKeyDown(KeyCode.A) && zoomSize > 1f)
           || Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            ZoomOut();
        }

        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            dragging = true;
            dragPosition = mouseWorldPosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
        }

        if (dragging)
        {
            deltaMove = mouseWorldPosition - dragPosition;
            view = transform.position - deltaMove;
        }
    }

    public void ZoomIn()
    {
        zoomSize = Mathf.Clamp(zoomSize + 1, 1f, 10f);
    }

    public void ZoomOut()
    {
        zoomSize = Mathf.Clamp(zoomSize - 1, 1f, 10f);
    }

    public void FocusOnNode(Person person)
    {
        auto = true;
        view = new Vector3(person.transform.position.x, person.transform.position.y, view.z);
    }
}