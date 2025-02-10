using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using StarterAssets;

namespace SotomaYorch.Mechanics
{
    [RequireComponent(typeof(InventoryKeyItem))]
    public class TakeKeyItemEffects : RaycastEffects
    {
        #region Parameters

        public bool turnOffKeyItemAfterTake = true;

        #endregion

        #region UnityEvents

        [Header("Specific Unity Event")]
        [SerializeField] protected UnityEvent onTakeKeyItemUnityEvent;

        #endregion

        #region RuntimeVariables

        protected InventoryKeyItem _scrInventoryKeyItem;
        protected bool _validateTag;

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
            base.InitializeGenericEffect();

            #if UNITY_EDITOR
            if (_scrInventoryKeyItem == null)
            {
                _scrInventoryKeyItem = GetComponent<InventoryKeyItem>();
            }
            ValidateTags();
            #endif
        }

        protected void ValidateTags()
        {
            foreach (string inventoryTag in _scrInventoryKeyItem.tagOfItemsToRecollect)
            {
                _validateTag = false;
                foreach (string raycastTag in tagsWithOtherRaycasted)    
                {
                    _validateTag = true;
                }
                if (!_validateTag)
                {
                    Debug.LogError(gameObject.name + " : TakeKeyItemEffects - " +
                        "Missing TAG. " +
                        "The tag "+ inventoryTag + " from the inventory is not listed in this LoadKeyItemEffect script. " +
                        "Please add it so this script works properly.");
                }
            }
        }

        #endregion

        #region PublicMethods

        public void TakeKeyItem()
        {
            switch (_effectState)
            {
                case EffectState.ENTER:
                case EffectState.STAY:
                    OnTakeItem();
                    break;
            }
        }

        #endregion

        #region LocalMethods

        protected void OnTakeItem()
        {
            onTakeKeyItemUnityEvent?.Invoke();
            if (turnOffKeyItemAfterTake)
            {
                _goSighted.SetActive(false);
            }
            _scrInventoryKeyItem.AddKeyItemByTag(_currentSightedTag);
        }

        #endregion
    }
}