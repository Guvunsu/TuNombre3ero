using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{
    public void StateMechanic(StateMechanics value)
    {
        _fsm.StateMechanics = value;
    }

    enum StateMechanics
    {

    }
}
