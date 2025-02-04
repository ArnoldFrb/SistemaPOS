namespace SistemaPOS.Src.Core.Services.Dialogs
{
    internal class DialogService : IDialogService
    {

        public Task ShowDialog(string title, string message, string buttonLabel)
        {
            return Application.Current!.MainPage!.DisplayAlert(title, message, buttonLabel);
        }
    }
}
