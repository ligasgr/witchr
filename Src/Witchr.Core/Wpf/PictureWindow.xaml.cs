using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FlickrNet;

namespace Witchr.Core.Wpf
{
    /// <summary>
    /// Interaction logic for PictureWindow.xaml
    /// </summary>
    public partial class PictureWindow : Window
    {

        private int position = 0;
        private PhotoCollection searchResult;

        public PictureWindow()
        {
            InitializeComponent();
            var f = Witchr.Core.Domain.FlickrManager.GetInstance();
            PhotoSearchOptions o = new PhotoSearchOptions();
            o.Extras = PhotoSearchExtras.AllUrls | PhotoSearchExtras.Description | PhotoSearchExtras.OwnerName;
            o.SortOrder = PhotoSearchSortOrder.Relevance;
            o.Tags = "nature";
            f.PhotosSearchAsync(o, result =>
            {
                if (result.Error != null)
                {
                    MessageBox.Show("An error occurred while talking to Flickr: " + result.Error.Message);
                    return;
                }
                searchResult = result.Result;
                setPictureSourceToCurrentPosition();
            }
          );
        }

        private void setPictureSourceToCurrentPosition()
        {
            string address = searchResult.ElementAt(position).OriginalUrl;
            if (address == null)
                address = searchResult.ElementAt(position).LargeUrl;
            if (address == null)
                address = searchResult.ElementAt(position).MediumUrl;
            if (address == null)
                address = searchResult.ElementAt(position).SmallUrl;
            Uri imageUri = new Uri(address);
            flickrImage.Source = new BitmapImage(imageUri);
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                if (position == 0)
                {
                    position = searchResult.Count - 1;
                }
                else
                {
                    position -= 1;
                }
                setPictureSourceToCurrentPosition();
            }
            else if (e.Key == Key.Right)
            {
                if (position == searchResult.Count - 1)
                {
                    position = 0;
                }
                else
                {
                    position += 1;
                }
                setPictureSourceToCurrentPosition();
            }
        }
    }
}
