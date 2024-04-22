using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YuController : PlayerController
{

    //Controller, co vybira Anezku pro ruzne akce.
    public override void FixedUpdate()
    {
        base.FixedUpdate();
        UpdateTargets(rightHandTarget, headTopPosition);
        UpdateStatus(statusSphere, headTopPosition);

        if (Input.inputString != "")
        {
            var inputKey = Input.inputString[0];
            switch(inputKey)
            {
                case '1': 
                    selected = true;
                    break;                
                case '2':
                case '3':
                case '4':
                case '5':
                    selected = false;
                    break;
            }
        }
    }
}
