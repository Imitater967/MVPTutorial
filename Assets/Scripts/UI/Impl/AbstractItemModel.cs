using UnityEngine;

namespace Git.Imitater967.MVPTutorial.UI {
    public abstract class AbstractItemModel : ScriptableObject, ItemModel{
        public abstract Sprite Sprite { get; }
    }
}