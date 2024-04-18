using UnityEngine;

namespace Git.Imitater967.MVPTutorial.UI {
    public class AbstractPresenter<M,V> : MonoBehaviour {
        [SerializeField]
        protected M m_Model;
        [SerializeField]
        protected V m_View;

        public M Model => m_Model;
        public V View => m_View;
    }
}