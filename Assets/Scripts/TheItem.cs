using Git.Imitater967.MVPTutorial.UI;
using UnityEngine;

namespace Git.Imitater967.MVPTutorial {
    [CreateAssetMenu(menuName = "Tutorial/Item")]
    public class TheItem : AbstractItemModel {
        [SerializeField]
        protected Sprite m_Sprite;
        public override Sprite Sprite { get => m_Sprite; }
    }
}