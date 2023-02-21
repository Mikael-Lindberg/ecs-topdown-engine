using System.Collections.Generic;

public class Scene {
    private List<GameObject> gameObjects;

    public Scene() {
        gameObjects = new List<GameObject>();
    }

    public void AddGameObject(GameObject gameObject) {
        gameObjects.Add(gameObject);
    }

    public void RemoveGameObject(GameObject gameObject) {
        gameObjects.Remove(gameObject);
    }

    public void Update() {
        foreach (GameObject gameObject in gameObjects) {
            gameObject.Update();
        }
    }
}
