using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace Fitfolio
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
	/// 
    /// Authors Ahlam, Awais, Azeem and Bilal
    /// Jobs: 
    /// UI Handled By Bilal
    /// Add Functionality, UI and logo Handled By Azeem 
    /// UI and Rest of functionality Handled By Ahlam 
    /// Database and UI Handled by Awais
    public partial class Window1 : Window
	{
		
		public Window1()
		{
			InitializeComponent();
		}


		private void button1_Click(object sender, RoutedEventArgs e)
		{
			string connStr = "server=mariadb.vamk.fi;user=e2101083;database=e2101083_FitFolio;port=3306;password=jBxqVvNfMGH";
			MySqlConnection conn = new MySqlConnection(connStr);
			try
			{
				//Console.WriteLine("Connecting to MySQL...");

				conn.Open();
				string sql = "SELECT name,password FROM users";
				MySqlCommand cmd = new MySqlCommand(sql, conn);

				MySqlDataReader rdr = cmd.ExecuteReader();

				while (rdr.Read())
				{
					string user = textBoxEmail.Text;
					string pass = passwordBox.Password;
					if (rdr[0].ToString() == user && rdr[1].ToString() == pass)
					{
						MainWindow mw = new MainWindow();
						mw.Show();
						this.Close();
					}
					else errormessage.Text = "Wrong Username or Password!";
				}

				rdr.Close();
				
			}
			catch (Exception ex) { Console.WriteLine(ex.ToString()); }

			conn.Close();

			

		}
	}
}
