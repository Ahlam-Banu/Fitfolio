using System;
using System.Windows;
using System.Windows.Controls;
using MySql.Data.MySqlClient;

namespace Fitfolio
{
    public partial class add : Window
    {
        string connectionString = "server=mariadb.vamk.fi;user=e2101083;database=e2101083_FitFolio;port=3306;password=jBxqVvNfMGH\n";

        public add()
        {
            InitializeComponent();
        }

        private void AddData_Click(object sender, RoutedEventArgs e)
        {
            // Get the data entered by the user
            string title = titleTextBox.Text;
            string description = descriptionTextBox.Text;
            string selectedWorkout = (workout.SelectedItem as ListViewItem).Content.ToString();
            int workoutId = GetWorkoutId(selectedWorkout); // You need to implement this method

            // Add the data to the database
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand("INSERT INTO exercises (exercise_name, exercise_desc, workout_id, user_id) VALUES (@exercise_name, @exercise_desc, @workout_id, @user_id)", conn);
                    cmd.Parameters.AddWithValue("@exercise_name", title);
                    cmd.Parameters.AddWithValue("@exercise_desc", description);
                    cmd.Parameters.AddWithValue("@workout_id", workoutId);
                    cmd.Parameters.AddWithValue("@user_id", 1); // Assuming user_id is always 1 for now
                    cmd.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            this.Close();
        }

        // Method to get workout ID based on its name
        private int GetWorkoutId(string workoutName)
        {
            // Implement logic to fetch workout ID from the database based on its name
            // For simplicity, I'm assuming a static mapping here, but in real-world scenario, you'd query the database
            switch (workoutName)
            {
                case "Cardio":
                    return 1;
                case "Strength":
                    return 2;
                case "Yoga":
                    return 3;
                default:
                    return -1; // Invalid workout name
            }
        }
    }
}
