public class Password {
    private string _user;
    private string _website;
    private string _usernameEmail;
    private string _password;
    private string _newUserFile;
    public Password (string user, string website, string usernameEmail, string password) {
        _website = website;
        _usernameEmail = usernameEmail;
        _password = password;
        _user = user;
        _newUserFile = $"userData/{_user}.txt";

    }
    public Password (string user) {
        _user = user;
        _newUserFile = $"userData/{_user}.txt";
        _website = UserInterface.GetUserInput("\nWebsite: ");
        _usernameEmail = UserInterface.GetUserInput("Username/Email: ");
        _password = GeneratePassword();
        SavePassword();
    }
    public string FormatForDisplay(int num) {
        return $"{num}) -- {_website.ToUpper()} --\nUsername -- {_usernameEmail}\nPassword -- {_password}";
    }
    public string GeneratePassword() {
        PasswordGenerator _generator = new PasswordGenerator();
        return _generator.GeneratePassword();
    }
    public void UpdatePassword(int line) {
        _password = GeneratePassword();
        string newPasswordData = $"{_website}|{_usernameEmail}|{_password}";
        lineChanger(newPasswordData, _newUserFile, line);
    }
    private void SavePassword() {
        using (StreamWriter outputFile = new StreamWriter(_newUserFile, true)) {
            outputFile.WriteLine($"{_website}|{_usernameEmail}|{_password}");
        }
    }
    public void DeletePassword(int line) {
        List<string> lines = new List<string>(File.ReadAllLines(_newUserFile));
        lines.RemoveAt(line);
        File.WriteAllLines(_newUserFile, lines);
    }
    static void lineChanger(string newText, string fileName, int line_to_edit) {
        string[] arrLine = File.ReadAllLines(fileName);
        arrLine[line_to_edit] = newText;
        File.WriteAllLines(fileName, arrLine);
    }
}