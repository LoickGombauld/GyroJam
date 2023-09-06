using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private Gyro m_inputsActions;
    public Gyro InputsActions => m_inputsActions;

    // PLAYER

    // Start is called before the first frame update
    public void Initialize()
    {
        m_inputsActions = new Gyro();
        InputsActions.Enable();
    }
}
