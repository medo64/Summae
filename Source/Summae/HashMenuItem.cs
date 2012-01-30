using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Summae {
    internal class HashMenuItem : ToolStripMenuItem {

        public HashMenuItem(string key, string text, bool isChecked) {
            this.Key = key;
            this.Text = text;
            this.Checked = isChecked;
        }


        protected override void OnClick(EventArgs e) {
            this.Checked = !this.Checked;
        }

        public string Key { get; private set; }

    }
}
