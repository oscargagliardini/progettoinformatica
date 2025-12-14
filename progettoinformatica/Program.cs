// See https://aka.ms/new-console-template for more information
namespace Progettoterradimezzo;
internal class Program
{
    static int lanciodado(){
        Random dado = new Random();
        return dado.Next(1,4);
    }

    static int vitaagg(int vita, int danno){
        vita = vita - danno;
        return vita;
    }

    static int sceltapersonaggio(){
        Console.WriteLine("Scegli il tuo personaggio (1, 2 o 3): ");
        int scelta = Convert.ToInt32(Console.ReadLine());
        return scelta;
    }

    static int statuspersonaggio(int vita, int fortuna, int forza){
        Console.WriteLine("Il tuo personaggio ha");
        Console.WriteLine("Vita "+ vita);
        Console.WriteLine("Fortuna "+ fortuna);
        Console.WriteLine("Forza "+ forza);
        return 0;
    }

    private static void Main(string[] args)
    {
        Console.WriteLine("Benvenuto nel Gioco dello Hobbit!");
        Console.WriteLine("regole del gioco: ...");
        Console.WriteLine("potrai scegliere tra 3 personaggi: 1. Gandalf(+50 vita) 2. Frodo(+10 fortuna) 3. Aragorn(+20 forza)");
        int scelta = sceltapersonaggio();
        // In base alla scelta del personaggio, puoi modificare le statistiche iniziali
        int vita = 100;
        int fortuna =10;
        int forza=30;


        string[] Mappa = {
          "La Contea", "Brea", "Bosco Vetusto", "Colle Vento", "Fiume Brandivino",
          "Eriador", "Valle di Roncitosso", "Gran Burrone", "Lothlórien", 
          "Passo di Caradhras", "Anduin", "Amon Hen", "Moria", "Isengard", 
           "Gondor", "Minas Tirith", "Fosso di Helm", "Cirith Ungol", 
            "Cancello Nero", "Monte Fato" 
        };

        while(vita > 0){
            if(scelta == 1){
                vita += 50;
            } else if (scelta == 2){
                fortuna += 10;
            } else if (scelta == 3){
                forza += 20;
            }
            
            Console.WriteLine("Premi invio per lanciare il dado e avanzare nella mappa.");
            Console.ReadLine();
            int avanzamento = lanciodado();
            Console.WriteLine("Hai lanciato il dado e avanzato di {avanzamento} posizioni.");

           
        }

    }
}
