using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SotomaYorch.Mechanics
{
    public class InventoryKeyItem : MonoBehaviour
    {
        #region Parameters

        [Header("Parameters")]
        [SerializeField] public string[] tagOfItemsToRecollect;

        #endregion

        #region RuntimeVariables

        [SerializeField] protected List<int> numberOfKeyItemsCollected;

        #endregion

        #region UnityMethods

        void Start()
        {
            numberOfKeyItemsCollected = new List<int>();
            for (int i = 0; i < tagOfItemsToRecollect.Length; i++)
            {
                numberOfKeyItemsCollected.Add(0);
            }
        }

        void OnDrawGizmos()
        {
            InitializeReferences();
        }

        #endregion

        #region LocalMethods

        protected virtual void InitializeReferences()
        {
            #if UNITY_EDITOR
            if (tagOfItemsToRecollect?.Length == 0)
            {
                Debug.LogError(gameObject.name + " : InventoryKeyItem - There are no assigned tags for the inventory to manage!!!");
            }
            #endif
        }

        #endregion

        #region PublicMethods

        public void AddKeyItemByTag(string value)
        {
            for (int i = 0; i < tagOfItemsToRecollect.Length; i++)
            {
                if (value == tagOfItemsToRecollect[i])
                {
                    numberOfKeyItemsCollected[i]++;
                    return;
                }
            }
        }

        public void DeleteAllKeyItemsByTag(string value)
        {
            for (int i = 0; i < tagOfItemsToRecollect.Length; i++)
            {
                if (value == tagOfItemsToRecollect[i])
                {
                    numberOfKeyItemsCollected[i] = 0;
                    return;
                }
            }
        }

        public void DeleteNumberOfKeyItemsByTag(string tag, int value)
        {
            for (int i = 0; i < tagOfItemsToRecollect.Length; i++)
            {
                if (tag == tagOfItemsToRecollect[i])
                {
                    numberOfKeyItemsCollected[i] -= value;
                    return;
                }
            }
        }

        public bool HasRequiredNumberOfKeyItems(string tag, int value)
        {
            for (int i = 0; i < tagOfItemsToRecollect.Length; i++)
            {
                if (tag == tagOfItemsToRecollect[i])
                {
                    return numberOfKeyItemsCollected[i] >= value;
                }
            }
            return false;
        }

        #endregion
    }
}