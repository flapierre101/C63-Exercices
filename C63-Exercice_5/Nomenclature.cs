using System.Collections.Generic;

// Nomenclature en C#
// Tout est presque en PascalCase
// Sauf :
// Variables membres privees : private int _nomDeVariablePrive;
// Variables locales et parametre : int variableLocale;

// Les accolades vont sur une ligne séparée et non à la fin de la ligne

// Supprimer les éléments inutilisés, les fonctions vide et le code commenté

// Un fichier par classe
// Fonctionne quand même avec plusieurs fichiers par classe, sauf pour les MonoBehaviour
// Donc utile pour tester rapidement, mais déplacer avec Ctrl+. avant de commit

// Events
// Terminer les signatures de fonction delegate par Event
// public delegate void DamageEvent();
// public delegate void SleepEvent(Sleep sleep);

// Débuter par On pour les événemenrs ainsi que les fonctions connectées aux événements
// public DamageEvent OnDamage;
// public SleepEvent OnSleep;
// public void OnDamage() {}
// public void OnSleep(Sleep sleep) {}

// Ordre des membres de classe
class Nomenclature
{
    // Enum en premier, en ordre public/protected/private
    public enum Month
    {
        January,
        February,
        March,
        April,
        May,
        //...
    }

    protected enum ProtectedEnum { }

    private enum PrivateENum { }

    // Eviter les classes internes public, mettre dans un fichier Date.cs
    //public class Date
    //{
    //}

    // Classes internes private OK, permet de ne pas polluer le namespace
    private class DateCalculator
    {
        public Month Month;
        // ...
    }

    // Variables static en premier, en bloc selon public/protected/private
    public static List<int> DaysOfMonth = new List<int> { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
    public static int DaysOfWeek = 7;

    protected static string CalenderTitle = "CalenderApp";

    private static int Months = 12;
    private static int Weeks = 52;

    // Properties static, en bloc selon public/protected/private
    public static int StaticProperty1 { get; private set; }

    protected static int StaticProperty2 { get; private set; }

    private static int StaticProperty3 { get; set; }

    // Fonctions static selon public/protected/private
    public static void StaticFunction1() { }
    public static void StaticFunction2() { }
    public static void StaticFunction3() { }

    protected static void StaticFunction4() { }

    private static void StaticFunction5() { }
    private static void StaticFunction6() { }

    // Variables membres, en bloc selon public/protected/private
    public int Public1;
    public string Public2;
    public float Public3;

    protected int Protected1;

    private int _private1;
    private int _private2;

    // Properties en bloc selon public/protected/private
    public static int Property1 { get; private set; }

    protected static int Property2 { get; private set; }

    private static int Property3 { get; set; }

    // Fonctions selon public/protected/private
    public static void Function1() { }
    public static void Function2() { }
    public static void Function3() { }

    protected static void Function4() { }

    private static void Function5() { }
    private static void Function6() { }
}
