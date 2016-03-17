using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;

public class UIGameSpeedBar : MonoBehaviour
{
    public Slider speedSlider;

    public Button moreSpeedButton;

    public Button lessSpeedButton;

    public Button playPauseButton;

    public Text speedText;

    public Text dateText;

    public void Update()
    {
        GameSpeedController gameSpeed = GameSpeedController.instance;

        // Met à jour le slider avec la vitesse actuelle du jeu
        speedSlider.value = Mathf.Lerp(speedSlider.value,
                                        (1f - ((float)(gameSpeed.nbSpeedsMax - gameSpeed.speed) / (float)gameSpeed.nbSpeedsMax)), 
                                        Time.deltaTime);        

        // Boutons pour régler la vitesse + / - 
        moreSpeedButton.interactable = gameSpeed.speed < gameSpeed.nbSpeedsMax;
        lessSpeedButton.interactable = gameSpeed.speed > 1;

        // Affiche la date courant
        dateText.text = gameSpeed.currentDate.ToString("d", CultureInfo.CreateSpecificCulture("fr-FR"));

        // Affiche la vitesse actuelle du jeu
        speedText.text = gameSpeed.speed + "";
    }

    /// <summary>
    /// Met en pause si le jeu est en cours 
    /// ou bien remet en jeu si le jeu est en pause
    /// </summary>
    public void TogglePause()
    {
        GameSpeedController.instance.pause = !GameSpeedController.instance.pause;            
    }

    /// <summary>
    /// Passe à une vitesse supérieure
    /// </summary>
    public void MoreSpeed()
    {
        GameSpeedController.instance.speed++;
    }

    /// <summary>
    /// Ralentit la vitesse du jeu
    /// </summary>
    public void LessSpeed()
    {
        GameSpeedController.instance.speed--;
    }
}

