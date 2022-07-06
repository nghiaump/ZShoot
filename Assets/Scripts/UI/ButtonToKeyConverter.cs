using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonToKeyConverter : MonoBehaviour
{
    private static float _interval = 0.1f;
    private static float _lastTime = 0f;
    public static bool s_buttonFire1 = false;
    public static bool s_buttonFire1Down = false;

    public static bool s_buttonSwitchGunDown = false;
    public static bool s_buttonReloadDown = false;
    public static bool s_buttonJumpDown = false;

    public static void SetFireTrue()
    {
        if(Time.time - _lastTime > _interval)
        {
            s_buttonFire1 = true;
            
        }
    }
}
