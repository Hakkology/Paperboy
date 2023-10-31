using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner
{
    private List<GameObject> carPrefabs;
    private List<CarPath> carPaths;
    private float spawnInterval = 4.0f;

    public CarSpawner(List<GameObject> carPrefabs, List<CarPath> carPaths)
    {
        this.carPrefabs = carPrefabs;
        this.carPaths = carPaths;
    }

    public void onStart(){
        SpawnInitialCars();
    }

    public IEnumerator SpawnCarsCoroutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            GameObject carPrefab = carPrefabs[Random.Range(0, carPrefabs.Count)];
            carPrefab.gameObject.SetActive(true);
            CarPath selectedPath = carPaths[Random.Range(0, carPaths.Count)];

            GameObject instantiatedCar = GameObject.Instantiate(carPrefab, selectedPath.spawnPoint.point.position, Quaternion.Euler(selectedPath.spawnPoint.rotation));
            CarHandler carMoverHandler = instantiatedCar.AddComponent<CarHandler>();
            carMoverHandler.Initialize(selectedPath);
        }
    }

    private void SpawnInitialCars(){
        GameObject carPrefab = carPrefabs[Random.Range(0, carPrefabs.Count)];
        carPrefab.gameObject.SetActive(true);
        CarPath selectedPath = carPaths[2];
        GameObject instantiatedCar = GameObject.Instantiate(carPrefab, selectedPath.spawnPoint.point.position, Quaternion.Euler(selectedPath.spawnPoint.rotation));
        CarHandler carMoverHandler = instantiatedCar.AddComponent<CarHandler>();
        carMoverHandler.Initialize(selectedPath);

        GameObject carPrefab2 = carPrefabs[Random.Range(0, carPrefabs.Count)];
        carPrefab2.gameObject.SetActive(true);
        CarPath selectedPath2 = carPaths[3];
        GameObject instantiatedCar2 = GameObject.Instantiate(carPrefab2, selectedPath2.spawnPoint.point.position, Quaternion.Euler(selectedPath2.spawnPoint.rotation));
        CarHandler carMoverHandler2 = instantiatedCar2.AddComponent<CarHandler>();
        carMoverHandler2.Initialize(selectedPath);
    }
}
