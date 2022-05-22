using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pruebaJ
{
    public partial class Form1 : Form, Proxy.IChatServiceCallback
    {
        System.Collections.IList list;
        List<CircularButton> lista;
        public bool turno { get; set; }
        public bool ganador { get; set; }
        public bool singleplayer;
        BOT Carlos;
        public Proxy.ChatServiceClient server { get; set; }
        public TableLayoutPanel panel;

        public Form1(bool player)
        {
            InitializeComponent();

            singleplayer = false;

            panel = this.tableLayoutPanel1;


            foreach (CircularButton boton in this.tableLayoutPanel1.Controls)
            {
                if (boton.TabIndex > 23 && boton.TabIndex < 30)
                {
                    boton.State = true;
                }
            }

            turno = true;
            ganador = false;
            if (singleplayer)
            {
                Carlos = new BOT(this.tableLayoutPanel1);

                backgroundWorker1.WorkerSupportsCancellation = true;
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void circularButton1_Click(object sender, EventArgs e)
        {
            if (server != null)
            {
                Server(circularButton1);
            }
            else
            {
                this.circularButton1.Buscar(this.tableLayoutPanel1, this.turno, false);

                if (singleplayer)
                {
                    Carlos.Rojos.Add(this.circularButton1);
                }
            }
        }

        private void circularButton2_Click(object sender, EventArgs e)
        {
            if (server != null)
            {
                Server(circularButton2);
            }
            else
            {
                this.circularButton2.Buscar(this.tableLayoutPanel1, this.turno, false);

                if (singleplayer)
                {
                    Carlos.Rojos.Add(this.circularButton2);
                }
            }
        }

        private void circularButton3_Click(object sender, EventArgs e)
        {
            if (server != null)
            {
                Server(circularButton3);
            }
            else
            {
                this.circularButton3.Buscar(this.tableLayoutPanel1, this.turno, false);

                if (singleplayer)
                {
                    Carlos.Rojos.Add(this.circularButton3);
                }
            }
        }

        private void circularButton4_Click(object sender, EventArgs e)
        {
            if (server != null)
            {
                Server(circularButton4);
            }
            else
            {
                this.circularButton4.Buscar(this.tableLayoutPanel1, this.turno, false);

                if (singleplayer)
                {
                    Carlos.Rojos.Add(this.circularButton4);
                }
            }
        }

        private void circularButton5_Click(object sender, EventArgs e)
        {
            if (server != null)
            {
                Server(circularButton5);
            }
            else
            {
                this.circularButton5.Buscar(this.tableLayoutPanel1, this.turno, false);

                if (singleplayer)
                {
                    Carlos.Rojos.Add(this.circularButton5);
                }
            }
        }

        private void circularButton6_Click(object sender, EventArgs e)
        {
            if (server != null)
            {
                Server(circularButton6);
            }
            else
            {
                this.circularButton6.Buscar(this.tableLayoutPanel1, this.turno, false);

                if (singleplayer)
                {
                    Carlos.Rojos.Add(this.circularButton6);
                }
            }
        }

        private void circularButton7_Click(object sender, EventArgs e)
        {
            if (server != null)
            {
                Server(circularButton7);
            }
            else
            {
                this.circularButton7.Buscar(this.tableLayoutPanel1, this.turno, false);

                if (singleplayer)
                {
                    Carlos.Rojos.Add(this.circularButton7);
                }
            }
        }

        private void circularButton8_Click(object sender, EventArgs e)
        {
            if (server != null)
            {
                Server(circularButton8);
            }
            else
            {
                this.circularButton8.Buscar(this.tableLayoutPanel1, this.turno, false);

                if (singleplayer)
                {
                    Carlos.Rojos.Add(this.circularButton8);
                }
            }
        }

        private void circularButton9_Click(object sender, EventArgs e)
        {
            if (server != null)
            {
                Server(circularButton9);
            }
            else
            {
                this.circularButton9.Buscar(this.tableLayoutPanel1, this.turno, false);

                if (singleplayer)
                {
                    Carlos.Rojos.Add(this.circularButton9);
                }
            }
        }

        private void circularButton10_Click(object sender, EventArgs e)
        {
            if (server != null)
            {
                Server(circularButton10);
            }
            else
            {
                this.circularButton10.Buscar(this.tableLayoutPanel1, this.turno, false);

                if (singleplayer)
                {
                    Carlos.Rojos.Add(this.circularButton10);
                }
            }
        }

        private void circularButton11_Click(object sender, EventArgs e)
        {
            if (server != null)
            {
                Server(circularButton11);
            }
            else
            {
                this.circularButton11.Buscar(this.tableLayoutPanel1, this.turno, false);

                if (singleplayer)
                {
                    Carlos.Rojos.Add(this.circularButton11);
                }
            }
        }

        private void circularButton12_Click(object sender, EventArgs e)
        {
            if (server != null)
            {
                Server(circularButton12);
            }
            else
            {
                this.circularButton12.Buscar(this.tableLayoutPanel1, this.turno, false);

                if (singleplayer)
                {
                    Carlos.Rojos.Add(this.circularButton12);
                }
            }
        }

        private void circularButton13_Click(object sender, EventArgs e)
        {
            if (server != null)
            {
                Server(circularButton13);
            }
            else
            {
                this.circularButton13.Buscar(this.tableLayoutPanel1, this.turno, false);

                if (singleplayer)
                {
                    Carlos.Rojos.Add(this.circularButton13);
                }
            }
        }

        private void circularButton14_Click(object sender, EventArgs e)
        {
            if (server != null)
            {
                Server(circularButton14);
            }
            else
            {
                this.circularButton14.Buscar(this.tableLayoutPanel1, this.turno, false);

                if (singleplayer)
                {
                    Carlos.Rojos.Add(this.circularButton14);
                }
            }
        }

        private void circularButton15_Click(object sender, EventArgs e)
        {
            if (server != null)
            {
                Server(circularButton15);
            }
            else
            {
                this.circularButton15.Buscar(this.tableLayoutPanel1, this.turno, false);

                if (singleplayer)
                {
                    Carlos.Rojos.Add(this.circularButton15);
                }
            }
        }

        private void circularButton16_Click(object sender, EventArgs e)
        {
            if (server != null)
            {
                Server(circularButton16);
            }
            else
            {
                this.circularButton16.Buscar(this.tableLayoutPanel1, this.turno, false);

                if (singleplayer)
                {
                    Carlos.Rojos.Add(this.circularButton16);
                }
            }
        }

        private void circularButton17_Click(object sender, EventArgs e)
        {
            if (server != null)
            {
                Server(circularButton17);
            }
            else
            {
                this.circularButton17.Buscar(this.tableLayoutPanel1, this.turno, false);

                if (singleplayer)
                {
                    Carlos.Rojos.Add(this.circularButton17);
                }
            }
        }

        private void circularButton18_Click(object sender, EventArgs e)
        {
            if (server != null)
            {
                Server(circularButton18);
            }
            else
            {
                this.circularButton18.Buscar(this.tableLayoutPanel1, this.turno, false);

                if (singleplayer)
                {
                    Carlos.Rojos.Add(this.circularButton18);
                }
            }
        }

        private void circularButton19_Click(object sender, EventArgs e)
        {
            if (server != null)
            {
                Server(circularButton19);
            }
            else
            {
                this.circularButton19.Buscar(this.tableLayoutPanel1, this.turno, false);

                if (singleplayer)
                {
                    Carlos.Rojos.Add(this.circularButton19);
                }
            }
        }

        private void circularButton20_Click(object sender, EventArgs e)
        {
            if (server != null)
            {
                Server(circularButton20);
            }
            else
            {
                this.circularButton20.Buscar(this.tableLayoutPanel1, this.turno, false);

                if (singleplayer)
                {
                    Carlos.Rojos.Add(this.circularButton20);
                }
            }
        }

        private void circularButton21_Click(object sender, EventArgs e)
        {
            if (server != null)
            {
                Server(circularButton21);
            }
            else
            {
                this.circularButton21.Buscar(this.tableLayoutPanel1, this.turno, false);

                if (singleplayer)
                {
                    Carlos.Rojos.Add(this.circularButton21);
                }
            }
        }

        private void circularButton22_Click(object sender, EventArgs e)
        {
            if (server != null)
            {
                Server(circularButton22);
            }
            else
            {
                this.circularButton22.Buscar(this.tableLayoutPanel1, this.turno, false);

                if (singleplayer)
                {
                    Carlos.Rojos.Add(this.circularButton22);
                }
            }
        }

        private void circularButton23_Click(object sender, EventArgs e)
        {
            if (server != null)
            {
                Server(circularButton23);
            }
            else
            {
                this.circularButton23.Buscar(this.tableLayoutPanel1, this.turno, false);

                if (singleplayer)
                {
                    Carlos.Rojos.Add(this.circularButton23);
                }
            }
        }

        private void circularButton24_Click(object sender, EventArgs e)
        {
            if (server != null)
            {
                Server(circularButton24);
            }
            else
            {
                this.circularButton24.Buscar(this.tableLayoutPanel1, this.turno, false);

                if (singleplayer)
                {
                    Carlos.Rojos.Add(this.circularButton24);
                }
            }
        }

        private void circularButton25_Click(object sender, EventArgs e)
        {
            if (server != null)
            {
                Server(circularButton25);
            }
            else
            {
                this.circularButton25.Buscar(this.tableLayoutPanel1, this.turno, false);

                if (singleplayer)
                {
                    Carlos.Rojos.Add(this.circularButton25);
                }
            }
        }

        private void circularButton26_Click(object sender, EventArgs e)
        {
            if (server != null)
            {
                Server(circularButton26);
            }
            else
            {
                this.circularButton26.Buscar(this.tableLayoutPanel1, this.turno, false);

                if (singleplayer)
                {
                    Carlos.Rojos.Add(this.circularButton26);
                }
            }
        }

        private void circularButton27_Click(object sender, EventArgs e)
        {
            if (server != null)
            {
                Server(circularButton27);
            }
            else
            {
                this.circularButton27.Buscar(this.tableLayoutPanel1, this.turno, false);

                if (singleplayer)
                {
                    Carlos.Rojos.Add(this.circularButton27);
                }
            }
        }

        private void circularButton28_Click(object sender, EventArgs e)
        {
            if (server != null)
            {
                Server(circularButton28);
            }
            else
            {
                this.circularButton28.Buscar(this.tableLayoutPanel1, this.turno, false);

                if (singleplayer)
                {
                    Carlos.Rojos.Add(this.circularButton28);
                }
            }
        }

        private void circularButton29_Click(object sender, EventArgs e)
        {
            if (server != null)
            {
                Server(circularButton29);
            }
            else
            {
                this.circularButton29.Buscar(this.tableLayoutPanel1, this.turno, false);

                if (singleplayer)
                {
                    Carlos.Rojos.Add(this.circularButton29);
                }
            }
        }

        private void circularButton30_Click(object sender, EventArgs e)
        {
            if (server != null)
            {
                Server(circularButton30);
            }
            else
            {
                this.circularButton30.Buscar(this.tableLayoutPanel1, this.turno, false);

                if (singleplayer)
                {
                    Carlos.Rojos.Add(this.circularButton30);
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            do
            {
                if (turno == false)
                {
                    Thread.Sleep(500);

                    Carlos.jugar();
                }
            } while (ganador == false);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            circularButton1.Clear();
            circularButton2.Clear();
            circularButton3.Clear();
            circularButton4.Clear();
            circularButton5.Clear();
            circularButton6.Clear();
            circularButton7.Clear();
            circularButton8.Clear();
            circularButton9.Clear();
            circularButton10.Clear();
            circularButton11.Clear();
            circularButton12.Clear();
            circularButton13.Clear();
            circularButton14.Clear();
            circularButton15.Clear();
            circularButton16.Clear();
            circularButton17.Clear();
            circularButton18.Clear();
            circularButton19.Clear();
            circularButton20.Clear();
            circularButton21.Clear();
            circularButton22.Clear();
            circularButton23.Clear();
            circularButton24.Clear();
            circularButton25.Clear();
            circularButton26.Clear();
            circularButton27.Clear();
            circularButton28.Clear();
            circularButton29.Clear();
            circularButton30.Clear();

            foreach (CircularButton boton in this.tableLayoutPanel1.Controls)
            {
                if (boton.TabIndex > 23 && boton.TabIndex < 30)
                {
                    boton.State = true;
                }
            }

            turno = true;
            ganador = false;

            if (singleplayer)
            {
                Carlos = new BOT(this.tableLayoutPanel1);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void Server(CircularButton boton)
        {
            TableLayoutPanelCellPosition tabla = this.tableLayoutPanel1.GetCellPosition(boton);
            string posicion = tabla.ToString();

            double x = Convert.ToDouble(posicion);
            double filas = x % 1;
            double columnas = x - filas;
            filas *= 10;

            int columnas2 = Convert.ToInt32(columnas);
            int filas2 = Convert.ToInt32(filas);

            server.BotonPresionado(columnas2, filas2);
        }

        public void AccionBoton(int columna, int fila, bool turno)
        {
            Form1.CheckForIllegalCrossThreadCalls = false;
            CircularButton.CheckForIllegalCrossThreadCalls = false;

            CircularButton button = (CircularButton)this.tableLayoutPanel1.GetControlFromPosition(columna, fila);

            button.Buscar(this.tableLayoutPanel1, turno, true);
        }

        public void TurnoErroneo()
        {
            MessageBox.Show("Todavia no  es tu turno");
        }
    }
}
