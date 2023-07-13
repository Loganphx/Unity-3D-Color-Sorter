using System;
using UnityEngine;

public class Box : MonoBehaviour
{
    [SerializeField] public Color boxColor;
    public Action OnBallEntered;
    
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Renderer>().material.color = boxColor;
        OnBallEntered?.Invoke();
    }
}