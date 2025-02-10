using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace SotomaYorch.Mechanics
{
    public class InputEventEffects : MonoBehaviour
    {
        #region Parameters

        public InputActionReference[] inputActionReferences;

        #endregion

        #region UnityEvents

        [Header("Unity Events")]
        [SerializeField] protected UnityEvent onInputActionEvent;

        #endregion

        #region UnityEvents

        void OnEnable()
        {
            InitializeGenericEffect();
        }

        void OnDisable()
        {
            DisableGenericEffect();
        }

        #endregion

        #region LocalMethods

        protected virtual void InitializeGenericEffect()
        {
            foreach (InputAction inputAction in inputActionReferences)
            {
                inputAction.performed += OnInputEvent;
            }
        }

        protected virtual void DisableGenericEffect()
        {
            foreach (InputAction inputAction in inputActionReferences)
            {
                inputAction.performed -= OnInputEvent;
            }
        }

        #endregion

        #region InputMethods

        public void OnInputEvent(InputAction.CallbackContext value)
        {
            foreach (InputAction inputAction in inputActionReferences)
            {
                if (value.action == inputAction)
                {
                    onInputActionEvent?.Invoke();
                }
            }
        }

        #endregion
    }
}