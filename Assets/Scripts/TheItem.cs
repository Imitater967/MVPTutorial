using Git.Imitater967.MVPTutorial.UI;
using UnityEngine;

namespace Git.Imitater967.MVPTutorial {
    /// <summary>
    /// UI物品Model的实现
    /// </summary>
    [CreateAssetMenu(menuName = "Tutorial/Item")]
    public class TheItem : AbstractItemModel {
        [SerializeField]
        protected Sprite m_Sprite;
        public override Sprite Sprite { get => m_Sprite; }
    }
}