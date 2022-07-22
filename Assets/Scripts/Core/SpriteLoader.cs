using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SpriteLoader : MonoBehaviour
{
    [SerializeField] string weaponName;

    // This dict stores for each folder multiple lists of sprites (accessory variants)
    private Dictionary<string, List<Sprite[]>> weaponAccessories;

    void Start()
    {
        GetAccessoriesDividedByVariants();
    }

    private void GetAccessoriesDividedByVariants()
    {
        weaponAccessories = new Dictionary<string, List<Sprite[]>>();

        var directoryInfo = new DirectoryInfo(@"Assets\\Resources\\" + weaponName);
        DirectoryInfo[] dirs = directoryInfo.GetDirectories();

        foreach (DirectoryInfo dir in dirs)
        {
            // Store every list of sprites present in this dir
            List<Sprite[]> sprites = new List<Sprite[]>();

            // Searching for sub folder
            var subDirectoryInfo = new DirectoryInfo(@"" + dir.FullName);
            DirectoryInfo[] subDirs = subDirectoryInfo.GetDirectories();

            foreach (DirectoryInfo subDir in subDirs)
            {
                var spritesToLoad = weaponName + "/" + dir.Name + "/" + subDir.Name + "/" + subDir.GetFiles()[0].Name.Replace(".png", "");
                sprites.Add(Resources.LoadAll<Sprite>(spritesToLoad));
            }
 
            weaponAccessories.Add(dir.Name, sprites);
        }
    }

    public List<Sprite[]> getAccessoriesByName(string accessoryName)
    {
        return weaponAccessories[accessoryName];
    }

    public Sprite getRandomAccessory(string name)
    {
     
        // Get amount of sprite lists for accessory identified by name
        var accessoryLists = weaponAccessories[name];

        // Choose a random list
        var index = Random.Range(0, accessoryLists.Count);
        var randomList = accessoryLists[index];

        // Choose a random variant in the random choosed list
        var randomVariant = randomList[Random.Range(0, randomList.Length)];

        return randomVariant;
    }
}
