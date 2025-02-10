using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SotomaYorch.Mechanics
{
    [RequireComponent(typeof(Rigidbody))]
    public class OnCollisionEffects : GenericEffects
    {
        #region Knobs

        [Header("Conditions")]
        public string[] tagsWithOtherCollision;

        #endregion

        #region UnityMethods

        void Start()
        {
            InitializeGenericEffect();
        }

        void OnDrawGizmos()
        {
            #if UNITY_EDITOR
                if (tagsWithOtherCollision?.Length == 0)
                {
                    Debug.LogError(gameObject.name + " : OnCollisionEffects - There are no assigned tags for collision effects!!!");
                }
            #endif
        }

        private void OnCollisionEnter(Collision other)
        {
            OnEnter(other.gameObject);
        }

        private void OnCollisionStay(Collision other)
        {
            OnStay(other.gameObject);
        }

        private void OnCollisionExit(Collision other)
        {
            OnExit(other.gameObject);
        }

        #endregion

        #region LocalMethods

        protected override void InitializeGenericEffect()
        {
            GetComponent<Rigidbody>().isKinematic = true;
        }

        protected override void OnEnter(GameObject other)
        {
            foreach (string tag in tagsWithOtherCollision)
            {
                if (other.tag == tag)
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
            foreach (string tag in tagsWithOtherCollision)
            {
                if (other.tag == tag)
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
            foreach (string tag in tagsWithOtherCollision)
            {
                if (other.tag == tag)
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