using System;
using UnityEngine;

public class TutorialWindow : MonoBehaviour
{
    [SerializeField] private PlayerMovement movementScript;
    [SerializeField] private MouseLock mouseScript;
    [SerializeField] private GameObject tutorialVisual;

    private const string TutorSeen = "TutorSeen";

    private void Awake()
    {
        if (PlayerPrefs.HasKey(TutorSeen))
        {
            StartView();
        }
    }

    public void StartView()
    {
        movementScript.enabled = true;
        mouseScript.enabled = true;
        tutorialVisual.SetActive(false);
        if (!PlayerPrefs.HasKey(TutorSeen))
        {
            PlayerPrefs.SetInt(TutorSeen, 1);
        }
    }
}