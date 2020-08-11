using GeorgeZhou_BaseballExample;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeorgeZhou_Exercise2
{
    public partial class DisplayPlayers : Form
    {
        public DisplayPlayers()
        {
            InitializeComponent();
        }

        //set entity dbcontext
        private GeorgeZhou_BaseballExample.BaseballEntities dbcontext =
            new GeorgeZhou_BaseballExample.BaseballEntities();

        private void DisplayPlayers_Load(object sender, EventArgs e)
        {
            // load the dbcontext datasource
            dbcontext.Players.Load();
            // set the datasource of datagridview to all players
            playerDataGridView.DataSource = dbcontext.Players.Local;
        }

        private void btnFindPlayer_Click(object sender, EventArgs e)
        {
            // get search query name from text box
            string playerLName = tbxPlayerInput.Text;

            // search query
            var playerSearch =
                from player in dbcontext.Players
                where player.LastName == playerLName
                select player;

            // Populate datagrid with the search query result
            playerDataGridView.DataSource = playerSearch.ToList();

            // Validation
            if (playerDataGridView.RowCount == 0)
            {
                MessageBox.Show("No data found","Data not found",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
            }
        }


        private void btnReset_Click(object sender, EventArgs e)
        {
            // set the datasource of datagridview to all players
            playerDataGridView.DataSource = dbcontext.Players.Local;
        }
    }
}
