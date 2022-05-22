using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pruebaJ
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
            this.Hide();
            Form1 Form1 = new Form1(true);
            Form1.Show();
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
           
            this.Hide();
            Form1 Form1 = new Form1(false);
            Form1.Show();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            var patch = System.Windows.Forms.Application.ExecutablePath.ToString();

            patch = patch.Substring(0, (patch.Length - 21)) + @"Musica\Asmr piano.wav";
            MessageBox.Show(patch);
            // System.Media.SoundPlayer player = new System.Media.SoundPlayer(@" C: \Users\pablo\Desktop\pruebaJ\pruebaJ\Musica\Asmr piano.wav");
            System.Media.SoundPlayer player = new System.Media.SoundPlayer(patch);
            player.Play();
        }
    }
}
