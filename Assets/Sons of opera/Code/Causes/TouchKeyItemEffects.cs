using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace SotomaYorch.Mechanics
{
    [RequireComponent(typeof(InventoryKeyItem))]
    public class TouchKeyItemEffects : OnTriggerEffects
    {
        #region Parameters

        public bool turnOffKeyItemAfterTouch = true;

        #endregion

        #region RuntimeVariables

        protected InventoryKeyItem _scrInventoryKeyItem;
        protected bool _validateTag;

        #endregion

        #region UnityMethods

        void Start()
        {
            InitializeGenericEffect();
        }

        void OnDrawGizmos()
        {
            #if UNITY_EDITOR
                ValidateTags();
            #endif
        }

        void OnTriggerEnter(Collider other)
        {
            OnEnter(other.gameObject);
        }

        void OnTriggerStay(Collider other)
        {
            OnStay(other.gameObject);
        }

        void OnTriggerExit(Collider other)
        {
            OnExit(other.gameObject);
        }

        #endregion

        #region RuntimeMethods

        protected override void InitializeGenericEffect()
        {
            base.InitializeGenericEffect();
            _scrInventoryKeyItem = GetComponent<InventoryKeyItem>();
        }
        
        protected void ValidateTags()
        {
            _scrInventoryKeyItem = GetComponent<InventoryKeyItem>();
            foreach (string inventoryTag in _scrInventoryKeyItem.tagOfItemsToRecollect)
            {
                _validateTag = false;
                foreach (string raycastTag in tagsWithOtherTrigger)    
                {
                    _validateTag = true;
                }
                if (!_validateTag)
                {
                    Debug.LogError(gameObject.name + " : LoadKeyItemEffects - " +
                        "Missing TAG. " +
                        "The tag "+ inventoryTag + " from the inventory is not listed in this LoadKeyItemEffect script. " +
                        "Please add it so this script works properly",gameObject);
                }
            }
        }

        protected override void OnEnter(GameObject other)
        {
            base.OnEnter(other);
            if (_effectState == EffectState.ENTER)
            {
                if (turnOffKeyItemAfterTouch)
                {
                    _goSighted.SetActive(false);
                }
                _scrInventoryKeyItem.AddKeyItemByTag(_currentSightedTag);
            }
        }

        #endregion
    }
}