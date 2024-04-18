using System.Collections.ObjectModel;
using UniRx;

namespace Git.Imitater967.MVPTutorial.UI {
    /// <summary>
    /// 背包M抽象
    /// </summary>
    public interface InventoryModel {
        public ReactiveCollection<AbstractItemModel> Items { get; }

        public void Drop(int index);

        public void Clear();

        public void Refresh();
    }
}