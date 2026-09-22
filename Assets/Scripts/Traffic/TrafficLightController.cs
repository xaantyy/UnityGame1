using UnityEngine;

public class TrafficLightController : MonoBehaviour
{
    [SerializeField] private Renderer _trafficLightEastWest;
    [SerializeField] private Renderer _trafficLightEastWest2;
    [SerializeField] private Renderer _trafficLightSouthNorth;
    [SerializeField] private Renderer _trafficLightSouthNorth2;
    [SerializeField] private float _greenTime = 10f;
    [SerializeField] private float _yellowTime = 3f;
    [SerializeField] private float _allRedTime = 9f;
    [SerializeField] private Renderer _pedestrianLightNorth;
    [SerializeField] private Renderer _pedestrianLightSouth;
    [SerializeField] private Renderer _pedestrianLightEast;
    [SerializeField] private Renderer _pedestrianLightWest;
    private float _timer = 0f;
    private int _currentLight = 0;

    void Start()
    {
        _timer = Random.Range(0f, _greenTime);

        SetEastWestColor(Color.green);
        SetSouthNorthColor(Color.red);
        SetPedestrianColors();
    }

    void Update()
    {
        _timer = _timer + Time.deltaTime;

        if (_currentLight == 0)
        {
            if (_timer >= _greenTime)
            {
                SetEastWestColor(Color.yellow);

                _currentLight = 1;
                _timer = 0f;

                SetPedestrianColors();
            }
        }
        else if (_currentLight == 1)
        {
            if (_timer >= _yellowTime)
            {
                SetEastWestColor(Color.red);
                SetSouthNorthColor(Color.red);

                _currentLight = 4;
                _timer = 0f;

                SetPedestrianColors();
            }
        }
        else if (_currentLight == 4)
        {
            if (_timer >= _allRedTime)
            {
                SetSouthNorthColor(Color.green);

                _currentLight = 2;
                _timer = 0f;

                SetPedestrianColors();
            }
        }
        else if (_currentLight == 2)
        {
            if (_timer >= _greenTime)
            {
                SetSouthNorthColor(Color.yellow);

                _currentLight = 3;
                _timer = 0f;

                SetPedestrianColors();
            }
        }
        else if (_currentLight == 3)
        {
            if (_timer >= _yellowTime)
            {
                SetSouthNorthColor(Color.red);
                SetEastWestColor(Color.red);

                _currentLight = 5;
                _timer = 0f;

                SetPedestrianColors();
            }
        }
        else if (_currentLight == 5)
        {
            if (_timer >= _allRedTime)
            {
                SetEastWestColor(Color.green);

                _currentLight = 0;
                _timer = 0f;

                SetPedestrianColors();
            }
        }
    }

    void SetEastWestColor(Color color)
    {
        SetColor(_trafficLightEastWest, color);
        SetColor(_trafficLightEastWest2, color);
    }

    void SetSouthNorthColor(Color color)
    {
        SetColor(_trafficLightSouthNorth, color);
        SetColor(_trafficLightSouthNorth2, color);
    }

    public bool CanDrive(bool eastWest)
    {
        if (eastWest == true)
        {
            if (_currentLight == 0 || _currentLight == 1)
            {
                return true;
            }
        }

        if (eastWest == false)
        {
            if (_currentLight == 2 || _currentLight == 3)
            {
                return true;
            }
        }

        return false;
    }

    public bool CanWalk(bool crossingEastWestRoad)
    {
        if (_currentLight == 4 || _currentLight == 5)
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
            SetColor(_pedestrianLightNorth, Color.green);
            SetColor(_pedestrianLightSouth, Color.green);
            SetColor(_pedestrianLightEast, Color.green);
            SetColor(_pedestrianLightWest, Color.green);
        }
        else
        {
            SetColor(_pedestrianLightNorth, Color.red);
            SetColor(_pedestrianLightSouth, Color.red);
            SetColor(_pedestrianLightEast, Color.red);
            SetColor(_pedestrianLightWest, Color.red);
        }
    }

    void SetColor(Renderer lightRenderer, Color color)
    {
        if (lightRenderer != null)
        {
            lightRenderer.material.color = color;
        }
    }
}