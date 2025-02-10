using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SotomaYorch.Mechanics
{
    [RequireComponent(typeof(OnTriggerEffects))]
    public class NavMeshFollowEffect : MonoBehaviour
    {
        #region References

        [SerializeField] protected NavMeshAgent _navMeshAgent;

        #endregion

        #region UnityMethods

        void OnDrawGizmos()
        {
            if (_navMeshAgent == null)
            {
                _navMeshAgent = GetComponent<NavMeshAgent>();
            }
        }

        #endregion

        #region PublicMethods

        public void FollowTarget(Transform value)
        {
            _navMeshAgent.destination = value.position;
        }

        public void FollowSightedTarget()
        {
            if (GetComponent<OnTriggerEffects>() != null)
            {
                _navMeshAgent.destination = GetComponent<OnTriggerEffects>().GetSightedObject.transform.position;
            }
        }

        #endregion
    }
}