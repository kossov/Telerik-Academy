namespace PhoneDevices
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class GSMAndCallHistoryTest
    {
        static void Main(string[] args) // only one main so they are in the same class :( or i didnt found out any other way..
        {
            // class GSMTest
            #region GSMTest
            GSM[] store = new GSM[4];
            store[0] = GSM.iPhone4S;
            store[1] = new GSM("Nokia", "Lumia 930");
            store[2] = new GSM("Sony", "Xperia Z3");
            store[3] = new GSM("Samsung", "Galaxy", new Display(DisplayType.AMOLED), new Battery(BatteryType.LiIon));

            foreach (var item in store)
            {
                Console.WriteLine(item);
                Console.WriteLine();
            }
            #endregion

            // class CallHistoryTest
            #region CallHistoryTest
            GSM nokiaLumia830 = new GSM("Nokia", "Lumia 830", new Display(DisplayType.AMOLED), new Battery(BatteryType.LiIon));
            Console.WriteLine(nokiaLumia830.ToString());

            nokiaLumia830.AddCall(new Call(new DateTime(2015, 03, 10, 10, 08, 00), "+359877777777", 54));

            nokiaLumia830.AddCall(new Call(new DateTime(2015, 03, 11, 11, 09, 00), "+359888888888", 25));

            nokiaLumia830.AddCall(new Call(new DateTime(2015, 03, 12, 12, 10, 00), "+359899999999", 203));

            nokiaLumia830.AddCall(new Call(new DateTime(2015, 03, 13, 13, 11, 00), "+359800000000", 123));
            foreach (Call call in nokiaLumia830.CallHistory)
            {
                Console.WriteLine(call);
            }

            Console.WriteLine("The total price of all calls: {0:F1} lv.",nokiaLumia830.HistoryPrice(0.37));
            nokiaLumia830.DeleteCall(nokiaLumia830.CallHistory.OrderByDescending(x => x.CallDuration).FirstOrDefault());
            Console.WriteLine("The total price without the longest call: {0:F1} lv.",nokiaLumia830.HistoryPrice(0.37));
            nokiaLumia830.ClearHistory();
            foreach (Call item in nokiaLumia830.CallHistory)
            {
                Console.WriteLine(item);
            }
            #endregion
        }
    }
}
