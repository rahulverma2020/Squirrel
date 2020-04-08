using Squirrel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppDeploymentWithSquirrel
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            CheckForUpdate();
        }

        private async Task CheckForUpdate()
        {
            using (var manager = new UpdateManager(@"C:\SquirrelReleases"))  //URL we can also put
            {
                var updates = await manager.CheckForUpdate();
                if (updates.ReleasesToApply.Any())
                {
                    var lastVersion = updates.ReleasesToApply.OrderBy(x => x.Version).Last();
                    await manager.DownloadReleases(new[] { lastVersion
                        });
                    await manager.ApplyReleases(updates);
                    await manager.UpdateApp();
                    MessageBox.Show("The application has been updated – please close and restart.");
                }
                else
                {
                    MessageBox.Show("No Updates are available at this time.");
                }

            }
        }
        private void Btnlogin_Click(object sender, EventArgs e)
        {
            var Result = LoginAuth.Authnticate(txtusr.Text.Trim(), txtpwd.Text.Trim());

            if (!Result)
            {
                MessageBox.Show("Invalid Credential");
            }
            else
            {
                Dashboard dashboard = new Dashboard();
                dashboard.ShowDialog();
                this.Close();
            }
        }

        private void Btncancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
