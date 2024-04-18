using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Git.Imitater967.MVPTutorial.UI {
    /// <summary>
    /// 背包V的实现
    /// </summary>
    public class InventoryView : MonoBehaviour, IDropHandler {
        [field: SerializeField]
        public Button RefreshBnt { get; private set; }

        [field: SerializeField]
        public Button ClearBnt { get; private set; }

        [field: SerializeField]
        public Transform ItemParent { get; private set; }

        [field: SerializeField]
        public Transform DragParent { get; private set; }

        [field: SerializeField]
        public UnityEvent<GameObject> OnDropEvent { get; private set; }

        [field: SerializeField]
        public GameObject DropObject { get; private set; }
        public void OnDrop(PointerEventData eventData) {
            if(DropObject == eventData.pointerEnter) {
                OnDropEvent.Invoke(eventData.pointerDrag);
            }
        }
    }
}