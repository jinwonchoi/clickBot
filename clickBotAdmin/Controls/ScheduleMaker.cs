using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeDoCommon;

namespace ClickBot.Controls
{
    public class ScheduleMaker
    {
        int totalHitCount = 0;
        int resultCount = 0;

        public int ResultCount
        {
            get { return resultCount; }
            set { resultCount = value; }
        }

        List<Int32> hourList1 = new List<int>();
        List<Int32> hourList2 = new List<int>();
        List<Int32> hourList3 = new List<int>();
        List<Int32> hourList4 = new List<int>();

        Period intensive;

        int hourCnt1= 0;
        int hourCnt2= 0;
        int hourCnt3= 0;
        int hourCnt4= 0;

        public void AssignHourList(List<int> hourList, int count)
        {
            int maxVal = 0;
            Random random = new Random();
            for (int i = 0; i < 5; i++)
            {
                int assigned = 0;
                if (count == 0)
                {
                    assigned = 0;
                }
                else
                {
                    maxVal = ((count*2)/(6-i) ==0)?1:(count*2)/(6-i);
                    assigned = random.Next(maxVal + 1);
                }
                hourList.Add(assigned);
                resultCount += assigned;
                count -= assigned;
            }
            hourList.Add(count);
            resultCount += count;
        }

        public Dictionary<string, int> GenerateSchedule(int totalCount, Period intense)
        {
            totalHitCount = totalCount;
            intensive = intense;
            Dictionary<string, int> dicHour = new Dictionary<string, int>();

            DistributeByPeriod();
            AssignHourList(hourList1, hourCnt1);
            AssignHourList(hourList2, hourCnt2);
            AssignHourList(hourList3, hourCnt3);
            AssignHourList(hourList4, hourCnt4);

            int hourIdx = 0;
            foreach (int hour in hourList1)
            {
                dicHour.Add(hourIdx.ToString("D2"), hour);
                hourIdx++;
            }
            foreach (int hour in hourList2) {
                dicHour.Add(hourIdx.ToString("D2"), hour);
                hourIdx++;
            }
            foreach (int hour in hourList3) {
                dicHour.Add(hourIdx.ToString("D2"), hour);
                hourIdx++;
            }
            foreach (int hour in hourList4){
                dicHour.Add(hourIdx.ToString("D2"), hour);
                hourIdx++;
            }
            return dicHour;
        }

        Period GetPeriod(int _period)
        {
            Period result = Period.Second;

            if (_period == (int)Period.First)
                result = Period.First;
            else if (_period == (int)Period.Second)
                result = Period.Second;
            else if (_period == (int)Period.Third)
                result = Period.Third;
            else if (_period == (int)Period.Fourth)
                result = Period.Fourth;
            return result;
        }

        void SetValue(Period period, Stage stage)
        {
            if (period == Period.First)
                hourCnt1 = ToAssignedCount(stage);
            else if (period == Period.Second)
                hourCnt2 = ToAssignedCount(stage);
            else if (period == Period.Third)
                hourCnt3 = ToAssignedCount(stage);
            else if (period == Period.Fourth)
                hourCnt4 = ToAssignedCount(stage);
        }

        int ToAssignedCount(Stage stage)
        {
            int result = 0;
            if (stage == Stage.MAX)
                result = (totalHitCount * ConstDef.PERIOD_RATIO_BUSY) / 100;
            else if (stage == Stage.PREV)
                result = (totalHitCount * ConstDef.PERIOD_RATIO_PREV) / 100;
            else if (stage == Stage.NEXT)
                result = (totalHitCount * ConstDef.PERIOD_RATIO_NEXT) / 100;
            else if (stage == Stage.MIN)
                result = (totalHitCount * ConstDef.PERIOD_RATIO_IDLE) / 100;

            return result;
        }

        Period curPeriod()
        {
            int checkValue = ((int)intensive + 4) % 4;
            return GetPeriod(checkValue);
        }

        Period nextPeriod()
        {
            int checkValue = ((int)intensive + 5) % 4;
            return GetPeriod(checkValue);
        }

        Period prevPeriod()
        {
            int checkValue = ((int)intensive + 3) % 4;
            return GetPeriod(checkValue);
        }

        Period minPeriod()
        {
            int checkValue = ((int)intensive + 6) % 4;
            return GetPeriod(checkValue);
        }

        private void DistributeByPeriod()
        {
            SetValue(curPeriod(), Stage.MAX);
            SetValue(nextPeriod(), Stage.NEXT);
            SetValue(prevPeriod(), Stage.PREV);
            SetValue(minPeriod(), Stage.MIN);
        }
    }

    public enum Period
    {
        First = 0, Second=1, Third=2, Fourth=3
    }

    enum Stage
    {
        MAX=0, PREV=1, NEXT=2,MIN=3
    }
}
