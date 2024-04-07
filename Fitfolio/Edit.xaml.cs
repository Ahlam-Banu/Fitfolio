using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Controls;


namespace Fitfolio
{
    public partial class Edit : Window
	{
        string connectionString = "server=mariadb.vamk.fi;user=e2101083;database=e2101083_FitFolio;port=3306;password=jBxqVvNfMGH";
        string exerciseIdString;
        public Edit()
		{
            exerciseIdString = Microsoft.VisualBasic.Interaction.InputBox("Enter the exercise ID to edit:", "Edit Exercise", "");

            // Check if user clicked Cancel or entered an empty string
            if (string.IsNullOrEmpty(exerciseIdString))
            {
                return;
            }

            // Parse the entered ID string to integer
            if (!int.TryParse(exerciseIdString, out int exerciseId))
            {
                MessageBox.Show("Please enter a valid integer ID.");
                return;
            }
            bool val = checkAvilablioty(exerciseId);
            if (val == true)
            {
                InitializeComponent();
            }
            else {
                MessageBox.Show("Error: NO id Match Found");
                   
                  };

        }
      private bool checkAvilablioty( int id)
		{
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand($"SELECT COUNT(*) FROM exercises WHERE exercise_id = {id}", conn);
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    if (count > 0)
                    {
                        // Task with given id exists in the database
                        return true;
                    }
                    else
                    {
                        // Task with given id does not exist in the database
                        return false;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

            return false;

        }
        void editcontent(int id)
		{

        }
        private void Button_Click(object sender, RoutedEventArgs e)
		{
			string title = titlebox.Text;
			string description = discriptionbox.Text;
			int workoutId = workout.SelectedIndex;
            string exerciseId = exerciseIdString;

            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand("UPDATE exercises SET exercise_name = @title, exercise_desc = @description, user_id = @userId, workout_id = @workoutId WHERE exercise_id = @exerciseId", conn);
                    cmd.Parameters.AddWithValue("@title", title);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@userId", 1);
                    cmd.Parameters.AddWithValue("@workoutId", workoutId + 1);
                    cmd.Parameters.AddWithValue("@exerciseId", exerciseId);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            this.Close();
        }
    }
	}

