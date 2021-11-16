using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UWP_MovieApiDemo
{
    public sealed partial class MainPage : Page
    {
        const string ApiKey = "YOUR_API_KEY";

        private ObservableCollection<Movie> movieList;

        public MainPage()
        {
            this.InitializeComponent();
            movieList = new ObservableCollection<Movie>();
        }

        public async static Task<Movie> GetMovie(string imdbId)
        {
            Movie movie = null;

            if (imdbId.StartsWith("tt"))
            {
                const string baseUrl = "http://www.omdbapi.com/";
                Uri requestUrl = new Uri($"{baseUrl}?i={imdbId}&apiKey={ApiKey}");

                using (var httpClient = new HttpClient())
                {
                    try
                    {
                        var json = await httpClient.GetStringAsync(requestUrl);
                        movie = JsonConvert.DeserializeObject<Movie>(json);
                    }
                    catch (HttpRequestException ex)
                    {
                        var errorDialog = new ContentDialog()
                        {
                            Title = "HttpClient error",
                            Content = ex.Message,
                            CloseButtonText = "OK"
                        };

                        await errorDialog.ShowAsync();
                    }
                }
            }
            else
            {
                var errorDialog = new ContentDialog()
                {
                    Title = "Invalid ID",
                    Content = "Please supply an IMDB ID, which must start with \"tt\".",
                    CloseButtonText = "OK"
                };

                await errorDialog.ShowAsync();
            }            

            return movie;
        }

        private async void fetchButton_Click(object sender, RoutedEventArgs e)
        {
            Movie movie = await GetMovie(imdbIdTextBox.Text);
            if (movie != null && movie.Title != "")
            {
                movieList.Add(movie);
            }
        }
    }
}
