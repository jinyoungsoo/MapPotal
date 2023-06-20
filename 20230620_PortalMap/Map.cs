using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace _20230620_PortalMap
{
    public class Map
    {
        public int boardSize; 
        public int posX; 
        public int posY; 
        public bool portal; 

        public bool firstMap; 
        public bool secondMap; 

        public void MapBoard()
        {
            boardSize = 15; 
            portal = true; // 포탈 생성 여부 초기화

            Player(); 

            while (true) // 루프
            {
                Console.Clear(); 
                PrintBoard(); 

                ConsoleKeyInfo userInput;
                userInput = Console.ReadKey(true); // 사용자 입력을 받는다.

                switch (userInput.Key) 
                {
                    case ConsoleKey.W:
                        MovePlayer(0, -1);
                        break;
                    case ConsoleKey.A:
                        MovePlayer(-1, 0); 
                        break;
                    case ConsoleKey.S:
                        MovePlayer(0, 1); 
                        break;
                    case ConsoleKey.D:
                        MovePlayer(1, 0); 
                        break;
                }
            }
        }

        public void Player()
        {
            posX = boardSize / 2; // 플레이어를 맵의 가운데에 배치
            posY = boardSize / 2;

            firstMap = true;       //처음 맵에서 시작
            secondMap = false;
        }

        public void PrintBoard()
        {
            for (int y = 0; y < boardSize; y++)
            {
                for (int x = 0; x < boardSize; x++)
                {
                    if (x == posX && y == posY)
                    {
                        Console.Write("△"); // 플레이어 위치에 △ 표시
                    }
                    else if ((x == 14 && y == 7 && portal && firstMap) || (x == 0 && y == 7 && !portal && secondMap))
                    {
                        Console.Write("♨"); // 포탈 위치에 ♨ 표시
                    }
                    else
                    {
                        Console.Write("□"); // 빈 공간 표시
                    }
                }
                Console.WriteLine();
            }
        }

        public void MovePlayer(int offsetX, int offsetY)
        {
            int newPosX = posX + offsetX; 
            int newPosY = posY + offsetY; 

            if (Move(newPosX, newPosY)) // 이동이 유효한지 확인
            {
                posX = newPosX; 
                posY = newPosY;

                if (firstMap && PortalArea(newPosX, newPosY)) // 첫 번째 맵에서 포탈에 진입하는지 확인
                {
                    MapPortal(); 
                }
                else if (secondMap && (newPosX == 0 && newPosY == 7)) // 두 번째 맵에서 포탈에 진입하는지 확인
                {
                    MapPortal();
                }
            }
        }

        private bool Move(int x, int y)
        {
            return x >= 0 && x < boardSize && y >= 0 && y < boardSize; // 좌표가 유효한 범위 내에 있는지 확인
        }

        public bool PortalArea(int x, int y)
        {
            return (x == 14 && y == 7 && portal && firstMap) || (x == 0 && y == 7 && !portal && secondMap);
            // 첫 번째 맵에서는 (14, 7)에 포탈이 있을 때 진입 가능
            // 두 번째 맵에서는 (0, 7)에 포탈이 없을 때 진입 가능
        }

        public void MapPortal()
        {
            Console.WriteLine("포탈에 진입 중...");
            

            Console.ReadKey();

            if (firstMap) // 첫 번째 맵에서 포탈에 진입할 때
            {
                posX = 1; 
                posY = 7;
                portal = false; // 첫 번째 맵의 포탈 제거
                firstMap = false; // 첫 번째 맵 상태 변경
                secondMap = true; // 두 번째 맵 상태 변경
            }
            else if (secondMap) // 두 번째 맵에서 포탈에 진입할 때
            {
                posX = 13; 
                posY = 7;
                portal = true; // 두 번째 맵의 포탈 생성
                firstMap = true; // 첫 번째 맵 상태 변경
                secondMap = false; // 두 번째 맵 상태 변경
            }
        }
    }
}