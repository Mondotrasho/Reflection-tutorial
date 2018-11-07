using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginContracts;
namespace MyPlugin
{
    public class MyPlugin : IPlugin
    {
        #region IPlugin Members
        public string Name
        {
            get
            {
                return "My Plugin";
            }
        }
        public void Do()
        {
            System.Windows.Forms.MessageBox.Show("Do Something in My Plugin");
        }
        #endregion
    }
}
