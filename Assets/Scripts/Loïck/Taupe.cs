using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Taupe : MonoBehaviour
{
    private TaupeType _type;

    public TaupeType Type
    {
        get => _type;
        set => _type = value;
    }
}
