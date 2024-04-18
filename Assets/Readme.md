
## MVP
Model即数据,我们会在UI里新建一个抽象类/接口 代表着我们所需要的数据, 比如物品Model,然后它被物品类继承.  
Presenter接收数据的修改事件,发送给View让View修改界面. 接收View的事件,通知Model,修改数据.  
View即UI界面的绑定

Presenter为UI的代表, 绑定在UI的根部. 比如背包UI里面有诺干的物品,那么背包的P就应该在背包的根, 物品的P是物品的根(仍然是背包的子物体).

M->P: 使用观察者模式  
P->V: 直接绑定方法  
V->P: 必须使用Delegate  
P->M: 直接修改
![](https://github.com/neuecc/UniRx/blob/master/StoreDocument/MVP_Pattern.png)
## 分模块

分模块需要注意的地方是, 各模块之间不应该有相互的引用,也就是A引用B, B引用A.  

由于Unity的特性, 我们不能够直接使用Interface, 需要提供一定的桥接
桥接方式:  
    - [接口选择器](https://github.com/Thundernerd/Unity3D-SerializableInterface)  
    - 使用抽象类