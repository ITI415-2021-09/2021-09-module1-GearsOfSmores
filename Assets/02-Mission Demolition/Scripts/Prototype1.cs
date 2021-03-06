using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum GameModeProto
{
    idle,
    playing,
    levelEnd
}


public class Prototype1 : MonoBehaviour
{
    static private Prototype1 S; // a private Singleton
    [Header("Set in Inspector")]
    public Text uitLevel;  // The UIText_Level Text
    public Text uitShots;  // The UIText_Shots Text
    public Text uitButton; // The Text on UIButton_View
    public Vector3 castlePos; // The place to put castles
    public GameObject[] castles;   // An array of the castles
    public bool killedAllEnem = false; // Bool to check if all enmeies are dead
    private Enemy[] _enemies;

    [Header("Set Dynamically")]
    public int level;     // The current level
    public int levelMax;  // The number of levels
    public int shotsTaken;
    public GameObject castle;    // The current castle
    public GameModeProto mode = GameModeProto.idle;
    public string showing = "Show Slingshot"; // FollowCam mode



    void Start()
    {
        S = this; // Define the Singleton
        level = 0;
        levelMax = castles.Length;
        StartLevel();
    }


    void StartLevel()
    {
        // Get rid of the old castle if one exists
        if (castle != null)
        {
            Destroy(castle);

            // Destroy old projectiles if they exist
            GameObject[] gos = GameObject.FindGameObjectsWithTag("Projectile");
            foreach (GameObject pTemp in gos)
            {
                Destroy(pTemp);
            }
            // Instantiate the new castle
            castle = Instantiate<GameObject>(castles[level]);

            castle.transform.position = castlePos;
            shotsTaken = 0;
            // Reset the camera
            SwitchView("Show Both");
            ProjectileLine.S.Clear();
            _enemies = FindObjectsOfType<Enemy>();
            // Reset the goal
            // Goal.goalMet = false;

            UpdateGUI();

            mode = GameModeProto.playing;
        }
    }

    void UpdateGUI()
    {
        // Show the data in the GUITexts
       uitLevel.text = "Level: " + (level + 1) + " of " + levelMax;
        uitShots.text = "Shots Taken: " + shotsTaken;
    }
    void Update()
    {
        UpdateGUI();
        EnemiesAreAllDead();
        

        if (killedAllEnem == true && (mode == GameModeProto.playing))
        {
            // Change mode to stop checking for level end
            mode = GameModeProto.levelEnd;
            // Zoom out
            SwitchView("Show Both");
            // Start the next level in 2 seconds
            Invoke("NextLevel", 2f);

        }



    }

    private void EnemiesAreAllDead()
    {
        foreach (var enemy in _enemies)
        {
            // if any of the enemies are active return
            if (enemy != null)
                return;
        }
        killedAllEnem = true;
        return;



    }

    void NextLevel()
    {
        level++;
        if (level == levelMax)
        {
            level = 0;
        }
        StartLevel();
        killedAllEnem = false;
    }

    public void SwitchView(string eView = "")
    {
        
        if (eView == "")
        {
            eView = uitButton.text;
        }
        showing = eView;
        switch (showing)
        {
            case "Show Slingshot":
                FollowCam.POI = null;
                uitButton.text = "Show Castle";
                break;
            case "Show Castle":
                FollowCam.POI = S.castle;
                uitButton.text = "Show Both";
                break;
            case "Show Both":
                FollowCam.POI = GameObject.Find("ViewBoth");
                uitButton.text = "Show Slingshot";
                break;
        }
    }

    // Static method that allows code anywhere to increment shotsTaken
    public static void ShotFired()
    {                                            // d
        S.shotsTaken++;
    }
}
