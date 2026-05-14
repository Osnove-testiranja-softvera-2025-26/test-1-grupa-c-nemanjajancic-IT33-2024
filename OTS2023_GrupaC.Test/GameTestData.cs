using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS2026_GrupaC.Test
{
    internal class GameTestData
    {
        public static IEnumerable MoveUp_SuccessfulMove_PlayerPositionChanged_TestData
        {
            get
            {
                yield return new TestCaseData(1, 2, 0, 3);
                yield return new TestCaseData(1, 2, 0, 5);
                yield return new TestCaseData(1, 2, 0, 6);
            }
        }
    }
}
