using UnityEngine;
using Random = System.Random;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] PlatformPrefab; 
    public GameObject FirstPlatformPrefab; 
    public int MinPlatform;
    public int MaxPlatform;
    public float DistanceBetweenPlatforms;
    public Transform FinishPlatform;
    public Transform CylinderRoot;
    public float ExtraCylinderScale = 1f;
    public Game Game;

    private void Awake()
    {
        int levelIndex = Game.LevelIndex;
        Random random = new Random(levelIndex);
        int platformsCount = RandomRange(random, MinPlatform, MaxPlatform + 1);

        for(int i = 0; i < platformsCount; i++) 
        {
            int prefabIndex = RandomRange(random, 0, PlatformPrefab.Length);
            GameObject platformPrefab = i == 0 ? FirstPlatformPrefab : PlatformPrefab[prefabIndex];
            GameObject platform =Instantiate(PlatformPrefab[prefabIndex], transform);
            platform.transform.localPosition = CalculatePlatformPosition(i);
            if (i > 0)
                platform.transform.localRotation = Quaternion.Euler(0, RandomRange(random, 0, 360f), 0);

        }

        FinishPlatform.localPosition = CalculatePlatformPosition(platformsCount);

        CylinderRoot.localScale = new Vector3(1, platformsCount * DistanceBetweenPlatforms + ExtraCylinderScale, 1);
    }

    private int RandomRange(Random random, int min, int maxExclusive)
    {
        int number = random.Next();
        int lenght = maxExclusive - min;
        number %= lenght;
        return min + number;

    }

    private float RandomRange(Random random, float min, float max)
    { 
        float t = (float)random.NextDouble();
        return Mathf.Lerp(min, max, t);  
    }

    private Vector3 CalculatePlatformPosition(int platformIndex)
    {
        return new Vector3(0, -DistanceBetweenPlatforms * platformIndex, 0);
    }
}
