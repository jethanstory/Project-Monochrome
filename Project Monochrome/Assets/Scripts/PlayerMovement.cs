//Player Movement system
using System.Collections;
using System.Collections.Generic;

using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using Random = UnityEngine.Random;

using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 6f; //12
    public float gravity = -9.81f;
    public float jumpHeight = 1f; //3

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public float sprintTime = 7000; //1000 //300

    bool canSprint;

    private float m_StepCycled;
    private float m_NextStep;
    private bool m_IsWalking;
    private Vector2 m_Input;
    private CharacterController m_CharacterController;
    private AudioSource m_AudioSource;
    [SerializeField] private AudioClip[] m_FootstepSounds;
    [SerializeField][Range(0f, 1f)] private float m_RunstepLenghten;
    [SerializeField] private float m_StepInterval;
    [SerializeField] private AudioClip m_JumpSound;
    private Vector3 m_MoveDir = Vector3.zero;
    private CollisionFlags m_CollisionFlags;
    [SerializeField] private Camera m_Camera;
    [SerializeField] private bool m_UseHeadBob;
    [SerializeField] private CurveControlledBob m_HeadBob = new CurveControlledBob();
    [SerializeField] private LerpControlledBob m_JumpBob = new LerpControlledBob();
    private Vector3 m_OriginalCameraPosition;

    private Vector3 newCameraPosition;


    Vector3 velocity;
    bool isGrounded;

    void Start()
    {
        m_StepCycled = 0f;
        m_NextStep = m_StepCycled / 2f;
        m_AudioSource = GetComponent<AudioSource>();
        m_CharacterController = GetComponent<CharacterController>();
        //m_Camera = Camera.main;
        m_OriginalCameraPosition = m_Camera.transform.localPosition;
        m_HeadBob.Setup(m_Camera, m_StepInterval);

    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);



        // if (m_CharacterController.velocity.sqrMagnitude > 0 && (x != 0 || z != 0))
        // {
        //     m_StepCycled += (m_CharacterController.velocity.magnitude + (speed * (m_IsWalking ? 1f : m_RunstepLenghten))) *
        //                  Time.fixedDeltaTime;

        //     // m_Camera.transform.localPosition =
        //     // m_HeadBob.DoHeadBob(m_CharacterController.velocity.magnitude +
        //     //                  (speed * (m_IsWalking ? 1f : m_RunstepLenghten)));
        //     // newCameraPosition = m_Camera.transform.localPosition;


        // }



        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (Input.GetKey("left shift") && canSprint == true)
        {
            speed = 10f; //20
            sprintTime += -20;
            if (sprintTime < 0)
                canSprint = false;

            // m_Camera.transform.localPosition =
            // m_HeadBob.DoHeadBob(m_CharacterController.velocity.magnitude +
            //                  (speed * (m_IsWalking ? 1f : m_RunstepLenghten)));
            // newCameraPosition = m_Camera.transform.localPosition;
        }
        else
        {
            newCameraPosition = m_OriginalCameraPosition;
            speed = 6f; //12

            if (sprintTime < 7000)
                sprintTime += 20; //1
            else if (sprintTime == 7000)
                canSprint = true;
        }
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

        //ProgressStepCycle(speed);
        //UpdateCameraPosition(speed);

        if (Input.GetKey(KeyCode.LeftControl))
        {
            controller.height = 1.0f;
        }

        else
        {
            controller.height = 2.0f;
        }
    }


    private void ProgressStepCycle(float speed)
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        // if (m_CharacterController.velocity.sqrMagnitude > 0 && (velocity.x != 0 || velocity.y != 0))

        // if (m_CharacterController.velocity.sqrMagnitude > 0 && (x != 0 || z != 0))
        // {
        //     m_StepCycled += (m_CharacterController.velocity.magnitude + (speed * (m_IsWalking ? 1f : m_RunstepLenghten))) *
        //                  Time.fixedDeltaTime;
        // }


        // if (m_CharacterController.velocity.sqrMagnitude > 0 && (m_Input.x != 0 || m_Input.y != 0))
        // {
        //     m_StepCycled += (m_CharacterController.velocity.magnitude + (speed * (m_IsWalking ? 1f : m_RunstepLenghten))) *
        //                  Time.fixedDeltaTime;
        // }

        if (!(m_StepCycled > m_NextStep))
        {
            return;
        }

        m_NextStep = m_StepCycled + m_StepInterval;

        PlayFootStepAudio();
    }

    private void PlayFootStepAudio()
    {
        if (!m_CharacterController.isGrounded)
        {
            return;
        }

        // if (isGrounded)
        // {
        //     return;
        // }

        // pick & play a random footstep sound from the array,
        // excluding sound at index 0
        int n = Random.Range(1, m_FootstepSounds.Length);
        m_AudioSource.clip = m_FootstepSounds[n];
        m_AudioSource.PlayOneShot(m_AudioSource.clip);
        // move picked sound to index 0 so it's not picked next time
        m_FootstepSounds[n] = m_FootstepSounds[0];
        m_FootstepSounds[0] = m_AudioSource.clip;
    }


    private void UpdateCameraPosition(float speed)
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 newCameraPosition;
        if (!m_UseHeadBob)
        {
            return;
        }
        // if (m_CharacterController.velocity.magnitude > 0 && m_CharacterController.isGrounded)  && (x != 0 || z != 0)
        if (m_CharacterController.velocity.magnitude > 0 && m_CharacterController.isGrounded)
        {

            m_Camera.transform.localPosition =
                m_HeadBob.DoHeadBob(m_CharacterController.velocity.magnitude +
                                  (speed * (m_IsWalking ? 1f : m_RunstepLenghten)));
            newCameraPosition = m_Camera.transform.localPosition;
            //newCameraPosition.y = m_Camera.transform.localPosition.y - m_JumpBob.Offset();
        }
        else
        {
            newCameraPosition = m_Camera.transform.localPosition;
            //newCameraPosition.y = m_OriginalCameraPosition.y - m_JumpBob.Offset();
        }
        m_Camera.transform.localPosition = newCameraPosition;
    }





}
