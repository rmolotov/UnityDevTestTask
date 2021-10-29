using UnityEngine;
using UnityEngine.EventSystems;

namespace Util
{
    public class InputController: MonoBehaviour
    {
        private RaycastHit _hitInfo;
        void Update()
        {
            if (Input.touchCount == 1 || Input.GetMouseButtonDown(0))
            {
                Vector2 clickPos;
#if !UNITY_EDITOR
                Touch touch = Input.GetTouch(0);
                clickPos = touch.position;
#else
                clickPos = Input.mousePosition;
#endif

                Ray ray = Camera.main.ScreenPointToRay(clickPos);

                Physics.Raycast(ray, out _hitInfo);
                Debug.DrawRay(ray.origin, ray.direction, Color.blue, 5f);
                
                _hitInfo.collider?.GetComponentInParent<IInteractable>()?.Interact();
            }
        }
    }
}