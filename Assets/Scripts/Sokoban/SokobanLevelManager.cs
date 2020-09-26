using UnityEngine;
using System.Collections.Generic;

public class SokobanLevelManager : MonoBehaviour
{
    public GameObject casillero;
    public GameObject casilleroTarget;
    public GameObject jugador;
    public GameObject bloque;
    public GameObject pared;
 
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
        Tablero tablero = SokobanLevelManager.instancia.dameTablero(8, 8);

        tablero.setearObjeto(pared, new Vector2(6, 6));
        tablero.setearObjeto(jugador, new Vector2(1,1));
        tablero.setearObjeto(bloque, new Vector2(5,4));
        tablero.setearObjeto(bloque, new Vector2(3, 3));
        tablero.setearObjeto(bloque, new Vector2(4, 4));
        tablero.setearObjeto(casilleroTarget, new Vector2(1, 7));
        tablero.setearObjeto(casilleroTarget, new Vector2(2, 7));
        tablero.setearObjeto(casilleroTarget, new Vector2(3, 7));
        return tablero;
    }
}


