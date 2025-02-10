using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SotomaYorch.Mechanics
{
    public class LoadSceneEffect : MonoBehaviour
    {
        #region PublicMethods

        public void LoadSceneByName(string value)
        {
            SceneManager.LoadScene(value);
        }

        #endregion
    }
}