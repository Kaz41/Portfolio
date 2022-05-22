using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pruebaJ
{
    class BOT
    {
        private List<CircularButton> rojos = new List<CircularButton>();
        private List<CircularButton> azules = new List<CircularButton>();
        private List<CircularButton> todos = new List<CircularButton>();

        internal List<CircularButton> Rojos { get => rojos; set => rojos = value; }
        internal List<CircularButton> Azules { get => azules; set => azules = value; }
        internal List<CircularButton> Todos { get => todos; set => todos = value; }

        TableLayoutPanel panel;

        public BOT(TableLayoutPanel panel)
        {
            foreach (CircularButton c in panel.Controls)
            {
                todos.Add(c);
            }

            this.panel = panel;
        }

        public void jugar()
        {
            if (Azules.Any()==false)
            {
                random();

                return;
            }

            Random r = new Random();

            int x = r.Next(0, 2);

            switch (x)
            {
                case 0:
                    {
                        if (atacar() == false)
                        {
                            if (defender() == false)
                            {
                                random();
                            }
                        }
                        break;
                    }
                case 1:
                    {
                        if (defender() == false)
                        {
                            if (atacar() == false)
                            {
                                random();
                            }
                        }
                        break;
                    }
            }
        }

        public bool atacar()
        {
            Random r = new Random();
            CircularButton c;
            CircularButton boton;

            c = Azules[r.Next(0, Azules.Count)];

            for(int i = 0; i < 4; i++)
            {
                switch (i)
                {
                    case 0:
                        {
                            boton = lateral(c, true);
                            if (boton != null)
                            {
                                boton.Buscar(panel, false, false);
                                Azules.Add(boton);
                                return true;
                            }

                            boton = lateral(c, false);
                            if (boton != null)
                            {
                                boton.Buscar(panel, false, false);
                                Azules.Add(boton);
                                return true;
                            }

                            break;
                        }
                    case 1:
                        {
                            boton = vertical(c, true);
                            if (boton != null)
                            {
                                boton.Buscar(panel, false, false);
                                Azules.Add(boton);
                                return true;
                            }

                            boton = vertical(c, false);
                            if (boton != null)
                            {
                                boton.Buscar(panel, false, false);
                                Azules.Add(boton);
                                return true;
                            }

                            break;
                        }
                    case 2:
                        {
                            boton = diag1(c, true);
                            if (boton != null)
                            {
                                boton.Buscar(panel, false, false);
                                Azules.Add(boton);
                                return true;
                            }

                            boton = diag1(c, false);
                            if (boton != null)
                            {
                                boton.Buscar(panel, false, false);
                                Azules.Add(boton);
                                return true;
                            }

                            break;
                        }
                    case 3:
                        {
                            boton = diag2(c, true);
                            if (boton != null)
                            {
                                boton.Buscar(panel, false, false);
                                Azules.Add(boton);
                                return true;
                            }

                            boton = diag2(c, false);
                            if (boton != null)
                            {
                                boton.Buscar(panel, false, false);
                                Azules.Add(boton);
                                return true;
                            }

                            break;
                        }
                }
            }

            Azules.Remove(c);

            return false;
        }

        public bool defender()
        {
            Random r = new Random();
            CircularButton c;
            CircularButton boton;

            c = Rojos[r.Next(0, Rojos.Count)];

            for (int i = 0; i < 4; i++)
            {
                switch (i)
                {
                    case 0:
                        {
                            boton = lateral(c, true);
                            if (boton != null)
                            {
                                boton.Buscar(panel, false, false);
                                Rojos.Add(boton);
                                return true;
                            }

                            boton = lateral(c, false);
                            if (boton != null)
                            {
                                boton.Buscar(panel, false, false);
                                Rojos.Add(boton);
                                return true;
                            }

                            break;
                        }
                    case 1:
                        {
                            boton = vertical(c, true);
                            if (boton != null)
                            {
                                boton.Buscar(panel, false, false);
                                Rojos.Add(boton);
                                return true;
                            }

                            boton = vertical(c, false);
                            if (boton != null)
                            {
                                boton.Buscar(panel, false, false);
                                Rojos.Add(boton);
                                return true;
                            }

                            break;
                        }
                    case 2:
                        {
                            boton = diag1(c, true);
                            if (boton != null)
                            {
                                boton.Buscar(panel, false, false);
                                Rojos.Add(boton);
                                return true;
                            }

                            boton = diag1(c, false);
                            if (boton != null)
                            {
                                boton.Buscar(panel, false, false);
                                Rojos.Add(boton);
                                return true;
                            }

                            break;
                        }
                    case 3:
                        {
                            boton = diag2(c, true);
                            if (boton != null)
                            {
                                boton.Buscar(panel, false, false);
                                Rojos.Add(boton);
                                return true;
                            }

                            boton = diag2(c, false);
                            if (boton != null)
                            {
                                boton.Buscar(panel, false, false);
                                Rojos.Add(boton);
                                return true;
                            }

                            break;
                        }
                }
            }

            Rojos.Remove(c);

            return false;
        }

        public void random()
        {
            Random r = new Random();

            CircularButton boton;

            do
            {
                boton = this.todos[r.Next(0, todos.Count)];
            } while (boton.State == false);

            this.Azules.Add(boton);

            boton.Buscar(this.panel, false, false);
        }

        public CircularButton lateral(CircularButton c, bool dir)
        {
            CircularButton boton;

            if (dir)
            {
                if (c.Der == null)
                {
                    return null;
                }

                if (c.Der.Color == c.Color)
                {
                    boton = lateral(c.Der, dir);
                    return boton;
                }
                if (c.Der.Color == 0)
                {
                    if (c.Der.State == true)
                    {
                        return c.Der;
                    }
                }
                return null;
            }
            else
            {
                if (c.Izq == null)
                {
                    return null;
                }

                if (c.Izq.Color == c.Color)
                {
                    boton = lateral(c.Izq, dir);
                    return boton;
                }
                if (c.Izq.Color == 0)
                {
                    if (c.Izq.State == true)
                    {
                        return c.Izq;
                    }
                }
                return null;
            }
        }

        public CircularButton vertical(CircularButton c, bool dir)
        {
            CircularButton boton;

            if (dir)
            {
                if (c.Sup == null)
                {
                    return null;
                }

                if (c.Sup.Color == c.Color)
                {
                    boton = lateral(c.Sup, dir);
                    return boton;
                }
                if (c.Sup.Color == 0)
                {
                    if (c.Sup.State == true)
                    {
                        return c.Sup;
                    }
                }
                return null;
            }
            else
            {
                if (c.Inf == null)
                {
                    return null;
                }

                if (c.Inf.Color == c.Color)
                {
                    boton = lateral(c.Inf, dir);
                    return boton;
                }
                if (c.Inf.Color == 0)
                {
                    if (c.Inf.State == true)
                    {
                        return c.Inf;
                    }
                }
                return null;
            }
        }
        
        public CircularButton diag1(CircularButton c,bool dir)
        {
            CircularButton boton;

            if (dir)
            {
                if (c.SupIzq == null)
                {
                    return null;
                }

                if (c.SupIzq.Color == c.Color)
                {
                    boton = lateral(c.SupIzq, dir);
                    return boton;
                }
                if (c.SupIzq.Color == 0)
                {
                    if (c.SupIzq.State == true)
                    {
                        return c.SupIzq;
                    }
                }
                return null;
            }
            else
            {
                if (c.InfDer == null)
                {
                    return null;
                }

                if (c.InfDer.Color == c.Color)
                {
                    boton = lateral(c.InfDer, dir);
                    return boton;
                }
                if (c.InfDer.Color == 0)
                {
                    if (c.InfDer.State == true)
                    {
                        return c.InfDer;
                    }
                }
                return null;
            }
        }

        public CircularButton diag2(CircularButton c, bool dir)
        {
            CircularButton boton;

            if (dir)
            {
                if (c.SupDer == null)
                {
                    return null;
                }

                if (c.SupDer.Color == c.Color)
                {
                    boton = lateral(c.SupDer, dir);
                    return boton;
                }
                if (c.SupDer.Color == 0)
                {
                    if (c.SupDer.State == true)
                    {
                        return c.SupDer;
                    }
                }
                return null;
            }
            else
            {
                if (c.InfIzq == null)
                {
                    return null;
                }

                if (c.InfIzq.Color == c.Color)
                {
                    boton = lateral(c.InfIzq, dir);
                    return boton;
                }
                if (c.InfIzq.Color == 0)
                {
                    if (c.InfIzq.State == true)
                    {
                        return c.InfIzq;
                    }
                }
                return null;
            }
        }
    }
}
