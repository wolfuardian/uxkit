using UnityEngine;
using UnityEngine.Events;

namespace Eos.UxKit
{
    public class LsSelect : MonoBehaviour
    {
        [SerializeField] private UnityEvent _onSelected = new UnityEvent();
        [SerializeField] private UnityEvent _onDeselected = new UnityEvent();

        private bool _isSelected;

        public void Toggle()
        {
            _isSelected = !_isSelected;
            if (_isSelected)
            {
                Selecting();
            }
            else
            {
                Deselecting();
            }
        }

        public void Selecting()
        {
            _isSelected = true;
            _onSelected.Invoke();
        }

        public void Deselecting()
        {
            _isSelected = false;
            _onDeselected.Invoke();
        }
    }
}
