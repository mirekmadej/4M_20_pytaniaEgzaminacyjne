using MySql.Data;
using MySql.Data.MySqlClient;

namespace _4M_20_pytaniaEgzaminacyjne
{
    struct Pytanie
    {
        public string pytanie;
        public string o1, o2, o3, o4;
        public string odp;
    }
    
    public partial class MainPage : ContentPage
    {
        int count = 1;
        private int nr = 0;
        private int nrPyt = 0;
        private int punkty = 0;
        private List<Pytanie> pytania = new List<Pytanie>();

        public MainPage()
        {
            Pytanie p1 = new Pytanie();

            /*
            using (TextReader r = File.OpenText(@"C:\Users\mm\source\repos\4M_20_pytaniaEgzaminacyjne\4M_20_pytaniaEgzaminacyjne\bin\Debug\net7.0-windows10.0.19041.0\win10-x64\testy.txt"))
            {
                string czysc(string s)
                {
                    bool b = s.Contains("*.");
                    if (b)
                        p1.odp = s[0].ToString().ToUpper(); ;
                    s = s.Substring(s.IndexOf(" ") + 1);
                    return s;
                }
                while(r.Peek()>0)
                {
                    p1.pytanie = czysc(r.ReadLine());
                    p1.o1 = czysc(r.ReadLine());
                    p1.o2 = czysc(r.ReadLine());
                    p1.o3 = czysc(r.ReadLine());
                    p1.o4 = czysc(r.ReadLine());
                    pytania.Add(p1);
                    r.ReadLine();
                }

            }

            */

            // tu zapisac listę do bazy
            // lista pytania zawiera pytania
            /*
               string pol = "server=localhost;user=root;database=egzamin;" +
                   "port=3306;password=";
               MySqlConnection c = new MySqlConnection(pol);
               c.Open();
               foreach (Pytanie p in pytania)
               {
                   string sql = $"INSERT INTO pytania (pytani1, o1, o2, o3, o4, odp) " +
                       $"VALUES ('{p.pytanie}', '{p.o1}', '{p.o2}', '{p.o3}', '{p.o4}', '{p.odp}') ";
                 //  MySqlCommand w= new MySqlCommand(sql, c);
                  // MySqlDataReader r = w.ExecuteReader();
                   //r.Close();
               }
               c.Close();
            */
            string pol = "server=192.168.213.80;user=egzamin;database=egzamin;" +
                "port=3306;password=egzamin";
            MySqlConnection c = new MySqlConnection(pol);
            c.Open();
            string sql = "SELECT * FROM pytania";
            MySqlCommand w= new MySqlCommand(sql, c);
            MySqlDataReader r = w.ExecuteReader();
            while (r.Read())
            {
                Pytanie p = new Pytanie();
                p.pytanie = r[1].ToString();
                p.o1 = r[2].ToString();
                p.o2 = r[3].ToString();
                p.o3 = r[4].ToString();
                p.o4 = r[5].ToString();
                p.odp = r[6].ToString();

                pytania.Add(p);
            }
            r.Close();
            c.Close();

            InitializeComponent();
            Random n = new Random();
            nrPyt = n.Next(pytania.Count - 1);
            ustawPytanie(pytania[nrPyt]);
        }
        private void ustawPytanie(Pytanie p)
        {
            lblNaglowek.Text = $"Pytanie {count}/10";
            lblPytanie.Text = p.pytanie;
            rbtO1.Content = p.o1;
            rbtO2.Content = p.o2;
            rbtO3.Content = p.o3;
            rbtO4.Content = p.o4;
        }

        private void btnZatwierdzClicked(object sender, EventArgs e)
        {

            string o = "";
            if (rbtO1.IsChecked)
                o = "A";
            if (rbtO2.IsChecked)
                o = "B";
            if (rbtO3.IsChecked)
                o = "C";
            if (rbtO4.IsChecked)
                o = "D";
            if (o == pytania[nrPyt].odp)
                punkty++;
            lblPunkty.Text = $"Punktów {punkty}/10";
            if (count >= 10)
            {
                btnZatwierdz.IsEnabled = false;
                return;
            }
                
            count++;

            Random n = new Random();
            nrPyt = n.Next(pytania.Count-1);
            ustawPytanie(pytania[nrPyt]);
            rbtO1.IsChecked = false;
            rbtO2.IsChecked = false;
            rbtO3.IsChecked = false;
            rbtO4.IsChecked = false;
        }
    }
}