using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputChecker
{
    private static bool _isAcceptingPlayerInput = true;

    public static bool isAcceptingPlayerInput
    {
        get
        {
            return _isAcceptingPlayerInput;
        }

        set
        {
            _isAcceptingPlayerInput = value;
        }
    }
}
