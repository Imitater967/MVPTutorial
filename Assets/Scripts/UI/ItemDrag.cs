using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Git.Imitater967.MVPTutorial.UI {
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
        public void OnBeginDrag(PointerEventData eventData) {
            m_OriginParent = transform.parent;
            transform.SetParent(m_DragParent);
            m_CanvasGroup.blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData eventData) {
            m_RectTransform.position = eventData.position;
        }

        public void OnEndDrag(PointerEventData eventData) {
            m_CanvasGroup.blocksRaycasts = true;
            m_RectTransform.SetParent(m_OriginParent);
            //由HorizontalLayout
            m_RectTransform.anchoredPosition = Vector2.zero;
        }

    }
}