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
        StartCoroutine(MoveCoroutine(gameObject, begin, end, time, pingpong));//��ʼ��һ��Э��
    }
    //ʹ��Э������������
    private IEnumerator MoveCoroutine(GameObject gameObject,Vector3 begin,Vector3 end,float time,bool pingpong)
    {
        float passtime = 0;
        while(passtime < time)
        {
            passtime += Time.deltaTime;
            gameObject.transform.position=Vector3.Lerp(begin,end,passtime/time);//ͨ��lerp���������������ֵ�Ӷ�ȷ��λ��
            yield return null;//ÿһ֡���������
        }//���!pingpong��Э�̽���
        if (pingpong)
        {
            passtime = 0;//�����ƶ�ʱ��
            while (passtime < time)
            {
                passtime += Time.deltaTime;
                gameObject.transform.position = Vector3.Lerp(end, begin, passtime / time);//��Ϊ�Ѿ������յ㣬�����յ����㻥��
                yield return null;
            }
            StartCoroutine(MoveCoroutine(gameObject,begin,end,time, pingpong));//���¿�ʼһ��Э�̣��ٴδ�������
        }//�µ�Э�̿�ʼ���ɵ�Э�̽���
    }
}
