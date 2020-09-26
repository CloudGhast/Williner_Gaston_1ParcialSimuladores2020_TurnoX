
    public class Nivel
    {
        public string Nombre { get; set; }
        public Tablero Tablero { get; set; }

        public Nivel(string nombre, Tablero tablero)
        {
            Nombre = nombre;
            Tablero = tablero;
        }
    }
