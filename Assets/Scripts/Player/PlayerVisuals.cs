using System;
using UnityEngine;

public class PlayerVisuals : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
       _animator = GetComponent<Animator>();
    }
}
