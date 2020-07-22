using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using KinematicCharacterController;
using KinematicCharacterController.Examples;
using System.Linq;

namespace KinematicCharacterController.Walkthrough.BasicMovement
{
    public class MyPlayer : MonoBehaviour
    {
        public ExampleCharacterCamera OrbitCamera;
        public Transform CameraFollowPoint;
        public MyCharacterController Character;

        private const string MouseXInput = "Mouse X";
        private const string MouseYInput = "Mouse Y";
        private const string MouseScrollInput = "Mouse ScrollWheel";
        private const string HorizontalInput = "Horizontal";
        private const string VerticalInput = "Vertical";
        public float scrollSpeed=0.2f;
        public float timeToStopScroll=1f;
        float timeFromLastMove=0f;        
        PlayerCharacterInputs characterInputs = new PlayerCharacterInputs();

        private void Start()
        {
            characterInputs = new PlayerCharacterInputs(); // Construir la estructura CharacterInputs
            Cursor.lockState = CursorLockMode.Confined;

            // Dile a la cámara que siga la transformación
            OrbitCamera.SetFollowTransform(CameraFollowPoint);

            // Ignora los colisionadores del personaje para comprobar la obstrucción de la cámara
            OrbitCamera.IgnoredColliders.Clear();
            OrbitCamera.IgnoredColliders.AddRange(Character.GetComponentsInChildren<Collider>());
        }

        private void LateUpdate()
        {
            if (Input.GetMouseButtonDown(0))
            {
                //Cursor.lockState = CursorLockMode.Locked;
            }

            HandleCharacterInput();
            HandleCameraInput();
        }

        private void HandleCameraInput()
        {
            // Crea el vector de entrada de look para la cámara
           
           float mouseLookAxisUp = Input.GetAxisRaw(MouseYInput);
            float mouseLookAxisRight = Input.GetAxisRaw(MouseXInput);
            Vector3 lookInputVector = new Vector3(mouseLookAxisRight, mouseLookAxisUp, 0f);
            
            // Evite mover la cámara mientras el cursor no está bloqueado
            if (Cursor.lockState != CursorLockMode.Locked)
            {
               // lookInputVector = Vector3.zero;
            }

            // Entrada para hacer zoom en la cámara (deshabilitada en WebGL porque puede causar problemas)
            float scrollInput = -Input.GetAxis(MouseScrollInput);


#if UNITY_WEBGL
        scrollInput = 0f;
#endif

            // Apply inputs to the camera
            OrbitCamera.UpdateWithInput(Time.deltaTime, scrollInput, lookInputVector);
            
            // Handle toggling zoom level
            if (Input.GetMouseButtonDown(1))
            {
                OrbitCamera.TargetDistance = (OrbitCamera.TargetDistance == 0f) ? OrbitCamera.DefaultDistance : 0f;
            }
        }

        private void HandleCharacterInput()
        {
            if (!CheckKeyMoves()) //si no hay teclas de movimiento apretadas, recien chequeo por el scroll
            {
                CheckScrollMoves(); //chequeo por el scroll
                if (timeFromLastMove>timeToStopScroll) //empiezo a contar para frenar el timer del scroll. 
                {
                    characterInputs.MoveAxisForward=0; //stop del movimiento disparado por el scroll
                }
                else
                timeFromLastMove+=Time.deltaTime;
            }   

            characterInputs.MoveAxisRight = Input.GetAxisRaw(HorizontalInput);
            characterInputs.CameraRotation = OrbitCamera.Transform.rotation;

            // Aplicar entradas al personaje
            Character.SetInputs(ref characterInputs);
        }
    bool CheckKeyMoves()
    {
        float keyMoves=Input.GetAxis(VerticalInput);
        if (keyMoves!=0f)//gabo
            {
                characterInputs.MoveAxisForward = keyMoves;                
                return true;                
            }
        return false;
    }
    void CheckScrollMoves()
    {
        float scrollMoves= Input.GetAxisRaw(MouseScrollInput)*scrollSpeed;
        if (scrollMoves!=0f)//gabo
            {
                characterInputs.MoveAxisForward = scrollMoves;
                timeFromLastMove=0; //si hay scroll pongo el timer en 0
            }
            
    }
    }
}