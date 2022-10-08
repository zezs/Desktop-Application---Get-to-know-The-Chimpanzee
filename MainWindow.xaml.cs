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

namespace WpfApp_Chimpanzee
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LBx_Categories.ItemsSource = App._content;
            LBx_Categories.SelectedIndex = 0;
            LBx_Photos.ItemsSource = App._gallery;
            LBx_Photos.SelectedIndex = 0; 

            TBk_Home.Text = $"Humans and chimpanzees are both known as primates, a specific classification of mammals that exist in our world today.You may be asking yourself, what exactly makes a primate a primate? And, if we are both primates, what is it about humans that makes us unique from chimps?\n Or are we more similar to chimps than some may think?";

            TBk_Home1.Text = $"The general rule of thumb for distinguishing primates from other mammalian species is that they locomote(move from one place to the next) differently than other mammals, have more manual dexterity(skillful movement of their hands), more acute senses, bone structure and dentition(characteristics of teeth number and arrangement), as well as differences in the brain.Primates, including the chimpanzee, are particularly excellent leapers and climbers, and over time there has been an increased trend for upright posture comparable to the way we humans walk.\n\n Just as humans have skillful hands and fingers, so do primates, including opposable thumbs and individually moving fingers.Primates have very acute senses, such as forward facing eyes, better visions than other mammals, excellent hearing, and sensitive pads on fingertips for touch which we primates rely and heavily for performing daily tasks as simple as holding a pencil in our hands.Our bone structures and dentition have evolved to be very similar, for example, chimpanzees and humans both have incisors, canines, molars and pre - molars used for feeding. Humans and chimps have also evolved to have a large brain to body mass ratio especially in the area of the cerebral cortex, the portion involved with consciousness.\n\n All of these features that make humans and chimpanzees so alike have evolved over time and scientists are just beginning to understand how we evolved together as well as why and how we share so many of the same characteristics.Look at your face in a mirror, open your mouth to see your teeth, and then look down at your hands and feet and compare them to a chimpanzees.Look at all of the similarities we share through our similar evolutionary path.";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Content con = new Content { categories = "fghfg", description = "sdfsd", imagePath= $"Gallery/11.jpg", imgdescription = "abcdefghijklmnopqrstuvwyz" };
            App._content.Add(con);
        }

        private void Tbx_filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Tbx_filter.Text == "")
                LBx_Categories.ItemsSource = App._content;
            else
            {
               // var lst = (from b in App._content where b.categories.ToLower().Contains(Tbx_filter.Text.ToLower()) select b).ToList();
                var list = (from c in App._content where c.description.ToLower().Contains(Tbx_filter.Text.ToLower()) || c.categories.ToLower().Contains(Tbx_filter.Text.ToLower()) select c).ToList();
                //lst.AddRange(list);
                LBx_Categories.ItemsSource = list.Distinct();
                if(list.Count > 0)
                LBx_Categories.SelectedIndex = 0;
                //TBx_Description.ItemsSource = list.Distinct();
            }

        }

        private void Btn_Categoies_Click(object sender, RoutedEventArgs e)
        {
            Grid_Home.Visibility= Visibility.Collapsed;
        }

        private void Btn_BackHome_Click(object sender, RoutedEventArgs e)
        {
            Grid_Home.Visibility = Visibility.Visible;
        }

        private void Btn_Gallery_Click(object sender, RoutedEventArgs e)
        {
            Grid_Gallery.Visibility = Visibility.Visible;
        }

        private void Btn_GalleryToHome_Click(object sender, RoutedEventArgs e)
        {
            Grid_Gallery.Visibility = Visibility.Collapsed;
        }

        private void Btn_Next_Click(object sender, RoutedEventArgs e)
        {
            LBx_Categories.SelectedIndex++;
            
        }

        private void Btn_Previous_Click(object sender, RoutedEventArgs e)
        {
            LBx_Categories.SelectedIndex--;
        }

        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            Gallery gal = new Gallery { imagePath = "/Chimpgallery/1.png", descriprion = "sivaltrhtrh" };
            //Gallery gal = new Gallery { imagePath = "Chimpgallery/1.png", descriprion = "chimp1" };
            App._gallery.Add(gal);
        }

        private void Btn_BackHome_Click1(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_pre_img_Click(object sender, RoutedEventArgs e)
        {
            if (LBx_Photos.SelectedIndex == 0)
                return;
            else
                LBx_Photos.SelectedIndex--;
        }

        private void Btn_next_img_Click(object sender, RoutedEventArgs e)
        {
            if (LBx_Photos.SelectedIndex == LBx_Photos.Items.Count - 1)
                return;
            else
            LBx_Photos.SelectedIndex++;
        }

        private void LBx_Categories_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Scroll_Topics.ScrollToTop();
        }
    }
}
