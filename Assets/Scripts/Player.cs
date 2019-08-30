using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    [Tooltip("In ms^-1")] [SerializeField] float xSpeed = 4f;
    [Tooltip("In ms^-1")] [SerializeField] float ySpeed = 3f;

    [SerializeField] float maximumHorizontal = 5.0f;
    [SerializeField] float maximumVertical = 2.0f;

    [SerializeField] GameObject[] guns;

    GameObject mainCamera;
    Transform mainCameraTransform;

    Scoreboard scoreBoard;

    float xThrow, yThrow;

    bool isAlive = true;

    void Start()
    {
        // mainCamera = FindObjectOfType<Main Camera>();
        mainCamera = (GameObject) GameObject.FindWithTag("MainCamera");
        mainCameraTransform = mainCamera.GetComponent<Transform>();
        scoreBoard = FindObjectOfType<Scoreboard>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAlive)
        {
            ProcessTranslation();
            //ProcessRotation();
            ProcessFiring();
        }
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;

        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * ySpeed * Time.deltaTime;

        float rawXPos = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(rawXPos, -maximumHorizontal, maximumHorizontal);

        float rawYPos = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(rawYPos, -maximumVertical, 5 * maximumVertical);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);

        mainCameraTransform.localPosition = new Vector3(mainCameraTransform.localPosition.x, mainCameraTransform.localPosition.y, mainCameraTransform.localPosition.z + 3);
    }


    void OnPlayerDeath() {
        //deathSfx.setActive(true);
        isAlive = false;
    }

    void ProcessFiring()
    {
        SetGunActive(CrossPlatformInputManager.GetButton("Fire"));
    }

    void SetGunActive(bool isActive)
    {
        //print(isActive);
        foreach(GameObject gun in guns)
        {
            var emissionModule = gun.GetComponent<ParticleSystem>().emission;
            emissionModule.enabled = isActive;
        }
    }
}
