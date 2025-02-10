using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SotomaYorch.Mechanics
{
    public class OnTrigger2DEffects : OnTriggerEffects
    {
        #region UnityMethods

        void Start()
        {
            InitializeGenericEffect();
        }

        void OnDrawGizmos()
        {
            #if UNITY_EDITOR
                if (tagsWithOtherTrigger.Length == 0)
                {
                    Debug.LogError(gameObject.name + " : OnTrigger2DEffects - There are no assigned tags for trigger effects!!!");
                }
            #endif
        }

        private void OnTrigger2DEnter(Collider2D other)
        {
            OnEnter(other.gameObject);
        }

        private void OnTrigger2DStay(Collider2D other)
        {
            OnStay(other.gameObject);
        }

        private void OnTrigger2DExit(Collider2D other)
        {
            OnExit(other.gameObject);
        }

        #endregion
    }
}