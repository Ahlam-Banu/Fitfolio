﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls;

namespace Fitfolio
{
    /// Authors Ahlam, Awais, Azeem and Bilal
    /// Jobs: 
    /// UI Handled By Bilal
    /// Add Functionality, UI and logo Handled By Azeem 
    /// UI and Rest of functionalities Handled By Ahlam 
    /// Database and UI Handled by Awais
    public partial class MainWindow : Window
    {
        string connectionString = "server=mariadb.vamk.fi;user=e2101083;database=e2101083_FitFolio;port=3306;password=jBxqVvNfMGH";
        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }
        void LoadData()
        {
            mainGrid0.Children.Clear();
            //on load
            List<string> GetNamesFromDatabase()
            {
                List<string> data = new List<string>();

                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();

                        MySqlCommand cmd = new MySqlCommand("SELECT * FROM exercises", conn);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string name = "Code :  " + reader.GetString(0) + "\n" + "Name : " + reader.GetString(1) + "\n" + "\n" + reader.GetString(2);
                                data.Add(name);
                            }
                            reader.Close();
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }

                return data;
            }

            // Get the names from the database
            List<string> sample = GetNamesFromDatabase();

            // Create a new Grid control for each name
            foreach (string name in sample)
            {

                for (int i = 0; i < sample.Count; i++)
                {
                    // Create a new Grid control
                    Grid nameGrid = new Grid();
                    if (i >= 4)
                    {
                        int a = i - 4;
                        nameGrid.Margin = new Thickness((10 + (a * 180)), (220), (568 - (a * 180)), (5));
                    }
                    else nameGrid.Margin = new Thickness((10 + (i * 180)), (19), (568 - (i * 180)), (196));

                    // Add a button to the grid

                    // Create a new ListView control
                    ListView listView = new ListView();
                    listView.Margin = new Thickness(10);
                    listView.SelectionChanged += someone_SelectionChanged;

                    // Create a new GridViewColumn for the ListView
                    GridViewColumn gridViewColumn = new GridViewColumn();
                    gridViewColumn.Header = "Exercise";
                    gridViewColumn.Width = 160;
                    gridViewColumn.DisplayMemberBinding = new Binding("exercise_id");




                    // Add the GridViewColumn to the GridView
                    GridView gridView = new GridView();
                    gridView.Columns.Add(gridViewColumn);




                    // Set the GridView as the ListView's view
                    listView.View = gridView;

                    // Add the ListView to the Grid
                    nameGrid.Children.Add(listView);

                    // Add the Grid to the main Grid
                    mainGrid0.Children.Add(nameGrid);

                    // Populate the ListView with data
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();

                        MySqlCommand cmd = new MySqlCommand($"SELECT * FROM exercises WHERE exercise_id = {i + 1}", conn);
                        using (MySqlDataReader r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                //string fname = r.GetString(1);

                                // Create a new ListViewItem object
                                ListViewItem item = new ListViewItem();
                                item.Content = new datas() { exercise_id = "Code :  " + r.GetString(0) + "\n" + "Name : " + r.GetString(1) + "\n" + "\n" + r.GetString(2) };

                                listView.Items.Add(item);
                            }
                            r.Close();
                        }
                    }
                }

            }
            //end on load
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //urgent
            string[] exercise_id = new string[15];
            mainGrid0.Children.Clear();

            // Remove the Grid itself from its parent container


            List<string> GetNamesFromDatabase()
            {
                List<string> data = new List<string>();
                //List<data> items = new List<data>();
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();

                        MySqlCommand cmd = new MySqlCommand("SELECT * FROM exercises WHERE workout_id = 1", conn);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            int y = 0;
                            while (reader.Read())
                            {
                                string name = "Code :  " + reader.GetString(0) + "\n" + "Name " + reader.GetString(1) + "\n" + "\n" + reader.GetString(2);
                                data.Add(name);
                                // for (int y = 0; y <= exercise_id.Length; y++)
                                // {
                                exercise_id[y] = reader.GetString(0);
                                //}
                                y++;
                            }
                            reader.Close();
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }

                return data;
            }

            // Get the names from the database
            List<string> sample = GetNamesFromDatabase();

            // Create a new Grid control for each name
            foreach (string name in sample)
            {

                for (int i = 0; i < sample.Count; i++)
                {
                    // Create a new Grid control
                    Grid nameGrid = new Grid();
                    if (i >= 4)
                    {
                        int a = i - 4;
                        nameGrid.Margin = new Thickness((10 + (a * 180)), (220), (568 - (a * 180)), (5));
                    }
                    else nameGrid.Margin = new Thickness((10 + (i * 180)), (19), (568 - (i * 180)), (196));

                    // Add a button to the grid

                    // Create a new ListView control
                    ListView listView = new ListView();
                    listView.Margin = new Thickness(10);
                    listView.SelectionChanged += someone_SelectionChanged;

                    // Create a new GridViewColumn for the ListView
                    GridViewColumn gridViewColumn = new GridViewColumn();
                    gridViewColumn.Header = "Exercise";
                    gridViewColumn.Width = 160;
                    gridViewColumn.DisplayMemberBinding = new Binding("exercise_id");




                    // Add the GridViewColumn to the GridView
                    GridView gridView = new GridView();
                    gridView.Columns.Add(gridViewColumn);




                    // Set the GridView as the ListView's view
                    listView.View = gridView;

                    // Add the ListView to the Grid
                    nameGrid.Children.Add(listView);

                    // Add the Grid to the main Grid
                    mainGrid0.Children.Add(nameGrid);

                    // Populate the ListView with data
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();

                        MySqlCommand cmd = new MySqlCommand($"SELECT * FROM exercises WHERE exercise_id = {exercise_id[i]} and workout_id = 1", conn);
                        using (MySqlDataReader r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                //string fname = r.GetString(1);

                                // Create a new ListViewItem object
                                ListViewItem item = new ListViewItem();
                                item.Content = new datas() { exercise_id = "No: " + r.GetString(0) + "\n" + "Name : " + r.GetString(1) + "\n" + "\n" + r.GetString(2) };

                                listView.Items.Add(item);
                            }
                            r.Close();
                        }
                    }
                }

            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window1 loginWindow = new Window1();
            loginWindow.Show();
            this.Close();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            mainGrid0.Children.Clear();
        }
        private void someone_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        public class datas
        {
            public string exercise_id { get; set; }

            public string exercise_name { get; set; }

            public string exercise_desc { get; set; }


        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            add addDataWindow = new add();
            addDataWindow.ShowDialog();

            mainGrid0.Children.Clear();
            MainWindow newWindow = new MainWindow();
            System.Windows.Application.Current.MainWindow = newWindow;
            newWindow.Show();
            this.Close();

        }

        private void refreshbtn_Click(object sender, RoutedEventArgs e)
        {
            mainGrid0.Children.Clear();
            MainWindow newWindow = new MainWindow();
            System.Windows.Application.Current.MainWindow = newWindow;
            newWindow.Show();
            this.Close();
        }
        //strength
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            mainGrid0.Children.Clear();
            string[] exercise_id = new string[15];
            mainGrid0.Children.Clear();

            // Remove the Grid itself from its parent container
            //nameGrid.Children.Remove(mainGrid0);

            List<string> GetNamesFromDatabase()
            {
                List<string> data = new List<string>();
                //List<data> items = new List<data>();
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();

                        MySqlCommand cmd = new MySqlCommand("SELECT * FROM exercises WHERE workout_id = 1", conn);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            int y = 0;
                            while (reader.Read())
                            {
                                string name = "Code :  " + reader.GetString(0) + "\n" + "Name : " + reader.GetString(1) + "\n" + "\n" + reader.GetString(2);
                                data.Add(name);
                                // for (int y = 0; y <= exercise_id.Length; y++)
                                // {
                                exercise_id[y] = reader.GetString(0);
                                //}
                                y++;
                            }
                            reader.Close();
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }

                return data;
            }

            // Get the names from the database
            List<string> sample = GetNamesFromDatabase();

            // Create a new Grid control for each name
            foreach (string name in sample)
            {

                for (int i = 0; i < sample.Count; i++)
                {
                    // Create a new Grid control
                    Grid nameGrid = new Grid();
                    if (i >= 4)
                    {
                        int a = i - 4;
                        nameGrid.Margin = new Thickness((10 + (a * 180)), (220), (568 - (a * 180)), (5));
                    }
                    else nameGrid.Margin = new Thickness((10 + (i * 180)), (19), (568 - (i * 180)), (196));

                    // Add a button to the grid

                    // Create a new ListView control
                    ListView listView = new ListView();
                    listView.Margin = new Thickness(10);
                    listView.SelectionChanged += someone_SelectionChanged;

                    // Create a new GridViewColumn for the ListView
                    GridViewColumn gridViewColumn = new GridViewColumn();
                    gridViewColumn.Header = "Exercise";
                    gridViewColumn.Width = 160;
                    gridViewColumn.DisplayMemberBinding = new Binding("exercise_id");




                    // Add the GridViewColumn to the GridView
                    GridView gridView = new GridView();
                    gridView.Columns.Add(gridViewColumn);




                    // Set the GridView as the ListView's view
                    listView.View = gridView;

                    // Add the ListView to the Grid
                    nameGrid.Children.Add(listView);

                    // Add the Grid to the main Grid
                    mainGrid0.Children.Add(nameGrid);

                    // Populate the ListView with data
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();

                        MySqlCommand cmd = new MySqlCommand($"SELECT * FROM exercises WHERE exercise_id = {exercise_id[i]} and workout_id = 2", conn);
                        using (MySqlDataReader r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                //string fname = r.GetString(1);

                                // Create a new ListViewItem object
                                ListViewItem item = new ListViewItem();
                                item.Content = new datas() { exercise_id = "Code :  " + r.GetString(0) + "\n" + "Name : " + r.GetString(1) + "\n" + "\n" + r.GetString(2) };

                                listView.Items.Add(item);
                            }
                            r.Close();
                        }
                    }
                }

            }
            //strength fin
        }
        //yoga
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            mainGrid0.Children.Clear();
            string[] exercise_id = new string[15];
            mainGrid0.Children.Clear();

            // Remove the Grid itself from its parent container
            //nameGrid.Children.Remove(mainGrid0);

            List<string> GetNamesFromDatabase()
            {
                List<string> data = new List<string>();
                //List<data> items = new List<data>();
                try
                {
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();

                        MySqlCommand cmd = new MySqlCommand("SELECT * FROM exercises WHERE workout_id = 2", conn);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            int y = 0;
                            while (reader.Read())
                            {
                                string name = "Code :  " + reader.GetString(0) + "\n" + "Name : " + reader.GetString(1) + "\n" + "\n" + reader.GetString(2);
                                data.Add(name);

                                exercise_id[y] = reader.GetString(0);

                                y++;
                            }
                            reader.Close();
                        }
                    }
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }

                return data;
            }

            // Get the names from the database
            List<string> sample = GetNamesFromDatabase();

            // Create a new Grid control for each name
            foreach (string name in sample)
            {

                for (int i = 0; i < sample.Count; i++)
                {
                    // Create a new Grid control
                    Grid nameGrid = new Grid();
                    if (i >= 4)
                    {
                        int a = i - 4;
                        nameGrid.Margin = new Thickness((10 + (a * 180)), (220), (568 - (a * 180)), (5));
                    }
                    else nameGrid.Margin = new Thickness((10 + (i * 180)), (19), (568 - (i * 180)), (196));

                    // Add a button to the grid

                    // Create a new ListView control
                    ListView listView = new ListView();
                    listView.Margin = new Thickness(10);
                    listView.SelectionChanged += someone_SelectionChanged;

                    // Create a new GridViewColumn for the ListView
                    GridViewColumn gridViewColumn = new GridViewColumn();
                    gridViewColumn.Header = "Exercise";
                    gridViewColumn.Width = 160;
                    gridViewColumn.DisplayMemberBinding = new Binding("exercise_id");




                    // Add the GridViewColumn to the GridView
                    GridView gridView = new GridView();
                    gridView.Columns.Add(gridViewColumn);




                    // Set the GridView as the ListView's view
                    listView.View = gridView;

                    // Add the ListView to the Grid
                    nameGrid.Children.Add(listView);

                    // Add the Grid to the main Grid
                    mainGrid0.Children.Add(nameGrid);

                    // Populate the ListView with data
                    using (MySqlConnection conn = new MySqlConnection(connectionString))
                    {
                        conn.Open();

                        MySqlCommand cmd = new MySqlCommand($"SELECT * FROM exercises WHERE exercise_id = {exercise_id[i]} and workout_id = 3", conn);
                        using (MySqlDataReader r = cmd.ExecuteReader())
                        {
                            while (r.Read())
                            {
                                //string fname = r.GetString(1);

                                // Create a new ListViewItem object
                                ListViewItem item = new ListViewItem();
                                item.Content = new datas() { exercise_id = "Code :  " + r.GetString(0) + "\n" + "Name : " + r.GetString(1) + "\n" + "\n" + r.GetString(2) };

                                listView.Items.Add(item);
                            }
                            r.Close();
                        }
                    }
                }

            }
        }
        //yoga fin

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            string exercise_idString = Microsoft.VisualBasic.Interaction.InputBox("Enter the exercise id to delete:", "Delete Exercise", "");
            if (exercise_idString == "")
            {
                MessageBox.Show("Input can not be empty.");
        	}
        	else
        	{
                int exercise_id;
                if (int.TryParse(exercise_idString, out exercise_id))
                {
                          // Delete the exercise from the database
                          using (MySqlConnection conn = new MySqlConnection(connectionString))
                          {
                             conn.Open();

                              MySqlCommand cmd = new MySqlCommand("DELETE FROM exercises WHERE exercise_id = @id", conn);
                              cmd.Parameters.AddWithValue("@id", exercise_id);
                              int rowsAffected = cmd.ExecuteNonQuery();

                              if (rowsAffected > 0)
                              {
                                  MessageBox.Show("Exercise deleted successfully.");

                                  // Update the IDs of the remaining tasks
                                  cmd = new MySqlCommand("SELECT * FROM exercises ORDER BY exercise_id", conn);
                                  MySqlDataReader reader = cmd.ExecuteReader();

                                  //int newId = 1;
                                  while (reader.Read())
                                  {
                                      int id = reader.GetInt32("id");

                                      updateid(id);
                                  }

                                  reader.Close();

                                  updateidincrement();
                                  // TODO: Refresh the exercises list in the UI
                                  mainGrid0.Children.Clear();
                                 MainWindow newWindow = new MainWindow();
                                  System.Windows.Application.Current.MainWindow = newWindow;
                                  newWindow.Show();
                                  this.Close();
                              }
                              else
                              {
                                  MessageBox.Show("Exercise not found.");
                              }
                          }

                      }
                      else { MessageBox.Show("Input can not be other than int."); }


                  }
                  void updateid(int id)
                  {
                      using (MySqlConnection conn = new MySqlConnection(connectionString))
        		{
                          int newId = 1;
                          if (id != newId)
                          {
                              conn.Open();
                              // Update the ID of the exercise in the database
                              MySqlCommand updateCmd = new MySqlCommand("UPDATE exercises SET exercise_id = @newId WHERE exercise_id = @id", conn);
                              updateCmd.Parameters.AddWithValue("@newId", newId);
                              updateCmd.Parameters.AddWithValue("@id", id);
                              updateCmd.ExecuteNonQuery();
                          }

                          newId++;
                          conn.Close();

                      }

                  }

                  void updateidincrement()
                  {
                      using (MySqlConnection conn = new MySqlConnection(connectionString))
                      {


                              conn.Open();
                              // Update the ID of the exercise in the database
                              MySqlCommand updateCmd = new MySqlCommand("ALTER TABLE exercises AUTO_INCREMENT = 1;", conn);
                              updateCmd.ExecuteNonQuery();     
                              conn.Close();

                      }

                  }

              }

        	private void Button_Click_5(object sender, RoutedEventArgs e)
        	{


                   // Call a method to open the edit window with the exercise data
                   Edit editdata = new Edit();
                   editdata.ShowDialog();

                   mainGrid0.Children.Clear();
                   MainWindow newWindow = new MainWindow();
                   System.Windows.Application.Current.MainWindow = newWindow;
                   newWindow.Show();
                   this.Close();
            }

        }
    }