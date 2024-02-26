using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using devDept.Eyeshot;
using devDept.Eyeshot.Control;
using devDept.Eyeshot.Entities;
using devDept.Geometry;

namespace SampleEyeShot
{
    class OmokRule
    {
        //승리 및 장목 검사
        public int CheckEggNum(Mesh board, Design design)
        {
            List<Entity> eggList = design.Entities.Where(x => x.EntityData == "Black" || x.EntityData == "White").ToList();

            int count = 0;

            bool checkBlink = false;
            bool checkEnemy = false;

            // 가로 검사
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 0; j < eggList.Count(); j++)
                {
                    if (Math.Round(design.Entities.Last().BoxMax.X - ((board.BoxMax.X / 18) * i)) == Math.Round(eggList[j].BoxMax.X)
                        && design.Entities.Last().BoxMax.Y == eggList[j].BoxMax.Y)
                    {
                        if (design.Entities.Last().EntityData == eggList[j].EntityData)
                        {
                            checkBlink = false;
                            count++;
                            break;
                        }
                        else
                        {
                            checkEnemy = true;
                            break;
                        }
                    }
                    else
                        checkBlink = true;
                }
                if (checkBlink == true || checkEnemy == true)
                    break;
            }

            checkBlink = false;
            checkEnemy = false;

            for(int i = 1; i <= 4; i++)
            {
                for (int j = 0; j < eggList.Count(); j++)
                {
                    if (Math.Round(design.Entities.Last().BoxMax.X + ((board.BoxMax.X / 18) * i)) == Math.Round(eggList[j].BoxMax.X)
                        && design.Entities.Last().BoxMax.Y == eggList[j].BoxMax.Y)
                    {
                        if (design.Entities.Last().EntityData == eggList[j].EntityData)
                        {
                            checkBlink = false;
                            count++;
                            break;
                        }
                        else
                        {
                            checkEnemy = true;
                            break;
                        }
                    }
                    else
                        checkBlink = true;
                }
                if (checkBlink == true || checkEnemy == true)
                    break;
            }
            if (count == 4)
            {
                return 0;
            }
            else if(count >= 5)
            {
                return 1;
            }
            count = 0;
            checkBlink = false;
            checkEnemy = false;

            // 세로 검사
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 0; j < eggList.Count(); j++)
                {
                    if (Math.Round(design.Entities.Last().BoxMax.Y - ((board.BoxMax.Y / 18) * i)) == Math.Round(eggList[j].BoxMax.Y)
                        && design.Entities.Last().BoxMax.X == eggList[j].BoxMax.X)
                    {
                        if (design.Entities.Last().EntityData == eggList[j].EntityData)
                        {
                            checkBlink = false;
                            count++;
                            break;
                        }
                        else
                        {
                            checkEnemy = true;
                            break;
                        }
                    }
                    else
                        checkBlink = true;
                }
                if (checkBlink == true || checkEnemy == true)
                    break;
            }

            checkBlink = false;
            checkEnemy = false;

            for (int i = 1; i <= 4; i++)
            {
                for (int j = 0; j < eggList.Count(); j++)
                {
                    if (Math.Round(design.Entities.Last().BoxMax.Y + ((board.BoxMax.Y / 18) * i)) == Math.Round(eggList[j].BoxMax.Y)
                        && design.Entities.Last().BoxMax.X == eggList[j].BoxMax.X)
                    {
                        if (design.Entities.Last().EntityData == eggList[j].EntityData)
                        {
                            checkBlink = false;
                            count++;
                            break;
                        }
                        else
                        {
                            checkEnemy = true;
                            break;
                        }
                    }
                    else
                        checkBlink = true;
                }
                if (checkBlink == true || checkEnemy == true)
                    break;
            }

            if (count == 4)
            {
                return 0;
            }
            else if(count >= 5)
            {
                return 1;
            }
            count = 0;
            checkBlink = false;
            checkEnemy = false;

            // 우상향 대각 검사
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 0; j < eggList.Count(); j++)
                {
                    if (Math.Round(design.Entities.Last().BoxMax.X + ((board.BoxMax.X / 18) * i)) == Math.Round(eggList[j].BoxMax.X)
                        && Math.Round(design.Entities.Last().BoxMax.Y + ((board.BoxMax.Y / 18) * i)) == Math.Round(eggList[j].BoxMax.Y))
                    {
                        if (design.Entities.Last().EntityData == eggList[j].EntityData)
                        {
                            checkBlink = false;
                            count++;
                            break;
                        }
                        else
                        {
                            checkEnemy = true;
                            break;
                        }
                    }
                    else
                        checkBlink = true;
                }
                if (checkBlink == true || checkEnemy == true)
                    break;
            }

            checkBlink = false;
            checkEnemy = false;

            for (int i = 1; i <= 4; i++)
            {
                for (int j = 0; j < eggList.Count(); j++)
                {
                    if (Math.Round(design.Entities.Last().BoxMax.X - ((board.BoxMax.X / 18) * i)) == Math.Round(eggList[j].BoxMax.X)
                        && Math.Round(design.Entities.Last().BoxMax.Y - ((board.BoxMax.Y / 18) * i)) == Math.Round(eggList[j].BoxMax.Y))
                    {
                        if (design.Entities.Last().EntityData == eggList[j].EntityData)
                        {
                            checkBlink = false;
                            count++;
                            break;
                        }
                        else
                        {
                            checkEnemy = true;
                            break;
                        }
                    }
                    else
                        checkBlink = true;
                }
                if (checkBlink == true || checkEnemy == true)
                    break;
            }

            if (count == 4)
            {
                return 0;
            }
            else if(count >= 5)
            {
                return 1;
            }
            count = 0;
            checkBlink = false;
            checkEnemy = false;

            // 우하향 대각 검사
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 0; j < eggList.Count(); j++)
                {
                    if (Math.Round(design.Entities.Last().BoxMax.Y - ((board.BoxMax.Y / 18) * i)) == Math.Round(eggList[j].BoxMax.Y)
                        && Math.Round(design.Entities.Last().BoxMax.X + ((board.BoxMax.X / 18) * i)) == Math.Round(eggList[j].BoxMax.X))
                    {
                        if (design.Entities.Last().EntityData == eggList[j].EntityData)
                        {
                            checkBlink = false;
                            count++;
                            break;
                        }
                        else
                        {
                            checkEnemy = true;
                            break;
                        }
                    }
                    else
                        checkBlink = true;
                }
                if (checkBlink == true || checkEnemy == true)
                    break;
            }

            checkBlink = false;
            checkEnemy = false;

            for (int i = 1; i <= 4; i++)
            {
                for (int j = 0; j < eggList.Count(); j++)
                {
                    if (Math.Round(design.Entities.Last().BoxMax.Y + ((board.BoxMax.Y / 18) * i)) == Math.Round(eggList[j].BoxMax.Y)
                        && Math.Round(design.Entities.Last().BoxMax.X - ((board.BoxMax.X / 18) * i)) == Math.Round(eggList[j].BoxMax.X))
                    {
                        if (design.Entities.Last().EntityData == eggList[j].EntityData)
                        {
                            checkBlink = false;
                            count++;
                            break;
                        }
                        else
                        {
                            checkEnemy = true;
                            break;
                        }
                    }
                    else
                        checkBlink = true;
                }
                if (checkBlink == true || checkEnemy == true)
                    break;
            }

            if (count == 4)
            {
                return 0;
            }
            else if(count >= 5)
            {
                return 1;
            }
            count = 0;
            checkBlink = false;
            checkEnemy = false;

            return 2;
        }

        // 흑돌 3-3 검사
        public bool CheckDouble3(Mesh board, Design design)
        {
            int doubleThreeCount = 0;
            doubleThreeCount += FindThreeWidth(board, design);
            doubleThreeCount += FindThreeLength(board, design);
            doubleThreeCount += FindThreeDiagonalUpwardRight(board, design);
            doubleThreeCount += FindThreeDiagonalDownwardRight(board, design);
            
            if(doubleThreeCount >= 2)
            {
                return true;
            }

            return false;
        }

        // 흑돌 4-4 검사
        public bool CheckDouble4(Mesh board, Design design)
        {
            int doubleFourCount = 0;
            doubleFourCount += FindFourWidth(board, design);
            doubleFourCount += FindFourLength(board, design);
            doubleFourCount += FindFourDiagonalUpwardRight(board, design);
            doubleFourCount += FindFourDiagonalDownwardRight(board, design);

            if(doubleFourCount >= 2)
            {
                return true;
            }
            return false;
        }

        // 4-4 가로 검사
        private int FindFourWidth(Mesh board, Design design)
        {
            List<Entity> eggList = design.Entities.Where(x => x.EntityData == "Black" || x.EntityData == "White").ToList();

            int blinkCount = 1;

            int stone1 = 0;
            int stone2 = 0;
            int totalStone = 0;

            bool checkBlink = false;
            bool checkEgg = false;

            for (int i = 1; i <= 5; i++)
            {
                for (int j = 0; j < eggList.Count(); j++)
                {
                    if (Math.Round(design.Entities.Last().BoxMax.X - ((board.BoxMax.X / 18) * i)) == Math.Round(eggList[j].BoxMax.X)
                            && design.Entities.Last().BoxMax.Y == eggList[j].BoxMax.Y)
                    {
                        if (eggList[j].EntityData == "White")
                        {
                            checkBlink = true;
                        }
                        else if (eggList[j].EntityData == "Black")
                        {
                            stone1++;
                            checkBlink = false;
                            checkEgg = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                if (checkEgg == false)
                {
                    if (checkBlink == false)
                        checkBlink = true;
                    else
                    {
                        blinkCount++;
                        break;
                    }

                    if (blinkCount == 1)
                    {
                        blinkCount--;
                    }
                    else
                    {
                        break;
                    }
                }
                checkEgg = false;
            }

            checkBlink = false;
            checkEgg = false;

            for (int i = 1; i <= 5; i++)
            {
                for (int j = 0; j < eggList.Count(); j++)
                {
                    if (Math.Round(design.Entities.Last().BoxMax.X + ((board.BoxMax.X / 18) * i)) == Math.Round(eggList[j].BoxMax.X)
                            && design.Entities.Last().BoxMax.Y == eggList[j].BoxMax.Y)
                    {
                        if (eggList[j].EntityData == "White")
                        {
                            checkBlink = true;
                        }
                        else if (eggList[j].EntityData == "Black")
                        {
                            stone2++;
                            checkBlink = false;
                            checkEgg = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                if (checkEgg == false)
                {
                    if (checkBlink == false)
                        checkBlink = true;
                    else
                    {
                        blinkCount++;
                        break;
                    }

                    if (blinkCount == 1)
                    {
                        blinkCount--;
                    }
                    else
                    {
                        break;
                    }
                }
                checkEgg = false;
            }

            totalStone = stone1 + stone2;
            if (totalStone != 3)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        // 4-4 세로 검사
        private int FindFourLength(Mesh board, Design design)
        {
            List<Entity> eggList = design.Entities.Where(x => x.EntityData == "Black" || x.EntityData == "White").ToList();

            int blinkCount = 1;

            int stone1 = 0;
            int stone2 = 0;
            int totalStone = 0;

            bool checkBlink = false;
            bool checkEgg = false;

            for (int i = 1; i <= 5; i++)
            {
                for (int j = 0; j < eggList.Count(); j++)
                {
                    if (Math.Round(design.Entities.Last().BoxMax.Y - ((board.BoxMax.Y / 18) * i)) == Math.Round(eggList[j].BoxMax.Y)
                            && design.Entities.Last().BoxMax.X == eggList[j].BoxMax.X)
                    {
                        if (eggList[j].EntityData == "White")
                        {
                            checkBlink = true;
                        }
                        else if (eggList[j].EntityData == "Black")
                        {
                            stone1++;
                            checkBlink = false;
                            checkEgg = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                if (checkEgg == false)
                {
                    if (checkBlink == false)
                        checkBlink = true;
                    else
                    {
                        blinkCount++;
                        break;
                    }

                    if (blinkCount == 1)
                    {
                        blinkCount--;
                    }
                    else
                    {
                        break;
                    }
                }
                checkEgg = false;
            }

            checkBlink = false;
            checkEgg = false;

            for (int i = 1; i <= 5; i++)
            {
                for (int j = 0; j < eggList.Count(); j++)
                {
                    if (Math.Round(design.Entities.Last().BoxMax.Y + ((board.BoxMax.Y / 18) * i)) == Math.Round(eggList[j].BoxMax.Y)
                            && design.Entities.Last().BoxMax.X == eggList[j].BoxMax.X)
                    {
                        if (eggList[j].EntityData == "White")
                        {
                            checkBlink = true;
                        }
                        else if (eggList[j].EntityData == "Black")
                        {
                            stone2++;
                            checkBlink = false;
                            checkEgg = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                if (checkEgg == false)
                {
                    if (checkBlink == false)
                        checkBlink = true;
                    else
                    {
                        blinkCount++;
                        break;
                    }

                    if (blinkCount == 1)
                    {
                        blinkCount--;
                    }
                    else
                    {
                        break;
                    }
                }
                checkEgg = false;
            }

            totalStone = stone1 + stone2;
            if (totalStone != 3)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        // 4-4 우상향 대각 검사
        private int FindFourDiagonalUpwardRight(Mesh board, Design design)
        {
            List<Entity> eggList = design.Entities.Where(x => x.EntityData == "Black" || x.EntityData == "White").ToList();

            int blinkCount = 1;

            int stone1 = 0;
            int stone2 = 0;
            int totalStone = 0;

            bool checkBlink = false;
            bool checkEgg = false;

            for (int i = 1; i <= 5; i++)
            {
                for (int j = 0; j < eggList.Count(); j++)
                {
                    if (Math.Round(design.Entities.Last().BoxMax.X + ((board.BoxMax.X / 18) * i)) == Math.Round(eggList[j].BoxMax.X)
                            && Math.Round(design.Entities.Last().BoxMax.Y + ((board.BoxMax.Y / 18) * i)) == Math.Round(eggList[j].BoxMax.Y))
                    {
                        if (eggList[j].EntityData == "White")
                        {
                            checkBlink = true;
                        }
                        else if (eggList[j].EntityData == "Black")
                        {
                            stone1++;
                            checkBlink = false;
                            checkEgg = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                if (checkEgg == false)
                {
                    if (checkBlink == false)
                        checkBlink = true;
                    else
                    {
                        blinkCount++;
                        break;
                    }

                    if (blinkCount == 1)
                    {
                        blinkCount--;
                    }
                    else
                    {
                        break;
                    }
                }
                checkEgg = false;
            }

            checkBlink = false;
            checkEgg = false;

            for (int i = 1; i <= 5; i++)
            {
                for (int j = 0; j < eggList.Count(); j++)
                {
                    if (Math.Round(design.Entities.Last().BoxMax.X - ((board.BoxMax.X / 18) * i)) == Math.Round(eggList[j].BoxMax.X)
                            && Math.Round(design.Entities.Last().BoxMax.Y - ((board.BoxMax.Y / 18) * i)) == Math.Round(eggList[j].BoxMax.Y))
                    {
                        if (eggList[j].EntityData == "White")
                        {
                            checkBlink = true;
                        }
                        else if (eggList[j].EntityData == "Black")
                        {
                            stone2++;
                            checkBlink = false;
                            checkEgg = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                if (checkEgg == false)
                {
                    if (checkBlink == false)
                        checkBlink = true;
                    else
                    {
                        blinkCount++;
                        break;
                    }

                    if (blinkCount == 1)
                    {
                        blinkCount--;
                    }
                    else
                    {
                        break;
                    }
                }
                checkEgg = false;
            }

            totalStone = stone1 + stone2;
            if (totalStone != 3)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        // 4-4 우하향 대각 검사
        private int FindFourDiagonalDownwardRight(Mesh board, Design design)
        {
            List<Entity> eggList = design.Entities.Where(x => x.EntityData == "Black" || x.EntityData == "White").ToList();

            int blinkCount = 1;

            int stone1 = 0;
            int stone2 = 0;
            int totalStone = 0;

            bool checkBlink = false;
            bool checkEgg = false;

            for (int i = 1; i <= 5; i++)
            {
                for (int j = 0; j < eggList.Count(); j++)
                {
                    if (Math.Round(design.Entities.Last().BoxMax.Y - ((board.BoxMax.Y / 18) * i)) == Math.Round(eggList[j].BoxMax.Y)
                             && Math.Round(design.Entities.Last().BoxMax.X + ((board.BoxMax.X / 18) * i)) == Math.Round(eggList[j].BoxMax.X))
                    {
                        if (eggList[j].EntityData == "White")
                        {
                            checkBlink = true;
                        }
                        else if (eggList[j].EntityData == "Black")
                        {
                            stone1++;
                            checkBlink = false;
                            checkEgg = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                if (checkEgg == false)
                {
                    if (checkBlink == false)
                        checkBlink = true;
                    else
                    {
                        blinkCount++;
                        break;
                    }

                    if (blinkCount == 1)
                    {
                        blinkCount--;
                    }
                    else
                    {
                        break;
                    }
                }
                checkEgg = false;
            }

            checkBlink = false;
            checkEgg = false;

            for (int i = 1; i <= 5; i++)
            {
                for (int j = 0; j < eggList.Count(); j++)
                {
                    if (Math.Round(design.Entities.Last().BoxMax.Y + ((board.BoxMax.Y / 18) * i)) == Math.Round(eggList[j].BoxMax.Y)
                            && Math.Round(design.Entities.Last().BoxMax.X - ((board.BoxMax.X / 18) * i)) == Math.Round(eggList[j].BoxMax.X))
                    {
                        if (eggList[j].EntityData == "White")
                        {
                            checkBlink = true;
                        }
                        else if (eggList[j].EntityData == "Black")
                        {
                            stone2++;
                            checkBlink = false;
                            checkEgg = true;
                            break;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                if (checkEgg == false)
                {
                    if (checkBlink == false)
                        checkBlink = true;
                    else
                    {
                        blinkCount++;
                        break;
                    }

                    if (blinkCount == 1)
                    {
                        blinkCount--;
                    }
                    else
                    {
                        break;
                    }
                }
                checkEgg = false;
            }

            totalStone = stone1 + stone2;
            if (totalStone != 3)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

        // 3-3 가로 검사
        private int FindThreeWidth(Mesh board, Design design)
        {
            List<Entity> eggList = design.Entities.Where(x => x.EntityData == "Black" || x.EntityData == "White").ToList();

            int blinkCount = 1;

            int stone1 = 0;
            int stone2 = 0;
            int totalStone = 0;

            bool checkBlink = false;
            bool checkEgg = false;
            bool wallBlock = false;
            bool enemyBlock = false;

            for(int i = 1; i <= 4; i++)
            {
                for (int j = 0; j < eggList.Count(); j++)
                {
                    if (Math.Round(design.Entities.Last().BoxMax.X - ((board.BoxMax.X / 18) * i)) == Math.Round(eggList[j].BoxMax.X)
                            && design.Entities.Last().BoxMax.Y == eggList[j].BoxMax.Y)
                    {
                        if ((eggList[j].BoxMax.X + eggList[j].BoxMin.X) / 2 == board.BoxMin.X)
                        {
                            wallBlock = true;
                            break;
                        }
                        else if (eggList[j].EntityData == "Black")
                        {
                            stone1++;
                            checkBlink = false;
                            checkEgg = true;
                            break;
                        }
                        else
                        {
                            enemyBlock = true;
                            break;
                        }
                    }
                }
                if (checkEgg == false)
                {
                    if (checkBlink == false)
                        checkBlink = true;
                    else
                    {
                        blinkCount++;
                        break;
                    }

                    if (blinkCount == 1)
                    {
                        blinkCount--;
                    }
                    else
                    {
                        break;
                    }
                }
                checkEgg = false;
            }

            checkBlink = false;
            checkEgg = false;

            for (int i = 1; i <= 4; i++)
            {
                for (int j = 0; j < eggList.Count(); j++)
                {
                    if (Math.Round(design.Entities.Last().BoxMax.X + ((board.BoxMax.X / 18) * i)) == Math.Round(eggList[j].BoxMax.X)
                            && design.Entities.Last().BoxMax.Y == eggList[j].BoxMax.Y)
                    {
                        if ((eggList[j].BoxMax.X + eggList[j].BoxMin.X) / 2 == board.BoxMax.X)
                        {
                            wallBlock = true;
                            break;
                        }
                        else if (eggList[j].EntityData == "Black")
                        {
                            stone2++;
                            checkBlink = false;
                            checkEgg = true;
                            break;
                        }
                        else
                        {
                            enemyBlock = true;
                            break;
                        }
                    }
                }
                if (checkEgg == false)
                {
                    if (checkBlink == false)
                        checkBlink = true;
                    else
                    {
                        blinkCount++;
                        break;
                    }

                    if (blinkCount == 1)
                    {
                        blinkCount--;
                    }
                    else
                    {
                        break;
                    }
                }
                checkEgg = false;
            }

            totalStone = stone1 + stone2;
            if(totalStone != 2)
            {
                return 0;
            }

            if (wallBlock == true)
            {
                return 0;
            }
            else
            {
                if(enemyBlock == true)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
        }

        // 3-3 세로 검사
        private int FindThreeLength(Mesh board, Design design)
        {
            List<Entity> eggList = design.Entities.Where(x => x.EntityData == "Black" || x.EntityData == "White").ToList();

            int blinkCount = 1;

            int stone1 = 0;
            int stone2 = 0;
            int totalStone = 0;

            bool checkBlink = false;
            bool checkEgg = false;
            bool wallBlock = false;
            bool enemyBlock = false;

            for (int i = 1; i <= 4; i++)
            {
                for (int j = 0; j < eggList.Count(); j++)
                {
                    if (Math.Round(design.Entities.Last().BoxMax.Y - ((board.BoxMax.Y / 18) * i)) == Math.Round(eggList[j].BoxMax.Y)
                            && design.Entities.Last().BoxMax.X == eggList[j].BoxMax.X)
                    {
                        if ((eggList[j].BoxMax.Y + eggList[j].BoxMin.Y) / 2 == board.BoxMin.Y)
                        {
                            wallBlock = true;
                            break;
                        }
                        else if (eggList[j].EntityData == "Black")
                        {
                            stone1++;
                            checkBlink = false;
                            checkEgg = true;
                            break;
                        }
                        else
                        {
                            enemyBlock = true;
                            break;
                        }
                    }
                }
                if (checkEgg == false)
                {
                    if (checkBlink == false)
                        checkBlink = true;
                    else
                    {
                        blinkCount++;
                        break;
                    }

                    if (blinkCount == 1)
                    {
                        blinkCount--;
                    }
                    else
                    {
                        break;
                    }
                }
                checkEgg = false;
            }

            checkBlink = false;
            checkEgg = false;

            for (int i = 1; i <= 4; i++)
            {
                for (int j = 0; j < eggList.Count(); j++)
                {
                    if (Math.Round(design.Entities.Last().BoxMax.Y + ((board.BoxMax.Y / 18) * i)) == Math.Round(eggList[j].BoxMax.Y)
                            && design.Entities.Last().BoxMax.X == eggList[j].BoxMax.X)
                    {
                        if ((eggList[j].BoxMax.Y + eggList[j].BoxMin.Y) / 2 == board.BoxMax.Y)
                        {
                            wallBlock = true;
                            break;
                        }
                        else if (eggList[j].EntityData == "Black")
                        {
                            stone2++;
                            checkBlink = false;
                            checkEgg = true;
                            break;
                        }
                        else
                        {
                            enemyBlock = true;
                            break;
                        }
                    }
                }
                if (checkEgg == false)
                {
                    if (checkBlink == false)
                        checkBlink = true;
                    else
                    {
                        blinkCount++;
                        break;
                    }

                    if (blinkCount == 1)
                    {
                        blinkCount--;
                    }
                    else
                    {
                        break;
                    }
                }
                checkEgg = false;
            }

            totalStone = stone1 + stone2;
            if (totalStone != 2)
            {
                return 0;
            }

            if (wallBlock == true)
            {
                return 0;
            }
            else
            {
                if (enemyBlock == true)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
        }

        // 3-3 우상향 대각 검사
        private int FindThreeDiagonalUpwardRight(Mesh board, Design design)
        {
            List<Entity> eggList = design.Entities.Where(x => x.EntityData == "Black" || x.EntityData == "White").ToList();

            int blinkCount = 1;

            int stone1 = 0;
            int stone2 = 0;
            int totalStone = 0;

            bool checkBlink = false;
            bool checkEgg = false;
            bool wallBlock = false;
            bool enemyBlock = false;

            for (int i = 1; i <= 4; i++)
            {
                for (int j = 0; j < eggList.Count(); j++)
                {
                    if (Math.Round(design.Entities.Last().BoxMax.X + ((board.BoxMax.X / 18) * i)) == Math.Round(eggList[j].BoxMax.X)
                            && Math.Round(design.Entities.Last().BoxMax.Y + ((board.BoxMax.Y / 18) * i)) == Math.Round(eggList[j].BoxMax.Y))
                    {
                        if ((eggList[j].BoxMax.Y + eggList[j].BoxMin.Y) / 2 == board.BoxMax.Y
                            || (eggList[j].BoxMax.X + eggList[j].BoxMin.X) / 2 == board.BoxMax.X)
                        {
                            wallBlock = true;
                            break;
                        }
                        else if (eggList[j].EntityData == "Black")
                        {
                            stone1++;
                            checkBlink = false;
                            checkEgg = true;
                            break;
                        }
                        else
                        {
                            enemyBlock = true;
                            break;
                        }
                    }
                }
                if (checkEgg == false)
                {
                    if (checkBlink == false)
                        checkBlink = true;
                    else
                    {
                        blinkCount++;
                        break;
                    }

                    if (blinkCount == 1)
                    {
                        blinkCount--;
                    }
                    else
                    {
                        break;
                    }
                }
                checkEgg = false;
            }

            checkBlink = false;
            checkEgg = false;

            for (int i = 1; i <= 4; i++)
            {
                for (int j = 0; j < eggList.Count(); j++)
                {
                    if (Math.Round(design.Entities.Last().BoxMax.X - ((board.BoxMax.X / 18) * i)) == Math.Round(eggList[j].BoxMax.X)
                            && Math.Round(design.Entities.Last().BoxMax.Y - ((board.BoxMax.Y / 18) * i)) == Math.Round(eggList[j].BoxMax.Y))
                    {
                        if ((eggList[j].BoxMax.Y + eggList[j].BoxMin.Y) / 2 == board.BoxMin.Y
                            || (eggList[j].BoxMax.X + eggList[j].BoxMin.X) / 2 == board.BoxMin.X)
                        {
                            wallBlock = true;
                            break;
                        }
                        else if (eggList[j].EntityData == "Black")
                        {
                            stone2++;
                            checkBlink = false;
                            checkEgg = true;
                            break;
                        }
                        else
                        {
                            enemyBlock = true;
                            break;
                        }
                    }
                }
                if (checkEgg == false)
                {
                    if (checkBlink == false)
                        checkBlink = true;
                    else
                    {
                        blinkCount++;
                        break;
                    }

                    if (blinkCount == 1)
                    {
                        blinkCount--;
                    }
                    else
                    {
                        break;
                    }
                }
                checkEgg = false;
            }

            totalStone = stone1 + stone2;
            if (totalStone != 2)
            {
                return 0;
            }

            if (wallBlock == true)
            {
                return 0;
            }
            else
            {
                if (enemyBlock == true)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
        }

        // 3-3 우하향 대각 검사
        private int FindThreeDiagonalDownwardRight(Mesh board, Design design)
        {
            List<Entity> eggList = design.Entities.Where(x => x.EntityData == "Black" || x.EntityData == "White").ToList();

            int blinkCount = 1;

            int stone1 = 0;
            int stone2 = 0;
            int totalStone = 0;

            bool checkBlink = false;
            bool checkEgg = false;
            bool wallBlock = false;
            bool enemyBlock = false;

            for (int i = 1; i <= 4; i++)
            {
                for (int j = 0; j < eggList.Count(); j++)
                {
                    if (Math.Round(design.Entities.Last().BoxMax.Y - ((board.BoxMax.Y / 18) * i)) == Math.Round(eggList[j].BoxMax.Y)
                             && Math.Round(design.Entities.Last().BoxMax.X + ((board.BoxMax.X / 18) * i)) == Math.Round(eggList[j].BoxMax.X))
                    {
                        if ((eggList[j].BoxMax.Y + eggList[j].BoxMin.Y) / 2 == board.BoxMin.Y
                            || (eggList[j].BoxMax.X + eggList[j].BoxMin.X) / 2 == board.BoxMax.X)
                        {
                            wallBlock = true;
                            break;
                        }
                        else if (eggList[j].EntityData == "Black")
                        {
                            stone1++;
                            checkBlink = false;
                            checkEgg = true;
                            break;
                        }
                        else
                        {
                            enemyBlock = true;
                            break;
                        }
                    }
                }
                if (checkEgg == false)
                {
                    if (checkBlink == false)
                        checkBlink = true;
                    else
                    {
                        blinkCount++;
                        break;
                    }

                    if (blinkCount == 1)
                    {
                        blinkCount--;
                    }
                    else
                    {
                        break;
                    }
                }
                checkEgg = false;
            }

            checkBlink = false;
            checkEgg = false;

            for (int i = 1; i <= 4; i++)
            {
                for (int j = 0; j < eggList.Count(); j++)
                {
                    if (Math.Round(design.Entities.Last().BoxMax.Y + ((board.BoxMax.Y / 18) * i)) == Math.Round(eggList[j].BoxMax.Y)
                            && Math.Round(design.Entities.Last().BoxMax.X - ((board.BoxMax.X / 18) * i)) == Math.Round(eggList[j].BoxMax.X))
                    {
                        if ((eggList[j].BoxMax.Y + eggList[j].BoxMin.Y) / 2 == board.BoxMax.Y
                            || (eggList[j].BoxMax.X + eggList[j].BoxMin.X) / 2 == board.BoxMin.X)
                        {
                            wallBlock = true;
                            break;
                        }
                        else if (eggList[j].EntityData == "Black")
                        {
                            stone2++;
                            checkBlink = false;
                            checkEgg = true;
                            break;
                        }
                        else
                        {
                            enemyBlock = true;
                            break;
                        }
                    }
                }
                if (checkEgg == false)
                {
                    if (checkBlink == false)
                        checkBlink = true;
                    else
                    {
                        blinkCount++;
                        break;
                    }

                    if (blinkCount == 1)
                    {
                        blinkCount--;
                    }
                    else
                    {
                        break;
                    }
                }
                checkEgg = false;
            }

            totalStone = stone1 + stone2;
            if (totalStone != 2)
            {
                return 0;
            }

            if (wallBlock == true)
            {
                return 0;
            }
            else
            {
                if (enemyBlock == true)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
        }
    }
}
