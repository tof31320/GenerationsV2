using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Il s'agit d'un élément de l'arborescence de la famille 
/// il peut s'agir d'une personne ou d'un couple
/// un node est toujours associé à un node parent et peut avoir plusieurs nodes enfants
/// </summary>
[RequireComponent(typeof(LineRenderer))]
public class Node : MonoBehaviour {

    /// <summary>
    /// Le parent 
    /// </summary>    
    public Node parent = null;   

    /// <summary>
    /// A quelle génération appartient le node
    /// </summary>
    public int generation = 0;

    /// <summary>
    /// Les nodes enfants
    /// </summary>
    public List<Node> children = new List<Node>();

    /// <summary>
    /// Gestion de l'affichage du node à l'écran (layout) 
    /// Largeur et Hauteur    
    /// </summary>
    public float layoutWidth = 1f;
    public float layoutHeight = 1f;

    /// <summary>
    /// Les liens affichés avec le parents
    /// </summary>
    public List<LineRenderer> links;

    public LineRenderer line;

    /// <summary>
    /// La personne associée au node
    /// </summary>
    public Person person;

    /// <summary>
    /// ??
    /// </summary>
    private float nodeWidth = 0f;

    /// <summary>
    /// Les paramètres d'affichage propres au node
    /// </summary>
    public LayoutParams layoutParams;

    public bool useITween = false;

    public void Start()
    {
        // Le node parent est toujours le parent dans la hierarchie du jeu (scene)
        //parent = transform.parent.GetComponent<Node>();

        layoutParams = GetComponent<LayoutParams>();
        person = GetComponent<Person>();
        line = GetComponent<LineRenderer>();
        line.SetWidth(0.1f, 0.1f);

        // Associe les nodes enfants déjà présents dans la hierarchie du jeu (scene)
        //children = new List<Node>();
        /*for(int i = 0; i < transform.childCount; i++)
        {
            Node n = transform.GetChild(i).GetComponent<Node>();
            if (n != null)
            {
                children.Add(n);
            }    
        }*/
    }    

    /// <summary>
    /// Calcule la largeur qu'il faut réserver pour afficher le node à l'écran
    /// La largeur est trouvée à partir de largeur totales des nodes enfants 
    /// Il s'agit d'une méthode appelée récursivement
    /// </summary>
    /// <returns></returns>
    public float GetLayoutWidth()
    {
        // La taille "atomique" du node (sans enfants)
        float width = layoutWidth + Tree.instance.spacingX;

        // Plus large pour le node Couple
        if (person != null && person.GetPersonCouple() != null)
        {
            width += layoutWidth;
        }

        // Calcule la taille des nodes enfants
        float childrenWidth = 0f;
        foreach(Node node in children)
        {
            childrenWidth += node.GetLayoutWidth();
        }

        // Si la taille des enfants est plus grande que celle du noeu
        if (childrenWidth > width)
        {
            return childrenWidth;
        }

        // sinon, il s'agit de la taille du noeu (le noeu a au max 1 enfant)
        return width;
    }

    /// <summary>
    /// Arragement des nodes enfants en fonction du node parent
    /// </summary>
    public void LayoutNode()
    {
        // Largeur totale du noeud parent avec ses enfants
        float width = GetLayoutWidth();
    
        // Largeur proportionnelle entre deux enfants
        float nodeWidth = width / children.Count;
                        
        // 1ere position du 1er enfant : situé juste en dessous du node 
        Vector3 pos = new Vector3(transform.position.x, transform.position.y + Tree.instance.spacingY, transform.position.z);           

        int i = 0;

        // La taille du node enfant précédent
        float widthPrec = 0f;

        foreach(Node node in children)
        {              
            // Calcule la position du node enfant à partir de la position node enfant précédent
            pos = new Vector3(pos.x + widthPrec + (i > 0 ? Tree.instance.spacingX : 0),
                              pos.y,
                              pos.z);

            // Positionne le node enfant avec un effet de ralentissement           
            node.transform.position = Vector3.Lerp(node.transform.position, pos, Time.deltaTime);                        

            // Passe au node suivant
            i++;
            widthPrec = node.GetLayoutWidth();
            nodeWidth = widthPrec;

            // On fait de même pour tous les enfants du node enfant (récursif)
            node.LayoutNode();
        }
        
        // Dessine la ligne vers le node parent        
        if (parent != null)
        {
            Vector3[] positions = new Vector3[2]
            {
                parent.transform.position,
                transform.position
            };
            if (line != null)
            {
                line.SetPosition(0, positions[0]);
                line.SetPosition(1, positions[1]);
            }            
        }    
    }    
}
