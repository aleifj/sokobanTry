using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]//제이슨으로 맵 불러옴
public struct MapStruct
{
    public int SizeX;
    public int SizeY;
    public string Data;
}

public enum MapEnum//맵에 등장하는 오브젝트의 타입
{
    Ground, Wall, Goal, Box, BoxOnGoal, Player
}
public class GameManager : MonoBehaviour
{
    //싱글톤
    public static GameManager instance = null;
    private const float MOVE_SPEED = 7.0f;//플레이어 움직이는 속도.
    [SerializeField] private GameObject player;
    private Vector2 playerPosition;//플레이어의 위치.
    private Vector2 playerDirection;//플레이어의 방향.
    public MapStruct map;//맵의 정보를 가지고 있는 함수?

    private void Awake()
    {
        if(instance == null)//싱글톤 선언.
        {
            instance = this;
        }
    }
    //x,y 좌표에 따른 map에서의 위치 얻어오기
    private Vector2 GetPosition(float x, float y)
    {
        return new Vector2(x - map.SizeX * 0.5f, y - map.SizeY * 0.5f);
    }
    private void CheckKeyInput()
    {
        if (Input.GetButtonDown("Horizontal") || Input.GetButtonDown("Vertical"))
        {
            //x, y축 값을 -1, 0, 1로만 받아서(GetAxisRaw)
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");
            //대각선 입력은 무시하고
            if (moveX == 0 || moveY == 0)
            {
                //방향값을 정한다.
                playerDirection = new Vector2(moveX, moveY);
                //방향값에 따른 플레이어 애니메이션 실행
                player.GetComponent<PlayerAnimation>().SetAnimation(playerDirection);
            }
        }
    }
    private void Update()
    {
        //키 잆력 체크하고 방향, 위치값 변경
        CheckKeyInput();
        //플레이어 이미지 위치 변경. Lerp가 뭐지?, Lerp = position이 변화할 때 끊어지듯이 움직이는것이 아니라 자연스러워 보이게 변화함.
        player.transform.position = Vector2.Lerp(player.transform.position, GetPosition(playerPosition.x, playerPosition.y), Time.deltaTime * MOVE_SPEED);
    }
}
