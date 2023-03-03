using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrEase : MonoBehaviour
{
    public Vector3 begin = Vector3.zero;
    public Vector3 end = 10 * Vector3.one;
    public GameObject gameObject = null;
    public bool pingpong = true;
    public float time = 5;

    public enum LerpType//使用枚举来存储不同的动画效果
    {
        Linear,
        EaseIn,
        EaseOut,
        EaseInOut
    }
    public LerpType t;//当前的动画效果
    // Start is called before the first frame update
    void Start()
    {
        move(gameObject, begin, end, time, pingpong);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void move(GameObject gameObject, Vector3 begin, Vector3 end, float time, bool pingpong)
    {
        StartCoroutine(MoveCoroutine(gameObject, begin, end, time, pingpong,t));//开始第一个协程
    }
    //使用协程来处理问题
    private IEnumerator MoveCoroutine(GameObject gameObject, Vector3 begin, Vector3 end, float time, bool pingpong,LerpType t)
    {

        float passtime = 0;
        while (passtime < time)
        {
            passtime += Time.deltaTime;
            float lerptype = WhitchLerpType(passtime / time, t);//根据不同的类型得到不同的插值比例
            gameObject.transform.position = Vector3.Lerp(begin, end, lerptype);//通过lerp函数来计算比例插值从而确定位置
            yield return null;//每一帧后继续进行
        }//如果!pingpong，协程结束
        if (pingpong)
        {
            passtime = 0;//重置移动时间
            while (passtime < time)
            {
                passtime += Time.deltaTime;
                float lerptype = WhitchLerpType(passtime / time, t);
                gameObject.transform.position = Vector3.Lerp(end,begin, lerptype);//因为已经到了终点，所以终点和起点互换
                yield return null;
            }
            StartCoroutine(MoveCoroutine(gameObject, begin, end, time, pingpong,t));//重新开始一次协程，再次从起点出发
        }//新的协程开始，旧的协程结束
    }

    private float WhitchLerpType(float time,LerpType t)//根据不同的效果类型计算不同的插值比例
    {
        switch (t)
        {
            case LerpType.Linear://线性直接返回
                return time;
            case LerpType.EaseIn:
                return Mathf.Pow(time, 2);//当前前进的比例越小移动的距离越小，加速
            case LerpType.EaseOut:
                return 1-Mathf.Pow(1-time, 2);//当前前进的比例越大移动的举例越小，减速
            case LerpType.EaseInOut:
                return time < 0.5f ? Mathf.Pow(time, 2)*2 : 1 - Mathf.Pow(1 - time, 2)*2;//先加速后减速，必须乘以2，否则没法到达中点
            default:
                return time;
        }
    }

}
