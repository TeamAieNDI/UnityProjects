using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Ruche : MonoBehaviour {

    int _population;
    public bool EstAuSol;
    Image _image;
    Etat _state;
    Text _text;
    Button _button;
    Secours[] _secours;
    bool devoileMenu;

    bool IsDead
    {
        get
        {
            return _population <= 0;
        }
    }

    void DevoileMenu()
    {
        if(devoileMenu)
        {
            foreach (var secour in _secours)
            {
                secour.gameObject.SetActive(true);
            }
            devoileMenu = false;
        }
        else
        {
            foreach (var secour in _secours)
            {
                secour.gameObject.SetActive(false);
            }
            devoileMenu = true;
        }
        
    }
    

    void Awake()
    {
        _button = GetComponent<Button>();
        devoileMenu = true;

        _button.onClick.AddListener( () =>
        {
            DevoileMenu();
        });

        _state = Etat.None;
        _population = 1000;
        _image = GetComponent<Image>();

        _secours = GetComponentsInChildren<Secours>();

        _text = GetComponentInChildren<Text>();

        rucheInonde = Resources.Load<Sprite>("IMG/RucheInonde");
        rucheNormal = Resources.Load<Sprite>("IMG/RucheNormal");

    }

    void Start()
    {
        foreach(var secour in _secours)
        {
            secour.gameObject.SetActive(false);
        }
    }
    
    public void SetState(Etat etat)
    {
        _state = etat;
        switch(_state)
        {
            case Etat.None:
                _image.sprite = rucheNormal;
                break;
            case Etat.Inondation:
                _image.sprite = rucheInonde;
                break;
        }
    }

    Sprite rucheNormal;
    Sprite rucheInonde;

    public void SetSprite(Sprite sprite)
    {
        _image.sprite = sprite;
    }
    
    public enum Etat
    {
        None,
        Pesticide,
        Inondation,
        Ouragan,
        Canicule
    }
    
    void Update()
    {
        if (IsDead) return;

        switch(_state)
        {
            case Etat.None:
                return;
                break;
            case Etat.Inondation:
                PopLower();
                break;
        }
    }

    void PopLower()
    {
        _population--;
        _text.text = _population.ToString();

        if (IsDead)
        {
            _image.sprite = rucheNormal;
            _image.color = new Color(0.5f, 0.5f, 0.5f);
            _text.text = "";
            _button.onClick.RemoveAllListeners();
        }

    }

    public void SoignePesticide()
    {

    }
    public void SoigneInondation()
    {
        if(_state == Etat.Inondation)
        {
            SetState(Etat.None);
        }
    }

    public void SoigneOuragan()
    {

    }

    public void SoigneCanicule()
    {

    }


}
