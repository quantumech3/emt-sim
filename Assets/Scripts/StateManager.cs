using UnityEngine;
using System;
using System.Collections;
using UnityEngine.XR.Interaction.Toolkit;


public class StateManager : MonoBehaviour {

    
    public static int gameState = 0;
    void Start ()
    {
        
    }

    // static method to increment the state
    public static void IncrementState()
    {
        gameState++;
    }
    public static int GetState()
    {
        return gameState;
    }
}