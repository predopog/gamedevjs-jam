using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragMe : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    [SerializeField] bool returnToPosition = false;
    private bool isMoving = false;
    private float interpolationPoint = 0f;
    private Vector3 origin;

    gameManager gm;

    void Awake(){
        gm = GameObject.Find("GameManager").GetComponent<gameManager>();

        origin = transform.position;
    }

    void Update(){
        if (returnToPosition){
            transform.position = Vector3.Lerp(transform.position, origin, interpolationPoint);
            if (isMoving) interpolationPoint += 0.05f;
            if (interpolationPoint >= 1.5f) { isMoving = false; interpolationPoint = 0f; }
        }
        if (!isDragging) return;

        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;

    }

    private void OnMouseDown(){
        transform.localScale += transform.localScale * 0.5f;
        offset = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        isDragging = true;
        isMoving = false;

        if (!returnToPosition) return;

    }

    private void OnMouseUp(){
        transform.localScale = new Vector3(1, 1, 1);
        isDragging = false;
        if (!returnToPosition) return;

        
        // se estiver a distância maior que X da posição inicial
        if (Vector3.Distance(transform.position, origin) >= 3.5f)
        {
            // coloca a quest como accepted ou rejected 
            switch (gameObject.name)
            {
                case "acceptObject":
                    Debug.Log("Accepted");
                    gm.goToNextLevel(true);
                    break;
                case "rejectObject":
                    Debug.Log("Rejected");
                    gm.goToNextLevel(false);
                    break;
            }
            
            // chama função pra ir pra próxima quest
            
        }

        isMoving = true;

    }

}
