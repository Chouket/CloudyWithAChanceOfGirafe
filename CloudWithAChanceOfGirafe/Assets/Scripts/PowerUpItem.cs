using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpItem : MonoBehaviour {


    [SerializeField]
    bool WJump;
    [SerializeField]
    bool hogehoge;

        void Start()
        {
            WJump = false;
            hogehoge = false;
        }

        public string ItemSet(string Item)
        {
            string callback = "have a Item!!";
            if (WJump == true || hogehoge == true) return callback;
            return callback;
        }

        public string ItemCall()
        {
            string callBack = "Nothing";
            if (WJump == true)
            {
                callBack = "WJump";
                WJump = false;
            }
            if (hogehoge == true)
            {
                callBack = "hogehoge";
                hogehoge = false;
            }
            return callBack;
        }
    

}
