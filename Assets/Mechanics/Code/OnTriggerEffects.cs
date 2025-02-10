using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SotomaYorch.Mechanics
{
    [RequireComponent(typeof(Rigidbody))]
    public class OnTriggerEffects : GenericEffects
    {
        #region Knobs

        [Header("Conditions")]
        [SerializeField] public string[] tagsWithOtherTrigger;

        #endregion

        #region UnityMethods

        void OnDrawGizmos()
        {
            #if UNITY_EDITOR
                if (tagsWithOtherTrigger?.Length == 0)
                {
                    Debug.LogError(gameObject.name + " : OnTriggerEffects - There are no assigned tags for trigger effects!!!");
                }
                InitializeGenericEffect();
            #endif

        }

        private void OnTriggerEnter(Collider other)
        {
            OnEnter(other.gameObject);
        }

        private void OnTriggerStay(Collider other)
        {
            OnStay(other.gameObject);
        }

        private void OnTriggerExit(Collider other)
        {
            OnExit(other.gameObject);
        }

        #endregion

        #region LocalMethods

        protected override void InitializeGenericEffect()
        {
            if (!GetComponent<Rigidbody>().isKinematic)
            {
                GetComponent<Rigidbody>().isKinematic = true;
            }
        }

        protected override void OnEnter(GameObject other)
        {
            foreach (string tag in tagsWithOtherTrigger)
            {
                if (other.gameObject.tag == tag)
                {
                    _targetSighted = true;
                    _goSighted = other;
                    _currentSightedTag = tag;
                    _effectState = EffectState.ENTER;
                    onEnterUnityEvent?.Invoke();
                }
            }
        }

        protected override void OnStay(GameObject other)
        {
            foreach (string tag in tagsWithOtherTrigger)
            {
                if (other.gameObject.tag == tag)
                {
                    _targetSighted = true;
                    _goSighted = other;
                    _currentSightedTag = tag;
                    _effectState = EffectState.STAY;
                    onStayUnityEvent?.Invoke();
                }
            }
        }

        protected override void OnExit(GameObject other)
        {
            foreach (string tag in tagsWithOtherTrigger)
            {
                if (other.gameObject.tag == tag)
                {
                    _targetSighted = true;
                    _goSighted = other;
                    _currentSightedTag = tag;
                    _effectState = EffectState.EXIT;
                    onExitUnityEvent?.Invoke();
                }
            }
        }

        #endregion
    }
}