using Raylib_cs;
using System.Collections.Generic;
using System.Numerics;


public class GameObject {
    private Dictionary<Type, Component> components = new Dictionary<Type, Component>();

    public Vector2 forward = new Vector2(0, -1f);

    private Transform transform;

    private float speed = 200f;

    public GameObject(float x, float y) {
        AddComponent<Transform>(x, y);
        transform = GetComponent<Transform>();
        Console.WriteLine("Created an object with the position: " + new Vector2(x, y));
    }

    public T AddComponent<T>(params object[] constructorArgs) where T : Component {
        T component = (T)Activator.CreateInstance(typeof(T), constructorArgs);
        component.gameObject = this;
        components[typeof(T)] = component;
        return component;
    }

    public void RemoveComponent<T>() where T : Component {
        components.Remove(typeof(T));
    }

    public T GetComponent<T>() where T : Component {
        Component component;
        if (components.TryGetValue(typeof(T), out component)) {
            return (T)component;
        }
        return null;
    }

    public void Update() {
        forward = new Vector2((float)Math.Sin(transform.rotation * Math.PI / 180), (float)Math.Cos(transform.rotation * Math.PI / 180));
        // transform.Translate(forward * 100 * Raylib.GetFrameTime());

        if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) {
            transform.Rotate(KeyboardKey.KEY_A);
        }
        if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) {
            transform.Rotate(KeyboardKey.KEY_D);
        }

        if (transform.position.X > Raylib.GetScreenWidth()) {
            transform.position.X = 0;
        }

        if (transform.position.X < 0) {
            transform.position.X = Raylib.GetScreenWidth();
        }

        if (transform.position.Y > Raylib.GetScreenHeight()) {
            transform.position.Y = 0;
        }

        if (transform.position.Y < 0) {
            transform.position.Y = Raylib.GetScreenHeight();
        }

        foreach (Component component in components.Values) {
            component.Update();
        }

        Raylib.DrawCircle((int)transform.position.X, (int)transform.position.Y, 10, Color.RED);
        Raylib.DrawLineEx(transform.position, transform.position + transform.direction * 50, 2, Color.BLUE);
    }
}