using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AnimationRigging
{
    public interface IPositionable {
        Vector3 Position {get; set;}
    }

    public class PositionRelativeToChild : MonoBehaviour, IPositionable
    {
        [SerializeField] private Transform _target;
        public Vector3 Position {
            get => _target.position;
            set => transform.position = value - (_target.position - transform.position);
        }
    }
}