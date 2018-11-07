using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PluginContracts;

namespace pluginApp
{
    public partial class Form1 : Form
    {
        public Dictionary<string,IPlugin> _plugins = new Dictionary<string, IPlugin>();

        public Form1()
        {
            InitializeComponent();

            // First of all we have to know where to search for plugins.
            // Usually we will specify a folder in that all plugins are put in.
            // In this folder we search for all assemblies.
            // I'm using the current directory (ie, the directory the executable is in), but you
            // would normally provide an option for the user to set somewhere in your application
            string path = Directory.GetCurrentDirectory();
            ICollection<IPlugin> plugins = Program.LoadPlugins(path);
            // create a button for each loaded plugin and connect the content and the click event
            // of the button to the property and the method of the plugin.
            foreach (var item in plugins)
            {
                _plugins.Add(item.Name, item);
                Button b = new Button();
                b.Text = item.Name;
                b.Click += ButtonOnClick;
                _tableLayoutPanel.Controls.Add(b);
            }
        }
        private void ButtonOnClick(object sender, System.EventArgs e)
        {
            Button b = sender as Button;
            if (b != null)
            {
                string key = b.Text.ToString();
                if (_plugins.ContainsKey(key))
                {
                    IPlugin plugin = _plugins[key];
                    plugin.Do();
                }
            }
        }
    }
}
