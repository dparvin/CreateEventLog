using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace CreateEventLog
{
    public partial class CreateLog : Form
    {
        public CreateLog()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtLogName.Text))
            {
                var LogName = txtLogName.Text;
                var SourceName = txtSourceName.Text;
                if (string.IsNullOrEmpty(SourceName))
                    SourceName = LogName;
                try
                {
                    var el = new EventLog(LogName, ".", SourceName);
                    el.WriteEntry("Initializing the event log");
                    el.MaximumKilobytes = 1024 * 1024;
                    el.ModifyOverflowPolicy(OverflowAction.OverwriteOlder, 7);
                    el.Close();
                    MessageBox.Show("Event Log process done");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was an error trying to create the event log: \n\n  " + ex.Message + "\n\nTry running the application in Administrator Mode.");
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
