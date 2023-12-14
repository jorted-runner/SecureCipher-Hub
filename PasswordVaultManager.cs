public class PasswordVaultManager {
    private List<Password> _passwords = new List<Password> ();
    public void ViewPasswords() {
        int i = 1;
        foreach (var password in _passwords) {
            Console.WriteLine($"\n{password.FormatForDisplay(i)}\n");
            i++;
        }
    }
    public void LoadPasswords(string username) {
        string[] passwordData;
        string passwordFile = $"userData/{username}.txt";
        passwordData = File.ReadAllLines(passwordFile);
        foreach (string line in passwordData.Skip(1).ToArray()) {
            string[] data = line.Split("|");
            string website = data[0];
            string usernameEmail = data[1];
            string password = data[2];
            _passwords.Add(new Password(username, website, usernameEmail, password));
        }
    }
    public void AddPassword(string username) {
        _passwords.Add(new Password(username));
    }
    public void UpdatePassword() {
        int userChoice = int.Parse(UserInterface.GetUserInput("Which password would you like to update? "));
        int passwordIndex = userChoice - 1;
        _passwords[passwordIndex].UpdatePassword(userChoice);

    }
    public void DeletePassword() {
        int userChoice = int.Parse(UserInterface.GetUserInput("Which password would you like to delete? "));
        int passwordIndex = userChoice - 1;
        _passwords[passwordIndex].DeletePassword(userChoice);
        _passwords.RemoveAt(passwordIndex);
    }
}