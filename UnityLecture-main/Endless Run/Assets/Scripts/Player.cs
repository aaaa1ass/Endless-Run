using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;

public enum RoadLine
{ 
    LEFT = -1,
    MIDDLE = 0,
    RIGHT = 1
}

public class Player : MonoBehaviour
{
    [SerializeField] CharacterController characterController;
    [SerializeField] Vector3 direction;

    [SerializeField] Animator animator;
    [SerializeField] RoadLine roadLine;
    [SerializeField] float jumpPower = 20f;
    [SerializeField] float positionX = 3.5f;

    [SerializeField] UnityEvent playerEvent;

    [SerializeField] ObjectSound objectSound = new ObjectSound();

    private void Start()
    {
        direction = transform.position;

    }

    void Update()
    {
        // 캐릭터 이동 함수
        Move();

        // 캐릭터 점프 함수
        Jump();

        // 캐릭터 이동 상태
        Status();

    }

    public void Move()
    {
        // 왼쪽 방향 키를 입력했을 때
        if(Input.GetKeyDown(KeyCode.LeftArrow) && Time.timeScale != 0)
        {
            AudioManager.instance.Sound(objectSound.audioClip[0]);

            if (roadLine == RoadLine.LEFT)
            {
                roadLine = RoadLine.LEFT;
            }
            else
            {
                roadLine--;
            }
        }

        // 오른쪽 방향 키를 입력했을 때
        if(Input.GetKeyDown(KeyCode.RightArrow)&& Time.timeScale != 0)
        {
            AudioManager.instance.Sound(objectSound.audioClip[0]);

            if (roadLine == RoadLine.RIGHT)
            {
                roadLine = RoadLine.RIGHT;
            }
            else
            {
                roadLine++;
            }
        }
    }

    public void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(transform.position.y <= 0.01f)
            {
                characterController.Move(Vector3.up * jumpPower * Time.deltaTime);
            }
        }
        direction.y -= 50f * Time.deltaTime;

        transform.position = direction;
    }

    public void Status()
    {
        switch (roadLine)
        {
            case RoadLine.LEFT : transform.position = new Vector3( -positionX, transform.position.y, 0);
                break;
            case RoadLine.MIDDLE : transform.position = new Vector3(0, transform.position.y, 0);
                break;
            case RoadLine.RIGHT : transform.position = new Vector3( +positionX, transform.position.y, 0);
                break;
        }
    }

    public void OnDie()
    {
        playerEvent.Invoke();
        animator.Play("Die");

    }

    public void OnGameOverUI()
    {
        GameManager.instance.GameOverPanel();
    }

    private void OnTriggerEnter(Collider other)
    {
        IItem item = other.GetComponent<IItem>();

        if(item != null)
        {
            item.Use();
            other.GetComponent<MeshRenderer>().enabled = false;
        }

        if (other.CompareTag("Obstacle"))
        {
            OnDie();
        }
    }
}
