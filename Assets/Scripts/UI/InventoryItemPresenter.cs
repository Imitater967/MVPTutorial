using System;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

namespace Git.Imitater967.MVPTutorial.UI {
    /// <summary>
    /// MVP中的其中一个P,单独负责物品的
    /// </summary>
    public class InventoryItemPresenter : AbstractPresenter<AbstractInventoryModel,InventoryView> {
        [SerializeField]
        protected ItemPresenter m_ItemPrefab;
        protected Dictionary<AbstractItemModel, ItemPresenter> m_ModelDict;

        private void Awake() {
            m_ModelDict = new Dictionary<AbstractItemModel, ItemPresenter>();
            m_View.OnDropEvent.AsObservable().Subscribe(gameObject => {
                if (gameObject.TryGetComponent<ItemPresenter>(out var presenter)) {
                    DestroyItemPresenter(presenter.Model);
                }
            }).AddTo(this);
        }

        private void Start() {
            //注册M->P的事件
            RegisterModelEvents();
            //初始刷预设的变量
            for (var i = 0; i < m_Model.Items.Count; i++) {
                InstantiateItemPresenter(m_Model.Items[i]);
            }
            return;
            void RegisterModelEvents() {
                m_Model.Items.ObserveRemove().Subscribe(evt => { DestroyItemPresenter(evt.Value); });
                m_Model.Items.ObserveReset().Subscribe(evt => {
                    foreach (var modelDictValue in new List<AbstractItemModel>(m_ModelDict.Keys)) {
                        DestroyItemPresenter(modelDictValue);
                    }
                });
                m_Model.Items.ObserveAdd().Subscribe(evt => { InstantiateItemPresenter(evt.Value); });
            }
        }

        private void DestroyItemPresenter(AbstractItemModel model) {
            Destroy(m_ModelDict[model].gameObject);
            m_ModelDict.Remove(model);
        }

        private void InstantiateItemPresenter(AbstractItemModel model) {
            var itemPresenter = Instantiate(m_ItemPrefab, m_View.ItemParent);
            itemPresenter.Initialize(model,m_View.DragParent);
            m_ModelDict.Add(model,itemPresenter);
        }
    }
}