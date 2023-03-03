using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrMove : MonoBehaviour
{
    public Vector3 begin = Vector3.zero;
    public Vector3 end = 10 * Vector3.one;
    public GameObject gameObject = null;
    public bool pingpong = true;
    public float time = 5;
    // Start is called before the first frame update
    void Start()
    {
        move(gameObject,begin,end,time,pingpong);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void move(GameObject gameObject,Vector3 begin,Vector3 end,float time,bool pingpong)
    {
        StartCoroutine(MoveCoroutine(gameObject, begin, end, time, pingpong));//开始第一个协程
    }
    //使用协程来处理问题
    private IEnumerator MoveCoroutine(GameObject gameObject,Vector3 begin,Vector3 end,float time,bool pingpong)
    {
        float passtime = 0;
        while(passtime < time)
        {
            passtime += Time.deltaTime;
            gameObject.transform.position=Vector3.Lerp(begin,end,passtime/time);//通过lerp函数来计算比例插值从而确定位置
            yield return null;//每一帧后继续进行
        }//如果!pingpong，协程结束
        if (pingpong)
        {
            passtime = 0;//重置移动时间
            while (passtime < time)
            {
                passtime += Time.deltaTime;
                gameObject.transform.position = Vector3.Lerp(end, begin, passtime / time);//因为已经到了终点，所以终点和起点互换
                yield return null;
            }
            StartCoroutine(MoveCoroutine(gameObject,begin,end,time, pingpong));//重新开始一次协程，再次从起点出发
        }//新的协程开始，旧的协程结束
    }
}
