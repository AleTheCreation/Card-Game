using System.Collections;
using System.Collections.Generic;

namespace BattleCards;

public class GameRun
{
    public static Card[,] BBoard;
    public static Player PlayerInTurn { get; set; }

    public static Player PlayerOpposide { get; set; }

    public static Dictionary<Card, int> CardsInGame;



    public GameRun(Player playerInTurn, Player playerOpposide)
    {
        CardsInGame = new Dictionary<Card, int>();
        BBoard = new Card[5, 5];
        PlayerInTurn = playerInTurn;
        PlayerOpposide = playerOpposide;
    }


    public static void SystemGame(Player player, int turn, int index) 
    {
        
        bool temp = true;
        PassiveEffect();
        DeleteCard();

        KeyValuePair<Card, int> ACardInGame = new KeyValuePair<Card, int>(
            player.Hand[index],
            player.Hand[index].Id
        );
        if (!CardsInGame.Contains(ACardInGame))
            CardsInGame.Add(player.Hand[index], player.Hand[index].Id);
        player.PlayerM.Add(player.Hand[index]);
        player.Hand.Remove(player.Hand[index]);

        foreach (var item in ACardInGame.Key.Efectos)
        {
            item.effect(PlayerInTurn, PlayerOpposide);
        }

        

        
        

        if (turn % 2 != 0)
        {
            for (var i = 0; i < 2; i++)
            {
                for (var j = 0; j < BBoard.GetLength(1); j++)
                {
                    if (BBoard[i, j] == null)
                    {
                        BBoard[i, j] = player.PlayerM[player.PlayerM.Count - 1];
                        temp = false;
                        break;
                    }
                   
                    
                }
                if (temp == false)
                    break;
            }
        }
        else
        {
            for (var i = BBoard.GetLength(0) - 1; i > 2; i--)
            {
                for (var j = BBoard.GetLength(1) - 1; j >= 0; j--)
                {
                    if (BBoard[i, j] == null)
                    {
                        BBoard[i, j] = player.PlayerM[player.PlayerM.Count - 1];
                        temp = false;
                        break;
                    }
                    
                }
                if (temp == false)
                    break;
            }
        }
    }

    public static bool FinalCheck(Player player1, Player player2)
    {
        if (
            player1.RaundsWon == 3
            || player2.RaundsWon == 3
            || player1.Hand.Count == 0
            || player2.Hand.Count == 0
        )
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool CheckBoard(Player player, int turn)
    {
        bool temp = true;
        if (turn % 2 != 0)
        {
            for (var i = 0; i < 2; i++)
            {
                for (var j = 0; j < BBoard.GetLength(1); j++)
                {
                    if (BBoard[i, j] == null)
                    {
                        temp = false;
                        break;
                    }
                }
                if (temp == false)
                {
                    break;
                }
            }
        }
        else
        {
            for (var i = BBoard.GetLength(0) - 1; i > 2; i--)
            {
                for (var j = BBoard.GetLength(1) - 1; j >= 0; j--)
                {
                    if (BBoard[i, j] == null)
                    {
                        temp = false;
                        break;
                    }
                }
                if (temp == false)
                {
                    break;
                }
            }
        }

        return temp;
    }

    public static void PassiveEffect ()
    {
        for (var i = 0; i < BBoard.GetLength(0); i++)
        {
            for (var j = 0; j < BBoard.GetLength(1); j++)
            {
                if (BBoard[i, j] != null)
                {
                    if (BBoard[i, j].Passive && BBoard[i, j].Power > 0)
                    foreach (var item in BBoard[i, j].Efectos)
                    { 
                        item.effect(PlayerInTurn, PlayerOpposide);   
                    }
                }
            }
            
        }
    }
    public static void DeleteCard ()
    {
        for (var i = 0; i < BBoard.GetLength(0); i++)
        {
            for (var j = 0; j < BBoard.GetLength(1); j++)
            {
                if (BBoard[i, j] != null)
                {
                    if (BBoard[i, j].Power <= 0)
                    {
                        BBoard[i, j] = null;
                    }
                }
            }
            
        }
    }

    public static void GameRule(Player player1, Player player2)
    {
       


        GameRun.BBoard = new Card[5, 5];
        GameRun.CardsInGame.Clear();
        player1.PassRound = false;
        player2.PassRound = false;
        player1.Point(player1.PlayerM);
        player2.Point(player2.PlayerM);
        player1.PlayerM.Clear();
        player2.PlayerM.Clear();
        if (player1.TotalPoint == player2.TotalPoint)
        {
            player1.Update();
            player2.Update();
        }
        else if (player1.TotalPoint > player2.TotalPoint)
        {
            player1.RaundsWon++;
            player1.Update();
            player2.Update();
        }
        else if (player2.TotalPoint > player1.TotalPoint)
        {
            player2.RaundsWon++;
            player2.Update();
            player1.Update();
        }
    }

    #region DealingCards
    public static void Update(Player player)
    {
        if (player.Deck.Count == player.DeckSize)
        {
            Stuffle(player);
            for (var i = 0; i < player.HandSize; i++)
            {
                DrawCard(player);
            }
        }
        else
        {
            DrawCard(player);
        }
    }

    public static void Stuffle(Player player)
    {
        Random rnd = new Random();
        var AuxCard = new Card();
        for (var i = 0; i < player.Deck.Count; i++)
        {
            AuxCard = player.Deck[i];
            int RandomIndex = rnd.Next(0, player.Deck.Count);
            player.Deck[i] = player.Deck[RandomIndex];
            player.Deck[RandomIndex] = AuxCard;
        }
    }

    public static void DrawCard(Player player)
    {
        if (player.Deck.Count > 0)
        {
            player.Hand.Add(player.Deck[0]);
            player.Deck.RemoveAt(0);
        }
    }
    #endregion
}
