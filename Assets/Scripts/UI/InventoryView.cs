using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Git.Imitater967.MVPTutorial.UI {
    public class InventoryView : MonoBehaviour , IDropHandler{
        [field: SerializeField]
        public Button RefreshBnt { get; private set; }
        [field: SerializeField]
        public Button ClearBnt { get; private set; }
        [field: SerializeField]
        public Transform ItemParent { get; private set; }

        public void OnDrop(PointerEventData eventData) {
            Debug.Log($"Dropped + {eventData.pointerEnter.name}");
        }
    }
}