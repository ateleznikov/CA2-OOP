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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CA2_OOP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// https://github.com/ateleznikov/CA2-OOP/tree/main/CA2-OOP
    public partial class MainWindow : Window
    {
        List<Team> AllTeams = new List<Team>();
        BitmapImage solidStar = new BitmapImage(new Uri("/img/starsolid.png", UriKind.Relative));
        BitmapImage outlineStar = new BitmapImage(new Uri("/img/staroutline.png", UriKind.Relative));
        public MainWindow()
        {
            InitializeComponent();
        }

        public void GetData(object sender, RoutedEventArgs e)
        {
            Team t1 = new Team() { Name = "France" };
            Team t2 = new Team() { Name = "Italy" };
            Team t3 = new Team() { Name = "Spain" };
            //French players
            Player p1 = new Player() { Name = "Marie", ResultRecord = "WWDDL" };
            Player p2 = new Player() { Name = "Claude", ResultRecord = "DDDLW" };
            Player p3 = new Player() { Name = "Antoine", ResultRecord = "LWDLW" };
            //Italian players
            Player p4 = new Player() { Name = "Marco", ResultRecord = "WWDLL" };
            Player p5 = new Player() { Name = "Giovanni", ResultRecord = "LLLLD" };
            Player p6 = new Player() { Name = "Valentina", ResultRecord = "DLWWW" };
            //Spanish players
            Player p7 = new Player() { Name = "Maria", ResultRecord = "WWWWW" };
            Player p8 = new Player() { Name = "Jose", ResultRecord = "LLLLL" };
            Player p9 = new Player() { Name = "Pablo", ResultRecord = "DDDDD" };
            t1.Players = new List<Player>();
            t1.Players.Add(p1);
            t1.Players.Add(p2);
            t1.Players.Add(p3);
            t2.Players = new List<Player>();
            t2.Players.Add(p4);
            t2.Players.Add(p5);
            t2.Players.Add(p6);
            t3.Players = new List<Player>();
            t3.Players.Add(p7);
            t3.Players.Add(p8);
            t3.Players.Add(p9);
            AllTeams.Add(t1);
            AllTeams.Add(t2);
            AllTeams.Add(t3);

            lbxTeams.ItemsSource = AllTeams;
            AllTeams.Sort();
            

        }

        private void lbxTeams_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Team selected = lbxTeams.SelectedItem as Team;

            if (selected != null)
            {
                lbxPlayers.ItemsSource = selected.Players;
            }
            
        }
        public void UpdatedStars()
        {
            Player selectedPlayer = lbxPlayers.SelectedItem as Player;
            
            if (selectedPlayer != null)
            {
                if (selectedPlayer.CalculatedPoints > 0 && selectedPlayer.CalculatedPoints <= 5)
                {
                    img1.Source = solidStar;
                    img2.Source = outlineStar;
                    img3.Source = outlineStar;
                }
                else if ((selectedPlayer.CalculatedPoints >= 6 && selectedPlayer.CalculatedPoints <= 10))
                {
                    img1.Source = solidStar;
                    img2.Source = solidStar;
                    img3.Source = outlineStar;
                }
                else if ((selectedPlayer.CalculatedPoints >= 11 && selectedPlayer.CalculatedPoints <= 15))
                {
                    img1.Source = solidStar;
                    img2.Source = solidStar;
                    img3.Source = solidStar;
                }
                else
                {
                    img1.Source = outlineStar;
                    img2.Source = outlineStar;
                    img3.Source = outlineStar;
                }
            }
            
        }
        public void UpdRecord(char result)
        {
            Player selectedPlayer = lbxPlayers.SelectedItem as Player;
            if (selectedPlayer != null)
            {
                string updString = selectedPlayer.ResultRecord.Substring(1);
                updString = updString + result;
                selectedPlayer.ResultRecord = updString;
            }
            Team selectedTeam = lbxTeams.SelectedItem as Team;

            if (selectedTeam != null)
            {
                lbxPlayers.ItemsSource = null;
                lbxPlayers.ItemsSource = selectedTeam.Players;
            }
            UpdatedStars();

            lbxTeams.ItemsSource = null;
            lbxTeams.ItemsSource = AllTeams;
            AllTeams.Sort();
            lbxTeams.SelectedItem = selectedTeam;
        }

        private void PlusWin(object sender, RoutedEventArgs e)
        {
            UpdRecord('W');
        }

        private void PlusLoss(object sender, RoutedEventArgs e)
        {
            UpdRecord('L');
        }

        private void PlusDraw(object sender, RoutedEventArgs e)
        {
            UpdRecord('D');
        }

        private void lbxPlayers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdatedStars();
        }
    }
}
