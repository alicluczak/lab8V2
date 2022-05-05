using lab8p2.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace lab8p2
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }
        private void btnWysw_Click(object sender, RoutedEventArgs e)
        {
            DbUczelnia db = new DbUczelnia();
            var s = db.Studenci;
            foreach (var x in s)
            {
                lbxLista.Items.Add(x.ToString());
            }
            double? a = db.Studenci.Average(t => t.Ocena);
            lblSrednia.Content = a;
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            lbxLista.Items.Clear();
            DbUczelnia db = new DbUczelnia();
            using (SqlConnection pol = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Uczelnia;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                SqlCommand com = new SqlCommand($"INSERT INTO Studenci (imie,nazwisko,ocena,wiek) VALUES ('{tbxImie.Text}','{tbxNazwisko.Text}','{tbxOcena.Text}','{tbxWiek.Text}')", pol);
                pol.Open();
                com.ExecuteScalar(); // albo com.ExecuteNonQuery();
                pol.Close();
            }
            btnWysw_Click(sender, e);
        }

        private void btnPrezentSwiateczny_Click(object sender, RoutedEventArgs e)
        {
            lbxLista.Items.Clear();
            DbUczelnia db = new DbUczelnia();
            var s = db.Studenci;
            using (SqlConnection pol = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Uczelnia;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                pol.Open();
                foreach (Student x in s)
                {
                    SqlCommand com = new SqlCommand($"UPDATE Studenci SET Ocena=@Ocena WHERE IdStudent={x.IdStudent} AND Ocena<=4.5", pol);
                    com.Parameters.Add("@Ocena", System.Data.SqlDbType.Float);
                    com.Parameters["@Ocena"].Value = x.Ocena + 0.5;
                    com.ExecuteScalar();               
                }
            }
            btnWysw_Click(sender, e);
        }

        private void btnUsun_Click(object sender, RoutedEventArgs e)
        {
            DbUczelnia db = new DbUczelnia();
            using (SqlConnection pol = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=Uczelnia;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                //SqlCommand com = new SqlCommand($"DELETE from Studenci WHERE IdStudent=@IdStudent", pol);
                //com.Parameters.Add("@IdStudent", System.Data.SqlDbType.Int);
                //com.Parameters["@IdStudent"].Value = lbxLista.SelectedItem;
                //db.Studenci.Remove(com);
                //pol.Open();
                //com.ExecuteScalar(); // albo com.ExecuteNonQuery();
                //pol.Close();
                int pom = Convert.ToInt32(lbxLista.SelectedIndex) + 1;
                var toDelete = new Student { IdStudent = pom };
                db.Studenci.Attach(toDelete);
                db.Studenci.Remove(toDelete);
                db.SaveChanges();
                //NIE DZIAŁA
            }

        }
    }
}
