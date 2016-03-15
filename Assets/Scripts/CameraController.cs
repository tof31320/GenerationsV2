using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

/// <summary>
/// Controle de la camera pilotée automatiquement par le jeu
/// ou par la souris du joueur
/// </summary>
public class CameraController : MonoBehaviour
{
    /// <summary>
    /// Déplacer la camera (scrolling) si le pointeur se trouve dans les marges de l'écran
    /// </summary>
    public bool useBorders = true;
    /// <summary>
    /// Définition des marges de l'écran pour le scrolling (Left/Right, Top/Bottom)
    /// </summary>
    public Vector2 margin = new Vector2(10f, 10f);

    /// <summary>
    /// Vitesse de déplacement
    /// </summary>
    public float scrollSpeed = 1f;

    /// <summary>
    /// Activer ou non l'effet de ralentissement
    /// </summary>
    public bool useDampView = true;
    /// <summary>
    /// Paramètre pour l'effet de ralentissement (damping)
    /// </summary>
    public float damp = 1f;    

    /// <summary>
    /// Le point cible que vise la camera 
    /// </summary>
    public Vector3 view = new Vector3(0f, 0f, -10f);
    
    /// <summary>
    /// Valeur actuelle du Zoom
    /// </summary>
    public float zoomSize = 0f;
    public float ZOOM_MAX = 10;
    public float ZOOM_MIN = 1f;

    /// <summary>
    /// Activer ou non la gestion du glisser (dragging)
    /// </summary>
    public bool dragging = false;

    /// <summary>
    /// La position de la camera au début du glissé
    /// </summary>
    public Vector3 dragPosition = Vector3.zero;

    /// <summary>
    /// Déplacement relatif du glissé
    /// </summary>
    public Vector3 deltaMove = Vector3.zero;

    /// <summary>
    /// Caméra pilotée par le jeu (le joueur ne peut pas controler)
    /// </summary>
    public bool auto = false;

    void Start()
    {
        // initialise la valeur du zoom avec la valeur de la caméra
        zoomSize = GetComponent<Camera>().orthographicSize;
    }

    public void Update()
    {
        // Déplace la caméra vers sa cible (avec effet de ralentissement)
        transform.position = Vector3.Lerp(transform.position, view, damp);

        // Ajustement du zoom (avec effet de ralentissement)
        GetComponent<Camera>().orthographicSize = Mathf.Lerp(GetComponent<Camera>().orthographicSize, zoomSize, damp);

        // En pilotage automatique
        if (auto)
        {
            // Désactive le pilotage automatique si la caméra se trouve assez proche de son point cible
            if (Vector3.Distance(transform.position, view) < 0.1f)
            {                
                auto = false;
            }
        }

        // Si le pointeur sur un élément UI ou en pilotage automatique, on n'écoute pas les inputs du joueur
        if (EventSystem.current.IsPointerOverGameObject() || auto)
        {
            return;
        }

        // Gestion du Zoom
        if ((Input.GetKeyDown(KeyCode.Z) && zoomSize < ZOOM_MAX)
            || Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            ZoomIn();
        }
        else if ((Input.GetKeyDown(KeyCode.A) && zoomSize > ZOOM_MIN)
           || Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            ZoomOut();
        }

        // Gestion du déplacement de la caméra par glissé/déposé (dragging)
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
        {
            // Appuyé
            dragging = true;
            dragPosition = mouseWorldPosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            // Laché
            dragging = false;
        }

        if (dragging)
        {
            deltaMove = mouseWorldPosition - dragPosition;
            view = transform.position - deltaMove;
        }
    }

    /// <summary>
    /// Zoom vers le point cible
    /// </summary>
    public void ZoomIn()
    {
        zoomSize = Mathf.Clamp(zoomSize + 1, 1f, 10f);
    }

    /// <summary>
    /// Dézoome
    /// </summary>
    public void ZoomOut()
    {
        zoomSize = Mathf.Clamp(zoomSize - 1, 1f, 10f);
    }

    /// <summary>
    /// Déplacement automatique vers un élément du jeu
    /// </summary>
    /// <param name="person"></param>
    public void FocusOnNode(Person person)
    {
        auto = true;
        view = new Vector3(person.transform.position.x, person.transform.position.y, view.z);
    }
}