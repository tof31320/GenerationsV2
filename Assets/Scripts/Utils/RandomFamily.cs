using UnityEngine;
using System.Collections;

/// <summary>
/// Classe utilitaire pour la génération automatique d'une famille
/// </summary>
public class RandomFamily : MonoBehaviour {

    public static string[] maleNames = { "Louis", "Martin", "Jean", "Albert", "Franck", "Joseph", "Emile", "Paul", "Léon", "Pascal", "François" };
    public static string[] femaleNames = { "Erika", "Jeanne", "Martine", "Louise", "France", "Joan", "Emilie", "Véra", "Léa", "Pascaline", "Anne"};

    /// <summary>
    /// Les infos sur la famille
    /// </summary>
    public Family family;

    /// <summary>
    /// Combien de générations maximum à créer
    /// </summary>
    public int nbGenerations = 4;

    /// <summary>
    /// Combien d'enfants maximum par couple
    /// </summary>
    public int nbChildrenMax = 4;

    /// <summary>
    /// Arborescence de la famille du joueur
    /// </summary>
    public Tree tree;

    /// <summary>
    /// Indique si on génère une famille visible
    /// </summary>
    public bool visible = true;

	public void Start()
    {
        family = GetComponent<Family>();
        tree = GetComponent<Tree>();

        Person root = CreatePerson(null, nbGenerations);
        if (tree != null && root != null)
        {
            tree.root = root.GetComponent<Node>();
        }
    }

    public Person CreatePerson(Person parent, int generation, Sexe sexe = Sexe.MALE)
    {
        GameObject g = Instantiate(GameController.instance.personPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        if (parent != null)
        {
            g.transform.SetParent(parent.transform);
        }
        else
        {
            g.transform.SetParent(transform);
        }

        Node node = g.GetComponent<Node>();
        if (parent != null) { 
            node.parent = parent.GetComponent<Node>();
        }

        Person person = g.GetComponent<Person>();
        // Infos propres de la personne
        person.family = family;
        person.sexe = sexe;
        person.firstname = RandomFirstname(person.sexe);
        
        // Met à jour l'avatar
        if (person.sexe == Sexe.FEMALE)
        {
            person.avatar = GameController.instance.defaultFemaleAvatarSprite;
        }
        else
        {
            person.avatar = GameController.instance.defaultMaleAvatarSprite;
        }

        // Affiche ou pas la personne dans le jeu
        person.visible = visible;

        // On créer les enfants par récursivité
        if (generation > 1)
        {
            int nbChildren = Random.Range(0, nbChildrenMax);
            for (int i = 0; i < nbChildren; i++)
            {
                CreatePerson(person, generation - 1, RandomSexe());
            }
        }

        g.name = person.firstname + "_" + family.lastname;

        return person;
    }    

    public Sexe RandomSexe()
    {
        int val = Random.Range(0, 2);

        if (val < 1f)
        {
            return Sexe.MALE;
        }
        else
        {
            return Sexe.FEMALE;
        }
    }

    public string RandomFirstname(Sexe sexe = Sexe.MALE)
    {
        string[] names = null;
        if (sexe == Sexe.MALE)
        {
            names = maleNames;
        }
        else
        {
            names = femaleNames;
        }

        int index = Random.Range(0, names.Length);

        return names[index];
    }
}
