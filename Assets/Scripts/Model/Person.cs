﻿using UnityEngine;
using System.Collections;

/// <summary>
/// Modélise une personne du jeu
/// </summary>
public class Person : MonoBehaviour
{
    /// <summary>
    /// La famille du personnage
    /// </summary>
    public Family family;

    /// <summary>
    /// Le prénom
    /// </summary>
    public string firstname = null;

    /// <summary>
    /// Si la personne est en couple
    /// </summary>
    public Couple couple = null;

    public void Start()
    {
        couple = GetComponentInChildren<Couple>();
    }
}
