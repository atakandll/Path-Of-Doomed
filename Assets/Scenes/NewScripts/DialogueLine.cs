using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{
    public class DialogueLine : DialogueBaseClass
    {
        private Text textHolder;

        [Header("Text Options")]
        [SerializeField] private string input;

        [SerializeField] private Color textColor;
        [SerializeField] private Font textFont;

        [Header("Text Options")]
        [SerializeField] private float delay;

        [Header("Sound Options")]
        [SerializeField] private AudioClip sound;


        private void Awake()
        {
            textHolder = GetComponent<Text>();
            StartCoroutine(WriteText(input, textHolder, textColor, textFont, delay, sound));
        }

    }


}

