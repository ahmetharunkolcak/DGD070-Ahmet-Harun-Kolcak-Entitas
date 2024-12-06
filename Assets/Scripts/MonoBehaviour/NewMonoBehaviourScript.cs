using UnityEngine;
using Entitas;

public class PlayerHealthMonoBehaviour : MonoBehaviour
{
    private Contexts _contexts;
    private GameEntity _playerEntity;
    private Systems _systems;

    public float currentHealth;

    void Start()
    {
        _contexts = Contexts.sharedInstance;

        
        _systems = new PlayerHealthFeature(_contexts);
        _systems.Initialize();

       
        _playerEntity = _contexts.game.CreateEntity();
        _playerEntity.AddPlayerHealth(100); // Initial health set to 100
        currentHealth = 100;
    }

    void Update()
    {
        
        _systems.Execute();
        _systems.Cleanup();

        
        if (Input.GetKeyDown(KeyCode.D))
        {
            _playerEntity.isPlayerDamaged = true; // Trigger damage
        }
        if (Input.GetKeyDown(KeyCode.H))
        {
            _playerEntity.isPlayerHealed = true; // Trigger healing
        }

        
        if (_playerEntity.hasPlayerHealth)
        {
            currentHealth = _playerEntity.playerHealth.Value;
        }
    }

    void OnGUI()
    {
        
        GUI.Label(new Rect(10, 10, 200, 20), "Player Health: " + currentHealth);
    }

    void OnDestroy()
    {
       
        _systems.TearDown();
    }
}
