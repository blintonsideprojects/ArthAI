using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileGrid : MonoBehaviour
{
    public int Width, Height;
    public int TileSize, Seed;
    public Dictionary<int, Tile> Tiles { get; private set; }
 
    [Serializable]
    class GroundTiles : TileData
    {
        public GroundTileType TileType;
    }
 
    [Serializable]
    class ObjectTiles : TileData
    {
        public ObjectTileType TileType;
    }

    class TileData
    {
        public Sprite Sprite;
        public Color Color;
        public Tile Tile;
        public Tile.ColliderType ColliderType;
    }

 
    [SerializeField]
    private GroundTiles[] GroundTileTypes;
    [SerializeField]
    private ObjectTiles[] ObjectTileTypes;

    public Dictionary<TilemapType, TilemapStructure> Tilemaps;

    private void Awake()
    {
        Tiles = InitializeTiles();
    
        Tilemaps = new Dictionary<TilemapType, TilemapStructure>();
    
        // Add all our tilemaps by type to collection, so we can access them easily.
        foreach (Transform child in transform)
        {
            var tilemap = child.GetComponent<TilemapStructure>();
            if (tilemap == null) continue;
            if (Tilemaps.ContainsKey(tilemap.Type))
            {
                throw new Exception("Duplicate tilemap type: " + tilemap.Type);
            }
            Tilemaps.Add(tilemap.Type, tilemap);
        }
    
        // Let's initialize our tilemaps now that they are in the collection.
        foreach (var tilemap in Tilemaps.Values)
        {
            tilemap.Initialize();
        }
    }   

    private Tile CreateTile(Color color, Sprite sprite)
    {
        // If we haven't specified one, we just create an empty one for the color instead
        bool setColor = false;
        Texture2D texture = sprite == null ? null : sprite.texture;
        if (texture == null)
        {
            setColor = true;
            // Created sprites do not support custom physics shape
            texture = new Texture2D(TileSize, TileSize)
            {
                filterMode = FilterMode.Point
            };
            sprite = Sprite.Create(texture, new Rect(0, 0, TileSize, TileSize), new Vector2(0.5f, 0.5f), TileSize);
        }
    
        // We should be using Point mode, to get the most quality out of our tiles
        texture.filterMode = FilterMode.Point;
    
        // Create our sprite with the texture passed along
        sprite = Sprite.Create(texture, new Rect(0, 0, TileSize, TileSize), new Vector2(0.5f, 0.5f), TileSize);
    
        // Create a scriptable object instance of type Tile (inherits from TileBase)
        var tile = ScriptableObject.CreateInstance<Tile>();
    
        if (setColor)
        {
            // Make sure color is not transparant
            color.a = 1;
            // Set the tile color
            tile.color = color;
        }
    
        // Assign the sprite we created earlier to our tiles
        tile.sprite = sprite;
    
        return tile;
    }

    private Dictionary<int, Tile> InitializeTiles() 
    {
        var dictionary = new Dictionary<int, Tile>();
    
        // Create a Tile for each GroundTileType
        foreach (var tiletype in GroundTileTypes)
        {
            // Don't make a tile for empty
            if (tiletype.TileType == 0) continue;

            // If we have a custom tile, use it otherwise create new
            var tile = tiletype.Tile == null ? 
            CreateTile(tiletype.Color, tiletype.Sprite) : 
            tiletype.Tile;
            tile.colliderType = tiletype.ColliderType;

            // Add to dictionary by key int value, value Tile
            dictionary.Add((int)tiletype.TileType, tile);
        }
    
        // Create a Tile for each ObjectTileType
        foreach (var tiletype in ObjectTileTypes)
        {
            // Don't make a tile for empty
            if (tiletype.TileType == 0) continue;

            // If we have a custom tile, use it otherwise create new 
            var tile = tiletype.Tile == null ? 
            CreateTile(tiletype.Color, tiletype.Sprite) :
            tiletype.Tile;
            tile.colliderType = tiletype.ColliderType;
            
            // Add to dictionary by key int value, value Tile
            dictionary.Add((int)tiletype.TileType, tile);
        }
    
        return dictionary;
    }
}