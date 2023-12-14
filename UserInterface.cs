public class UserInterface {
    private PasswordVaultManager _passwordVaultManager = new PasswordVaultManager();
    private AuthenticationManager _authenticationManager = new AuthenticationManager();
    private string _authenticatedUser;
    public bool DisplayLoginMenu() {
        DisplayLogo();
        Console.WriteLine("1) Log In\n2) Create New User");
        try {
            int tempChoice = int.Parse(GetUserInput("Type in menu selection: "));
            switch (tempChoice) {
                case 1:
                    if (UserLogin()) {
                        return true;
                    } else {
                        return false;
                    }
                case 2:
                    if (CreateNewUser()) {
                        return true;
                    } else {
                        WaitToAdvance();
                        DisplayLoginMenu();
                        break;
                    }
                default:
                    RangeError();
                    WaitToAdvance();
                    DisplayLoginMenu();
                    break;
            }
        } catch {
            NumericError();
            WaitToAdvance();
            DisplayLoginMenu();
        }
        return false; 
    }
    private bool UserLogin() {
        string tempUserName = GetUserInput("\nUsername: ");
        string tempPassword = GetUserInput("Password: ");
        bool loginResponse = _authenticationManager.AuthenticateUser(tempUserName, tempPassword);
        if (loginResponse) {
            _authenticatedUser = tempUserName;
            _passwordVaultManager.LoadPasswords(_authenticatedUser);
        } else {
            WaitToAdvance();
        }
        return loginResponse;

    }
    private bool CreateNewUser() {
        User _user = new User();
        string tempUsername = _user.SetUserName();
        if (_authenticationManager.UsernameCheck(tempUsername)) {
            _authenticatedUser = tempUsername;
            _user.SetPassword();
            _user.SaveUser();
            return true;
        } else {
            return false;
        }
    }
    public bool DisplayMainMenu() {
        DisplayLogo();
        Console.WriteLine("1) Generate New Password\n2) Update a Password\n3) View Passwords\n4) Delete a Password\n5) Log Out and Exit");
        try {
            int menuChoice = int.Parse(GetUserInput("Select an option from the menu: "));
            switch (menuChoice) {
                case 1:
                    _passwordVaultManager.AddPassword(_authenticatedUser);
                    WaitToAdvance();
                    return true;
                case 2:
                    UpdatePassword();
                    return true;
                case 3:
                    DisplayPasswordList();
                    return true;
                case 4:
                    DeletePassword();
                    return true;
                case 5:
                    return false;
                default:
                    RangeError();
                    WaitToAdvance();
                    DisplayMainMenu();
                    return true;
            }
        } catch {
            NumericError();
            WaitToAdvance();
            DisplayMainMenu();
            return true;
        }
    }

    public static string GetUserInput(string message) {
        Console.Write(message);
        return Console.ReadLine();
    }

    private void NumericError() {
        Console.WriteLine("Invalid Choice. Choice must be numeric.");
    }

    private void RangeError() {
        Console.WriteLine("Invalid Choice. Choice outside valid range.");
    }

    private void DisplayPasswordList() {
        DisplayLogo();
        _passwordVaultManager.ViewPasswords();
        WaitToAdvance();
    }
    private void UpdatePassword() {
        DisplayLogo();
        _passwordVaultManager.ViewPasswords();
        _passwordVaultManager.UpdatePassword();
        WaitToAdvance();
    }
    private void DeletePassword() {
        DisplayLogo();
        _passwordVaultManager.ViewPasswords();
        _passwordVaultManager.DeletePassword();
        WaitToAdvance();
    }
    private void DisplayLogo() {
        Console.Clear();
        Console.WriteLine("--- SecureCipher Hub ---\n");
    }
    private void WaitToAdvance() {
        Console.WriteLine("\n-- Press Enter to Continue --");
        Console.ReadLine();
    }
}