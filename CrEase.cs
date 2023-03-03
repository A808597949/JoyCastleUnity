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

    public enum LerpType//ʹ��ö�����洢��ͬ�Ķ���Ч��
    {
        Linear,
        EaseIn,
        EaseOut,
        EaseInOut
    }
    public LerpType t;//��ǰ�Ķ���Ч��
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
        StartCoroutine(MoveCoroutine(gameObject, begin, end, time, pingpong,t));//��ʼ��һ��Э��
    }
    //ʹ��Э������������
    private IEnumerator MoveCoroutine(GameObject gameObject, Vector3 begin, Vector3 end, float time, bool pingpong,LerpType t)
    {

        float passtime = 0;
        while (passtime < time)
        {
            passtime += Time.deltaTime;
            float lerptype = WhitchLerpType(passtime / time, t);//���ݲ�ͬ�����͵õ���ͬ�Ĳ�ֵ����
            gameObject.transform.position = Vector3.Lerp(begin, end, lerptype);//ͨ��lerp���������������ֵ�Ӷ�ȷ��λ��
            yield return null;//ÿһ֡���������
        }//���!pingpong��Э�̽���
        if (pingpong)
        {
            passtime = 0;//�����ƶ�ʱ��
            while (passtime < time)
            {
                passtime += Time.deltaTime;
                float lerptype = WhitchLerpType(passtime / time, t);
                gameObject.transform.position = Vector3.Lerp(end,begin, lerptype);//��Ϊ�Ѿ������յ㣬�����յ����㻥��
                yield return null;
            }
            StartCoroutine(MoveCoroutine(gameObject, begin, end, time, pingpong,t));//���¿�ʼһ��Э�̣��ٴδ�������
        }//�µ�Э�̿�ʼ���ɵ�Э�̽���
    }

    private float WhitchLerpType(float time,LerpType t)//���ݲ�ͬ��Ч�����ͼ��㲻ͬ�Ĳ�ֵ����
    {
        switch (t)
        {
            case LerpType.Linear://����ֱ�ӷ���
                return time;
            case LerpType.EaseIn:
                return Mathf.Pow(time, 2);//��ǰǰ���ı���ԽС�ƶ��ľ���ԽС������
            case LerpType.EaseOut:
                return 1-Mathf.Pow(1-time, 2);//��ǰǰ���ı���Խ���ƶ��ľ���ԽС������
            case LerpType.EaseInOut:
                return time < 0.5f ? Mathf.Pow(time, 2)*2 : 1 - Mathf.Pow(1 - time, 2)*2;//�ȼ��ٺ���٣��������2������û�������е�
            default:
                return time;
        }
    }

}
