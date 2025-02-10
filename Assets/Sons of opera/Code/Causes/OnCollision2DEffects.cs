using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SotomaYorch.Mechanics
{
    public class OnCollision2DEffects : OnCollisionEffects
    {
        #region UnityMethods

        void Start()
        {
            InitializeGenericEffect();
        }

        private void OnCollision2DEnter(Collision2D other)
        {
            OnEnter(other.gameObject);
        }

        private void OnCollision2DStay(Collision2D other)
        {
            OnStay(other.gameObject);
        }

        private void OnCollision2DExit(Collision2D other)
        {
            OnExit(other.gameObject);
        }

        #endregion
    }
}