using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace SotomaYorch.Mechanics
{
    [RequireComponent(typeof(HealthManager))]
    [RequireComponent(typeof(Collider))]
    public class HurtBoxEffects : OnTriggerEffects
    {
        #region UnityEvents

        [SerializeField] protected UnityEvent onHurtUnityEvent;
        [SerializeField] protected UnityEvent onCooldownUnityEvent;

        #endregion

        #region Parameters

        public float cooldownTime = 1f;

        #endregion

        #region References

        [SerializeField,HideInInspector] protected Collider _hurtBox;
        [SerializeField,HideInInspector] protected HealthManager _healthManager;

        #endregion

        #region RuntimeVariables

        protected bool _isHurtBoxEnabled = true;

        #endregion

        #region UnityMethods

        void OnDrawGizmos()
        {
            InitializeGenericEffect();
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

        #region RuntimeMethods

        protected override void OnEnter(GameObject other)
        {
            base.OnEnter(other);
            CheckForHurtEvent(other);
        }

        protected override void OnStay(GameObject other)
        {
            base.OnStay(other);
            CheckForHurtEvent(other);
        }

        protected void CheckForHurtEvent(GameObject other)
        {
            if (_isHurtBoxEnabled && 
                (_effectState == EffectState.ENTER || _effectState == EffectState.STAY))
            {
                if (_healthManager != null && other.gameObject.GetComponent<HitBoxEffects>() != null)
                {
                    _healthManager.ReduceHealth(other.gameObject.GetComponent<HitBoxEffects>().damagePerHit);
                    onHurtUnityEvent?.Invoke();
                    StartCoroutine(CooldownCoroutine());
                }
            }
        }

        protected override void InitializeGenericEffect()
        {
            base.InitializeGenericEffect();
            #if UNITY_EDITOR
            if (_healthManager == null)
            {
                _healthManager = GetComponent<HealthManager>();
            }
            if (_hurtBox == null )
            {
                _hurtBox = GetComponent<Collider>();
                _hurtBox.isTrigger = true;
                _hurtBox.gameObject.tag = "HurtBox";
                _hurtBox.enabled = true;
            }
            if (_hurtBox.gameObject.tag != "HurtBox")
            {
                _hurtBox.gameObject.tag = "HurtBox";
            }
            tagsWithOtherTrigger = new string[1];
            tagsWithOtherTrigger[0] = "HitBox";

            if (GetComponent<Rigidbody>() != null)
            {
                if (!GetComponent<Rigidbody>().isKinematic)
                {
                    GetComponent<Rigidbody>().isKinematic = true;
                }
            }
            #endif
        }

        protected IEnumerator CooldownCoroutine()
        {
            _isHurtBoxEnabled = false;
            yield return new WaitForSeconds(cooldownTime);
            _isHurtBoxEnabled = true;
            onCooldownUnityEvent?.Invoke();
        }

        #endregion

    }
}

