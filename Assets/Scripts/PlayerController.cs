    using UnityEngine;

    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private TileGrid _grid;
        [SerializeField]
        private Rigidbody2D _rigidbody;
        [SerializeField]
        private float _movementSpeed;

        private TilemapStructure _groundMap;
         
        // Start is called before the first frame update
        void Start()
        {
            _groundMap = _grid.GetTilemap(TilemapType.Ground);
        }
 
        void Update()
        {
            Apply2DPhysicsMovement();
        }
         
        private void Apply2DPhysicsMovement()
        {
            var xMove = Input.GetAxisRaw("Horizontal");
            var yMove = Input.GetAxisRaw("Vertical");
            _rigidbody.velocity = new Vector2(xMove * _movementSpeed, yMove * _movementSpeed);
        }
    }