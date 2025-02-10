using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SotomaYorch.Mechanics
{
    public class CleanTextInTimeEffect : MonoBehaviour
    {
        #region RuntimeVariables

        protected TextMeshProUGUI _textMesh;

        #endregion

        #region UnityMethods

        void Start()
        {
            _textMesh = GetComponent<TextMeshProUGUI>();
        }

        #endregion

        #region PublicMethods

        public void CleanTextMeshProInTime(float value)
        {
            Invoke("CleanTextMesh", value);
        }

        #endregion

        #region LocalMethods

        protected void CleanTextMesh()
        {
            _textMesh.text = "";
        }

        #endregion

    }
}