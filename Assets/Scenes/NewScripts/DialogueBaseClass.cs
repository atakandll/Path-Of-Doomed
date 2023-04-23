﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{
    public class DialogueBaseClass : MonoBehaviour
    {
        protected IEnumerator WriteText(string input, Text textHolder, Color textColor, Font textFont, float delay, AudioClip sound) // text holderın amacı take each letter from the ınput string ve bunu loop döngüsü içinde yapıyor

        {
            textHolder.color = textColor;
            SoundManager.instance.PlaySound(sound);
            textHolder.font = textFont;

            for (int i = 0; i < input.Length; i++)
            {
                textHolder.text += input[i];
                yield return new WaitForSeconds(0.1f);

            }

        }

    }

}

