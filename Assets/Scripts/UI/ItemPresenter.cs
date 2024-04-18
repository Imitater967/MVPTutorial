using System;
using UnityEngine;
using UnityEngine.UI;

namespace Git.Imitater967.MVPTutorial.UI {

    [Serializable]
    public class ItemView {
        [field: SerializeField]
        public Image m_Icon;

        public void SetIconImage(Sprite sprite) {
            m_Icon.sprite = sprite;
        }
    }

    public class ItemPresenter : AbstractPresenter<AbstractItemModel,ItemView> {
        public void Initialize(AbstractItemModel modelItem) {
            m_Model = modelItem;
            m_View.SetIconImage(m_Model.Sprite);
        }
    }
}