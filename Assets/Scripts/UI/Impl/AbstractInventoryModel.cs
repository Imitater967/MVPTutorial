using UniRx;
using UnityEngine;

namespace Git.Imitater967.MVPTutorial.UI {
    public abstract class AbstractInventoryModel : MonoBehaviour, InventoryModel{
        public abstract ReactiveCollection<AbstractItemModel> Items { get; }
        public abstract void Drop(int index);
        public abstract void Clear();
        public abstract void Refresh();
    }
}