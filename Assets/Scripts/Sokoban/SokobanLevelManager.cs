using UnityEngine;
using System.Collections.Generic;

public class SokobanLevelManager : MonoBehaviour
{
    public GameObject casillero;
    public GameObject casilleroTarget;
    public GameObject jugador;
    public GameObject bloque;
    public GameObject pared;
    public Texture2D mapa;
    public ColorAPrefab[] colorMappings;

    public static SokobanLevelManager instancia;

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public List<GameObject> dameLstPrefabsSokoban()
    {
        List<GameObject> lstPrefabsSokoban = new List<GameObject>();
        lstPrefabsSokoban.Add(casillero);
        lstPrefabsSokoban.Add(casilleroTarget);
        lstPrefabsSokoban.Add(jugador);
        lstPrefabsSokoban.Add(pared);
        lstPrefabsSokoban.Add(bloque);
        
        return lstPrefabsSokoban;
    }
                
    private Tablero dameTablero(int x, int y)
    {
        Tablero tablero = new Tablero(x, y);

        for (int i = 0; i < tablero.casilleros.GetLength(0); i++)
        {
            for (int j = 0; j < tablero.casilleros.GetLength(1); j++)
            {
                tablero.setearObjeto(casillero, new Vector2(i, j));
            }
        }

        return tablero;
    }

    public Nivel dameNivel(string nombre)
    {
        return SokobanLevelManager.instancia.dameNiveles().Find(x => x.Nombre == nombre);
    }

    private List<Nivel> dameNiveles()
    {
        List<Nivel> lstNiveles = new List<Nivel>();
        lstNiveles.Add(new Nivel("Nivel1", SokobanLevelManager.instancia.dameTableroNivel1()));
        return lstNiveles;
    }

    private Tablero dameTableroNivel1()
    {
        Tablero tablero = instancia.dameTablero(mapa.width, mapa.height);
        GenerarNivel(tablero);
        return tablero;
    }

        void GenerarNivel(Tablero tablero)
        {
            for (int x = 0; x < mapa.width; x++)
            {
                for (int y = 0; y < mapa.height; y++)
                {
                    GenerarTile(x, y, tablero);
                }
            }
        }

        void GenerarTile(int x, int y, Tablero tablero)
        {
            Color pixelColor = mapa.GetPixel(x, y);
            if (pixelColor.a == 0)
            {
                return;
            }
            foreach (ColorAPrefab colorMapping in colorMappings)
            {
                if (colorMapping.color.Equals(pixelColor))
                {
                    Vector2 position = new Vector2(x, y);
                    tablero.setearObjeto(colorMapping.prefab, position);
                }

            }
        }
}





