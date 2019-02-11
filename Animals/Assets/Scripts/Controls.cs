using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour {


    public static bool Left() {

        return Input.GetKey(KeyCode.A);
    }
    
    public static bool Right()
    {
        return Input.GetKey(KeyCode.D);
    }


    public static bool Up() {
        return Input.GetKey(KeyCode.W);
    }

    public static bool Jump() {
        return Input.GetKeyDown(KeyCode.W);
    }

    public static bool Space() {
        return Input.GetKeyDown(KeyCode.Space);
    }

}
