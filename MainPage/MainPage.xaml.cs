namespace FbmWebApp;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void OnNavigated(object sender, WebNavigatedEventArgs e)
    {
        if (e.Result == WebNavigationResult.Success)
        {
            // 1. Reveal the webpage
            MainWebView.IsVisible = true;

            // 2. Kill the loader layout to remove the overlap
            LoadingLayout.IsVisible = false;

            // 3. Hide any previous errors
            ErrorLayout.IsVisible = false;
        }
        else
        {
            // If failed, hide webview and show the error message
            MainWebView.IsVisible = false;
            LoadingLayout.IsVisible = false;
            ErrorLayout.IsVisible = true;
        }
    }

    private void OnRetryClicked(object sender, EventArgs e)
    {
        // Reset the UI state
        ErrorLayout.IsVisible = false;
        LoadingLayout.IsVisible = true;

        // Reload the view
        MainWebView.Reload();
    }
}
