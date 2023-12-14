public class AuthenticationManager {
    private List<User> _users = new List<User>();
    public AuthenticationManager () {
        LoadUsers();
    }
    private void LoadUsers() {
        string[] rawUserData = File.ReadAllLines("userData/Users.txt");
        foreach (string userData in rawUserData.Skip(1).ToArray()) {
            string[] splitData = userData.Split("|");
            string username = splitData[0];
            string password = splitData[1];
            _users.Add(new User(username, password));
        }
    }
    public bool AuthenticateUser (string inputUsername, string inputPassword) {
        foreach (var user in _users) {
            if (user.GetUsername() == inputUsername && user.GetPassword() == inputPassword) {
                return true;
            } else {
                Console.WriteLine("Invalid username or password");
                return false;
            }
        }
        return false;
    }
    public bool UsernameCheck(string toCheckUsername) {
        foreach (var user in _users) {
            if (user.GetUsername() == toCheckUsername) {
                Console.WriteLine($"Username {toCheckUsername} is already in use.");
                return false;
            }
        }
        return true;
    }
}