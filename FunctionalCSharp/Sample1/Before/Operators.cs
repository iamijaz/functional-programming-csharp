

namespace FunctionalCSharp.Sample1.Before
{
    public sealed class MySingleton2
    {
        private static MySingleton2 _instance;

        private MySingleton2()
        {
        }

        public static MySingleton2 Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MySingleton2();
                }

                return _instance;
            }
        }

        // Other stuff here



        void Main2()
        {
            //MySingleton.Instance.ToString().Dump();
        }
    }
}