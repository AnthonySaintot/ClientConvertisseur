using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using ClientConvertisseur.Models;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using WSConvertisseur.Services;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ClientConvertisseur.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ConvertisseurEuroPage : Page
    {
        private WSService service;
        public ConvertisseurEuroPage()
        {

            this.InitializeComponent();
            service = new WSService();
            ActionGetDataAsync();
        }
        private async void ActionGetDataAsync()
        {
            var result = await service.GetDevisesAsync("Devises");
            if (result == null)
            {
                Dialogue("Erreur", "API non disponible");
            }
            else
            {
                this.DeviseComboBox.DataContext = new List<Devise>(result);
            }
        }
        private async void Dialogue(string Title,string Content)
        {
            ContentDialog Dialog = new ContentDialog
            {
                Title = Title,
                Content = Content,
                CloseButtonText = "Ok"
            };
            Dialog.XamlRoot = this.Content.XamlRoot;

            ContentDialogResult result = await Dialog.ShowAsync();
        }
        private void ConvertirButton_Click(object sender, RoutedEventArgs e)
        {
            // Récupérer le montant en euros depuis le premier TextBox
            if (double.TryParse(MontantEuroTextBox.Text, out double montantEnEuros))
            {
                // Récupérer le taux de conversion à partir du ComboBox (supposons que vous ayez une liste de taux)
                if (DeviseComboBox.SelectedItem is Devise devise)
                {
                    // Effectuer la conversion
                    double montantConverti = montantEnEuros * devise.Taux;

                    // Afficher le résultat dans le deuxième TextBox
                    MontantConvertiTextBox.Text = montantConverti.ToString("F2"); // "F2" pour formater avec deux décimales
                }
                else
                {
                    // Gérer le cas où aucune devise n'est sélectionnée
                    Dialogue("Erreur", "Veuillez sélectionner une devise.");
                }
            }
            else
            {
                // Gérer le cas où la saisie du montant en euros n'est pas valide
                Dialogue("Erreur", "Saisir un montant valide");
            }
        }

    }
}
