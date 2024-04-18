using UnityEngine;
using UnityEngine.EventSystems;

namespace Git.Imitater967.MVPTutorial.UI {
    /// <summary>
    /// 物品拖曳的组件
    /// </summary>
    public class ItemDrag : MonoBehaviour, IBeginDragHandler, IDragHandler,IEndDragHandler {
        private Transform m_OriginParent;
        private RectTransform m_RectTransform;
        private Transform m_DragParent;
        private CanvasGroup m_CanvasGroup;
        
        private void Awake() {
            m_RectTransform = (RectTransform)transform;
            m_CanvasGroup = GetComponent<CanvasGroup>();
        }

        public void Initialize(Transform dragParent) {
            m_DragParent = dragParent;
        }
        
        /// <summary>
        /// 开始拖动. 设置物品父层级以防被遮挡
        /// </summary>
        /// <param name="eventData"></param>
        public void OnBeginDrag(PointerEventData eventData) {
            m_OriginParent = transform.parent;
            transform.SetParent(m_DragParent);
            m_CanvasGroup.blocksRaycasts = false;
        }

        /// <summary>
        /// 拖动中,同步拖动的位置
        /// </summary>
        /// <param name="eventData"></param>
        public void OnDrag(PointerEventData eventData) {
            m_RectTransform.position = eventData.position;
        }

        /// <summary>
        /// 停止拖曳,重置物品状态
        /// </summary>
        /// <param name="eventData"></param>
        public void OnEndDrag(PointerEventData eventData) {
            m_CanvasGroup.blocksRaycasts = true;
            m_RectTransform.SetParent(m_OriginParent);
            //由HorizontalLayout
            m_RectTransform.anchoredPosition = Vector2.zero;
        }

    }
}