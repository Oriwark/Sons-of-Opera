using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using StarterAssets;

namespace SotomaYorch.Mechanics
{
    public class TakeObjectEffects : RaycastEffects
    {
        #region Parameters

        public bool turnOffObjectAfterTouch = true;

        #endregion

        #region UnityEvents

        [Header("Specific Unity Event")]
        [SerializeField] public UnityEvent onTakeObjectUnityEvent;

        #endregion

        #region UnityMethods

        private void OnDrawGizmos()
        {
            InitializeGenericEffect();
        }

        #endregion

        #region PublicMethods

        public void TakeObject()
        {
            switch (_effectState)
            {
                case EffectState.ENTER:
                case EffectState.STAY:
                    OnTakeObject();
                    break;
            }
        }

        #endregion

        #region LocalMethods

        protected void OnTakeObject()
        {
            if (turnOffObjectAfterTouch)
            {
                _goSighted.gameObject.SetActive(false);
            }
            onTakeObjectUnityEvent?.Invoke();
        }

        #endregion
    }
}