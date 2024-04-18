 
using Git.Imitater967.MVPTutorial.UI;
using UniRx;

namespace Git.Imitater967.MVPTutorial.UI {
    public class InventoryActionPresenter : AbstractPresenter<AbstractInventoryModel,InventoryView> {
        private void Awake() {
            m_View.ClearBnt.OnClickAsObservable().Subscribe(_ => {
                m_Model.Clear();
            }).AddTo(this);
            m_View.RefreshBnt.OnClickAsObservable().Subscribe(_ => {
                m_Model.Refresh();
            });
        }
    }
}