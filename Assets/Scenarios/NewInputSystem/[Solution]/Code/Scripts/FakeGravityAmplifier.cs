using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ReviewNewInputSystem
{
    public class FakeGravityAmplifier : MonoBehaviour
    {
        [SerializeField] private float amplification;
        private Rigidbody _rigid;

        private void Awake()
        {
            _rigid = GetComponent<Rigidbody>();
        }
        private void FixedUpdate()
        {
            _rigid.AddForce(Physics.gravity * (amplification - 1f));
        }
    }
}