﻿using UnityEngine;
using System.Collections;

/// <summary>
/// Les types d'agencement possibles pour afficher l'arborecence de la famille
/// 
/// LEFT    : Le node parent est aligné à gauche, les nodes enfants placés en dessous et décalés vers la gauche
/// CENTER  : Pas implémenté
/// RIGHT   : Pas implémenté
/// </summary>
public enum LayoutAlign
{
    LEFT,
    CENTER,
    RIGHT
}

/// <summary>
/// Modélise l'arborescence d'une famille
/// </summary>
public class Tree : MonoBehaviour {

    /// <summary>
    /// Singleton (a revoir)
    /// </summary>
    private static Tree _instance = null;
    public static Tree instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindGameObjectWithTag("Tree").GetComponent<Tree>();
            }
            return _instance;
        }
    }

    /// <summary>
    /// Gestion de l'affichage de l'arborescence
    /// Espace horizontal entre deux nodes enfants
    /// </summary>
    public float spacingX = 0.5f;
    /// <summary>
    /// Espace vertical entre deux nodes (parent - enfants)
    /// </summary>
    public float spacingY = -3f;

    /// <summary>
    /// Type d'agencement sélectionné
    /// </summary>
    public LayoutAlign align = LayoutAlign.LEFT;

    /// <summary>
    /// Le 1er noeu (racine) 
    /// </summary>
    private Node _root = null;
    public Node root
    {
        get
        {
            return _root;
        }
        set
        {
            // On change de node racine
            _root = value;
            // On réarrange l'arborescence
            Layout();
        }
    }

    public void Start()
    {
        // Associe le node racine avec celui déjà au démarrage du jeu
        root = transform.GetChild(0).GetComponent<Node>();
    }

    /// <summary>
    /// Réarrange l'arborescence
    /// </summary>
    public void Layout()
    {
        if (node != null)
        {
            node.transform.position = transform.position;

            node.LayoutNode();
        }
    }    

    public void Update()
    {
        // Arrange l'arborescence à chaque frame (voir si c'est génant)
        // permet d'avoir l'effet de ralentissement
        Layout();
    }
}
