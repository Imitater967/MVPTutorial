using Git.Imitater967.MVPTutorial.UI;
using UnityEngine;

namespace Git.Imitater967.MVPTutorial.UI {
    public class InventoryItemPresenter : AbstractPresenter<AbstractInventoryModel,InventoryView> {
        protected ItemPresenter m_ItemPrefab;
    }
}