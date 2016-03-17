using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// Chargé de controller la vitesse de déroulement du jeu
/// Il y a 4 vitesses de jeu possibles
/// Gère aussi le temps de jeu
/// </summary>
public class GameSpeedController : MonoBehaviour
{
    /// <summary>
    /// Singleton et accessible depuis le controleur principal du jeu
    /// </summary>
    private static GameSpeedController _instance = null;
    public static GameSpeedController instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameSpeedController>();
            }
            return _instance;
        }
    }

    /// <summary>
    /// Quand commence le jeu (début d'une nouvelle partie fixé le 1er janvier 1600)
    /// </summary>
    public DateTime currentDate = new DateTime(1600, 1, 1);

    /// <summary>
    /// Vitesse actuelle du jeu (1 à 4)
    /// </summary>
    public int speed = 1;

    /// <summary>
    /// Combien de vitesses il est possible de sélectionner
    /// </summary>
    public int nbSpeedsMax = 4;

    private float _speedPerTime = 4f;

    /// <summary>
    /// Si le jeu est pause ou pas
    /// </summary>
    public bool pause = false;

    /// <summary>
    /// La dernière fois que le jeu à été mis à jour
    /// </summary>
    private float _lastUpdateTime = 0f;

    /// <summary>
    /// Appelée à chaque mise à jour du jeu (selon la vitesse sélectionné)
    /// Les éléments du jeu peuvent s'inscrire à cette mise à jour
    /// </summary>
    public delegate void UpdateGame();
    public UpdateGame onUpdateGame;

    public void Start()
    {
        onUpdateGame += OnUpdateGameDefault;
    }

    public void Update()
    {
        if (pause)
        {
            return;
        }
        else
        {
            if (Time.time - _lastUpdateTime > (nbSpeedsMax - speed + 1))
            {
                _lastUpdateTime = Time.time;

                if (onUpdateGame != null) {
                    onUpdateGame();
                }
            }
        }
    }    

    public void OnUpdateGameDefault()
    {
        currentDate = currentDate.AddDays(1);        
    }
}

