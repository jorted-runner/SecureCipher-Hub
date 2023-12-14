using System.Runtime.InteropServices;

public class User {
    private string _username;
    private string _password;
    private string _filename = "userData/Users.txt";
    public User (string username, string password) {
        _username = username;
        _password = password;
    }
    public User () {

    }
    public string SetUserName() {
        _username = UserInterface.GetUserInput("Username: ");
        return _username;
    }
    public void SetPassword() {
        _password = UserInterface.GetUserInput("Password: "); 
    }

    public void SaveUser() {
        using (StreamWriter outputFile = new StreamWriter(_filename, true)) {
            outputFile.WriteLine($"{_username}|{_password}");
        }
        string newUserFile = $"userData/{_username}.txt";
        using (StreamWriter outputFile = new StreamWriter(newUserFile, true)) {
            outputFile.WriteLine("website|username|password");
        }
    }
    public string GetUsername () {
        return _username;
    }
    public string GetPassword () {
        return _password;
    }
    public void UpdatePassword() {

    }
    public void AddPassword() {

    }
    public void DeletePassword() {

    }
    public void ChangePassword() {

    }
    public void ViewPasswords() {
        
    }
}