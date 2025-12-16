using System.Data;
using System.Runtime.Remoting;
using Microsoft.VisualBasic;

internal class Program
{
        static int lanciodado()
        {
            Random dado = new Random();
            return dado.Next(1, 4);
        }

        static int vitaagg(int vita, int danno)
        {
            vita = vita - danno;
            return vita;
        }

        static int sceltapersonaggio()
        {
            Console.WriteLine("Scegli il tuo personaggio (1, 2 o 3): ");
            int scelta = Convert.ToInt32(Console.ReadLine());
            return scelta;
        }

        static int statuspersonaggio(int vita, int fortuna, int forza,int denaro)
        {
            Console.WriteLine("Il tuo personaggio ha");
            Console.WriteLine("Vita " + vita);
            Console.WriteLine("Fortuna " + fortuna);
            Console.WriteLine("Forza " + forza);
            Console.WriteLine("Denaro " + denaro);
            return 0;
        }

        static int avanzamentomappa(int posizione, int avanzamento,bool vc)
        {
            if (vc=true)
            {
                avanzamento = avanzamento + 1;
            }
            posizione = posizione + avanzamento;
            return posizione;
        }

        static int sceltaevento(int posizione,int fortuna)
        {
            


             int probabilitamostro = new Random().Next(30, 80);
             if (posizione<=7)
             {
                 probabilitamostro = probabilitamostro - (fortuna  +10);
             }
             else if (posizione<=14)
             {
                 probabilitamostro = probabilitamostro-(fortuna / 2 +5); ;
             }
             else
             {
                 probabilitamostro = probabilitamostro - (fortuna / 2);
             }
             if (probabilitamostro>60){
                 Console.WriteLine("Hai incontrato un mostro!");
                 return 1;
             }
             else
             {
                 Console.WriteLine("Hai incontrato una missione secondaria!");
                 return 2;
             }
        

        
        }
        
        

        static void Main(string[] args)
        {
            Console.WriteLine("Benvenuto nel Gioco dello Hobbit!");
            Console.WriteLine("regole del gioco: ...");
            Console.WriteLine("potrai scegliere tra 3 personaggi: 1. Gandalf(+50 vita) 2. Frodo(+10 fortuna e +10 denaro) 3. Aragorn(+20 forza)");
            int scelta = sceltapersonaggio();
            Console.WriteLine("all inizio avrai delle statistiche base: 100 vita, 10 fortuna, 30 forza e 25 denaro che dovrai gestire per arrivare alla fine del gioco");
            Console.WriteLine("dovrai lanciare un dado per avanzare nella mappa e in base alla tua posizione e fortuna  potrai incontrare mostri oppure missioni secondarie da cui puoi trarre benefici comprare oggetti per migliorare le tue statistiche");
            Console.WriteLine("l'obiettivo e arrivare al Monte Fato senza che la tua vita scenda a zero buona fortuna!");
            // In base alla scelta del personaggio, puoi modificare le statistiche iniziali
            int vita = 100;
            int fortuna = 10;
            int forza = 30;
            int denaro = 25;


            string[] Mappa = {
          "La Contea", "Brea", "Bosco Vetusto", "Colle Vento", "Fiume Brandivino",
          "Eriador", "Valle di Roncitosso", "Gran Burrone", "Lothlórien",
          "Passo di Caradhras", "Anduin", "Amon Hen", "Moria", "Isengard",
           "Gondor", "Minas Tirith", "Fosso di Helm", "Cirith Ungol",
            "Cancello Nero", "Monte Fato"
            };
            int posizione = 0;
            int tn=0;
            while (vita > 0)
            {
                tn++;
                
                if (scelta == 1)
                {
                    vita = vita + 50;
                }
                else if (scelta == 2)
                {
                    fortuna = fortuna + 10;
                    denaro = denaro + 10;

                }
                else if (scelta == 3)
                {
                    forza = forza + 20;
                }


                for (int i = 0; i < Mappa.Length; i++)
                {
                    Console.WriteLine("Turno numero: " + tn);
                    Console.WriteLine("vuoi vedere lo status del tuo personaggio? (si/no)");
                    string rispostaStatus = Console.ReadLine();
                    if (rispostaStatus == "si")
                    {
                        statuspersonaggio(vita, fortuna, forza,denaro);
                    }

                    Console.WriteLine("Premi invio per lanciare il dado e avanzare nella mappa.");
                    Console.ReadLine();
                    int avanzamento = lanciodado();
                    Console.WriteLine("Hai lanciato il dado e avanzato di " + avanzamento + " posizioni.");
                    bool vc=false;
                    posizione = avanzamentomappa(posizione, avanzamento,vc);
                    Console.WriteLine("Sei ora a: " + Mappa[posizione]);

                    if (posizione <= 7)
                    {
                        Console.WriteLine("ti trovi nella regione di Eriador , la probabilita di incontrare mostri potenti e bassa ed e molto famosa per le sue pozioni magiche che aumentano la fortuna vuoi  comprarne una? (si/no)");
                        string risposta = Console.ReadLine();
                        if (risposta == "si")
                        {
                            if (denaro >= 5)
                            {
                                denaro = denaro - 5;
                                int pozione = new Random().Next(1, 11);

                                fortuna = fortuna + pozione;
                                Console.WriteLine("Hai acquistato una pozione che aumenta la tua fortuna di " + pozione + " punti. La tua fortuna ora e di " + fortuna + " punti.");
                            }
                            else
                            {
                                Console.WriteLine("Non hai abbastanza denaro per comprare la pozione.");
                            }
                        }
                        int evento = sceltaevento(posizione, fortuna);
                        if (evento == 1){

                            Console.WriteLine("oh,no hai trovato un grifone nel tuo cammino devi combatterlo" );
                            Console.WriteLine(
                                ""
                            );
                            int danno = new Random().Next(20, 29);
                            int dannoSubito = danno - (forza / 10);
                            if (dannoSubito < 0)
                            {dannoSubito = 0;
                            }
                            vita = vitaagg(vita, dannoSubito);
                            Console.WriteLine("Hai subito " + dannoSubito + " punti di danno. La tua vita ora e di " + vita + " punti.");


                        }
                        else if (evento == 2)
                        {
                            Console.WriteLine("hai trovato una missione secondaria che ti fara guadagnare denaro e vita");
                            Console.WriteLine("completando la missione guadagnerai una ricompensa");
                            Console.WriteLine("dovrai aiutare un elfo a trovare il suo anello perduto");
                            int esitoMissione = new Random().Next(1, 11);
                            if (esitoMissione + fortuna / 10 > 8)
                            {
                                Console.WriteLine("Hai completato con successo la missione!");
                            int ricompensaDenaro = new Random().Next(5, 16);
                            int ricompensaVita = new Random().Next(10, 31);
                            denaro = denaro + ricompensaDenaro;
                            vita = vita + ricompensaVita;
                            Console.WriteLine("Hai guadagnato " + ricompensaDenaro + " denaro e " + ricompensaVita + " punti vita.");
                            }
                            else
                            {
                                Console.WriteLine("Non sei riuscito a completare la missione.");
                        }

                    }
                        
                    
                    
                        
                    }
                    if (posizione <= 10)
                    {
                        Console.WriteLine("ti trovi nella regione di Rohan , la probabilita di incontrare mostri potenti e media ed e molto famosa per le sue armi che aumentano la forza vuoi  comprarne una? (si/no)");
                        string risposta = Console.ReadLine();
                        if (risposta == "si")
                        {
                            if (denaro >= 10)
                            {
                                denaro = denaro - 10;
                                int arma = new Random().Next(1, 11);

                                forza = forza + arma;
                                Console.WriteLine("Hai acquistato un'arma che aumenta la tua forza di " + arma + " punti. La tua forza ora e di " + forza + " punti.");
                            }
                            else
                            {
                                Console.WriteLine("Non hai abbastanza denaro per comprare l'arma.");
                            }
                        }
                        Console.WriteLine("puoi comprare anche un cavallo per 15 di denaro che ti fara aumenta le caselle di avanzamento del dado di 1 vuoi comprarne uno? (si/no)");
                        Console.WriteLine(          "      .''
                                               "  ._.-.___.' (`\
                                                //(         ( `'.      
                                        "     '/ )\ ).__. )          "
                                         "   ' <' `\ ._ / '\.       "
                                         "        `   \     \".          "
                        )
                        string rispostaCavallo = Console.ReadLine();
                        if (rispostaCavallo == "si")
                        {
                            if (denaro >= 15)
                            {
                                denaro = denaro - 15;
                                Console.WriteLine("Hai acquistato un cavallo! Ogni volta che lancerai il dado, avanzerai di 1 posizione in piu.");
                                
                                vc=true;
                            }
                            else
                            {
                                Console.WriteLine("Non hai abbastanza denaro per comprare il cavallo.");
                            }
                        }
                        int evento = sceltaevento(posizione, fortuna);
                        if (evento == 1)
                        {
                            Console.WriteLine("oh,no hai trovato un troll nel tuo cammino devi combatterlo");
                            Console.WriteLine("");
                            int danno = new Random().Next(30, 39);
                            int dannoSubito = danno - (forza / 10);
                            if (dannoSubito < 0)
                            {dannoSubito = 0;
                            }
                            vita = vitaagg(vita, dannoSubito);
                            Console.WriteLine("Hai subito " + dannoSubito + " punti di danno. La tua vita ora e di " + vita + " punti.");
                        }
                        else if (evento == 2)
                        {
                            Console.WriteLine("hai trovato una missione secondaria che ti fara guadagnare denaro e forza");
                            Console.WriteLine("completando la missione guadagnerai una ricompensa");
                            Console.WriteLine("dovrai aiutare un nano a difendere la sua miniera dagli orchi");
                            Console.WriteLine("");
                            int esitoMissione = new Random().Next(1, 11);
                            if (esitoMissione + forza / 10 > 8)
                            {
                                Console.WriteLine("Hai completato con successo la missione!");
                                int ricompensaDenaro = new Random().Next(10, 21);
                                int ricompensavita = new Random().Next(5, 16);
                                denaro = denaro + ricompensaDenaro;
                                vita = vita + ricompensavita;
                                Console.WriteLine("Hai guadagnato " + ricompensaDenaro + " denaro e " + ricompensaForza + " punti forza.");
                            }
                            else
                            {
                                Console.WriteLine("Non sei riuscito a completare la missione.");
                            }

                        }

                    }
                    if (posizione <= 17)
                    {
                        Console.WriteLine("ti trovi nella regione di Gondor , la probabilita di incontrare mostri potenti e alta ed e molto famosa per le sue armature che aumentano la vita vuoi  comprarne una? (si/no)");
                        string risposta = Console.ReadLine();
                        if (risposta == "si")
                        {
                            if (denaro >= 15)
                            {
                                denaro = denaro - 15;
                                int armatura = new Random().Next(1, 21);

                                vita = vita + armatura;
                                Console.WriteLine("Hai acquistato un'armatura che aumenta la tua vita di " + armatura + " punti. La tua vita ora e di " + vita + " punti.");
                            }
                            else
                            {
                                Console.WriteLine("Non hai abbastanza denaro per comprare l'armatura.");
                            }
                        }
                          int evento = sceltaevento(posizione, fortuna);
                          if(evento == 1)
                          {
                              Console.WriteLine("oh,no hai trovato un lupo alpha  nel tuo cammino devi combatterlo");
                              Console.WriteLine("");
                              int danno = new Random().Next(35, 49);
                              int dannoSubito = danno - (forza / 10);
                              if (dannoSubito < 0)
                              {dannoSubito = 0;
                              }
                              vita = vitaagg(vita, dannoSubito);
                              Console.WriteLine("Hai subito " + dannoSubito + " punti di danno. La tua vita ora e di " + vita + " punti.");
                          }
                          else if (evento == 2)
                          {
                              Console.WriteLine("hai trovato una missione secondaria che ti fara guadagnare denaro e forza");
                              Console.WriteLine("completando la missione guadagnerai una ricompensa");
                              Console.WriteLine("dovrai aiutare un guerriero a difendere la sua citta dagli assalitori");
                              Console.WriteLine("");
                              int esitoMissione = new Random().Next(1, 11);
                              if (esitoMissione + forza / 10 > 8)
                              {
                                  Console.WriteLine("Hai completato con successo la missione!");
                                  int ricompensaDenaro = new Random().Next(15, 26);
                                  int ricompensaForza = new Random().Next(10, 21);
                                  denaro = denaro + ricompensaDenaro;
                                  forza = forza + ricompensaForza;
                                  Console.WriteLine("Hai guadagnato " + ricompensaDenaro + " denaro e " + ricompensaForza + " punti forza.");
                              }
                              else
                              {
                                  Console.WriteLine("Non sei riuscito a completare la missione.");
                              }

                          }

                    }
                    if(posizione==18)
                    {
                        Console.WriteLine("ti trovi vicino al Monte Fato , la probabilita di incontrare mostri potenti e altissima preparati per l'ultimo scontro!");
                        Console.WriteLine("oh,no hai trovato il Drago finale nel tuo cammino devi combatterlo");
                        Console.WriteLine("
                        
                        
                                     __        _
                                                _/  \    _(\(o
                                               /     \  /  _  ^^^o
                                              /   !   \/  ! '!!!v'
                                              !  !  \ _' ( \____
                                              ! . \ _!\   \===^\)
                                             \ \_!  / __!
                                                \!   /    \
                                                (\_      _/   _\ )
                                                  \ ^^--^^ __-^ /(__
                                                   ^^----^^    "^--v'
                        
                        )
                        int danno = new Random().Next(40, 59);
                        int dannoSubito = danno - (forza / 10);
                        if (dannoSubito < 0)
                        {dannoSubito = 0;
                        }
                        vita = vitaagg(vita, dannoSubito);
                        Console.WriteLine("Hai subito " + dannoSubito + " punti di danno. La tua vita ora e di " + vita + " punti.");

                    }
                    if (posizione == Mappa.Length - 1)
                    {
                        Console.WriteLine("Congratulazioni! Hai raggiunto il Monte Fato e completato il gioco!");
                        break;
                    }


                }

            }
            Console.WriteLine("Game Over! La tua vita e scesa a zero.");
        }
}

