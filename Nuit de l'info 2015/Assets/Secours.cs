using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Secours : MonoBehaviour {

    Ruche _ruche;
    public Role ActualRole;
    
    public enum Role
    {
        Pesticide,
        Inondation,
        Ouragan,
        Canicule,
        Close
    }

	void Awake()
    {
        _ruche = GetComponentInParent<Ruche>();
        
        switch (ActualRole)
        {
            case Role.Canicule:
                GetComponent<Image>().sprite = Resources.Load<Sprite>("IMG/pictoCanicule");
                break;
            case Role.Inondation:
                GetComponent<Image>().sprite = Resources.Load<Sprite>("IMG/pictoInondation");
                break;
            case Role.Ouragan:
                GetComponent<Image>().sprite = Resources.Load<Sprite>("IMG/pictoOuragan");
                break;
            case Role.Pesticide:
                GetComponent<Image>().sprite = Resources.Load<Sprite>("IMG/pictoPesticide");
                break;
        }

        var button = GetComponent<Button>();
        button.onClick.AddListener( () => 
        {
            Soigne();
        });
    }

    void Soigne()
    {
        switch(ActualRole)
        {
            case Role.Canicule:
                _ruche.SoigneCanicule();
                break;
            case Role.Inondation:
                _ruche.SoigneInondation();
                break;
            case Role.Ouragan:
                _ruche.SoigneOuragan();
                break;
            case Role.Pesticide:
                _ruche.SoignePesticide();
                break;
        }
        _ruche.DevoileMenu();
    }

}
