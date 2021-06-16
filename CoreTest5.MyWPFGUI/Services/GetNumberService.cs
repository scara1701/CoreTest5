using CoreTest5.MyLib.Services;

namespace CoreTest5.MyWPFGUI.Services
{
    public class GetNumberService : IGetNumberService
    {
        private int _number;

        public int Number
        {
            get { return _number; }
            set { _number = value; }
        }

        public GetNumberService(int number)
        {
            Number = number;
        }


        public int GetNumber()
        {
            return _number;
        }
    }
}
