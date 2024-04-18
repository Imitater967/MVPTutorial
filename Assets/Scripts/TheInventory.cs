using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Git.Imitater967.MVPTutorial;
using Git.Imitater967.MVPTutorial.UI;
using UniRx;
using UnityEngine;

namespace Git.Imitater967.MVPTutorial {
    /// <summary>
    /// UI背包的实现
    /// </summary>
    public class TheInventory : AbstractInventoryModel {
        [SerializeField]
        private ReactiveCollection<AbstractItemModel> m_Items;
        [SerializeField]
        private List<TheItem> m_StartUpItem;
        
        public override ReactiveCollection<AbstractItemModel> Items {
            get { return m_Items; }
        }
        
        private void Awake() {
            Refresh();    
        }
        
        public override void Drop(int index) {
            m_Items.RemoveAt(index);
        }

        public override void Clear() {
            m_Items.Clear();
        }

        public override void Refresh() {
            if (m_Items == null) {
                m_Items = new ReactiveCollection<AbstractItemModel>(m_StartUpItem);
            }
            else {
                m_Items.Clear();
                foreach (var t in m_StartUpItem) {
                    m_Items.Add(t);
                }
            }
        }


    }
  
}
