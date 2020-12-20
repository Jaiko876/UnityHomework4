using TMPro;
using UnityEngine;

namespace UI
{
    public class UIView : MonoBehaviour
    {
        private TMP_Text _speedInfo;
        private float _defaultSpeedValue;

        public void InitializeUIView()
        {
            _speedInfo = gameObject.GetComponentInChildren<TMP_Text>();
        }
        public void SetSpeedInfo(string speedInfo)
        {
            _speedInfo.SetText(speedInfo);
        }

        public float DefaultSpeedValue
        {
            get => _defaultSpeedValue;
            set => _defaultSpeedValue = value;
        }
    }
}
