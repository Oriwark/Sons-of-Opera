using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SotomaYorch.Mechanics
{

    public class RaycastEffects : GenericEffects
    {
        #region Parameters

        [Header("Parameters")]
        [SerializeField] public Transform cameraTransform;
        [SerializeField] public float raycastDistance = 2.0f;
        [SerializeField] public string[] tagsWithOtherRaycasted;

        [Header("Debug")]
        public bool debugRay;

        #endregion

        #region RuntimeVariables

        [SerializeField] protected Ray _ray;

        #endregion

        #region UnityMethods

        void OnDrawGizmos()
        {
            InitializeGenericEffect();
        }

        void FixedUpdate() //Update()
        {
            RaycastUpdate();
        }

        #endregion

        #region RuntimeMethods

        protected override void InitializeGenericEffect()
        {
            #if UNITY_EDITOR
            if (cameraTransform == null)
            {
                cameraTransform = Camera.main.transform;
            }
            if (tagsWithOtherRaycasted?.Length == 0)
            {
                Debug.LogError(gameObject.name + " : RaycastEffects - There are no assigned tags for raycast effects!!!",gameObject);
            }

            if (debugRay)
            {
                if (cameraTransform != null)
                {
                    _ray.origin = cameraTransform.position;
                    _ray.direction = cameraTransform.forward;
                    Debug.DrawRay(
                        _ray.origin,
                        _ray.direction * raycastDistance,
                        Color.red,
                        Time.fixedDeltaTime
                    );
                }
            }
            #endif
        }

        protected virtual void RaycastUpdate()
        {
            _ray.origin = cameraTransform.position;
            _ray.direction = cameraTransform.forward;

            RaycastHit raycastHit;
            if (Physics.Raycast(_ray, out raycastHit, raycastDistance))
            {
                foreach (string tag in tagsWithOtherRaycasted)
                {
                    if (raycastHit.collider.gameObject.tag == tag)
                    {
                        _goSighted = raycastHit.collider.gameObject;
                        if (!_targetSighted)
                        {
                            OnEnter(_goSighted);
                        }
                        else
                        {
                            if (_currentSightedTag == tag)
                            {
                                OnStay(_goSighted);
                            }
                            else
                            {
                                OnStay(_goSighted);
                            }
                        }
                    }
                    else
                    {
                        if (_targetSighted)
                        {
                            OnExit(_goSighted);
                        }
                    }
                }
            }
            else
            {
                if (_targetSighted)
                {
                    OnExit(_goSighted);
                }
            }
        }

        #endregion

        #region LocalMethods

        protected override void OnEnter(GameObject other)
        {
            onEnterUnityEvent?.Invoke();
            _targetSighted = true;
            _currentSightedTag = other.tag;
            _effectState = EffectState.ENTER;
        }

        protected override void OnStay(GameObject other)
        {
            onStayUnityEvent?.Invoke();
            _targetSighted = true;
            _currentSightedTag = other.tag;
            _effectState = EffectState.STAY;
        }

        protected override void OnExit(GameObject other)
        {
            onExitUnityEvent?.Invoke();
            _targetSighted = false;
            _currentSightedTag = "";
            _effectState = EffectState.EXIT;
        }

        #endregion
    }
}