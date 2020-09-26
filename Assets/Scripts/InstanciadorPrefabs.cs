using System.Collections.Generic;
using UnityEngine;

public class InstanciadorPrefabs : MonoBehaviour
{
    public static InstanciadorPrefabs instancia;

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

    private void borrarPrefabsSobreCasilleros(List<GameObject> lstPrefabsQueSeMueven)
    {
        foreach (GameObject item in lstPrefabsQueSeMueven)
        {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag(item.tag))
            {
                if (obj.tag != "casillero")
                {
                    Destroy(obj);
                }
            }
        }
    }

    public void graficarCasilleros(Tablero tablero, GameObject casillero)
    {
        for (int i = 0; i < tablero.casilleros.GetLength(0); i++)
        {
            for (int j = 0; j < tablero.casilleros.GetLength(1); j++)
            {
                Instantiate(casillero, new Vector3(i, 0.0f, j), Quaternion.identity);
            }
        }
    }

    public void graficarCasillerosTarget(Tablero tablero, GameObject casilleroTarget)
    {
        for (int i = 0; i < tablero.casilleros.GetLength(0); i++)
        {
            for (int j = 0; j < tablero.casilleros.GetLength(1); j++)
            {
                if (tablero.dameObjeto(new Vector2(i, j)) != null && tablero.dameObjeto(new Vector2(i, j)).name == "CasilleroTarget")
                {
                    GameObject obj = tablero.dameObjeto(new Vector2(i, j));
                    Instantiate(obj, new Vector3(i, 0.01f, j), Quaternion.identity);
                }
            }
        }
    }

    public void graficarObjetosTablero(Tablero tablero, List<GameObject> lstPrefabsQueSeMueven)
    {
      InstanciadorPrefabs.instancia.borrarPrefabsSobreCasilleros(lstPrefabsQueSeMueven);
        
        for (int i = 0; i < tablero.casilleros.GetLength(0); i++)
        {
            for (int j = 0; j < tablero.casilleros.GetLength(1); j++)
            {
                Vector3 lugar = new Vector3(i - 0.1f, 0.3f, j + 0.2f);

                if (tablero.dameObjeto(new Vector2(i, j)) != null && tablero.dameObjeto(new Vector2(i, j)).tag != "casillero")
                {
                    GameObject obj = tablero.dameObjeto(new Vector2(i, j));
                    Instantiate(obj, lugar, Quaternion.identity);
                }
            }
        }
    }
}
