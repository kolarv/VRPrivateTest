using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JanController : PlayerController
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
                case '3': 
                    selected = true;
                    break;
                case '1':  
                case '2':
                case '4':
                case '5':
                    selected = false;
                    break;
            }
        }
    }
}
