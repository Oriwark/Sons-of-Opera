using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SotomaYorch.Mechanics
{
    [RequireComponent(typeof(Animation))]
    public class PlayAnimationEffect : MonoBehaviour
    {
        #region PublicMethods

        public void PlayAnimationClip(AnimationClip value)
        {
            GetComponent<Animation>().clip = value;
            GetComponent<Animation>().Play();
        }

        #endregion
    }
}