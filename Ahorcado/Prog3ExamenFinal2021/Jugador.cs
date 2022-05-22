using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog3ExamenFinal2021
{
    class Jugador
    {
        private string nombre;
        private int vidas = 6;
        private int puntaje;

        public Jugador()
        {

        }

        public Jugador(string nombre)
        {
            Nombre = nombre;
        }

        public void RestarVida()
        {
            vidas--;
        }

        public void CalcularPuntaje(int a, int b)
        {
            this.puntaje = a + b;
        }

        public string Nombre { get => nombre; set => nombre = value; }
        public int Vidas { get => vidas; set => vidas = value; }
        public int Puntaje { get => puntaje; set => puntaje = value; }
    }
}
