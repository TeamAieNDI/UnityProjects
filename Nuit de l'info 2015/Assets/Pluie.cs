using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Pluie : MonoBehaviour {

    List<Sprite> _images;
    Image ImageComp;
    int indice;
    bool skip;

    void Awake()
    {
        skip = false;
        indice = 0;
        _images = new List<Sprite>();
        _images.Add(Resources.Load<Sprite>("IMG/pluie1"));
        _images.Add(Resources.Load<Sprite>("IMG/pluie2"));
        _images.Add(Resources.Load<Sprite>("IMG/pluie3"));
        _images.Add(Resources.Load<Sprite>("IMG/pluie4"));

        ImageComp = GetComponent<Image>();
        ImageComp.sprite = _images[0];
    }
    void Update()
    {
        if (skip)
        {
            skip = false;
            return;
        }
        else
        {
            skip = true;
        }
        indice++;
        if (indice == _images.Count) indice = 0;

        ImageComp.sprite = _images[indice];
    }

	
}
