using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace SotomaYorch.Mechanics
{
    #region Enums

    public enum EffectState
    {
        NONE,
        ENTER,
        STAY,
        EXIT
    }

    #endregion

    public class GenericEffects : MonoBehaviour
    {
        #region UnityEvents

        [Header("Unity Events")]
        [SerializeField] protected UnityEvent onEnterUnityEvent;
        [SerializeField] protected UnityEvent onStayUnityEvent;
        [SerializeField] protected UnityEvent onExitUnityEvent;

        #endregion

        #region RuntimeVariables

        protected bool _targetSighted;
        protected GameObject _goSighted;
        protected EffectState _effectState;
        protected string _currentSightedTag;

        #endregion

        #region PublicMethods

        public void ChangeSightedObjectMaterial(Material value)
        {
            if (_goSighted != null)
            {
                _goSighted.GetComponent<MeshRenderer>().material = value;
            }
        }

        public void ActivateSightedObject(bool value)
        {
            _goSighted?.SetActive(value);
        }

        public void PlayAnimationOfSightedObject(AnimationClip value)
        {
            if (_goSighted?.GetComponent<Animation>() != null)
            {
                _goSighted.GetComponent<Animation>().clip = value;
                _goSighted.GetComponent<Animation>().Play();
            }
        }

        public void ToggleSightedGameObject()
        {
            _goSighted?.SetActive(!_goSighted.activeSelf);
        }

        public void TeleportSightedObject(Transform value)
        {
            if (_goSighted != null)
            {
                _goSighted.transform.position = value.position;
                _goSighted.transform.rotation = value.rotation;
            }
        }

        public void LoadScene(string value)
        {
            SceneManager.LoadScene(value);
        }

        #endregion

        #region LocalMethods

        protected virtual void InitializeGenericEffect()
        {
            
        }

        protected virtual void OnEnter(GameObject other)
        {

        }

        protected virtual void OnStay(GameObject other)
        {

        }

        protected virtual void OnExit(GameObject other)
        {

        }

        #endregion

        #region GettersAndSetters

        public GameObject GetSightedObject
        {
            get { return _goSighted; }
        }

        #endregion
    }
}