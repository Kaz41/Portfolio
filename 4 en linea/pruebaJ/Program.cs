using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pruebaJ
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form1 form = new Form1(true);
            InstanceContext context = new InstanceContext(form);
            Proxy.ChatServiceClient server = new Proxy.ChatServiceClient(context);
            server.IngresaPlayer();

            form.server = server;

            Application.Run(form);
        }
    }
}
