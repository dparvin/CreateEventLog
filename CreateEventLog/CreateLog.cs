using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace CreateEventLog
{
    /// <summary>
    /// A Windows form used to create an event log.
    /// </summary>
    /// <seealso cref="Form" />
    public partial class CreateLog : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateLog"/> class.
        /// </summary>
        public CreateLog()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the btnOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
