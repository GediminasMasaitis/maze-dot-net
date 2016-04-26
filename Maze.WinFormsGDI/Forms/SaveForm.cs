using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maze.WinFormsGDI.Forms
{
    public partial class SaveForm : Form
    {
        public SaveForm()
        {
            InitializeComponent();
        }

        private SaveMethod CurrentSaveMethod
        {
            get
            {
                if (ImageSaveMethodRB.Checked)
                {
                    return SaveMethod.Image;
                }
                if (NBTSaveMethodRB.Checked)
                {
                    return SaveMethod.NBT;
                }
                throw new ArgumentOutOfRangeException();
            }
        }

        private void SaveMethodNextButton_Click(object sender, EventArgs e)
        {
            switch (CurrentSaveMethod)
            {
                case SaveMethod.Image:
                    break;
                case SaveMethod.NBT:
                    MainTablessTabControl.SelectedTab = NBTSettingsTabPage;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(CurrentSaveMethod), CurrentSaveMethod, null);
            }
        }

        private void NBTSettingsBackButton_Click(object sender, EventArgs e)
        {
            MainTablessTabControl.SelectedTab = SaveMethodTabPage;
        }
    }
}
