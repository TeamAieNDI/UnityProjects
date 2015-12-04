using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BadEnd : MonoBehaviour
{

    void Awake()
    {
        God.Get.RecupDialogue();
        God.Get.DialogueBoxSetActive(new List<string>()
        {
            ":(", ""
        }, () => { Application.LoadLevel("01-MenuPrincipal"); return true; });
    }
}
