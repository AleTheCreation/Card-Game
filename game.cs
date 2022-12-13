using System.Runtime.InteropServices;
using System.Linq;
namespace BattleCards
{
    public class Game
    {
        public Game() //juego
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
            ConsoleKey option = Console.ReadKey().Key;
            System.Console.Clear();
            if (option == ConsoleKey.D1 )
            {
                System.Console.WriteLine("Desea jugar contra la computadora o contra otro jugador?");
                System.Console.WriteLine("1. Computadora");
                System.Console.WriteLine("2. Jugador");
                ConsoleKeyInfo option2 = Console.ReadKey();
                System.Console.Clear();
                if(option2.KeyChar=='2')
                {
                   StartGameVsPerson();
                }
                else if(option2.KeyChar=='1')
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
            else if (option == ConsoleKey.D2)
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
            string player1Name = System.Console.ReadLine().Trim();
            System.Console.Clear();
            System.Console.WriteLine("Ingrese el nombre del segundo jugador:");
            string player2Name = System.Console.ReadLine().Trim();
            System.Console.Clear();
            Player player1 = new Player(player1Name);
            Player player2 = new Player(player2Name);
            System.Console.WriteLine("Hola " + player1.GetName() + " y " + player2.GetName() + "! a continuacion se elegira al hazar quien comenzara el juego.");
            System.Console.WriteLine(player1.GetName() + " eliga cara o cruz:");
            System.Console.WriteLine("1. Cara");
            System.Console.WriteLine("2. Cruz");
            ConsoleKey option = Console.ReadKey().Key;
            System.Console.Clear();
            if (option == ConsoleKey.D1 || option == ConsoleKey.D2)
            {
               string moneda=CaraoCruz();
                if (moneda == "Cara")
                {
                    System.Console.WriteLine("El resultado fue cara!");
                    System.Console.WriteLine(player1.GetName() + " comenzara el juego!");
                 
                    System.Console.WriteLine("Presione cualquier tecla para continuar...");
                    System.Console.ReadKey();
                    System.Console.Clear();
                    GameLoop(player1, player2, 1);
                }
                else
                {
                    System.Console.WriteLine("El resultado fue cruz!");
                    System.Console.WriteLine(player2.GetName() + " comenzara el juego!");
                   
                    System.Console.WriteLine("Presione cualquier tecla para continuar...");
                    System.Console.ReadKey();
                    System.Console.Clear();
                    GameLoop(player2, player1, 1);
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

   static void SystemGame(Player player, int turn, int id, Player player1, Player player2)
        {
            player.Update();  // En cada turno repartir carta en cada turno
            bool temp = true;
            var dic = new Dictionary<Card, int>();
            if(turn == 1)
            {  
             System.Console.WriteLine(player.GetName()+ " Ha recibido 5 cartas, elija cual desea jugar");}
                    for(int i=0; i< player.GetHand();i++) // imprime las cartas en mano del jugador que este jugando
                    {
                        dic.Add(player.GetHands()[i], i+1);
                        System.Console.WriteLine(i+1+". "+ player.GetHands()[i].Name+": "+player.GetHands()[i].Description +", Power: " +player.GetHands()[i].Power+", Faction: "+player.GetHands()[i].Faction);
                    }
                    Board board = new Board(player1, player2);
                    ConsoleKeyInfo option = Console.ReadKey();
            //Se activa la carta jugada en el campo y se remueve de la mano
            if(id == 1){
                
                int index = (48 - ((int)option.Key))*(-1); //Esto lo puse asi xq el option me da x ejemplo 49 '1' y no vi otra via pa hacerlo si quieres modifica
                
                for (var i = 0; i < 2; i++)
                {
                    for (var j = 0; j < Board.board.GetLength(1); j++)
                    {
                        if (Board.board[i, j] == "[  ]")
                        {
                            Board.board[i ,j] = "[" + player.GetHands()[index].Id.ToString() + "]";
                            Board.CardsInGame.Add(player.GetHands()[index], player.GetHands()[index].Id);
                            player.Hand.Remove(player.GetHands()[index]);
                            temp = false;
                            break;
                            
                        }
                    }
                    if(temp == false){
                        break;
                    }

                    
                }

            }
            else if(id == 2){
                
                int index = (48 - ((int)option.Key))*(-1);
                for (var i = Board.board.GetLength(0)-1; i > 2; i--)
                {
                    for (var j = Board.board.GetLength(1)-1; j >= 0; j--)
                    {
                        if (Board.board[i, j] == "[  ]")
                        {
                            Board.board[i ,j] = "[" + player.GetHands()[index].Id.ToString() + "]";
                            Board.CardsInGame.Add(player.GetHands()[index], player.GetHands()[index].Id);
                            player.Hand.Remove(player.GetHands()[index]);
                            temp = false;
                            break;
                            
                        }
                    }
                    if(temp == false){
                        break;
                    }

                    
                }

            }
            else{
                System.Console.WriteLine("Opcion invalida, presione cualquier tecla para volver al menu...");
                System.Console.ReadKey();
                System.Console.Clear();
                Game game = new Game();
            }
            Board board2 = new Board(player1, player2);

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
        static void GameLoop(Player player1, Player player2, int turn)
        {
       //     if(EndGame(player1, player2)) return;


            System.Console.WriteLine("Turno de " + player1.GetName());
           // Board board = new Board();
           // board.BoardInfo(player1, player2);
            SystemGame(player1, turn, 1, player1, player2);
            
            System.Console.WriteLine("Presione cualquier tecla para continuar...");
            System.Console.ReadKey();
            System.Console.Clear();
            System.Console.WriteLine("Turno de " + player2.GetName());
            SystemGame(player2, turn, 2, player1, player2);
            System.Console.WriteLine("Presione cualquier tecla para continuar...");
            System.Console.ReadKey();
            System.Console.Clear();
            GameLoop(player1, player2, turn++);

        }
        static void GameRule()
        {
            

        }
        // static bool EndGame(Player player1, Player player2) //MODIFICA TO ESTO
        // {
            // if(player1.GetLife()==0)
            // {
            //     System.Console.WriteLine(player2.GetName() + " ha ganado!");
            //     System.Console.WriteLine("Presione cualquier tecla para volver al menu...");
            //     System.Console.ReadKey();
            //     System.Console.Clear();
            //     Game game = new Game();
            //     return true;
            // }
            // else if(player2.GetLife()==0)
            // {
            //     System.Console.WriteLine(player1.GetName() + " ha ganado!");
            //     System.Console.WriteLine("Presione cualquier tecla para volver al menu...");
            //     System.Console.ReadKey();
            //     System.Console.Clear();
            //     Game game = new Game();
            //     return true;
            // }

            // else if (player1.GetDeckCount() == 0 && player1.GetHand() == 0)
            // {
            //     if (player1.GetLife() > player2.GetLife())
            //     {
            //         System.Console.WriteLine(player1.GetName() + " ha ganado!");
            //         System.Console.WriteLine("Presione cualquier tecla para volver al menu...");
            //         System.Console.ReadKey();
            //         System.Console.Clear();
            //         Game game = new Game();
            //         return true;
            //     }
            //     else if (player1.GetLife() < player2.GetLife())
            //     {
            //         System.Console.WriteLine(player2.GetName() + " ha ganado!");
            //         System.Console.WriteLine("Presione cualquier tecla para volver al menu...");
            //         System.Console.ReadKey();
            //         System.Console.Clear();
            //         Game game = new Game();
            //         return true;
            //     }
            //     else
            //     {
            //         System.Console.WriteLine("Empate!");
            //         System.Console.WriteLine("Presione cualquier tecla para volver al menu...");
            //         System.Console.ReadKey();
            //         System.Console.Clear();
            //         Game game = new Game();
            //         return true;
            //     }

        //     }
        //   return false;
       // }
    }
}