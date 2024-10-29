using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StuffChange : MonoBehaviour
{
    [SerializeField] private Sprite ground;//바닥
    [SerializeField] private Sprite wall;//벽
    [SerializeField] private Sprite goal;//골
    [SerializeField] private Sprite box;//상자
    [SerializeField] private Sprite boxOnGoal;//골 위에 상자

    private SpriteRenderer sr;//스프라이트 그려주는 렌더러
    private MapEnum mapEnumType;//맵에 그려지는 오브젝트의 타입
    private bool isOnGoal;//골 위에 상자가 있는지 여부.
#region Property
    public MapEnum MapEnumType//오브젝트 타입 프로퍼티
    {
        set//get은 없고 set만 있다.
        {
            mapEnumType = value;
            if(mapEnumType == MapEnum.Ground)
            {
                sr.sprite = ground;
                sr.sortingOrder = 1;
            }
            else if(mapEnumType == MapEnum.Wall)
            {
                sr.sprite = wall;
                sr.sortingOrder = 2;
            }
            else if(mapEnumType == MapEnum.Goal)
            {
                sr.sprite = goal;
                sr.sortingOrder = 3;
            }
            else//상자인 경우
            {
                //상자가 골인지 아닌지, box 와 boxongoal 두개 한꺼번에 한다 우와
                sr.sprite = isOnGoal ? boxOnGoal : box;
                sr.sortingOrder = 4;
            }

        }
    }
    public bool IsOnGoal
    {
        get => isOnGoal;
        set
        {
            isOnGoal = value;
            if(mapEnumType == MapEnum.Box)
            {
                sr.sprite = isOnGoal ? boxOnGoal : box;
            }

        }
    }
#endregion Property
    private void Awake()//enum값 지정 때문에 
    {
        sr = GetComponent<SpriteRenderer>();
        mapEnumType = MapEnum.Ground;
        isOnGoal = false;
    }
}
