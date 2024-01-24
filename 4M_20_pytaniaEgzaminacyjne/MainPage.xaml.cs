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
        private int punkty = 0;
        private List<Pytanie> pytania = new List<Pytanie>();

        public MainPage()
        {
            Pytanie p1 = new Pytanie()
            {
            pytanie = "2+2 = ",
            o1 = "1",
            o2 = "2",
            o3 = "3",
            o4 = "4",
            odp = "4"
            };
            pytania.Add(p1);
            InitializeComponent();
            //random
            ustawPytanie(pytania[nr]);
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
            if (o == pytania[nr].odp)
                punkty++;
            lblPunkty.Text = $"Punktów {punkty}/10";
            //random nr
            count++;
            if (count >= 10)
                btnZatwierdz.IsEnabled=false;
            ustawPytanie(pytania[nr]);
        }
    }
}