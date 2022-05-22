using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prog3ExamenFinal2021
{
    public partial class Form2 : Form
    {
        Stopwatch osw = new Stopwatch();
        Jugador j1;
        int tiempo = 60;
        List<string> palabras = new List<string>();
        List<char> palabra = new List<char>();
        List<char> encriptado = new List<char>();

        public Form2(string name)
        {
            InitializeComponent();



            this.j1 = new Jugador(name);

            this.label3.Text = "Vidas: " + j1.Vidas;

            Recoger();
            ElegirPalabra();

            this.label1.Text = "";
            for(int i=0; i < this.encriptado.Count; i++)
            {
                this.label1.Text += this.encriptado[i];
            }

            this.osw.Start();

            this.timer1.Enabled = true;
        }

        public Form2()
        {
            InitializeComponent();
        }

        private void Recoger()
        {
            FileInfo file = new FileInfo(@"C:\Users\Martin\Desktop\Ahorcado.txt");

            try
            {
                if (file.Exists)
                {
                    FileStream fs = file.OpenRead();
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        palabras.Add(sr.ReadLine());
                        palabras.Add(sr.ReadLine());
                        palabras.Add(sr.ReadLine());
                        palabras.Add(sr.ReadLine());
                    }
                    fs.Close();
                }
                else
                {
                    MessageBox.Show("archivo no encontrado");
                }
            }
            catch
            {
                MessageBox.Show("error");
            }



        }

        private void ElegirPalabra()
        {
            Random r = new Random();

            char[] aux = new char[this.palabras.Count];

            aux = this.palabras[r.Next(0,this.palabras.Count)].ToCharArray();

            for(int i = 0; i < aux.Length; i++)
            {
                this.palabra.Add(aux[i]);
                this.encriptado.Add('*');
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var aux = new string(palabra.ToArray());

            if (this.textBox1.Text.Equals(aux))
            {
                this.timer1.Stop();
                FileInfo file = new FileInfo(@"C:\Users\Martin\Desktop\Ranking.txt");
                MessageBox.Show("GANO");
                j1.CalcularPuntaje(this.tiempo, this.j1.Vidas);
                FileStream fs = file.OpenWrite();

                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine("Nombre: {0}: Puntaje {1}.", this.j1.Nombre, this.j1.Puntaje);
                }

                this.Close();
            }

            if (palabra.Contains(char.Parse(this.textBox1.Text)))
            {
                this.label1.Text = "";
                for(int i=0; i < this.palabra.Count; i++)
                {
                    if (this.palabra[i]==char.Parse(this.textBox1.Text))
                    {
                        this.encriptado[i] = this.palabra[i];
                    }
                }
                for (int i = 0; i < this.encriptado.Count; i++)
                {
                    this.label1.Text += this.encriptado[i];
                }
            }
            else
            {
                this.j1.RestarVida();
                this.label3.Text = String.Format("Vidas: {0}", this.j1.Vidas);
            }

            if (j1.Vidas == 0)
            {
                MessageBox.Show("PERDIO");
                this.Close();
            }

            if (this.encriptado.Contains('*') == false)
            {
                this.timer1.Stop();
                FileInfo file = new FileInfo(@"C:\Users\Martin\Desktop\Ranking.txt");
                MessageBox.Show("GANO");
                j1.CalcularPuntaje(this.tiempo, this.j1.Vidas);
                FileStream fs = file.OpenWrite();

                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine("Nombre: {0}: Puntaje {1}.", this.j1.Nombre, this.j1.Puntaje);
                }

                this.Close();
            }

            this.textBox1.Text = "";
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            TimeSpan crono = new TimeSpan(0, 0, 0, 0, (int)this.osw.ElapsedMilliseconds);

            int x = 60;
            x = x - crono.Seconds;
            this.tiempo = x;
            this.label2.Text = "Tiempo: " + x;

            if (crono.Seconds == 60)
            {
                this.timer1.Stop();
                MessageBox.Show("PERDIO");
            }
        }
    }
}
