using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SotomaYorch.Mechanics
{
    public class TeleportTargetEffect : MonoBehaviour
    {
        #region PublicMethods

        public void TeleportThisGameObjectToTarget(Transform value)
        {
            gameObject.transform.position = value.position;
            gameObject.transform.rotation = value.rotation;
        }

        #endregion
    }
}
