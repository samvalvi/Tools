namespace Tools
{
    public sealed class Log
    {
        private static Log _instance = null;
        private string _path;
        //Protección contra multihilos
        private static object _lock = new object();

        public static Log GetInstance(string path)
        {
            //Deja un hilo en espera
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new Log(path);
                }
            }
            return _instance;
        }

        private Log(string path)
        {
            _path = path;
        }

        public void Save(string msg)
        {
            File.AppendAllText(_path, msg + Environment.NewLine);
        }
    }
}