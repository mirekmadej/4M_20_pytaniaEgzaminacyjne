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

            using (TextReader r = File.OpenText(@"C:\Users\mm\source\repos\4M_20_pytaniaEgzaminacyjne\4M_20_pytaniaEgzaminacyjne\bin\Debug\net7.0-windows10.0.19041.0\win10-x64\testy.txt"))
            {
                string czysc(string s)
                {
                    bool b = s.Contains("*.");
                    s = s.Substring(s.IndexOf(" ") + 1);
                    if (b)
                        p1.odp = s;
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
                o = rbtO1.Content.ToString();
            if (rbtO2.IsChecked)
                o = rbtO2.Content.ToString();
            if (rbtO3.IsChecked)
                o = rbtO3.Content.ToString();
            if (rbtO4.IsChecked)
                o = rbtO4.Content.ToString();
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
            nrPyt = n.Next(19);
            ustawPytanie(pytania[nrPyt]);
            rbtO1.IsChecked = false;
            rbtO2.IsChecked = false;
            rbtO3.IsChecked = false;
            rbtO4.IsChecked = false;
        }
    }
}