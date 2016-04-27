using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Maze.Core.Cells;
using Maze.Core.Maps;
using Maze.NBT.Common;
using Maze.NBT.Renderers;

namespace Maze.WinFormsGDI.Forms
{
    public partial class SaveForm : Form
    {
        public IMap Map { get; set; }

        public SaveForm(IMap map)
        {
            Map = map;
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

        private void NBTSettingsNextButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new SaveFileDialog())
            {
                dialog.Filter = @"NBT Schematic Files (*.schematic)|*.schematic|All Files|*.*";
                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                var renderer = new NBTMapRenderer(Map, dialog.FileName);
                renderer.AddFloor = NBTAddFloorCheckBox.Checked;
                renderer.AddCeiling = NBTAddCeilingCheckBox.Checked;
                renderer.FloorBlock = new SchematicBlock((byte)NBTFloorIDNUD.Value, (byte)NBTFloorDataNUD.Value);
                renderer.CeilingBlock = new SchematicBlock((byte)NBTCeilingIDNUD.Value, (byte)NBTCeilingDataNUD.Value);
                renderer.Blocks[CellState.Empty] = new SchematicBlock((byte)NBTPathIDNUD.Value, (byte)NBTPathDataNUD.Value);
                renderer.Blocks[CellState.Filled] = new SchematicBlock((byte)NBTWallsIDNUD.Value, (byte)NBTWallsDataNUD.Value);
                renderer.ForceRenderNow();
            }
        }
    }
}
