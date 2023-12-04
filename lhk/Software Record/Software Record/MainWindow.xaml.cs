using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using System.Data;

namespace Software_Record
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private dbms mysqlconn = new dbms();
        private MySqlConnection myconn = null;
        private MySqlCommand mycmd = null;
        private MySqlDataAdapter myda = null;
        private MySqlDataReader mydr = null;

        public MainWindow()
        {
            InitializeComponent();
            FetchPCList();
        }

        private void FetchPCList()
        {
            try
            {
                using (myconn = new MySqlConnection(mysqlconn.MySetting))
                {
                    if (myconn.State == ConnectionState.Closed) { myconn.Open(); }
                    using (mycmd = new MySqlCommand(@"SELECT `IDPC`, `DisplayName`, `Desc`, `PCName`, `AdminUsername`, `AdminPassword`
                        FROM `list_pc`
                        WHERE `Status` <> 'D';", myconn))
                    {
                        using (myda = new MySqlDataAdapter(mycmd))
                        {
                            DataTable dt = new DataTable();
                            myda.Fill(dt);
                            listBoxPCList.DataContext = dt;
                            listBoxPCList.DisplayMemberPath = "DisplayName";
                            if (listBoxPCList.Items.Count > 0 && listBoxPCList.SelectedIndex == -1)
                            {
                                listBoxPCList.SelectedIndex = 0; // Selecting 1st data
                            }
                        }
                    }
                    if (myconn.State == ConnectionState.Open) { myconn.Close(); }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error Occur: " + ex.Message);
            }
        }

        private void buttonClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void listBoxPCList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (listBoxPCList.Items.Count > 0 && listBoxPCList.SelectedIndex != -1)
                {
                    DataRowView selectedPC = listBoxPCList.SelectedItem as DataRowView;
                    string DisplayName = selectedPC["DisplayName"].ToString();
                    textBoxPCDisplayName.Text = DisplayName;
                }
            }
            catch { } // dismiss error
        }

        private void buttonPCEdit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listBoxPCList.Items.Count > 0 && listBoxPCList.SelectedIndex != -1)
                {
                    DataRowView selectedPC = listBoxPCList.SelectedItem as DataRowView;
                    int IDPC = Convert.ToInt32(selectedPC["IDPC"]);
                    using (ManagePC wMPC = new ManagePC(1, IDPC))
                    {
                        wMPC.Owner = this;
                        wMPC.ShowDialog();
                    }
                }
            }
            catch { } // dismiss error
        }

        private void buttonPCViewInfo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listBoxPCList.Items.Count > 0 && listBoxPCList.SelectedIndex != -1)
                {
                    DataRowView selectedPC = listBoxPCList.SelectedItem as DataRowView;
                    int IDPC = Convert.ToInt32(selectedPC["IDPC"]);
                    using (ManagePC wMPC = new ManagePC(0, IDPC))
                    {
                        wMPC.Owner = this;
                        wMPC.ShowDialog();
                    }
                }
            }
            catch { } // dismiss error
        }

        private void buttonPCAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataRowView selectedPC = listBoxPCList.SelectedItem as DataRowView;
                int IDPC = Convert.ToInt32(selectedPC["IDPC"]);
                using (ManagePC wMPC = new ManagePC(2, IDPC))
                {
                    wMPC.Owner = this;
                    wMPC.ShowDialog();
                }
            }
            catch { } // dismiss error
        }

        private void buttonSoftwareView_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (listBoxPCList.Items.Count > 0 && listBoxPCList.SelectedIndex != -1)
                {
                    DataRowView selectedPC = listBoxPCList.SelectedItem as DataRowView;
                    int IDPC = Convert.ToInt32(selectedPC["IDPC"]);
                    string DisplayName = selectedPC["DisplayName"].ToString();
                    using (WindowSoftwareList wSL = new WindowSoftwareList(IDPC, DisplayName))
                    {
                        wSL.Owner = this;
                        wSL.ShowDialog();
                    }
                }
            }
            catch { } // dismiss error
        }
    }
}
