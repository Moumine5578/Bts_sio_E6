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
using System.Net.Http;
using System.Text.Json;
using LiveCharts;
using LiveCharts.Wpf;
using System.Reflection.Emit;
using System.Runtime.Serialization;
using System.Numerics;

namespace TardyGrade.WPF
{
    /// <summary>
    /// Logique d'interaction pour StatistiquesWindow.xaml
    /// </summary>
    public partial class StatistiquesWindow : Window
    {
        public DateTime DateDebut { get; }
        public DateTime DateFin { get; }
        public int Id { get; set; }

        #region Propriété pour les Graphiques en barres
        
        public Func<double, string> Formatter { get; set; }

        // Déclarez la propriété SeriesCollection pour le graph des nombreStats
        public SeriesCollection SeriesCollectionNombreStats { get; set; }
        public string[] LabelsNombreStats { get; set; }

        #region Comptes
        // Déclarez la propriété SeriesCollection pour le graph des ComptesPostantLePlus
        public SeriesCollection SeriesCollectionComptesPostantLePlus { get; set; }
        public string[] LabelsComptesPostantLePlus { get; set; }

        // Déclarez la propriété SeriesCollection pour le graph des ComptesCommentantLePlus
        public SeriesCollection SeriesCollectionComptesCommentantLePlus { get; set; }
        public string[] LabelsComptesCommentantLePlus { get; set; }
        #endregion

        #region Posts

        // Déclarez la propriété SeriesCollection pour le graph des moyennes de posts
        public SeriesCollection SeriesCollectionMoyPosts { get; set; }
        public string[] LabelsMoyPosts { get; set; }

        // Déclarez la propriété SeriesCollection pour le graph des PostsLikes
        public SeriesCollection SeriesCollectionPostsPlusLikes { get; set; }
        public string[] LabelsPostsPlusLikes { get; set; }

        // Déclarez la propriété SeriesCollection pour le graph des PostsSuperLikes
        public SeriesCollection SeriesCollectionPostsPlusSuperLikes { get; set; }
        public string[] LabelsPostsPlusSuperLikes { get; set; }

        #endregion

        #endregion

        public StatistiquesWindow(DateTime dateDebut, DateTime dateFin)
        {
            InitializeComponent();

            DateDebut = dateDebut;
            DateFin = dateFin;

            

            // Convertir les DateTime en chaînes de caractères
            textBlockTitreDateDebut.Text = DateDebut.ToString("dd/MM/yyyy");
            textBlockTitreDateFin.Text = DateFin.ToString("dd/MM/yyyy");

            textBlockConfirmationDateDebut.Text = DateDebut.ToString("dd/MM/yyyy");
            textBlockConfirmationDateFin.Text = DateFin.ToString("dd/MM/yyyy");


            // Utilisez les dates pour récupérer les statistiques et afficher les résultats
            LoadStatistics(dateDebut, dateFin);
        }

        // Méthode pour récupérer et afficher les statistiques
        private async void LoadStatistics(DateTime dateDebut, DateTime dateFin)
        {
            // On recupere les statistiques entre les deux date avec GetByDates du Client
            Client apiClient = new Client();
            NombreStats_DTO statistic = apiClient.GetByDates(dateDebut, dateFin);
            Id = statistic.Id.Value;
            DisplayStatistics(statistic);
        }

        // Méthode pour afficher les statistiques dans l'interface utilisateur
        private void DisplayStatistics(NombreStats_DTO statistic)
        {
            // Affichez les statistiques dans les TextBlocks de votre interface utilisateur
            textBlockId.Text = $"ID : {statistic.Id}";
            textBlockDateDebut.Text = $"Date de début : {statistic.DateDebut.ToString("g")}";
            textBlockDateFin.Text = $"Date de fin : {statistic.DateFin.ToString("g")}";

            #region Nombre de créations

            textBlockNombreCreationsComptes.Text = $"Nombre de comptes créés : {statistic.NombreCreationsComptes}";
            textBlockNombreCreationsPosts.Text = $"Nombre de posts créés : {statistic.NombreCreationsPosts}";
            textBlockNombreCreationsCommentaires.Text = $"Nombre de commentaires postés : {statistic.NombreCreationsCommentaires}";
            textBlockNombreCreationsLikes.Text = $"Nombre de likes : {statistic.NombreCreationsLikes}";

            // Créer les entrées pour le graphique
            SeriesCollectionNombreStats = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = $"{statistic.DateDebut.ToString("dd/MM/yyyy")} - {statistic.DateFin.ToString("dd/MM/yyyy")}",
                    Values = new ChartValues<double> { statistic.NombreCreationsComptes, statistic.NombreCreationsPosts, statistic.NombreCreationsCommentaires, statistic.NombreCreationsLikes }
                }
            };
            // Définir les étiquettes pour l'axe X du graphique
            LabelsNombreStats = new[] { "Comptes créés", "Posts créés", "Commentaires postés", "Likes" };

            // Définir le formateur pour l'axe Y du graphique
            Formatter = value => value.ToString("N");

            // Mettre à jour le DataContext pour refléter les changements
            DataContext = this;
            #endregion

            #region Comptes

            #region Comptes postant le plus

            // Effacez d'abord toutes les lignes existantes dans le DataGrid
            dataGridComptesPostantLePlus.Items.Clear();

            dataGridComptesPostantLePlus.ItemsSource = statistic.ComptesPostantLePlus;

            // Liste de velues/labels pour les comptes postant le plus
            var ValuesComptesPosts1 = new ChartValues<double> { };
            var ValuesComptesPosts2 = new ChartValues<double> { };
            List<string> labelsList = new List<string>();
            
            foreach (var compte in statistic.ComptesPostantLePlus)
            {
               /* dataGridComptesPostantLePlus.Items.Add(new
                {
                    Pseudo = compte.Pseudo,
                    Posts = compte.NombrePosts,
                    Commentaires = compte.NombreCommentaires
                }); */

                // Ajoutez les valeurs à la liste des valeurs pour les graphiques
                ValuesComptesPosts1.Add(compte.NombrePosts);
                ValuesComptesPosts2.Add(compte.NombreCommentaires);

                // Ajouter le pseudo du compte à la liste des étiquettes
                labelsList.Add(compte.Pseudo);

            }

            // Créer les entrées pour le graphique
            SeriesCollectionComptesPostantLePlus = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Posts",
                    Values = ValuesComptesPosts1
                },
                new ColumnSeries
                {
                    Title = "Commentaires",
                    Values = ValuesComptesPosts2
                }
            };
            // Définir les étiquettes pour l'axe X du graphique
            LabelsComptesPostantLePlus = labelsList.ToArray();

            // Définir le formateur pour l'axe Y du graphique
            Formatter = value => value.ToString("N");

            // Mettre à jour le DataContext pour refléter les changements
            DataContext = this;
            #endregion

            #region Comptes Commentant le plus

            // Liste de velues pour les comptes postant le plus
            var ValuesComptesCom1 = new ChartValues<double> { };
            var ValuesComptesCom2 = new ChartValues<double> { };

            labelsList.Clear();
            // Effacez d'abord toutes les lignes existantes dans le DataGrid
            dataGridComptesCommentantLePlus.Items.Clear();
            dataGridComptesCommentantLePlus.ItemsSource = statistic.ComptesPostantLePlus;
            // Pour chaque compte dans la liste des comptes postant le plus, ajoutez une ligne dans le DataGrid
            foreach (var compte in statistic.ComptesCommentantLePlus)
            {
                // Ajoutez les valeurs à la liste des valeurs pour les graphiques
                ValuesComptesCom1.Add(compte.NombrePosts);
                ValuesComptesCom2.Add(compte.NombreCommentaires);

                // Ajouter le pseudo du compte à la liste des étiquettes
                labelsList.Add(compte.Pseudo);
            }

            // Créer les entrées pour le graphique
            SeriesCollectionComptesCommentantLePlus = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Posts",
                    Values = ValuesComptesCom1
                },
                new ColumnSeries
                {
                    Title = "Commentaires",
                    Values = ValuesComptesCom2
                }
            };
            // Convertir la liste en tableau
            LabelsComptesCommentantLePlus = labelsList.ToArray();

            // Définir le formateur pour l'axe Y du graphique
            Formatter = value => value.ToString("N");

            // Mettre à jour le DataContext pour refléter les changements
            DataContext = this;

            #endregion

            #endregion

            #region Posts

            #region Moyennes

            textMoyenneLikesPosts.Text = $"Moyenne de likes : {statistic.MoyenneLikesPosts}";
            textMoyenneComPosts.Text = $"Moyenne de commentaires  : {statistic.MoyenneCommentairesPosts}";

            // Créer les entrées pour le graphique
            SeriesCollectionMoyPosts = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = $"{statistic.DateDebut.ToString("dd/MM/yyyy")} - {statistic.DateFin.ToString("dd/MM/yyyy")}",
                    Values = new ChartValues<double> { statistic.MoyenneLikesPosts, statistic.MoyenneCommentairesPosts }
                }
            };
            // Définir les étiquettes pour l'axe X du graphique
            LabelsMoyPosts = new[] { "Likes", "Commentaires"};

            // Définir le formateur pour l'axe Y du graphique
            Formatter = value => value.ToString("N");

            // Mettre à jour le DataContext pour refléter les changements
            DataContext = this;

            #endregion


            #region Posts les plus likés
            // Effacez d'abord toutes les lignes existantes dans le DataGrid
            dataGridPostsLikesLePlus.Items.Clear();
            dataGridPostsLikesLePlus.ItemsSource = statistic.PostsLesPlusLikes;
            // Modifier le DataGrid pour que la date de publication soit uniquement la date


            // Liste des values pour les posts les plus likés
            var ValuesPostsLikes = new ChartValues<double> { };
            List<string> labelsListPostsLikes = new List<string>();

            foreach (var post in statistic.PostsLesPlusLikes)
            {
                // Ajoutez les valeurs à la liste des valeurs pour les graphiques
                ValuesPostsLikes.Add(post.NombreLikes);

                // Ajouter le classement du post à la liste des étiquettes (1, 2, 3, ...)
                labelsListPostsLikes.Add((labelsListPostsLikes.Count + 1).ToString());
            }

            // Créer les entrées pour le graphique
            SeriesCollectionPostsPlusLikes = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Likes",
                    Values = ValuesPostsLikes,
                    Fill = Brushes.LightGreen
                }
            };
            // Définir les étiquettes pour l'axe X du graphique
            LabelsPostsPlusLikes = labelsListPostsLikes.ToArray();

            // Définir le formateur pour l'axe Y du graphique
            Formatter = value => value.ToString("N");

            #endregion

            #region Posts les plus superlikés

            // Effacez d'abord toutes les lignes existantes dans le DataGrid
            dataGridPostsSuperLikesLePlus.Items.Clear();
            dataGridPostsSuperLikesLePlus.ItemsSource = statistic.PostsLesPlusSuperLikes;

            // Liste des values pour les posts les plus superlikés
            var ValuesPostsSuperLikes = new ChartValues<double> { };
            List<string> labelsListPostsSuperLikes = new List<string>();

            foreach (var post in statistic.PostsLesPlusSuperLikes)
            {
                // Ajoutez les valeurs à la liste des valeurs pour les graphiques
                ValuesPostsSuperLikes.Add(post.NombreSuperLikes);

                // Ajouter le classement du post à la liste des étiquettes (1, 2, 3, ...)
                labelsListPostsSuperLikes.Add((labelsListPostsSuperLikes.Count + 1).ToString());
            }

            // Créer les entrées pour le graphique
            SeriesCollectionPostsPlusSuperLikes = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "SuperLikes",
                    Values = ValuesPostsSuperLikes,
                    Fill = Brushes.LightBlue
                }
            };
            // Définir les étiquettes pour l'axe X du graphique
            LabelsPostsPlusSuperLikes = labelsListPostsSuperLikes.ToArray();
            Formatter = value => value.ToString("N");

            #endregion

            #endregion
        }

        private void ReturnToMainWindow_Click(object sender, RoutedEventArgs e)
        {
            // Créez une nouvelle instance de MainWindow
            //MainWindow mainWindow = new MainWindow();

            // Fermez la fenêtre actuelle
            Close();

            // Affichez la fenêtre principale
            //mainWindow.Show();
        }

        private void Button_Supprimer_Stat_Click(object sender, RoutedEventArgs e)
        {
            // Afficher la boîte de dialogue de confirmation
            ConfirmationDialog.Visibility = Visibility.Visible;

            // Mettre le focus sur le TextBox pour que l'utilisateur puisse commencer à taper immédiatement
            ConfirmationTextBox.Focus();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            // Vérifiez si l'utilisateur a écrit "oui"
            if (ConfirmationTextBox.Text.ToLower() == "oui")
            {
                // Supprimer les statistiques avec Delete du Client
                Client apiClient = new Client();
                apiClient.Delete(Id, DateDebut, DateFin);

                // Fermez ou cachez la fenêtre principale si nécessaire
                Close();
            }

            // Masquer la boîte de dialogue de confirmation
            ConfirmationDialog.Visibility = Visibility.Collapsed;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Masquer la boîte de dialogue de confirmation
            ConfirmationDialog.Visibility = Visibility.Collapsed;
        }

        private void ConfirmationTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ConfirmButton_Click(sender, e);
            }
            else if (e.Key == Key.Escape)
            {
                CancelButton_Click(sender, e);
            }
        }

        private void ConfirmationDialog_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Appeler CancelButton_Click si la partie grise est cliquée
            CancelButton_Click(sender, e);
        }

        private void ConfirmationDialog_Content_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Arrêter la propagation de l'événement MouseDown pour le contenu de la boîte de dialogue
            e.Handled = true;
        }
    }
}
