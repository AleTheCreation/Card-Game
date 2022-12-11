using System.Runtime.InteropServices;
using System.Linq;
namespace BattleCards
{
    public class Game
    {
        public Game()
        {
           Presentation();

        }
        static void Presentation()
        {
            System.Console.WriteLine("Bienvenido a BattleCards!");
            System.Console.WriteLine("Presione cualquier tecla para continuar...");
            System.Console.ReadKey();
            System.Console.Clear();
            System.Console.WriteLine("Hola, a continuacion podra seleccionar lo que desea hacer en el juego:");
            System.Console.WriteLine("1. Jugar ");
            System.Console.WriteLine("2. Salir");
            string option = System.Console.ReadLine();
            System.Console.Clear();
            if (option == "1")
            {
                System.Console.WriteLine("Desea jugar contra la computadora o contra otro jugador?");
                System.Console.WriteLine("1. Computadora");
                System.Console.WriteLine("2. Jugador");
                option = System.Console.ReadLine();
                System.Console.Clear();
                if(option=="2")
                {
                   StartGameVsPerson();
                }
                else if(option=="1")
                {
                    StartGameVsComputer();
                }
                else
                {
                    System.Console.WriteLine("Opcion invalida, presione cualquier tecla para volver al menu...");
                    System.Console.ReadKey();
                    System.Console.Clear();
                    Game game = new Game();
                }
               
            }
            else if (option == "2")
            {
                System.Console.WriteLine("Gracias por jugar!");
                System.Console.WriteLine("Presione cualquier tecla para salir...");
                System.Console.ReadKey();
                System.Console.Clear();
            }
            else
            {
                System.Console.WriteLine("Opcion invalida, presione cualquier tecla para volver al menu...");
                System.Console.ReadKey();
                System.Console.Clear();
                Game game = new Game();
            }
        }

       

        static void StartGameVsPerson()
        {
            System.Console.WriteLine("Ingrese el nombre del primer jugador:");
            string player1Name = System.Console.ReadLine();
            System.Console.Clear();
            System.Console.WriteLine("Ingrese el nombre del segundo jugador:");
            string player2Name = System.Console.ReadLine();
            System.Console.Clear();

            Player player1 = new Player(player1Name);
            Player player2 = new Player(player2Name);
            System.Console.WriteLine("Hola " + player1.GetName() + " y " + player2.GetName() + "! a continuacion se elegira al hazar quien comenzara el juego.");
            System.Console.WriteLine(player1.GetName() + " eliga cara o cruz:");
            string option = System.Console.ReadLine();
            System.Console.Clear();
            if (option == "cara" || option == "cruz")
            {
                option=CaraoCruz();
                if (option == "Cara")
                {
                    System.Console.WriteLine("El resultado fue cara!");
                    System.Console.WriteLine(player1.GetName() + " comenzara el juego!");
                    System.Console.WriteLine("Presione cualquier tecla para continuar...");
                    System.Console.ReadKey();
                    System.Console.Clear();
                    GameLoop(player1, player2);
                }
                else
                {
                    System.Console.WriteLine("El resultado fue cruz!");
                    System.Console.WriteLine(player2.GetName() + " comenzara el juego!");
                    System.Console.WriteLine("Presione cualquier tecla para continuar...");
                    System.Console.ReadKey();
                    System.Console.Clear();
                    GameLoop(player2, player1);
                }
            }
            else
            {
                System.Console.WriteLine("Opcion invalida, presione cualquier tecla para volver al menu...");
                System.Console.ReadKey();
                System.Console.Clear();
                Game game = new Game();
            }
            
            System.Console.WriteLine("Presione cualquier tecla para comenzar...");
            System.Console.ReadKey();
            System.Console.Clear();
        }
 static void StartGameVsComputer()
 {
    System.Console.WriteLine("Elija el adversario contra el que desea jugar");
    System.Console.Clear();
    Console.ForegroundColor = ConsoleColor.Red;
    System.Console.WriteLine("1. Writer_02");
    Console.ForegroundColor = ConsoleColor.Blue;
    System.Console.WriteLine("2. The_Creation");
    Console.ForegroundColor = ConsoleColor.Green;
    System.Console.WriteLine("3. Artagos");
    Console.ForegroundColor = ConsoleColor.White;
 }

 static string CaraoCruz()
 {
Random rnd = new Random();
                int coin = rnd.Next(0, 2);
                if (coin == 0)
                {
                    return "cara";
                }
                else
                {
                    return "cruz";
                }
 }
        static void GameLoop(Player player1, Player player2)
        {
            System.Console.WriteLine("Turno de " + player1.GetName());
            Board board = new Board();
            board.BoardInfo(player1, player2);
   //         board.PrintBoard();
            
            System.Console.WriteLine("Presione cualquier tecla para continuar...");
            System.Console.ReadKey();
            System.Console.Clear();
            System.Console.WriteLine("Turno de " + player2.GetName());
            System.Console.WriteLine("Presione cualquier tecla para continuar...");
            System.Console.ReadKey();
            System.Console.Clear();
            GameLoop(player1, player2);

        }
        static void GameRule()
        {

        }
        static bool EndTurn()
        {
            
          return true;
        }
    }
}