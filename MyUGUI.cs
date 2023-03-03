using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyUGUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*我在项目《东方驱魔社》中使用过UGUI。
     UGUI最大的特点就是可视化设计，迅速通过拖曳组件来设计UI。
    同时还可以自定义UI组件的外观，样式和交互事件，还可以为组件添加动画。
    Canvas是UGUI的核心组件，是所有UGUI组件的父组件，控制着UI组件的显示和层级关系。Layout组件是用于在Canvas中自动排列UI元素的组件，在UGUI中可以用的组件包括Button按钮组件，Text文本组件，Image图片组件等等。
    除了组件的显示之外，还可以使用EventTrigger来控制UI，捕获UI获得的事件，从而出发相应的函数效果。
    UGUI在使用时，首先便是要创建一个Canvas对象，要将Canvas组件添加到一个空物体上，然后根据需求，在Canvas上添加各种UI元素，比如Burron，Text，Image等，还可以使用Layout组件将葛总UI元素自动排列。
    必须的是要使用Event Trigger组件为UI元素添加事件处理，在一些事件触发后可以调用函数。除此之外，还可以使用Animator为组件添加动画效果。
    我为《东方驱魔社》中的UI做了类图，其中实现了背包物品的管理功能。
     */
}
