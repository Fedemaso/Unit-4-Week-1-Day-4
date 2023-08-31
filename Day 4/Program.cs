
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

class Utente
{
    public static string Username { get; private set; }
    public static DateTime LoginTime { get; private set; }
    private static List<DateTime> accessi = new List<DateTime>();

    public static bool Login(string username, string password, string confirmPassword)
    {
        if (string.IsNullOrEmpty(username) || password != confirmPassword)
            return false;

        Username = username;
        LoginTime = DateTime.Now;
        accessi.Add(LoginTime);
        return true;
    }

    public static void Logout()
    {
        if (!IsLoggedIn())
        {
            Console.WriteLine("Nessun utente loggato.");
            return;
        }

        Username = null;
        LoginTime = default;
        Console.WriteLine("Logout effettuato.");
    }

    public static void VerificaOraDataLogin()
    {
        if (!IsLoggedIn())
        {
            Console.WriteLine("Nessun utente loggato.");
            return;
        }

        Console.WriteLine($"Utente loggato il {LoginTime}.");
    }

    public static void ListaAccessi()
    {
        if (!IsLoggedIn())
        {
            Console.WriteLine("Nessun utente loggato.");
            return;
        }

        Console.WriteLine("Storico accessi:");
        foreach (var accesso in accessi)
        {
            Console.WriteLine(accesso);
        }
    }

    public static bool IsLoggedIn()
    {
        return !string.IsNullOrEmpty(Username);
    }
}

class Program
{
    static void Main(string[] args)
    {
        int scelta;

        do
        {
            Console.WriteLine("===============OPERAZIONI==============");
            Console.WriteLine("Scegli l’operazione da effettuare:");
            Console.WriteLine("1.: Login");
            Console.WriteLine("2.: Logout");
            Console.WriteLine("3.: Verifica ora e data di login");
            Console.WriteLine("4.: Lista degli accessi");
            Console.WriteLine("5.: Esci");
            Console.WriteLine("========================================");

            scelta = Convert.ToInt32(Console.ReadLine());

            switch (scelta)
            {
                case 1:
                    Console.Write("Username: ");
                    string username = Console.ReadLine();
                    Console.Write("Password: ");
                    string password = Console.ReadLine();
                    Console.Write("Conferma password: ");
                    string confirmPassword = Console.ReadLine();
                    if (Utente.Login(username, password, confirmPassword))
                        Console.WriteLine("Login effettuato.");
                    else
                        Console.WriteLine("Errore durante il login, password errata");
                    break;

                case 2:
                    Utente.Logout();
                    break;

                case 3:
                    Utente.VerificaOraDataLogin();
                    break;

                case 4:
                    Utente.ListaAccessi();
                    break;

                case 5:
                    Console.WriteLine("Uscita...");
                    break;

                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }
        } while (scelta != 5);
    }
}
