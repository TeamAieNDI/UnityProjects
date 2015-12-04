using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Ruche : MonoBehaviour {

    public int _population;
    public bool EstAuSol;
    Image _image;
    Etat _state;
    Text _text;
    Button _button;
    Secours[] _secours;
    bool devoileMenu;
    Transform _initialePosition;

    Sprite rucheNormal;
    Sprite rucheInonde;
    Sprite rucheInondeSafe;
    Sprite rucheOuraganSafe;

    NuiageDePluie nuage;

    bool IsDead
    {
        get
        {
            return _population <= 0;
        }
    }

    public void DevoileMenu()
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
        

        _initialePosition = this.transform;
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
        rucheInondeSafe = Resources.Load<Sprite>("IMG/RucheInondeSafe");
        rucheNormal = Resources.Load<Sprite>("IMG/RucheNormal");
        rucheOuraganSafe = Resources.Load<Sprite>("IMG/RucheOuraganSafe");

    }

    void Start()
    {
        nuage = GetComponentInChildren<NuiageDePluie>();
        nuage.gameObject.SetActive(false);

        foreach (var secour in _secours)
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
            case Etat.Canicule:
                AnimRed();
                break;
            case Etat.Pesticide:
                AnimGreen();
                break;
        }
    }

    void AnimRed()
    {
        _image.CrossFadeColor(new Color(1, 0, 0), 1f, false, false);
    }

    void AnimGreen()
    {
        _image.CrossFadeColor(new Color(0, 1, 0), 1f, false, false);
    }

    public void ReturnToNormalColor()
    {
        _image.CrossFadeColor(new Color(1, 1, 1), 0.5f, false, false);
    }

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

            case Etat.Ouragan:
                Tremble();
                PopLower();
                break;
            case Etat.Canicule:
                PopLower();
                break;
            case Etat.Pesticide:
                PopLower();
                break;
        }
    }

    void Tremble()
    {
        var signe = Random.value;
        
        Vector3 direction = new Vector3(Random.value, Random.value);

        if (signe > 0.5) direction *= -1;

        this.transform.Translate(direction);

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
        if (_state == Etat.Pesticide)
        {
            ReturnToNormalColor();
            SetState(Etat.None);
        }
    }

    public void SoigneInondation()
    {
        if(_state == Etat.Inondation)
        {
            SetState(Etat.None);
            _image.sprite = rucheInondeSafe;
        }
    }

    public void SoigneOuragan()
    {
        if(_state == Etat.Ouragan)
        {
            RemetPosition();
            SetState(Etat.None);
            _image.sprite = rucheOuraganSafe;
        }
    }

    public void SoigneCanicule()
    {
        if(_state == Etat.Canicule)
        {
            ReturnToNormalColor();
            SetState(Etat.None);
            NuageOTD();
        }
    }

    void NuageOTD()
    {
        nuage.gameObject.SetActive(true);
        Invoke("FermeTaGueuleNuage", 1f);
    }

    void FermeTaGueuleNuage()
    {
        nuage.gameObject.SetActive(false);
    }

    public void RemetPosition()
    {
        this.transform.position = _initialePosition.position;
    }

}
