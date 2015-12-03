using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

    public class God : MonoBehaviour
    {

        DialogueBox _dialogueBox;
         CatastropheManager _catastropheManager;
        static God Me;

        public CatastropheManager Cata
        {
            get { return _catastropheManager; }
        }

        public static God Get
        {
            get { return GameObject.Find("God").GetComponent<God>(); }
        }

        void Awake()
        {
            Me = this;
            DontDestroyOnLoad(this);
        }

        public void LancementDuJeu()
        {
            _dialogueBox = GameObject.Find("EspaceDialogue").GetComponent<DialogueBox>();
            _catastropheManager = this.gameObject.AddComponent(typeof(CatastropheManager)) as CatastropheManager;
            
            

            this.gameObject.AddComponent<GameEventManager>().Go();

    }

        public void DialogueBoxSetActive(List<string> textes, Func<bool> callback)
        {
            _dialogueBox.gameObject.SetActive(true);
            _dialogueBox.InitaliseNewDialogue(textes, () => { EndOfDialogue(callback); return true; });
        }


        public void EndOfDialogue(Func<bool> callback)
        {
            _dialogueBox.gameObject.SetActive(false);
            callback.Invoke();
        }

        public void EndOfGame()
        {
            Debug.Log("Fin du Game");
        }

}
