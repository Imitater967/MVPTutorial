using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Git.Imitater967.MVPTutorial.UI {
    public class InventoryItemPresenter : AbstractPresenter<AbstractInventoryModel,InventoryView> {
        [SerializeField]
        protected ItemPresenter m_ItemPrefab;
        protected Dictionary<AbstractItemModel, ItemPresenter> m_ModelDict;

        private void Awake() {
            m_ModelDict = new Dictionary<AbstractItemModel, ItemPresenter>();
        }

        private void Start() {
            m_Model.Items.ObserveRemove().Subscribe(evt => {
                DestroyItemPresenter(evt.Value);
            });
            m_Model.Items.ObserveReset().Subscribe(evt => {
                foreach (var modelDictValue in new List<AbstractItemModel>(m_ModelDict.Keys)) {
                    DestroyItemPresenter(modelDictValue);
                }
            });
            m_Model.Items.ObserveAdd().Subscribe(evt => {
                InstantiateItemPresenter(evt.Value);
            });
            for (var i = 0; i < m_Model.Items.Count; i++) {
                InstantiateItemPresenter(m_Model.Items[i]);
            }
        }

        private void DestroyItemPresenter(AbstractItemModel model) {
            Destroy(m_ModelDict[model].gameObject);
            m_ModelDict.Remove(model);
        }

        public void InstantiateItemPresenter(AbstractItemModel model) {
            var itemPresenter = Instantiate(m_ItemPrefab, m_View.ItemParent);
            itemPresenter.Initialize(model);
            m_ModelDict.Add(model,itemPresenter);
        }
    }
}