using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Configuration;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pruebaJ
{
    class CircularButton : Button
    {
        private int color = 0;
        public int Color { get => color; set => color = value; }

        private CircularButton der;
        private CircularButton izq;
        private CircularButton sup;
        private CircularButton inf;
        private CircularButton infDer;
        private CircularButton supDer;
        private CircularButton supIzq;
        private CircularButton infIzq;
        internal CircularButton Der { get => der; set => der = value; }
        internal CircularButton Izq { get => izq; set => izq = value; }
        internal CircularButton Sup { get => sup; set => sup = value; }
        internal CircularButton Inf { get => inf; set => inf = value; }
        internal CircularButton InfDer { get => infDer; set => infDer = value; }
        internal CircularButton SupDer { get => supDer; set => supDer = value; }
        internal CircularButton SupIzq { get => supIzq; set => supIzq = value; }
        internal CircularButton InfIzq { get => infIzq; set => infIzq = value; }

        private int lineaVert=0;
        private int lineaHor=0;
        private int lineaDiag1=0;
        private int lineaDiag2=0;
        public int LineaVert { get => lineaVert; set => lineaVert = value; }
        public int LineaHor { get => lineaHor; set => lineaHor = value; }
        public int LineaDiag1 { get => lineaDiag1; set => lineaDiag1 = value; }
        public int LineaDiag2 { get => lineaDiag2; set => lineaDiag2 = value; }

        private bool state = false;
        public bool State { get => state; set => state = value; }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            GraphicsPath GP = new GraphicsPath();

            GP.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);

            this.Region = new System.Drawing.Region(GP);

            base.OnPaint(pevent);
        }

        public void Clear()
        {
            this.BackColor = System.Drawing.Color.White;

            this.color = 0;

            this.izq = null;
            this.der = null;
            this.sup = null;
            this.inf = null;
            this.infDer = null;
            this.supDer = null;
            this.infIzq = null;
            this.supIzq = null;

            this.lineaDiag1 = 0;
            this.lineaDiag2 = 0;
            this.lineaHor = 0;
            this.lineaVert = 0;

            this.state = false;
        }

        public void Buscar(TableLayoutPanel panel, bool turno, bool mult)
        {
            if (this.state == false)
            {
                return;
            }

            if (mult)
            {
                if (turno == true)
                {
                    this.BackColor = System.Drawing.Color.Red;
                    this.color = 1;
                }
                else
                {
                    this.BackColor = System.Drawing.Color.Blue;
                    this.color = 2;
                }
            }
            else
            {
                Form1 form = (Form1)Form1.ActiveForm;

                if (form.turno == true)
                {
                    this.BackColor = System.Drawing.Color.Red;
                    this.color = 1;
                }
                else
                {
                    this.BackColor = System.Drawing.Color.Blue;
                    this.color = 2;
                }

                form.turno = !form.turno;
            }

            TableLayoutPanelCellPosition tabla = panel.GetCellPosition(this);
            string posicion = tabla.ToString();

            double x = Convert.ToDouble(posicion);
            double filas = x % 1;
            double columnas = x -filas;
            filas *= 10;

            int columnas2 = Convert.ToInt32(columnas);
            int filas2 = Convert.ToInt32(filas);

            this.lineaDiag1++;
            this.lineaDiag2++;
            this.lineaHor++;
            this.lineaVert++;

            try
            {
                this.der = (CircularButton)panel.GetControlFromPosition(columnas2 + 1, filas2);
            }
            catch (SystemException e)
            {
                this.der = null;
            }

            try
            {
                this.izq = (CircularButton)panel.GetControlFromPosition(columnas2 - 1, filas2);
            }
            catch (SystemException e)
            {
                this.izq = null;
            }

            try
            {
                this.sup = (CircularButton)panel.GetControlFromPosition(columnas2, filas2 - 1);
            }
            catch (SystemException e)
            {
                this.sup = null;
            }

            try
            {
                this.inf = (CircularButton)panel.GetControlFromPosition(columnas2, filas2 + 1);
            }
            catch (SystemException e)
            {
                this.inf = null;
            }

            try
            {
                this.supDer = (CircularButton)panel.GetControlFromPosition(columnas2 + 1, filas2 - 1);
            }
            catch (SystemException e)
            {
                this.supDer = null;
            }

            try
            {
                this.infDer = (CircularButton)panel.GetControlFromPosition(columnas2 + 1, filas2 + 1);
            }
            catch (SystemException e)
            {
                this.infDer = null;
            }

            try
            {
                this.supIzq = (CircularButton)panel.GetControlFromPosition(columnas2 - 1, filas2 - 1);
            }
            catch (SystemException e)
            {
                this.supIzq = null;
            }

            try
            {
                this.infIzq = (CircularButton)panel.GetControlFromPosition(columnas2 - 1, filas2 + 1);
            }
            catch (SystemException e)
            {
                this.infIzq = null;
            }

            if (this.sup != null)
            {
                this.sup.state = true;
            }

            Revision();

            state = false;
        }

        public void Revision()
        {
            bool x = false;
            bool y = false;

            switch (TabIndex)
            {
                case 0:
                    {
                        BDer(this.der);

                        BInf(this.inf);

                        BInfDer(this.infDer);

                        break;
                    }
                case 1:
                    {
                        BExtremoSup();
                        break;
                    }
                case 2:
                    {
                        BExtremoSup();
                        break;
                    }
                case 3:
                    {
                        BExtremoSup();
                        break;
                    }
                case 4:
                    {
                        BExtremoSup();
                        break;
                    }
                case 5:
                    {
                        BIzq(this.izq);

                        BInf(this.inf);

                        BInfIzq(this.infIzq);

                        break;
                    }
                case 6:
                    {
                        BLateral1();
                        break;
                    }
                case 7:
                    {
                        BInterna();
                        break;
                    }
                case 8:
                    {
                        BInterna();
                        break;
                    }
                case 9:
                    {
                        BInterna();
                        break;
                    }
                case 10:
                    {
                        BInterna();
                        break;
                    }
                case 11:
                    {
                        BLateral2();
                        break;
                    }
                case 12:
                    {
                        BLateral1();
                        break;
                    }
                case 13:
                    {
                        BInterna();
                        break;
                    }
                case 14:
                    {
                        BInterna();
                        break;
                    }
                case 15:
                    {
                        BInterna();
                        break;
                    }
                case 16:
                    {
                        BInterna();
                        break;
                    }
                case 17:
                    {
                        BLateral2();
                        break;
                    }
                case 18:
                    {
                        BLateral1();
                        break;
                    }
                case 19:
                    {
                        BInterna();
                        break;
                    }
                case 20:
                    {
                        BInterna();
                        break;
                    }
                case 21:
                    {
                        BInterna();
                        break;
                    }
                case 22:
                    {
                        BInterna();
                        break;
                    }
                case 23:
                    {
                        BLateral2();
                        break;
                    }
                case 24:
                    {
                        BDer(this.der);

                        BSup(this.sup);

                        BSupDer(this.supDer);

                        break;
                    }
                case 25:
                    {
                        BExtremoInf();
                        break;
                    }
                case 26:
                    {
                        BExtremoInf();
                        break;
                    }
                case 27:
                    {
                        BExtremoInf();
                        break;
                    }
                case 28:
                    {
                        BExtremoInf();
                        break;
                    }
                case 29:
                    {
                        BIzq(this.izq);

                        BSup(this.sup);

                        BSupIzq(this.supIzq);

                        break;
                    }
            }

            if(this.lineaDiag1>3 || this.lineaDiag2 > 3 || this.lineaVert > 3 || this.lineaHor > 3)
            {
                switch (this.color)
                {
                    case 1:
                        {
                            MessageBox.Show("Jugador 1 Gana");
                            break;
                        }
                    case 2:
                        {
                            MessageBox.Show("Jugador 2 Gana");
                            break;
                        }
                }
                Form1 form = (Form1)Form.ActiveForm;
                form.ganador = true;
            }

            Console.WriteLine();
        }

        public void BLateral1()
        {
            bool x = false;
            bool y = false;

            BDer(this.der);

            x = BInf(this.inf);
            y = BSup(this.sup);
            if (x == true && y == true)
            {
                this.inf.lineaVert = this.lineaVert;
                this.sup.lineaVert = this.lineaVert;
            }

            BInfDer(this.infDer);

            BSupDer(this.supDer);
        }

        public void BLateral2()
        {
            bool x = false;
            bool y = false;

            BIzq(this.izq);

            x = BInf(this.inf);
            y = BSup(this.sup);
            if (x == true && y == true)
            {
                this.inf.lineaVert = this.lineaVert;
                this.sup.lineaVert = this.lineaVert;
            }

            BSupIzq(this.supIzq);

            BInfIzq(this.infIzq);
        }

        public void BExtremoSup()
        {
            bool x = false;
            bool y = false;

            x = BIzq(this.izq);
            y = BDer(this.der);
            if (x == true && y == true)
            {
                this.izq.LineaHor = this.lineaHor;
                this.der.LineaHor = this.lineaHor;
            }

            BInf(this.inf);

            BInfDer(this.infDer);

            BInfIzq(this.infIzq);
        }

        public void BExtremoInf()
        {
            bool x = false;
            bool y = false;

            x = BIzq(this.izq);
            y = BDer(this.der);
            if (x == true && y == true)
            {
                this.izq.LineaHor = this.lineaHor;
                this.der.LineaHor = this.lineaHor;
            }

            BSup(this.sup);

            BSupIzq(this.supIzq);

            BSupDer(this.supDer);
        }

        public void BInterna()
        {
            bool x = false;
            bool y = false;

            x = BIzq(this.izq);
            y = BDer(this.der);
            if (x == true && y == true)
            {
                this.izq.LineaHor = this.lineaHor;
                this.der.LineaHor = this.lineaHor;
                x = false;
                y = false;
            }

            x = BInf(this.inf);
            y = BSup(this.sup);
            if (x == true && y == true)
            {
                this.inf.lineaVert = this.lineaVert;
                this.sup.lineaVert = this.lineaVert;
                x = false;
                y = false;
            }

            x = BInfDer(this.infDer);
            y = BSupIzq(this.supIzq);
            if (x == true && y == true)
            {
                this.infDer.LineaDiag1 = this.LineaDiag1;
                this.supIzq.LineaDiag1 = this.LineaDiag1;
                x = false;
                y = false;
            }

            x = BInfIzq(this.infIzq);
            y = BSupDer(this.supDer);
            if (x == true && y == true)
            {
                this.infIzq.LineaDiag2 = this.lineaDiag2;
                this.supDer.LineaDiag2 = this.lineaDiag2;
            }
        }

        public bool BIzq(CircularButton boton)
        {
            boton.der = this;

            if (this.color == boton.Color)
            {
                LineaHor+=boton.LineaHor;
                boton.LineaHor++;

                if (boton.LineaHor > 2)
                {
                    boton.Izq.LineaHor++;
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool BDer(CircularButton boton)
        {
            boton.izq = this;

            if (this.color == boton.Color)
            {
                LineaHor += boton.LineaHor;
                boton.LineaHor++;

                if (boton.LineaHor > 2)
                {
                    boton.Der.LineaHor++;
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool BSup(CircularButton boton)
        {
            boton.inf = this;

            if (this.color == boton.Color)
            {
                LineaVert += boton.LineaVert;
                boton.LineaVert++;

                if (boton.LineaVert > 2)
                {
                    boton.Sup.LineaVert++;
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool BInf(CircularButton boton)
        {
            boton.sup = this;

            if (this.color == boton.Color)
            {
                LineaVert += boton.LineaVert;
                boton.LineaVert++;

                if (boton.LineaVert > 2)
                {
                    boton.Inf.LineaVert++;
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool BSupDer(CircularButton boton)
        {
            boton.InfIzq = this;

            if (this.color == boton.Color)
            {
                lineaDiag2 += boton.LineaDiag2;
                boton.LineaDiag2++;

                if (boton.LineaDiag2 > 2)
                {
                    boton.SupDer.LineaDiag2++;
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool BSupIzq(CircularButton boton)
        {
            boton.InfDer = this;

            if (this.color == boton.Color)
            {
                lineaDiag1 += boton.LineaDiag1;
                boton.LineaDiag1++;

                if (boton.LineaDiag1 > 2)
                {
                    boton.SupIzq.LineaDiag1++;
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool BInfDer(CircularButton boton)
        {
            boton.supIzq = this;

            if (this.color == boton.Color)
            {
                lineaDiag1 += boton.LineaDiag1;
                boton.LineaDiag1++;

                if (boton.LineaDiag1 > 2)
                {
                    boton.InfDer.LineaDiag1++;
                }

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool BInfIzq(CircularButton boton)
        {
            boton.supDer = this;

            if (this.color == boton.Color)
            {
                lineaDiag2 += boton.LineaDiag2;
                boton.LineaDiag2++;

                if (boton.LineaDiag2 > 2)
                {
                    boton.InfIzq.LineaDiag2++;
                }

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
