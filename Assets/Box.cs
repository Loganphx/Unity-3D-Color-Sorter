using System;
using UnityEngine;

public class Box : MonoBehaviour
{
    public Action OnBallEntered;
    
    private void OnTriggerEnter(Collider other)
    { 
        OnBallEntered?.Invoke();
    }
}