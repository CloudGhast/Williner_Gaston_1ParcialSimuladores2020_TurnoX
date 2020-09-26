using UnityEngine;
using System.Collections.Generic;
public class Tablero
{
    public GameObject[,] casilleros { get; set; }

    public Tablero(int x, int y)
    {
        casilleros = new GameObject[x, y];
    }

    public void setearObjeto(GameObject objeto, Vector2 posicion)
    {
        if (!(posicion.x < 0) || (posicion.x >= casilleros.GetLength(0)) || (posicion.y < 0) || (posicion.y >= casilleros.GetLength(1)))
        {
            casilleros[(int)posicion.x, (int)posicion.y] = objeto;
        }
    }

    public void setearObjetos(GameObject objeto, List<Vector2> posiciones)
    {

        foreach (Vector2 posicion in posiciones)
        {
            if (!(posicion.x < 0) || (posicion.x >= casilleros.GetLength(0)) || (posicion.y < 0) || (posicion.y >= casilleros.GetLength(1)))
            {
                casilleros[(int)posicion.x, (int)posicion.y] = objeto;
            }
        }
    }

    public void setearObjeto(GameObject objeto, Vector2 origen, string sentido, int offset)
    {
        int valorX = 0, valorY = 0;
        switch (sentido)
        {
            case "derecha":
                valorX = offset;
                valorY = 0;
                break;
            case "arriba":
                valorX = 0;
                valorY = offset;
                break;
        }
        casilleros[(int)origen.x + valorX, (int)origen.y + valorY] = objeto;
    }

    public GameObject dameObjeto(Vector2 origen)
    {
        if ((origen.x < 0) || (origen.x >= casilleros.GetLength(0)) || (origen.y < 0) || (origen.y >= casilleros.GetLength(1)))
        {
            return null;
        }
        return casilleros[(int)origen.x, (int)origen.y];
    }

    public GameObject dameObjeto(Vector2 origen, string sentido, int offset)
    {
        int valorX = 0, valorY = 0;
        switch (sentido)
        {
            case "derecha":
                valorX = offset;
                break;
            case "arriba":
                valorY = offset;
                break;
        }

        if ((origen.x + valorX < 0) || (origen.x + valorX >= casilleros.GetLength(0)) || (origen.y + valorY < 0) || (origen.y + valorY >= casilleros.GetLength(1)))
        {
            return null;
        }
        return casilleros[(int)origen.x + valorX, (int)origen.y + valorY];
    }

    public List<Vector2> damePosicionesObjetos(string nombre)
    {
        List<Vector2> lstPosiciones = new List<Vector2>();

        for (int i = 0; i < casilleros.GetLength(0); i++)
        {
            for (int j = 0; j < casilleros.GetLength(1); j++)
            {
                if ((dameObjeto(new Vector2(i, j)) != null) && (dameObjeto(new Vector2(i, j)).name == nombre))
                {
                    lstPosiciones.Add(new Vector2(i, j));
                }
            }
        }
        return lstPosiciones;
    }

    public Vector2 damePosicionObjeto(string nombre)
    {
        List<Vector2> lstPosicionesObjetos = damePosicionesObjetos(nombre);
        return lstPosicionesObjetos[0];
    }
}
