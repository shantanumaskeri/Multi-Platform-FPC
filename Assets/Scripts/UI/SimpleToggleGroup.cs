using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    [RequireComponent(typeof(ToggleGroup))]

    public class SimpleToggleGroup : MonoBehaviour
    {
        private ToggleGroup _toggleGroup;
        private Toggle[] _toggles;

        private void Awake()
        {
            _toggleGroup = GetComponent<ToggleGroup>();
            _toggles = GetComponentsInChildren<Toggle>();
        }

        private void OnEnable()
        {
            foreach (var toggle in _toggles)
            {
                toggle.group = _toggleGroup;
                toggle.onValueChanged.AddListener(OnToggleValueChanged);
            }
        }

        private void OnToggleValueChanged(bool value)
        {
            if (value)
            {
                var onToggle = _toggleGroup.ActiveToggles().First();
                Debug.LogFormat("Toggle {0} turned on.", onToggle.name);
            }
        }

        private void OnDisable()
        {
            foreach (var toggle in _toggles)
            {
                toggle.onValueChanged.RemoveListener(OnToggleValueChanged);
            }
        }
    }
}