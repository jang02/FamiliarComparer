﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Intrinsics.X86;
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

namespace FamiliarComparer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static BindingList<Familiar> Fams = new();
        public MainWindow()
        {
            InitializeComponent();

            Fams = Handler.GetFams();
            famList.ItemsSource = Fams;
            famList.DisplayMemberPath = nameof(Familiar.displayString);

        }

        private void SelectedFamChanged(object sender, SelectionChangedEventArgs e)
        {
            if (famList.SelectedItem != null)
            {
                Familiar fam = (Familiar)famList.SelectedItem;

                attackUpdateText.Text = fam.Attack.ToString();
                critDMGUpdateText.Text = fam.CritDMG.ToString();

                totalDmgText.Content = fam.TotalDMG.ToString();
                totalCritText.Content = fam.TotalCrit.ToString();
            }

        }

        private void addFamiliar(object sender, RoutedEventArgs e)
        {
            int attack;
            int critdmg;
            try
            {
                attack = Int32.Parse(attackText.Text);
                critdmg = Int32.Parse(critDMGText.Text);
            }
            catch
            {
                return;
            }

            attackUpdateText.Text = "";
            critDMGUpdateText.Text = "";

            totalDmgText.Content = "";
            totalCritText.Content = "";

            Fams.Add(new Familiar(attack, critdmg));
            Handler.SaveFams(Fams);
            Fams = Handler.GetFams();
            famList.ItemsSource = Fams;

        }

        private void updateFamiliar(object sender, RoutedEventArgs e)
        {
            if (famList.SelectedItem != null)
            {

                Familiar fam = (Familiar) famList.SelectedItem;
                int attack;
                int critdmg;
                try
                {
                    attack = Int32.Parse(attackUpdateText.Text);
                    critdmg = Int32.Parse(critDMGUpdateText.Text);
                }
                catch
                {
                    return;
                }
                fam.Update(attack, critdmg);

                attackUpdateText.Text = fam.Attack.ToString();
                critDMGUpdateText.Text = fam.CritDMG.ToString();

                totalDmgText.Content = fam.TotalDMG.ToString();
                totalCritText.Content = fam.TotalCrit.ToString();

                Handler.SaveFams(Fams);
                Fams = Handler.GetFams();
                famList.ItemsSource = Fams;
            }
        }

        private void removeFamiliar(object sender, RoutedEventArgs e)
        {
            if (famList.SelectedItem != null)
            {
                Fams.Remove((Familiar)famList.SelectedItem);
                Handler.SaveFams(Fams);
                Fams = Handler.GetFams();
                famList.ItemsSource = Fams;
            }
        }
    }
}
