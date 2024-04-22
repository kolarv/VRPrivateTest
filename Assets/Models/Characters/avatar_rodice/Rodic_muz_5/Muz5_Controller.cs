using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muz5_Controller : PlayerController
{
    public override void FixedUpdate()
    {
        base.FixedUpdate();
        UpdateTargets(rightHandTarget, headTopPosition);
        UpdateStatus(statusSphere, headTopPosition);

        if (Input.inputString != "")
        {
            var inputKey = Input.inputString[0];
            switch (inputKey)
            {
                case '5':
                    selected = true;
                    break;
                case '1':
                case '2':
                case '3':
                case '4':
                    selected = false;
                    break;
            }
        }
    }
}
