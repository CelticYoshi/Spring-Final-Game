using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] public float _health = 1;
    
    public void TakeDamage(int damageAmount)
    {
        _health -= damageAmount;
    }
}
