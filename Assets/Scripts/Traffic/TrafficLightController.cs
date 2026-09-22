using UnityEngine;

public class TrafficLightController : MonoBehaviour
{
    public GameObject trafficLightEastWest;
    public GameObject trafficLightEastWest2;
    public GameObject trafficLightSouthNorth;
    public GameObject trafficLightSouthNorth2;
    public float greenTime = 10f;
    public float yellowTime = 3f;
    public float allRedTime = 9f;
    float timer = 0f;
    int currentLight = 0;
    public GameObject pedestrianLightNorth;
    public GameObject pedestrianLightSouth;
    public GameObject pedestrianLightEast;
    public GameObject pedestrianLightWest;

    void Start()
    {
        timer = Random.Range(0f, greenTime);
        SetEastWestColor(Color.green);
        SetSouthNorthColor(Color.red);
        SetPedestrianColors();
    }

    void Update()
    {
        timer = timer + Time.deltaTime;

        if (currentLight == 0)
        {
            if (timer >= greenTime)
            {
                SetEastWestColor(Color.yellow);
                currentLight = 1;
                timer = 0f;
                SetPedestrianColors();
            }
        }
        else if (currentLight == 1)
        {
            if (timer >= yellowTime)
            {
                SetEastWestColor(Color.red);
                SetSouthNorthColor(Color.red);
                currentLight = 4;
                timer = 0f;
                SetPedestrianColors();
            }
        }
        else if (currentLight == 4)
        {
            if (timer >= allRedTime)
            {
                SetSouthNorthColor(Color.green);
                currentLight = 2;
                timer = 0f;
                SetPedestrianColors();
            }
        }
        else if (currentLight == 2)
        {
            if (timer >= greenTime)
            {
                SetSouthNorthColor(Color.yellow);
                currentLight = 3;
                timer = 0f;
                SetPedestrianColors();
            }
        }
        else if (currentLight == 3)
        {
            if (timer >= yellowTime)
            {
                SetSouthNorthColor(Color.red);
                SetEastWestColor(Color.red);
                currentLight = 5;
                timer = 0f;
                SetPedestrianColors();
            }
        }
        else if (currentLight == 5)
        {
            if (timer >= allRedTime)
            {
                SetEastWestColor(Color.green);
                currentLight = 0;
                timer = 0f;
                SetPedestrianColors();
            }
        }
    }

    void SetEastWestColor(Color color)
    {
        if (trafficLightEastWest != null)
        {
            Renderer lightRenderer = trafficLightEastWest.GetComponent<Renderer>();
            lightRenderer.material.color = color;
        }

        if (trafficLightEastWest2 != null)
        {
            Renderer lightRenderer2 = trafficLightEastWest2.GetComponent<Renderer>();
            lightRenderer2.material.color = color;
        }
    }

    void SetSouthNorthColor(Color color)
    {
        if (trafficLightSouthNorth != null)
        {
            Renderer lightRenderer = trafficLightSouthNorth.GetComponent<Renderer>();
            lightRenderer.material.color = color;
        }

        if (trafficLightSouthNorth2 != null)
        {
            Renderer lightRenderer2 = trafficLightSouthNorth2.GetComponent<Renderer>();
            lightRenderer2.material.color = color;
        }
    }

    public bool CanDrive(bool eastWest)
    {
        if (eastWest == true)
        {
            if (currentLight == 0 || currentLight == 1)
            {
                return true;
            }
        }

        if (eastWest == false)
        {
            if (currentLight == 2 || currentLight == 3)
            {
                return true;
            }
        }
        return false;
    }

    public bool CanWalk(bool crossingEastWestRoad)
    {
        if (currentLight == 4 || currentLight == 5)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void SetPedestrianColors()
    {
        if (CanWalk(true) == true)
        {
            SetColor(pedestrianLightNorth, Color.green);
            SetColor(pedestrianLightSouth, Color.green);
            SetColor(pedestrianLightEast, Color.green);
            SetColor(pedestrianLightWest, Color.green);
        }
        else
        {
            SetColor(pedestrianLightNorth, Color.red);
            SetColor(pedestrianLightSouth, Color.red);
            SetColor(pedestrianLightEast, Color.red);
            SetColor(pedestrianLightWest, Color.red);
        }
    }

    void SetColor(GameObject obj, Color color)
    {
        if (obj != null)
        {
            Renderer lightRenderer = obj.GetComponent<Renderer>();
            lightRenderer.material.color = color;
        }
    }
}