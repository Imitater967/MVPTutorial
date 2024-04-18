using System;
using UnityEngine;
using UnityEngine.UI;

namespace Git.Imitater967.MVPTutorial.UI {

    /// <summary>
    /// 物品的M
    /// </summary>
    [Serializable]
    public class ItemView {
        [field: SerializeField]
        public Image m_Icon;

        public void SetIconImage(Sprite sprite) {
            m_Icon.sprite = sprite;
        }
    }

    /// <summary>
    /// 物品的P
    /// </summary>
    public class ItemPresenter : AbstractPresenter<AbstractItemModel,ItemView> {
        /// <summary>
        /// 物品的初始化方法
        /// </summary>
        /// <param name="modelItem">绑定的Model</param>
        /// <param name="dragParent">拖延时候的Parent</param>
        public void Initialize(AbstractItemModel modelItem,Transform dragParent = null) {
            m_Model = modelItem;
            m_View.SetIconImage(m_Model.Sprite);
            var drag = GetComponent<ItemDrag>();
            if (drag != null) {
                drag.Initialize(dragParent);
            }
        }
    }
}